using Microsoft.Playwright;

namespace CapitalCom.Tests.Core.Artifacts
{
    public sealed class ArtifactManager
    {
        private readonly IBrowserContext _context;
        private readonly IPage _page;
        public ArtifactManager(IBrowserContext context, IPage page)
        {
            _context = context;
            _page = page;
        }
        public async Task StartTraceAsync()
        {
            await _context.Tracing.StartAsync(new()
            {
                Screenshots = true,
                Snapshots = true,
                Sources = true
            });
        }

        public async Task StopTraceAsync()
        {
            var testName = TestContext.CurrentContext.Test.Name;
            var status = TestContext.CurrentContext.Result.Outcome.Status;

            if (status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                if (_page.Video is not null)
                {
                    var videoPath = await _page.Video.PathAsync();
                    ArtifactClaener.FailedVideos.Add(videoPath);
                }

                var tracePath = Path.Combine(ArtifactPaths.Traces, $"{SanitizeFileName(testName)}.zip");

                await _context.Tracing.StopAsync(new()
                {
                    Path = tracePath,
                });

                await TestContext.Out.WriteLineAsync($"Trace saved; {tracePath}");
            }
            else
            {
                await _context.Tracing.StopAsync();
            }
        }
        private static string SanitizeFileName(string fileName)
        {
            foreach (var invalidChar in Path.GetInvalidFileNameChars())
            {
                fileName = fileName.Replace(invalidChar, '_');
            }

            return fileName;
        }
    }
}
