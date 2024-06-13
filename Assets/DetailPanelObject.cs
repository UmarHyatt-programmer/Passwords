using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetailPanelObject : MonoBehaviour
{
    public static DetailPanelObject instance;
    public void Awake()
    {
        if(instance==null)instance=this;
    }
    public Payload.Title title;
    public NewField newFieldPrefab;
    public Transform newFieldParent;
    public InputField website,username,password,note;
    public List<NewField> newFields;
    
    public void DoneAndUpdate()
    {
        title.website=website.text;
        title.password=password.text;
        title.note=note.text;
        title.titleName=username.text;
        DataManager.Instance.SavePayLoad();
        UIManager.Instance.UpdatePayloadUI(DataManager.Instance.payload);
    }
    public void MapDetails(Payload.Title _title)
    {
        title=_title;
        website.text=title.website;
        username.text=title.titleName;
        password.text=title.password;
        note.text=title.note;
    }
    public void AddNewFieldButton()
    {
       NewField obj= Instantiate(newFieldPrefab,newFieldParent);
       newFields.Add(obj);
       obj.onRemoveField.AddListener(OnRemoveField);
    }
    public void OnRemoveField(NewField field)
    {
        newFields.Remove(field);
    }
}
