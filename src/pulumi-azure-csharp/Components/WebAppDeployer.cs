using ModernInfrastructure.Config;
using Pulumi.AzureNative.Web;
using Pulumi.AzureNative.Web.Inputs;

namespace ModernInfrastructure
{
    public class WebAppDeployer: IDeployer
    {
        private readonly GlobalConfig config;
        private readonly AppServiceConfig appServiceConfig;
        public WebAppDeployer(GlobalConfig config, AppServiceConfig appServiceConfig)
        {
            this.config = config;
            this.appServiceConfig = appServiceConfig;
        }

        public void Deploy()
        {
            var app = new WebApp("app-", new WebAppArgs
            {
                Name = $"{config.NamePrefix}-app",
                ResourceGroupName = config.ResourceGroupName,
                Location = config.Location,
                ServerFarmId = appServiceConfig.AppServicePlanId,
                Tags = config.Tags,
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
                    LinuxFxVersion = $"DOCKER|{appServiceConfig.AppDockerImage}:{appServiceConfig.AppDockerImageTag}"
                }
            });
        }
    }
}