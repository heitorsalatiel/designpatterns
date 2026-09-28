namespace Structural.Facade.Example2
{
    public interface IDevice
    {
        Task<Connection> ConnectionAsync();
        Task<Connection> TurnOnAsync();
    }
}
