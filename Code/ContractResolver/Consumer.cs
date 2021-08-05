using Newtonsoft.Json;
using System.Collections.Generic;

namespace Code.ContractResolver
{
    public class Consumer
    {
        public static string IgnoreProperties(Model model, List<string> ignoreColumnsValueZero) 
        {
            string NewJson = JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings { ContractResolver = new IgnorePropertiesContractResolver(ignoreColumnsValueZero) });

            return NewJson;
        }
    }
}
