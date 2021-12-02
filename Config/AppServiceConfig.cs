using Pulumi;

namespace ModernInfrascture.Config
{
    public class AppServiceConfig
    {
        public string Kind => "Linux";
        public string SkuTier => "Basic";
        public string SkuName=> "B1";
        public string AppDockerImage => "nginxdemos/hello";
        public string AppDockerImageTag => "plain-text";
        public Output<string> AppServicePlanId { get; set; }

        public AppServiceConfig ()
	    {
            this.AppServicePlanId = Output.Create<string>("");
	    }
    }
}