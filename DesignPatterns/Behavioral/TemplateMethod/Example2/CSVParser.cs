namespace Behavioral.TemplateMethod.Example2
{
    public class CSVParser : FileParser
    {
        public override Dictionary<string, string> ParseContent(string content)
        {
            Dictionary<string, string> result = [];

            foreach(var row in content.Split('\n'))
            {
                var parts = row.Split(',');

                result[parts[0]] = parts[1]; 
            }

            return result;
        }
    }
}
