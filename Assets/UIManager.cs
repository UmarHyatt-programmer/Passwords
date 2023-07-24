using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    private void Awake() 
    {
        if(Instance==null)Instance=this;
    }

    public GameObject itemPrefab;
    public Transform itemParent;
    public GameObject MainPanel;
    public GameObject AddPasswordButton,EditButton,CancelButton,deleteButton;
    public List<ItemObject> itemObjects;
    public List<ItemObject> selectedItems;
    public void EditButtonClick()
    {
        deleteButton.SetActive(true);
        CancelButton.SetActive(true);
        EditButton.SetActive(false);
        foreach (var item in itemObjects)
        {
            item.selectToggle.gameObject.SetActive(true);
        }
    }
    public void CancelButtonClick()
    {
        deleteButton.SetActive(false);
        CancelButton.SetActive(false);
        EditButton.SetActive(true);
        foreach (var item in itemObjects)
        {
            item.selectToggle.gameObject.SetActive(false);
        }
    }
    public void DeleteButtonClick()
    {
        deleteButton.SetActive(false);
        CancelButton.SetActive(false);
        EditButton.SetActive(true);
        foreach (var item in selectedItems)
        {
            DataManager.Instance.payloads.Remove(item.payload);
            Destroy(item.gameObject);
        }
    }

}
