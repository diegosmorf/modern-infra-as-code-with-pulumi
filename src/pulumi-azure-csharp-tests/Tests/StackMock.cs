using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Testing;

namespace ModernInfrastructure.Tests
{
    internal class StackMock : IMocks
    {
        public Task<(string? id, object state)> NewResourceAsync(MockResourceArgs args)
        {
            var outputs = ImmutableDictionary.CreateBuilder<string, object>();

            // Forward all input parameters as resource outputs, so that we could test them.
            outputs.AddRange(args.Inputs);

            //TODO: You can add mock for your test scenarios

            return Task.FromResult((args.Id, (object)outputs));
        }

        public Task<object> CallAsync(MockCallArgs args)
        {            
            return Task.FromResult((object)args.Args);
        }
    }
}