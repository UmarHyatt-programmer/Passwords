using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class NewField : MonoBehaviour
{
    public InputField fieldName,fieldValue;
    public UnityEvent<NewField> onRemoveField;

    public void RemoveField()
    {
        onRemoveField.Invoke(this);
        Destroy(this.gameObject);
    }
}
