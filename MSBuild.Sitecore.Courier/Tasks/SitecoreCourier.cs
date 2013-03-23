using System.IO;
using Microsoft.Build.Utilities;

namespace MSBuild.Sitecore.Courier.Tasks
{
    public class SitecoreCourier : ToolTask
    {
        public string SourceDirectory { get; set; }
        public string TargetDirectory { get; set; }
        public string OutputUpdateFile { get; set; }

        public SitecoreCourier()
        {
            ToolPath = "";
        }

        protected override string GenerateFullPathToTool()
        {
            return Path.Combine(ToolPath, ToolName);
        }

        protected override string ToolName
        {
            get
            {
                return @"Sitecore.Courier.Runner.exe";
            }
        }

        protected override string GenerateCommandLineCommands()
        {
            var builder = new CommandLineBuilder();

            builder.AppendSwitchIfNotNull("/source:", SourceDirectory);
            builder.AppendSwitchIfNotNull("/target:", TargetDirectory);
            builder.AppendSwitchIfNotNull("/output:", OutputUpdateFile);

            return builder.ToString();
        }
    }
}