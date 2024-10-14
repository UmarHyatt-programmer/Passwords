using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemObject : MonoBehaviour
{
    public Text titleTxt,userName;
    public Toggle selectToggle;
    public Button itemButton;
    public Payload.Title title;
    public void SetTitle(Payload.Title _title)
    {
        title=_title;
        titleTxt.text=title.title;
        userName.text=title.userName;
    }
    private void Start() 
    {
        itemButton.onClick.AddListener(OnButtonClick);
        selectToggle.onValueChanged.AddListener(OnToggleClick);
    }
    public void OnButtonClick()
    {
        UIManager.Instance.ActiveDetailPanel(title);
    }
    public void OnToggleClick(bool select)
    {
        if(select)
        UIManager.Instance.selectedItems.Add(this);
        else
        UIManager.Instance.selectedItems.Remove(this);
    }
}
