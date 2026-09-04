using System.Reflection;

namespace CapitalCom.Tests.Core.Fixtures
{
    public static class StorageStatePaths
    {
        public static readonly string SolutionDirectory = GetSolutionDirectory();
        public static readonly string AuthDirectory = Path.Combine(SolutionDirectory, ".auth");
        public static readonly string Authorized = Path.Combine(AuthDirectory, "authorized-user.json");
        public static readonly string Unauthorized = Path.Combine(AuthDirectory, "unauthorized-user.json");

        static StorageStatePaths()
        {
            System.IO.Directory.CreateDirectory(AuthDirectory);
        }

        private static string GetSolutionDirectory()
        {
            var directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;

            while (directory is not null && !File.Exists(Path.Combine(directory, "PlaywrightCapital.slnx")))
            {
                directory = Path.GetDirectoryName(directory);
            }

            if (directory is null)
            {
                throw new DirectoryNotFoundException("Solution directoru was not found");
            }

            return directory;
        }
    }
}
