using System;
using AppleAuth;
using AppleAuth.Enums;
using AppleAuth.Extensions;
using AppleAuth.Interfaces;
using AppleAuth.Native;
using UnityEngine;
public class AppleSigin : MonoBehaviour
{
    public Action<string> OnSignin;
    private const string AppleUserIdKey = "AppleUserId";
    private IAppleAuthManager _appleAuthManager;
    public void SignInWithApple()
    {
        var loginArgs = new AppleAuthLoginArgs(LoginOptions.IncludeEmail | LoginOptions.IncludeFullName);
        
        this._appleAuthManager.LoginWithAppleId(
            loginArgs,
            credential =>
            {
                // If a sign in with apple succeeds, we should have obtained the credential with the user id, name, and email, save it
                PlayerPrefs.SetString(AppleUserIdKey, credential.User);
                OnSignin.Invoke(credential.User);
                PlayFabAuthenticationManager.Instance.LoginWithApple(credential);
            },
            error =>
            {
                var authorizationErrorCode = error.GetAuthorizationErrorCode();
                Debug.LogWarning("Sign in with Apple failed " + authorizationErrorCode.ToString() + " " + error.ToString());
            });
    }
}
