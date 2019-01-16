using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace SJKP.ARMTools
{

    [Verb("extractparameters", HelpText = "Find parameter usage in template resource section and adds them to parameter section.")]
    public class ExtractParametersOptions : IHasTemplate
    {
        [Option(Required = true, HelpText = "The json arm template to parse")]
        public string template { get; set; }


        public static int Execute(ExtractParametersOptions opts)
        {
            var template = TemplateFileHelper.ReadTemplate(opts);
            var templateStr = TemplateFileHelper.ReadTemplateAsString(opts);
            var r = new Regex("parameters\\('(\\w*)'\\)");
            HashSet<string> parameters = new HashSet<string>();
            var matches = r.Matches(templateStr);
            foreach(Match match in matches)
            {
                var parameterName = match.Groups.ElementAtOrDefault(1)?.Value;
                if (parameterName == null)
                    continue;
                parameters.Add(parameterName);
                
            }

            //Find missing parameters
            foreach(var p in template.parameters)
            {
                if (parameters.TryGetValue(p.Name, out string nop))
                {
                    parameters.Remove(p.Name);
                }
            }

            BuildMissingParameters(parameters);

            return 0;
        }

        private static void BuildMissingParameters(HashSet<string> parameters)
        {
            throw new NotImplementedException();
        }
    }
}