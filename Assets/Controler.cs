using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controler : MonoBehaviour
{
    public NewPassswordObject newPassswordObject;
    public ItemObject itemPrefab;
    public Transform itemParent;
    public void AddItem()
    {
        Instantiate(itemPrefab,itemParent);
    }
    public void AddFeildButton()
    {

    }
    public void RemoveFeildButton()
    {

    }
    public void SaveNewPasswordButton()
    {
        // Item newItem=new Item();
        // newItem.website=newPassswordObject.website.text;
        // newItem.userName=newPassswordObject.username.text;
        // newItem.password=newPassswordObject.password.text;
        // newItem.notes=newPassswordObject.note.text;
        // DataManager.instance.passwords.items.Add(newItem);
    }
    public void SavaData()
    {

    }
    public void LoadData()
    {
        
    }
}
