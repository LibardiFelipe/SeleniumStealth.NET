using ADotNet.Clients;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets.Tasks;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets.Tasks.SetupDotNetTaskV1s;
using System.Collections.Generic;

namespace SeleniumStealth.NET.Infrastructure.Build
{
    static internal class Program
    {
        static void Main(string[] args)
        {
            var adoNetClient = new ADotNetClient();
            var githubPipeline = new GithubPipeline
            {
                Name = "SeleniumStealth.NET Build",
                OnEvents = new Events
                {
                    Push = new PushEvent
                    {
                        Branches = new string[] { "master" }
                    },

                    PullRequest = new PullRequestEvent
                    {
                        Branches = new string[] { "master" }
                    },
                },

                Jobs = new Jobs
                { 
                    Build = new BuildJob
                    {
                        RunsOn = BuildMachines.WindowsLatest,
                        Steps = new List<GithubTask>
                        {
                            new CheckoutTaskV2
                            {
                                Name = "Pulling Code"
                            },

                            new SetupDotNetTaskV1
                            {
                                Name = "Installing .NET",
                                TargetDotNetVersion = new TargetDotNetVersion
                                {
                                    /* Got the SDK version at https://dotnet.microsoft.com/en-us/download/dotnet/7.0 */
                                    DotNetVersion = "7.0.203"
                                }
                            },

                            new RestoreTask
                            {
                                Name = "Resoring .NET Packages",
                            },

                            new DotNetBuildTask
                            {
                                Name = "Compiling Solution"
                            },

                            new TestTask
                            {
                                Name = "Running Tests"
                            }
                        }
                    }
                }
            };

            adoNetClient.SerializeAndWriteToFile(
                adoPipeline: githubPipeline,
                path: "../../../../.github/workflows/dotnet.yml");
        }
    }
}