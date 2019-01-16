using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SJKP.ARMTools
{
    public class TemplateFileHelper
    {
        public static dynamic ReadTemplate(IHasTemplate options)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(ReadTemplateAsString(options));
        }

        public static string ReadTemplateAsString(IHasTemplate options)
        {
            return File.ReadAllText(options.template);
        }
    }
}
