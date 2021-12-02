using ModernInfrascture.Components;
using ModernInfrascture.Config;
using Pulumi;

namespace ModernInfrascture.Stacks
{
    public class ModernStack : Stack
    {
        private readonly GlobalConfig config;
        private readonly AppServiceConfig appServiceConfig;

        public ModernStack()
        {
            var location = "brazilsouth";
            var projectName = "TDC002";
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