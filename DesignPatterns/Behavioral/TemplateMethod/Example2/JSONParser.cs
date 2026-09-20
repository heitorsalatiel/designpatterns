using System.Text.Json;

namespace Behavioral.TemplateMethod.Example2
{
    public class JSONParser : FileParser
    {
        public override Dictionary<string, string> ParseContent(string content)
        {
            return JsonSerializer.Deserialize<Dictionary<string, string>>(content)!;
        }
    }
}
