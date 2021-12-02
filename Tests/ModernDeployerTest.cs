using FluentAssertions;
using ModernInfrascture.Stacks;
using NUnit.Framework;
using Pulumi.Azure.Core;
using Pulumi.AzureNative.Web;
using Pulumi.Testing;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;

namespace UnitTesting
{
    public class ModernDeployerTest
	{
		private static Task<ImmutableArray<Pulumi.Resource>> TestAsync()
		{
			return Pulumi.Deployment.TestAsync<ModernStack>(
												new StackMock(),
												new TestOptions { IsPreview = true, StackName = "test" });
		}

		[Test]
		public async Task When_CreateResourceGroup_Then_SingleOneExists()
		{
			//arrange			
			var location = "brazilsouth";
			var name = "br-test-TDC003-resourcegroup";

			//act
			var resources = await TestAsync();

			//assert
			var resourceGroups = resources.OfType<ResourceGroup>().ToList();
			resourceGroups.Count.Should().Be(1, "a single resource group is expected");

			var resourceGroup = resourceGroups.First();
			resourceGroup.Should().NotBeNull("Resource must be defined");
			(await resourceGroup.Name.GetValueAsync()).Should().Be(name);
			(await resourceGroup.Location.GetValueAsync()).Should().Be(location);

			AssertResourceTags(await resourceGroup.Tags.GetValueAsync());
		}

		private void AssertResourceTags(ImmutableDictionary<string, string>? tags)
		{
			tags.Should().NotBeNull("Tags must be defined");
			tags?.Count.Should().Be(6, "6 tags are required");
			tags.Should().ContainKey("Environment");
			tags.Should().ContainKey("CreatedBy");
			tags.Should().ContainKey("DeploymentDate");
			tags.Should().ContainKey("BuildNumber");
			tags.Should().ContainKey("BillingAreaCode");
			tags.Should().ContainKey("ProjectName");
		}

		[Test]
		public async Task When_CreateServicePlan_Then_SingleOneExists()
		{
			//arrange			
			var location = "brazilsouth";
			var name = "br-test-TDC003-serviceplan";

			//act
			var resources = await TestAsync();

			//assert
			var appServicePlans = resources.OfType<AppServicePlan>().ToList();
			appServicePlans.Count.Should().Be(1, "a single resource is expected");

			var appServicePlan = appServicePlans.First();
			appServicePlan.Should().NotBeNull("Resource must be defined");
			(await appServicePlan.Name.GetValueAsync()).Should().Be(name);
			(await appServicePlan.Location.GetValueAsync()).Should().Be(location);

			AssertResourceTags(await appServicePlan.Tags.GetValueAsync());
		}

		[Test]
		public async Task When_CreateWebApp_Then_SingleOneExists()
		{
			//arrange			
			var location = "brazilsouth";
			var name = "br-test-TDC003-app";

			//act
			var resources = await TestAsync();

			//assert
			var appServicePlans = resources.OfType<WebApp>().ToList();
			appServicePlans.Count.Should().Be(1, "a single resource is expected");

			var appServicePlan = appServicePlans.First();
			appServicePlan.Should().NotBeNull("Resource must be defined");
			(await appServicePlan.Name.GetValueAsync()).Should().Be(name);
			(await appServicePlan.Location.GetValueAsync()).Should().Be(location);

			AssertResourceTags(await appServicePlan.Tags.GetValueAsync());
		}
	}
}