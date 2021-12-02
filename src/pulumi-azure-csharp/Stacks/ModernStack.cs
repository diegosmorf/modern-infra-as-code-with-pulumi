using ModernInfrastructure.Components;
using ModernInfrastructure.Config;
using Pulumi;

namespace ModernInfrastructure.Stacks
{
    public class ModernStack : Stack
    {
        private readonly GlobalConfig config;
        private readonly AppServiceConfig appServiceConfig;

        public ModernStack()
        {
            var location = "brazilsouth";
            var projectName = "TDC010";
            var environment = Deployment.Instance.StackName;

            this.config = new GlobalConfig(environment,projectName,location);
            this.appServiceConfig = new AppServiceConfig();
            this.Deploy();
        }

        private void Deploy()
        {
            //Resource Group
            new ResourceGroupDeployer(config).Deploy();
            //App Service Plan 
            new AppServicePlanDeployer(config, appServiceConfig).Deploy();
            //WebApp
            new WebAppDeployer(config, appServiceConfig).Deploy();
        }
    }
}