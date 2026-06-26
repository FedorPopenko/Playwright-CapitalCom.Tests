# Playwright Capital.com Tests

NUnit + Playwright UI tests for Capital.com.

## Run

```powershell
dotnet restore --configfile .\NuGet.Config
dotnet build --no-restore
powershell -ExecutionPolicy Bypass -File .\CapitalCom.Tests\bin\Debug\net10.0\playwright.ps1 install
dotnet test --no-build
```
