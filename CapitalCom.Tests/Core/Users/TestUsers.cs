namespace CapitalCom.Tests.Core.Users
{
    public static class TestUsers
    {
        public static TestUser QaUser => new()
        {
            Email = GetRequiredEnvironmentVariable("CAPITAL_QA_USER_EMAIL"),
            Password = GetRequiredEnvironmentVariable("CAPITAL_QA_USER_PASSWORD")
        };

        private static string GetRequiredEnvironmentVariable(string name) =>
            Environment.GetEnvironmentVariable(name)
            ?? throw new InvalidOperationException($"Environment variable '{name}' is required to generate the authorized storage state.");
    }
}
