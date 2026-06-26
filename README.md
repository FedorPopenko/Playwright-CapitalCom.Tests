# Playwright Capital.com Tests

NUnit + Playwright UI tests for Capital.com.

Automated UI testing framework for Capital.com using C#, Playwright, and NUnit.  
The project implements Page Object Model (POM) and covers core user scenarios.

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


**In progress:**
- Press centre page tests
- Whitepaperr page tests
- Investory Relations page tests
- Is capital.com safe? page tests
- Our business model page tests
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
│   ├── Fixtures/
│   │   ├── AssemblyInfo.cs 
│   │   ├── CapitalTestBase.cs
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
│   ├── TestMatrix.cs
│   └── TestSettings.cs
├── Pages/
│   ├── About/
│   │   └── Who_We_Are/
│   │       ├── CompanyPage.cs
│   │       ├── OurOfficesPage.cs
│   │       ├──  PressCentrePage.cs
│   │       ├── 
│   │       ├── 
│   │       └── 
│   ├── Trading/
│   │   └── Platforms/
│   │       ├── 
│   │       ├── 
│   │       └── 
│   └── LoginAndSignUpForm.cs
└── Tests/
    ├── CompanyTests.cs 
    ├── HomePageTests.cs
    ├── OurOfficesTests.cs
    ├── 
    ├── 
    └── 

```
