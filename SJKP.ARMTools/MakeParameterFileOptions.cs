using CommandLine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SJKP.ARMTools
{

    [Verb("makeparameterfile", HelpText = "Generates a paramter file from the template")]
    public class MakeParameterFileOptions : IHasTemplate
    {
        [Option(Required = true, HelpText = "The json arm template to parse")]
        public string template { get; set; }
        [Option(Required = true, HelpText = "The json file to output the parameter file to")]
        public string outfile { get; set; }

        public static int Execute(MakeParameterFileOptions opts)
        {
            dynamic template = TemplateFileHelper.ReadTemplate(opts);
            JObject jObject = new JObject();

            foreach (var param in template.parameters) {
                jObject.Add(param.Name, new JObject(new JProperty("value", "")));
            }
            var empty = @"{
  ""$schema"": ""https://schema.management.azure.com/schemas/2015-01-01/deploymentParameters.json#"",
  ""contentVersion"": ""1.0.0.0"",
  ""parameters"": " + JsonConvert.SerializeObject(jObject, Formatting.Indented)  + @"
}";

            
            File.WriteAllText(opts.outfile, empty );


            return 0;

        }

       
    }
}
