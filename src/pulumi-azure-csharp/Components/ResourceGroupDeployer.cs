using ModernInfrastructure.Config;
using Pulumi.Azure.Core;

namespace ModernInfrastructure.Components
{
    public class ResourceGroupDeployer: IDeployer
    {
        private readonly GlobalConfig config;

        public ResourceGroupDeployer(GlobalConfig config)
        {
            this.config = config;
        }

        public void Deploy()
        {
            var resourceGroup = new ResourceGroup("resourcegroup-", 
                                                    new ResourceGroupArgs { 
                                                        Name = $"{config.NamePrefix}-resourcegroup",
                                                        Location = config.Location,
                                                        Tags = config.Tags} );

            config.ResourceGroupName = resourceGroup.Name;
        }
    }
}