using System.Threading.Tasks;
using Pulumi;
using ModernInfrastructure.Stacks;

namespace ModernInfrastructure
{
    public class Program
    {
        static Task<int> Main() => Deployment.RunAsync<SimpleStack>();
    }
}