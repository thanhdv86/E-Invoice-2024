using System.Configuration;
using System.Reflection;
using System.Xml;

namespace XMLSigner
{

    public static class Common
    {
        public static void AddUpdateConnectionString(string name, string value)
        {
            XmlNode node;
            var flag = true;
            var filename = GetAppName() + ".exe.config";
            var document = new XmlDocument();
            document.Load(filename);
            var list = document.DocumentElement.SelectNodes(string.Format("connectionStrings/add[@name='{0}']", name));
            if (list.Count > 0)
            {
                list[0].ParentNode.RemoveChild(list[0]);
            }
            if (flag)
            {
                node = document.CreateNode(XmlNodeType.Element, "add", null);
                var attribute = document.CreateAttribute("name");
                attribute.Value = name;
                node.Attributes.Append(attribute);
                attribute = document.CreateAttribute("connectionString");
                attribute.Value = "";
                node.Attributes.Append(attribute);
                attribute = document.CreateAttribute("providerName");
                attribute.Value = "System.Data.SqlClient";
                node.Attributes.Append(attribute);
            }
            else
            {
                node = list[0];
            }
            node.Attributes["connectionString"].Value = value;
            if (flag)
            {
                document.DocumentElement.SelectNodes("connectionStrings")[0].AppendChild(node);
            }
            document.Save(filename);
        }
        public static void changeConnectionStringValue(ConnectionStringSettings settings, string newValue)
        {
            typeof(ConfigurationElement).GetField("_bReadOnly", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(settings, false);
            settings.ConnectionString = newValue;
            var configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            ConfigurationManager.RefreshSection("connectionStrings");
        }

        public static void AddOrUpdateAppSettings(string key, string value)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {                
            }
        }
        public static string GetAppName()
        {
            return Assembly.GetExecutingAssembly().GetName().Name;
        }

        //public static string UriWebApi()
        //{
        //    return ConfigurationManager.AppSettings.Get("UriWebAPI");
        //}

    }
}
