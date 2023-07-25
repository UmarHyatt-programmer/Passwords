using System.Collections;
using System.Collections.Generic;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance;
    private void Awake() 
    {
        if(Instance==null)Instance=this;
    }
    public UnityEvent OnLogin;
    public UnityEvent OnSignup;
    public UnityEvent<Payload> OnreceivePayload;
    public UnityEvent<Payload> OnPayloadUpdate;
    public UnityEvent<UpdateUserDataResult> OnSendPayload;
}
