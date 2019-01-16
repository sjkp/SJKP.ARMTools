using CommandLine;

namespace SJKP.ARMTools
{
    partial class Program
    {
        [Verb("markdowntable", HelpText = "Generates a markdown table from the template input paramteres.")]
        public class MarkdownTableOptions : IHasTemplate
        {
            [Option(Required = true, HelpText = "The json arm template to parse")]
            public string template { get; set; }
        }
    }
}
