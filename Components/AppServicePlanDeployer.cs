using ModernInfrascture.Config;
using Pulumi.AzureNative.Web;
using Pulumi.AzureNative.Web.Inputs;

namespace ModernInfrascture.Components
{
    public class AppServicePlanDeployer: IDeployer
    {
        private readonly GlobalConfig config;
        private readonly AppServiceConfig appServiceConfig;
        public AppServicePlanDeployer(GlobalConfig config, AppServiceConfig appServiceConfig)
        {
            this.config = config;
            this.appServiceConfig = appServiceConfig;
        }        

        public void Deploy()
        {
            var appServicePlan = new AppServicePlan("serviceplan-", new AppServicePlanArgs
            {
                Name = $"{config.NamePrefix}-serviceplan",
                ResourceGroupName = config.ResourceGroupName,
                Location = config.Location,
                Kind = appServiceConfig.Kind,
                Reserved = true,
                Sku = new SkuDescriptionArgs
                {
                    Tier = appServiceConfig.SkuTier,
                    Name = appServiceConfig.SkuName,
                },
                Tags = config.Tags
            });

            appServiceConfig.AppServicePlanId = appServicePlan.Id;
        }
    }
}