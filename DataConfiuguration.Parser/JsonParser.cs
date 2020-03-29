using DataConfigurationApp.Model;
using Newtonsoft.Json;
using System;
using System.IO;

namespace DataConfiuguration.Parser
{
    public class JsonParser
    {
        public Organization Organization { get; }
        public Configuration Configuration { get; }

        public JsonParser()
        {
            var data = GetOrgConfigData();

            Organization = data.Item1;
            Configuration = data.Item2;
        }

        private static (Organization, Configuration) GetOrgConfigData()
        {
            try
            {
                string text = File.ReadAllText("Json/OrgConfig.json");
                var data = JsonConvert.DeserializeObject<JsonRootModel>(text);

                if (data == null) throw new Exception("Error in parsing json file!");

                return (data.organization, data.configuration);
            }
            catch (FileNotFoundException fileNotFoundEx)
            {
                throw fileNotFoundEx;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
