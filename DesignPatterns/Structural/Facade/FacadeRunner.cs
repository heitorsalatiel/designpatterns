using Structural.Facade.Example1;
using Structural.Facade.Example2;

namespace Structural.Facade
{
    public class FacadeRunner
    {
        public static async Task Execute()
        {
            Console.WriteLine();
            Console.WriteLine("========= Example 1 : =========");
            Console.WriteLine();

            var facade = new FacadeClass();
            facade.Operation1();

            Console.WriteLine();
            Console.WriteLine("========= Example 2 : =========");
            Console.WriteLine();

            var castingFacade = new CastingFacade(new DeviceExplorer());
            await castingFacade.CastAsync(Guid.NewGuid(), Guid.NewGuid());
        }
    }
}
