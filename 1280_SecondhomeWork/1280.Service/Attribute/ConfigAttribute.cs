using _1280.Service.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1280.Service
{
    [AttributeUsage(AttributeTargets.Class)]
   public  class ConfigAttribute : Attribute
    {
        public string FileName { get; }
        public ConfigTypeEnum ConfigType { get; } = ConfigTypeEnum.Json;
        public ConfigAttribute(string fileName)
        {
            this.FileName = fileName;
        }

        public ConfigAttribute(string fileName, ConfigTypeEnum configType)
		{
			this.FileName = fileName;
			this.ConfigType = configType;
		}

       
}
}
