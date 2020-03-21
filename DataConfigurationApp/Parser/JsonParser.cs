using DataConfigurationApp.Model;
using Newtonsoft.Json;
using System;
using System.IO;

namespace DataConfigurationApp.Parser
{
    public static class JsonParser
    {
        public static Organization Organization { get; set; }
        public static Configuration Configuration { get; set; }

        static JsonParser()
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
