# 🔑 **Playfab Authentication**

**Seamless Login, Account Creation, and Password Recovery with PlayFab in Unity** 🚀

---

## 📋 **Overview**

This project implements user **Login**, **Account Creation**, and **Forgot Password** features using **PlayFab** in Unity. Designed for game developers to manage player accounts with ease while leveraging PlayFab's robust backend.

---

## ✨ **Features**

- 🔐 **User Login**: Securely authenticate users with their credentials.  
- 📝 **Account Creation**: Simple email/password registration flow for new users.  
- 🔑 **Forgot Password**: Allow users to recover their accounts by resetting their passwords.  
- 💼 **PlayFab Integration**: Easily connect with PlayFab's backend to manage user authentication and sessions.

---

## 🚀 **Getting Started**

### **1. Prerequisites**

- Unity Hub & Unity Editor installed  
- A **PlayFab** account (Sign up at [PlayFab](https://playfab.com))  
- Basic C# knowledge  

### **2. Setup Steps**

1. **Clone the Repository**  
   ```bash
   git clone https://github.com/MohitGameStudio/Playfab-Authentication.git
   ```

2. **Open Project in Unity**  
   Open the project using **Unity Hub**.

3. **PlayFab Configuration**  
   - Log into your **PlayFab Dashboard**.  
   - Create a new title and retrieve your **Title ID**.  
   - Update the **PlayFabSettings.TitleId** in your script:  
     ```csharp
     PlayFabSettings.TitleId = "YOUR_TITLE_ID";
     ```

4. **Run and Test**  
   - Open the scene.  
   - Test **Login**, **Account Creation**, and **Forgot Password** features.

---

## 🛠️ **How It Works**

### **1. Login**  
- User enters email and password.  
- PlayFab authenticates credentials.  
- Successful login redirects to the main scene.  

**Code Example**:  
```csharp
var request = new LoginWithEmailAddressRequest
{
    Email = emailInput.text,
    Password = passwordInput.text
};
PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnLoginFailure);
```

---

### **2. Account Creation**  
- User provides email, username, and password.  
- PlayFab creates a new user account.  

**Code Example**:  
```csharp
var request = new RegisterPlayFabUserRequest
{
    Email = emailInput.text,
    Password = passwordInput.text,
    Username = usernameInput.text
};
PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnRegisterFailure);
```

---

### **3. Forgot Password**  
- User enters their email.  
- PlayFab sends a password reset email to the user.  

**Code Example**:  
```csharp
var request = new SendAccountRecoveryEmailRequest
{
    Email = emailInput.text,
    TitleId = PlayFabSettings.TitleId
};
PlayFabClientAPI.SendAccountRecoveryEmail(request, OnRecoverySuccess, OnRecoveryFailure);
```

---

## 🎮 **Demo Workflow**

1. **Login**: User logs in using valid credentials.  
2. **Create Account**: New users register with email, username, and password.  
3. **Forgot Password**: Users reset their password via email.  

---

## 💻 **Tech Stack**

- **Game Engine**: Unity  
- **Backend**: PlayFab  
- **Language**: C#  

---

## 🤝 **Contributing**

Contributions are welcome! Feel free to fork the repository and submit a pull request.  

---

## 📬 **Contact**

Created with ❤️ by **Mohit Kumar Singh** 🎮  
- 📧 Email: [MohitGameStudio@gmail.com](mailto:MohitGameStudio@gmail.com)  
- 🌟 Follow for more Unity game development projects!  

---

### ⭐ **If this project helped you, consider giving it a star!**  
