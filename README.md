# Modern (Developer-First) Infrastructure with C# + Pulumi + Azure 

<a href="https://www.pulumi.com?utm_campaign=pulumi-pulumi-github-repo&utm_source=github.com&utm_medium=top-logo" title="Pulumi - Modern Infrastructure as Code - AWS Azure Kubernetes Containers Serverless">
    <img src="https://www.pulumi.com/images/logo/logo-on-white-box.svg?" width="350">
</a>

**Pulumi's Infrastructure as Code SDK** is the easiest way to create and deploy cloud software that use containers, serverless functions, hosted services, and infrastructure, on any cloud.

<img src="https://www.pulumi.com/images/product/product-platform-desktop.svg"/>

## Summary
This project cover concepts about:  
 - Infrastructure as Code (IaC)
 - Cloud
 - UnitTest

## .Net Version
.NET 6.0

## 3rd Party Nuget Packages 
- Pulumi
- FluentAssertion
- NUnit

## Development Tools
 - Visual Studio Code
 - GIT
 - GitHub(Repos, Actions)
 
# It is ALL about software

As a developer, I want to have my code following best practices like:

- code versioning
- no hardcoded strings (sensitive data) in code
- write methods to do one thing and one thing only
- make your code testable
- make your code general enough so you can reuse it
- local debugging/troubleshooting
- promote artifact instead of promote code 

## Infrastructure as Code (IaC) and Immutability

The basic premise of IaC is everything is a code. We can compare to application development lifecycle, when you have new features or bugfix to deploy, you build new version and promote among the environments until touch production.  Patches/changes during this promotion process are not permitted. The benefits go beyond to have a versioned infra but documentation, high level of testability, security, monitoring, and reusability. You easily apply conventions, componentization and patterns that is new on infra context but very old on software development area.

## Getting Started

See the [Get Started](https://www.pulumi.com/docs/quickstart/?utm_campaign=pulumi-pulumi-github-repo&utm_source=github.com&utm_medium=getting-started-quickstart) guide to quickly get started with Pulumi on your platform and cloud of choice.

Otherwise, the following steps demonstrate how to deploy your first Pulumi program, using Azure and C# in minutes:

1. **Install**:

    To install the latest Pulumi release, run the following (see full
    [installation instructions](https://www.pulumi.com/docs/reference/install/?utm_campaign=pulumi-pulumi-github-repo&utm_source=github.com&utm_medium=getting-started-install) for additional installation options):

    ```bash
    choco install pulumi
    ```

    When developing locally, we recommend that you install the Azure CLI and then authorize access with a user account.

    ```bash
    az login --use-device-code    
    ```

    This command will prompt you for an access token, including a way to launch your web browser to easily obtain one. You can script by using PULUMI_ACCESS_TOKEN environment variable.

    ```bash    
    pulumi login
    ```

2. **Create a Project**:

    After installing, you can get started with the `pulumi new` command:

    ```bash
    $ mkdir quickstart && cd quickstart
    $ pulumi new azure-csharp
    $ pulumi stack init dev
    ```

    The `new` command offers templates for all languages and clouds.  Run it without an argument and it'll prompt     you with available projects.  This command created an Azure project written in C#.

3. **Deploy to the Cloud**:

    Run `pulumi up` to get your code to the cloud:

    ```bash
    $ pulumi up
    ```

    This makes all cloud resources needed to run your code.  Simply make edits to your project, and subsequent
    `pulumi up`s will compute the minimal diff to deploy your changes.

4. **Use Your Program**:

    Now that your code is deployed, you can interact with it.  In the above example, we can curl the endpoint:

    ```bash
    $ curl $(pulumi stack output url)
    ```

5. **Access the Logs**:

    If you're using containers or functions, Pulumi's unified logging command will show all of your logs:

    ```bash
    $ pulumi logs -f
    ```

6. **Destroy your Resources**:

    After you're done, you can remove all resources created by your program:

    ```bash
    $ pulumi destroy -y
    ```

To learn more, head over to [pulumi.com](https://pulumi.com/?utm_campaign=pulumi-pulumi-github-repo&utm_source=github.com&utm_medium=getting-started-learn-more-home) for much more information, including [tutorials](https://www.pulumi.com/docs/reference/tutorials/?utm_campaign=pulumi-pulumi-github-repo&utm_source=github.com&utm_medium=getting-started-learn-more-tutorials), [examples](https://github.com/pulumi/examples), and details of the core Pulumi CLI and [programming model concepts](https://www.pulumi.com/docs/reference/concepts/?utm_campaign=pulumi-pulumi-github-repo&utm_source=github.com&utm_medium=getting-started-learn-more-concepts).

