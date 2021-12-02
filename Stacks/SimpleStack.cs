using Pulumi;
using Pulumi.Azure.Core;
using Pulumi.AzureNative.Web;
using Pulumi.AzureNative.Web.Inputs;
using System;

namespace ModernInfrastructure.Stacks
{
    public class SimpleStack : Stack
    {
        public SimpleStack()
        {    
            var location = "brazilsouth";
            var projectName = "TDC003";
            var environment = Deployment.Instance.StackName;    

            var dockerImage = "nginxdemos/hello";
            var dockerImageTag = "plain-text";
            
            var tags = new InputMap<string>{ 
                { "Environment", environment }, 
                { "CreatedBy", "Diego-Cardoso" },
                { "DeploymentDate", DateTime.UtcNow.ToString() },
                { "BuildNumber", "2021-12-01.001" },
                { "BillingAreaCode", "123456789" },
                { "ProjectName", projectName }};
            
            var namePrefix = $"br-{environment}-{projectName}";
            var resourceGroup = new ResourceGroup( "resourcegroup-", 
                                                    new ResourceGroupArgs { 
                                                                    Name = $"{namePrefix}-resourcegroup",  
                                                                    Location = location,
                                                                    Tags = tags} );

            var appServicePlan = new AppServicePlan("serviceplan-", new AppServicePlanArgs
            {
                Name = $"{namePrefix}-serviceplan",
                ResourceGroupName = resourceGroup.Name,
                Location = location,
                Kind = "Linux",
                Reserved = true,
                Sku = new SkuDescriptionArgs
                {
                    Tier = "Basic",
                    Name = "B1",
                },
                Tags = tags
            });

            var app = new WebApp("app-", new WebAppArgs
            {
                Name = $"{namePrefix}-app",
                ResourceGroupName = resourceGroup.Name,
                Location = location,
                ServerFarmId = appServicePlan.Id,
                Tags = tags,
                SiteConfig = new SiteConfigArgs
                {
                    AppSettings = {
                        new NameValuePairArgs{
                            Name = "DOCKER_REGISTRY_SERVER_URL",
                            Value = "https://index.docker.io",
                        },
                        new NameValuePairArgs{
                            Name = "DOCKER_REGISTRY_SERVER_USERNAME",
                            Value = ""
                        },
                        new NameValuePairArgs{
                            Name = "DOCKER_REGISTRY_SERVER_PASSWORD",
                            Value = ""
                        },
                        new NameValuePairArgs{
                            Name = "WEBSITES_ENABLE_APP_SERVICE_STORAGE",
                            Value = "false",
                        },
                    },
                    LinuxFxVersion = $"DOCKER|{dockerImage}:{dockerImageTag}"
                }
            });
        }    
    }
}