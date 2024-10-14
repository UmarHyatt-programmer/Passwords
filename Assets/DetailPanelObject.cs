using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    public TMP_Text timeModified;
    public InputField titleInputField,username,password,note;
    public List<NewField> newFields;
    
    public void DoneAndUpdate()
    {
        title.title=titleInputField.text;
        title.userName=username.text;
        title.password=password.text;
        title.note=note.text;
        title.timeModified = System.DateTime.Now.ToString();
        Debug.Log("Time Modified: " + title.timeModified);
        DataManager.Instance.SavePayLoad();
        UIManager.Instance.UpdatePayloadUI(DataManager.Instance.payload);
    }
    public void MapDetails(Payload.Title _title)
    {
        title=_title;
        titleInputField.text = title.title;
        username.text=title.userName;
        password.text=title.password;
        note.text=title.note;
        timeModified.text = $"Last modified "+(String.IsNullOrEmpty(title.timeModified)? "no date found" : DateTime.Parse(title.timeModified).Date.Date.ToString("dd/MM/yyyy"));
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
