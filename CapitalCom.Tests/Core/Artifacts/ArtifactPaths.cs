namespace CapitalCom.Tests.Core.Artifacts
{
    public static class ArtifactPaths
    {
        public static string Root => Path.Combine(TestContext.CurrentContext.WorkDirectory, "test-results");

        public static string Videos => Path.Combine(Root, "videos");
        public static string Traces => Path.Combine(Root, "traces");
        public static string Screenshots => Path.Combine(Root, "screenshots");
    }
}
