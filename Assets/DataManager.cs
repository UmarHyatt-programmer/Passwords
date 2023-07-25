using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public Payload payload;
    private void OnEnable() 
    {
      EventManager.Instance.OnreceivePayload.AddListener(OnreceivePayload);
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
        public List<Field> fields;
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