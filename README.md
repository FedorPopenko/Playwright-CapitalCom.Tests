# Playwright Capital.com Tests

NUnit + Playwright UI tests for Capital.com.

Automated UI testing framework for Capital.com using C#, Playwright, and NUnit.  
The project implements Page Object Model (POM) and covers core user scenarios.

## Authorized test state

Authorized scenarios use `.auth/authorized-user.json`. Set credentials in the current shell, then refresh the local state explicitly:

```powershell
$env:CAPITAL_QA_USER_EMAIL = "your-test-account@example.com"
$env:CAPITAL_QA_USER_PASSWORD = "your-password"
dotnet test --filter "FullyQualifiedName~SaveAuthorizedUserStorageStateAsync"
```

The refresh test is explicit and does not run in the normal suite. Authorized tests fail early if the stored access token is missing or expires in under five minutes.

If CAPTCHA or MFA prevents automated sign-in, refresh the state manually in a visible Chrome window instead:

```powershell
dotnet test --filter "FullyQualifiedName~SaveAuthorizedStateWithVisibleChromeAsync"
```

---

## 🛠 Tech Stack

- C#
- .NET 8
- Playwright
- NUnit
- Page Object Model (POM)
- Git & GitHub

---

## 🚦 Project Status

**Active development**

**Implemented:**
- Home page tests
- Company page tests
- Our offices page tests
- Press centre page tests
- Is capital.com safe? page tests
- Our business model page tests
- Investory Relations page tests


**In progress:**
- Web platform page tests
- Mobile app page tests
- TradingView page tests
- MT4 page tests
- MT5 page tests
- API access
- Screenshots & reporting

---

## 📑 Test Scenarios

- Open the page across all licenses and languages ​​for three types of users
- Smoke test for all licenses and languages ​​for three types of users

---

## 🗂 Project Structure

```
UiTestsPlaywright/
├── Core/
│   ├── Artifacts/
│   │   ├── ArtifactCleaner.cs 
│   │   ├── ArtifactManager.cs
│   │   └── ArtifactPaths.cs
│   │
│   ├── Fixtures/
│   │   ├── AssemblyInfo.cs 
│   │   ├── AuthorizedStorageStateValidator.cs
│   │   ├── CapitalTestBase.cs
│   │   ├── StorageStatePaths.cs
│   │   └── StorageStateProvider.cs
│   │
│   ├── Models/
│   │   ├── CapitalCountry.cs 
│   │   ├── CapitalLanguage.cs
│   │   ├── CapitalLicense.cs 
│   │   ├── CapitalPagePath.cs
│   │   ├── CapitalRoute.cs 
│   │   ├── TestRunContext.cs
│   │   └── UserSessionState.cs
│   │
│   ├── Routing/
│   │   ├── CapitalLocaleProvider.cs 
│   │   ├── CapitalRouteRegistry.cs
│   │   └── CapitalUrlBuilder.cs
│   │
│   ├── Users/
│   │   ├── TestUser.cs 
│   │   └── TestUsers.cs
│   │
│   ├── TestMatrix.cs
│   └── TestSettings.cs
│ 
├── Pages/
│   ├── About/
│   │   └── Who_We_Are/
│   │       ├── CompanyPage.cs
│   │       ├── InvestorRelationsPage.cs
│   │       ├── IsCapitalComSafePage.cs
│   │       ├── OurBusinessModelPage.cs
│   │       ├── OurOfficesPage.cs
│   │       └── PressCentrePage.cs
│   ├── Trading/
│   │   └── Platforms/
│   │       ├── 
│   │       ├── 
│   │       └── 
│   │
│   ├── CookieForm.cs
│   ├── LocationForm.cs
│   └── LoginAndSignUpForm.cs
│   
└── Tests/
    ├── Auth/
    │   ├── GenerateStorageStatesTests.cs
    │   └── ManualLoginTest.cs
    │
    ├── CompanyTests.cs 
    ├── HomePageTests.cs
    ├── InvestorRelationsTests.cs
    ├── IsCapitalComSafeTests.cs
    ├── OurBusinessModelTests.cs
    ├── OurOfficesTests.cs
    ├── PressCentreTests.cs
    └── 

```
