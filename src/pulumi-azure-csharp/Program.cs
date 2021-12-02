using System.Threading.Tasks;
using Pulumi;
using ModernInfrastructure.Stacks;

namespace ModernInfrascture
{
    public class Program
    {
        static Task<int> Main() => Deployment.RunAsync<SimpleStack>();
    }
}