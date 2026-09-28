namespace Structural.Facade.Example2
{
    public class YoutubeApp : IApp
    {
        public async Task PlayAsync(Guid videoId)
        {
            Console.WriteLine($"Playing {videoId}");
        }
    }
}
