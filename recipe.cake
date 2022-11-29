#module nuget:?package=Cake.BuildSystems.Module&version=4.2.0
#load nuget:?package=Cake.Recipe&version=3.0.1
#l ./.build/statiq-docs.cake

Environment.SetVariableNames();

BuildParameters.SetParameters(
  context: Context,
  buildSystem: BuildSystem,
  sourceDirectoryPath: "./src",
  title: "Cake-Test",
  masterBranchName: "main",
  repositoryOwner: "nils-a",
  shouldRunDotNetCorePack: true,
  shouldUseDeterministicBuilds: true,
  preferredBuildProviderType: BuildProviderType.GitHubActions,
  preferredBuildAgentOperatingSystem: PlatformFamily.Linux);

BuildParameters.PrintParameters(Context);

ToolSettings.SetToolSettings(context: Context);

Build.RunDotNetCore();

