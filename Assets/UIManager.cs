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
    public InputField website,userName,password,note;
    public ItemObject itemPrefab;
    public Transform itemParent;
    public GameObject passwordsPanel,loginPanel,signupPanel,newPasswordPanel,detailPasswordPanel;
    public GameObject addPasswordButton,editButton,cancelButton,deleteButton,addNewPasswordButton;
    public List<ItemObject> itemObjects;
    public List<ItemObject> selectedItems;
    private void OnEnable() {
        EventManager.Instance.OnLogin.AddListener(OnLogin);
        EventManager.Instance.OnPayloadUpdate.AddListener(UpdatePayloadUI);
    }
    private void OnDisable() {

        EventManager.Instance.OnLogin.RemoveListener(OnLogin);
    }
    public void EditButtonClick()
    {
        deleteButton.SetActive(true);
        cancelButton.SetActive(true);
        editButton.SetActive(false);
        foreach (var item in itemObjects)
        {
            item.selectToggle.gameObject.SetActive(true);
        }
    }
    public void CancelButtonClick()
    {
        deleteButton.SetActive(false);
        cancelButton.SetActive(false);
        editButton.SetActive(true);
        foreach (var item in itemObjects)
        {
            item.selectToggle.gameObject.SetActive(false);
        }
    }
    public void DeleteButtonClick()
    {
        deleteButton.SetActive(false);
        cancelButton.SetActive(false);
        editButton.SetActive(true);
        foreach (var item in selectedItems)
        {
            DataManager.Instance.payload.titles.Remove(item.title);
            Destroy(item.gameObject);
        }
        foreach (var item in itemObjects)
        {
            item.selectToggle.gameObject.SetActive(false);
        }
        EventManager.Instance.OnPayloadUpdate.Invoke(DataManager.Instance.payload);
    }
    public void AddNewPasswordButton()
    {
        newPasswordPanel.SetActive(true);
    }
    public void SavePasswordButton()
    {
        Payload.Title title = new Payload.Title();
        title.titleName = userName.text;
        title.website = website.text;
        title.password = password.text;
        title.note = note.text;
        print(title.titleName);
        DataManager.Instance.AddTitle(title);
        UpdatePayloadUI(DataManager.Instance.payload);
        // use this fuction when press done button of save password panel and save data through data manager
        //DataManager.Instance.payload
    }
    public DetailPanelObject detailPanelObject;
    public void ActiveDetailPanel(Payload.Title title)
    {
        detailPanelObject.gameObject.SetActive(true);
        detailPanelObject.MapDetails(title);
    }
    public void OnLogin()
    {
        passwordsPanel.SetActive(true);
        loginPanel.SetActive(false);
    }
    public void UpdatePayloadUI(Payload _payload)
    {
        foreach (var item in _payload.titles)
        {
            ItemObject obj= Instantiate(itemPrefab,itemParent);
            obj.SetTitle(item);
            itemObjects.Add(obj);
            print(_payload.titles.Count);
           // return;
        }
    }
}
