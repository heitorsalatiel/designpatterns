namespace Structural.Facade.Example2
{
    public class Connection
    {
        public async Task<IApp> LaunchAppAsync(string appId)
        {
            Console.WriteLine($"Launch {appId}");
            return new YoutubeApp();
        }
    }
}
