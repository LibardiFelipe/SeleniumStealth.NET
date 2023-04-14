using ADotNet.Clients;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets.Tasks;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets.Tasks.SetupDotNetTaskV1s;
using System;
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
                        Branches = new string[] { "master", "teste" }
                    },

                    PullRequest = new PullRequestEvent
                    {
                        Branches = new string[] { "master", "teste" }
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
                                Name = "Obtendo código"
                            },

                            new SetupDotNetTaskV1
                            {
                                Name = "Instalando .NET",
                                TargetDotNetVersion = new TargetDotNetVersion
                                {
                                    /* Obtido em https://dotnet.microsoft.com/en-us/download/dotnet/7.0 */
                                    DotNetVersion = "7.0.203"
                                }
                            },

                            new RestoreTask
                            {
                                Name = "Restaurando pacotes .NET",
                            },

                            new DotNetBuildTask
                            {
                                Name = "Compilando solução"
                            },

                            new TestTask
                            {
                                Name = "Rodando testes"
                            }
                        }
                    }
                }
            };

            /* Serializa e gera o arquivo .yml */
            adoNetClient.SerializeAndWriteToFile(
                adoPipeline: githubPipeline,
                path: "../../../../.github/workflows/dotnet.yml");
        }
    }
}