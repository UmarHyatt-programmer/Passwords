using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class NewPassswordObject : MonoBehaviour
{
    public Payload.Title title;
    public NewField newFieldPrefab;
    public Transform newFieldParent;
    public InputField website,username,password,note;
    public List<NewField> newFields;

    public void DoneNewPasswordButton()
    {
        title.website=website.text;
        title.note=note.text;
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
