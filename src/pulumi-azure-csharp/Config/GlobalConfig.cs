using System;
using Pulumi;

namespace ModernInfrastructure.Config
{
    public class GlobalConfig
    {
        public string Environment{get;}
        public string ProjectName{get;}
        public string Location{get;}
        public string NamePrefix => $"br-{Environment}-{ProjectName}";
        public InputMap<string> Tags{get;}
        public Output<string> ResourceGroupName {get; set;}

        public GlobalConfig(string environment, string projectName, string location)
        {
            this.Environment = environment;
            this.ProjectName = projectName;
            this.Location = location;               

            this.Tags = new InputMap<string>{ 
                { "Environment", environment }, 
                { "CreatedBy", "Diego-Cardoso" },
                { "DeploymentDate", DateTime.UtcNow.ToString() },
                { "BuildNumber", "2021-12-02.001" },
                { "BillingAreaCode", "123456789" },
                { "ProjectName", projectName }};            
        
            this.ResourceGroupName = Output.Create<string>("");
        }
    }
}