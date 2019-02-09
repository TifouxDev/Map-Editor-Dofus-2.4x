using NLog;
using ShadowEmu.Common.Logger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ShadowEmu.Common.Config
{
    /// <summary>
    /// Tifoux configuration
    /// </summary>
    public class ConfigManager : ShadowEmu.Common.Extensions.DataManager<ConfigManager>
    {
        private string m_pathConfig;
        private Assembly m_asm;
        private List<string[]> m_fields = new List<string[]>();
        private List<ReflectionConfiguration> m_attributs = new List<ReflectionConfiguration>();
        private NLog.Logger m_logger = LogManager.GetCurrentClassLogger();
        public void Load(Assembly asm, string pathConfig)
        {
            m_asm = asm;
            m_pathConfig = pathConfig;
            ReflectionReading();
            ParseConfiguration();
            UpdateFields();
        }

        private void ParseConfiguration()
        {
            if (File.Exists(m_pathConfig) == false)
            {
                m_logger.Error("Can't find config file.");
                return;
            }

            string[] m_lines = File.ReadAllLines(m_pathConfig);
            foreach (string line in m_lines)
            {
                if (line.StartsWith("#") || line == "")
                    continue;
                string newLine = line.Replace(" ", "");
                string[] split = newLine.Split('=');

                string name = split[0];
                string value = split[1];
                if (!m_fields.Any(entry => entry[0] == name))
                {
                    m_fields.Add(split);
                }
            }

            m_logger.Info("Config file loaded.");
        }

        private void ReflectionReading()
        {
            #region Reflection
            foreach (System.Type current in
                     from entry in m_asm.GetTypes()
                     select entry)
            {
                foreach (var prop in current.GetFields())
                {
                    object[] attrs = prop.GetCustomAttributes(true);
                    foreach (object attr in attrs)
                    {
                        Configuration authAttr = attr as Configuration;
                        if (authAttr != null)
                        {
                            if(!m_attributs.Any(entry=> entry.Config.Name == authAttr.Name))
                                m_attributs.Add(new ReflectionConfiguration(current, authAttr, prop));
                        }
                    }
                }

            }
            #endregion
        }

        private void UpdateFields()
        {
            foreach(var fieldConfig in m_fields)
            {
                string name = fieldConfig[0].ToLower();

                if(m_attributs.Any(entry=>entry.Config.Name.ToLower() == name))
                {
                    var attribut = m_attributs.First(entry => entry.Config.Name.ToLower() == name);
                    var value = fieldConfig[1];
                    if (value.Contains("\""))
                    {
                      value=  value.Replace("\"", "");
                        attribut.Field.SetValue(attribut.CurrentObject, Convert.ToString(value));
                    }
                    else
                    {
                        attribut.Field.SetValue(attribut.CurrentObject, Convert.ToInt16(value));
                    }
                }

            }
        }
    }

    public class ReflectionConfiguration
    {
        private object m_object;
        private Configuration m_config;
        private FieldInfo m_field;

        public object CurrentObject
        {
            get { return m_object; }
        }

        public Configuration Config
        {
            get { return m_config; }
        }
        public FieldInfo Field
        {
            get { return m_field; }
        }
        public ReflectionConfiguration(object obj, Configuration configuration, FieldInfo field)
        {
            m_object = obj;
            m_config = configuration;
            m_field = field;
        }
    }
}
