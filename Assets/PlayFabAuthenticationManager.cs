using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using Unity;
public class PlayFabAuthenticationManager : MonoBehaviour
{
    private static PlayFabAuthenticationManager instance;

    public static PlayFabAuthenticationManager Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }
    public bool autoLogin;
    public string usernameTest,passwordTest;
    public InputField username, password;
    public GameObject loginPanel,signupPanel;
    private void Start()
    {
        // Initialize PlayFab with your Title ID
        PlayFabSettings.TitleId = "32109";
        if(autoLogin)
        {
            AutoLogin();
        }
    }
    public void AutoLogin()
    {
        LoginWithUsername(usernameTest,passwordTest);
    }
    public void LoginButton()
    {
        LoginWithUsername(username.text, password.text);
    }
    public void LoginWithEmail(string email, string password)
    {
        var request = new LoginWithEmailAddressRequest
        {
            Email = email,
            Password = password
        };

        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnLoginFailure);
    }
    public void LoginWithUsername(string username, string password)
    {
        var request = new LoginWithPlayFabRequest
        {
            Username = username,
            Password = password
        };
        PlayFabClientAPI.LoginWithPlayFab(request, OnLoginSuccess, OnLoginFailure);
    }
    private void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("Login successful!");

        // You can access the PlayFab session ticket or other player data from the result
        string sessionTicket = result.SessionTicket;
        string playFabId = result.PlayFabId;

        // Perform any additional logic after successful login
    }

    private void OnLoginFailure(PlayFabError error)
    {
        Debug.LogError("Login failed: " + error.GenerateErrorReport());

        // Handle login failure, display error message, etc.
    }

    public void SignUpButton()
    {
        SignUp(username.text,password.text);
    }
    void SignUp(string username, string password)
    {
        RegisterPlayFabUserRequest request = new RegisterPlayFabUserRequest
        {
            Username = username,
            Password = password,
            RequireBothUsernameAndEmail = false // Adjust this according to your requirements
        };

        PlayFabClientAPI.RegisterPlayFabUser(request, OnSignUpSuccess, OnSignUpFailure);
    }

    void OnSignUpSuccess(RegisterPlayFabUserResult result)
    {
        signupPanel.SetActive(false);
        // User sign-up successful, handle the response
    }

    void OnSignUpFailure(PlayFabError error)
    {
        Debug.LogError("signup failed: "+error.GenerateErrorReport());
        // User sign-up failed, handle the error
    }
}
