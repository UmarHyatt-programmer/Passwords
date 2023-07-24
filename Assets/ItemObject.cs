using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemObject : MonoBehaviour
{
    public Text _name;
    public Text website;
    public Toggle selectToggle;
    public Button itemButton;
    public Payload payload;

    private void Start() 
    {
        itemButton.onClick.AddListener(OnButtonClick);
        selectToggle.onValueChanged.AddListener(OnToggleClick);
    }
    public void OnButtonClick()
    {

    }
    public void OnToggleClick(bool select)
    {
        if(select)
        UIManager.Instance.selectedItems.Add(this);
        else
        UIManager.Instance.selectedItems.Remove(this);
    }
}
