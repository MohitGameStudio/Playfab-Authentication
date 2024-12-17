using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.UI;

public class PlayFabManager : MonoBehaviour
{
    [Header("Sign-In UI References")]
    public InputField signInEmailInput;        // InputField for Sign-In Email
    public InputField signInPasswordInput;     // InputField for Sign-In Password
    public Text signInMessageText;             // Message for Sign-In Feedback

    [Header("Create Account UI References")]
    public InputField createUsernameInput;     // InputField for Create Account Email
    public InputField createEmailInput;        // InputField for Create Account Email
    public InputField createPasswordInput;     // InputField for Create Account Password
    public Text createAccountMessageText;      // Message for Create Account Feedback

    [Header("Reset Password UI References")]
    public InputField resetPasswordEmailInput; // InputField for Reset Password Email

    [Header("Error Message UI")]
    public Text errorMessageText;              // General Error Message

    [Header("PlayFab Title ID")]
    public string playFabTitleId = "E7B1B"; // Replace with your Title ID

    // -------------------- REGISTER NEW USER --------------------
    public void CreateAccountButton()
    {
        if (string.IsNullOrEmpty(createEmailInput.text) || string.IsNullOrEmpty(createPasswordInput.text))
        {
            createAccountMessageText.text = "Email and Password cannot be empty!";
            return;
        }

        if (createPasswordInput.text.Length < 6)
        {
            createAccountMessageText.text = "Password too short! Must be at least 6 characters.";
            return;
        }

        var request = new RegisterPlayFabUserRequest
        {
            Username = createUsernameInput.text,
            Email = createEmailInput.text,
            Password = createPasswordInput.text
        };

        PlayFabClientAPI.RegisterPlayFabUser(request, OnCreateAccountSuccess, OnError);
    }

    private void OnCreateAccountSuccess(RegisterPlayFabUserResult result)
    {
        createAccountMessageText.text = "Account created successfully!";
        createUsernameInput.text = "";
        createEmailInput.text = "";
        createPasswordInput.text = "";
    }

    // -------------------- SIGN-IN EXISTING USER --------------------
    public void SignInButton()
    {
        if (string.IsNullOrEmpty(signInEmailInput.text) || string.IsNullOrEmpty(signInPasswordInput.text))
        {
            signInMessageText.text = "Email and Password cannot be empty!";
            return;
        }

        var request = new LoginWithEmailAddressRequest
        {
            Email = signInEmailInput.text,
            Password = signInPasswordInput.text
        };

        PlayFabClientAPI.LoginWithEmailAddress(request, OnSignInSuccess, OnError);
    }

    private void OnSignInSuccess(LoginResult result)
    {
        signInMessageText.text = "Sign-In successful! Welcome back.";
        signInEmailInput.text = "";
        signInPasswordInput.text = "";
    }

    // -------------------- RESET PASSWORD --------------------
    public void ResetPasswordButton()
    {
        if (string.IsNullOrEmpty(resetPasswordEmailInput.text))
        {
            errorMessageText.text = "Please enter your email to reset your password.";
            return;
        }

        var request = new SendAccountRecoveryEmailRequest
        {
            Email = resetPasswordEmailInput.text,
            TitleId = playFabTitleId
        };

        PlayFabClientAPI.SendAccountRecoveryEmail(request, OnPasswordResetSuccess, OnError);
    }

    private void OnPasswordResetSuccess(SendAccountRecoveryEmailResult result)
    {
        errorMessageText.text = "Password reset email sent. Check your inbox.";
        resetPasswordEmailInput.text = "";
    }

    // -------------------- ERROR HANDLING --------------------
    private void OnError(PlayFabError error)
    {
        errorMessageText.text = $"{error.ErrorMessage}";
        Debug.LogError(error.GenerateErrorReport());
    }
}
