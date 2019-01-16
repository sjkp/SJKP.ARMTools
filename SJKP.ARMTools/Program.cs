using CommandLine;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Reflection;

namespace SJKP.ARMTools
{
    partial class Program
    {

        static int Main(string[] args)
        {
            return CommandLine.Parser.Default.ParseArguments<MarkdownTableOptions, MakeParameterFileOptions>(args)
    .MapResult(
      (MarkdownTableOptions opts) => BuildMarkdownTableFromParameters(opts),
      (MakeParameterFileOptions opts) => MakeParameterFileOptions.Execute(opts),
      (ExtractParametersOptions opts) => ExtractParametersOptions.Execute(opts),
      errs => 1);


        }

        

        static int BuildMarkdownTableFromParameters(MarkdownTableOptions options)
        {
            dynamic template = TemplateFileHelper.ReadTemplate(options);
            Console.WriteLine("| parameter | type | description |");
            Console.WriteLine("| - | - | - |");
            foreach (var p in template.parameters)
            {
                Console.WriteLine($"| {p.Name} | {p.Value.type} | { p.Value.metadata?.description}|");
            }
            return 0;
        }

        
    }
    
}
