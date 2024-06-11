using System.Collections;
using System.Collections.Generic;
using Ommy.SaveData;
using Unity.VisualScripting;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public void Awake()
    {
      if(Instance==null)Instance=this;
    }
    public Payload payload;
    private void OnEnable() 
    {
      EventManager.Instance.OnreceivePayload.AddListener(OnreceivePayload);
      EventManager.Instance.OnPayloadUpdate.AddListener((p)=>SavePayLoad());
    }
    public void Start()
    {
      LoadPayLoad();
    }
    private void OnDisable() 
    {
      EventManager.Instance.OnreceivePayload.RemoveListener(OnreceivePayload);
    }
    public void OnreceivePayload(Payload _payload)
    {
      this.payload=_payload;
      EventManager.Instance.OnPayloadUpdate.Invoke(_payload);
    }
    public void AddTitle(Payload.Title title)
    {
      payload.titles.Add(title);
      SavePayLoad();
    }
    public void SavePayLoad()
    {
      SaveData.Instance.payload=payload;
      SaveSystem.SaveProgress();
      //EventManager.Instance.OnPayloadUpdate.Invoke(SaveData.Instance.payload);
    }
    public void LoadPayLoad()
    {
      SaveSystem.LoadProgress();
      payload=SaveData.Instance.payload;
      EventManager.Instance.OnPayloadUpdate.Invoke(SaveData.Instance.payload);
    }
}
[System.Serializable]
public class Payload
{
    public List<Title> titles;
    [System.Serializable]
    public class Title
    {
        public string titleName;
        public string website;
        public string password;
        [TextArea(3, 6)]
        public string note;
    }
    [System.Serializable]
    public class Field
    {
        public string name;
        public string value;
    }
}