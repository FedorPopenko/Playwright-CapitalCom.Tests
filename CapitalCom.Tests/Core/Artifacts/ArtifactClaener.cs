namespace CapitalCom.Tests.Core.Artifacts
{
    public static class ArtifactClaener
    {
        public static HashSet<string> FailedVideos { get; } = new();
        public static void DeletePassedVideos()
        {
            if (!Directory.Exists(ArtifactPaths.Videos))
            {
                return;
            }

            foreach (var video in Directory.GetFiles(ArtifactPaths.Videos, "*.webm"))
            {
                if (FailedVideos.Contains(video))
                {
                    continue;
                }

                File.Delete(video);
            }
        }
        public static void DeleteAllVideos()
        {
            if (!Directory.Exists(ArtifactPaths.Videos))
            {
                return;
            }

            foreach (var video in Directory.GetFiles(ArtifactPaths.Videos, "*.webm"))
            {
                File.Delete(video);
            }
        }
    }
}
