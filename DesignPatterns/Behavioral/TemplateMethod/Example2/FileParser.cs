namespace Behavioral.TemplateMethod.Example2
{
    public abstract class FileParser
    {
        //Template Method
        public Dictionary<string, string> ParseFile(string path)
        {
            LogOperation($"Validating file {path}");
            ValidateFile(path);

            LogOperation("Loading file...");
            var content = File.ReadAllText(path);

            LogOperation("Parsing file...");
            var data = ParseContent(content);

            LogOperation("Enriching file...");
            EnrichData(data);

            LogOperation("Validating file...");
            ValidateData(data);

            return data;
        }

        private void ValidateFile(string path)
        {
            if(!File.Exists(path))
            {
                throw new Exception("The file does not exist");
            }

            if(new FileInfo(path).Length == 0)
            {
                throw new Exception("File is empty");
            }
        }

        //Primitive Operation
        public abstract Dictionary<string, string> ParseContent(string content);

        //Hook Operation
        public virtual void LogOperation(string message)
        {
            Console.WriteLine($"{DateTime.UtcNow:HH:mm:ss} : {message}");
        }

        //Hook Operation
        protected virtual void EnrichData(Dictionary<string, string> data)
        {
            data["parsedAt"] = DateTime.UtcNow.ToString();
        }

        //Hook Operation
        protected virtual void ValidateData(Dictionary<string, string> data)
        {
        }
    }
}
