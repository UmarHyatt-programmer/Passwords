using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
public class PlayFabJSONReceiver : MonoBehaviour
{
    private const string TitleId = "YOUR_TITLE_ID";
    private const string SecretKey = "YOUR_SECRET_KEY";
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            GetData();
        }
    }
    private void GetData()
    {
        // Initialize PlayFab API with your title ID
        //PlayFabSettings.TitleId = TitleId;
        //PlayFabSettings.DeveloperSecretKey = SecretKey;

        // Create the request to get user data
        var request = new GetUserDataRequest();

        // Send the request to get user data
        PlayFabClientAPI.GetUserData(request, OnSuccess, OnError);
    }
    public Payload reciverData;
    private void OnSuccess(GetUserDataResult result)
    {
        // Check if the user data contains the JSON payload
        if (result.Data.TryGetValue("JSONPayload", out var jsonData))
        {
            // Parse the JSON payload
            reciverData = JsonUtility.FromJson<Payload>(jsonData.Value);
            Debug.Log("JSON Payload:");
        }
        else
        {
            Debug.Log("JSONPayload not found in user data.");
        }
    }

    private static void OnError(PlayFabError error)
    {
        Debug.LogError("Request failed: " + error.GenerateErrorReport());
    }
}
