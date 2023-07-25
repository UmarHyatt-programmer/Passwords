using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
public class PlayFabJSONSender : MonoBehaviour
{

    private const string TitleId = "YOUR_TITLE_ID";
    private const string SecretKey = "YOUR_SECRET_KEY";
    private void OnEnable() {
    }
    private void OnDisable() {
        
    }
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            SendData();
        }
    }
    public Payload senderData;
    private void SendData()
    {


        // Convert the payload to JSON string
        string jsonPayload = JsonUtility.ToJson(senderData);

        // Create the request
        var request = new UpdateUserDataRequest
        {
            Data = new Dictionary<string, string>
            {
                { "JSONPayload", jsonPayload }
            }
        };

        // Send the request to update user data
        PlayFabClientAPI.UpdateUserData(request, OnSuccess, OnError);
    }

    private static void OnSuccess(UpdateUserDataResult result)
    {
        EventManager.Instance.OnSendPayload.Invoke(result);
        Debug.Log("Request succeeded: " + result.ToJson());
    }

    private static void OnError(PlayFabError error)
    {
        Debug.LogError("Request failed: " + error.GenerateErrorReport());
    }
}
