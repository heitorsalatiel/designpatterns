namespace Structural.Facade.Example2
{
    public class CastingFacade(DeviceExplorer deviceExplorer)
    {
        public async Task CastAsync(Guid deviceId, Guid videoId)
        {
            IDevice device = await deviceExplorer.GetAsync(deviceId);

            if (device is not SmartTVDevice smartTVDevice)
            {
                throw new Exception("Smart TV not found");
            }

            Connection connection; 

            try
            {
                connection = await smartTVDevice.ConnectionAsync();
            }
            catch (Exception ex)
            {
                connection = await smartTVDevice.TurnOnAsync();

                await Task.Delay(2000);
            }

            IApp app = await connection.LaunchAppAsync("com.google.youtube");

            if(app is not YoutubeApp youtubeApp)
            {
                throw new Exception("Failed opening Youtube app");
            }

            await youtubeApp.PlayAsync(videoId);
        }
    }   
}
