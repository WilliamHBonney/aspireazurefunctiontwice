internal class Program
{
    private static void Main(string[] args)
    {
        var builder = DistributedApplication.CreateBuilder(args);

        builder.AddAzureFunctionsProject<Projects.FunctionApp1>("functionapp1-first")
            .WithArgs($"--verbose")
            .WithEndpoint("http", (endpointBuilder) =>
            {
                endpointBuilder.Port = 6074;
                endpointBuilder.TargetPort = 6074;
                endpointBuilder.IsProxied = false;
            })
            .WithEnvironment("EXAMPLE_ENV", "I am the environment var from the first one!")
            .WithEnvironment("WEBSITE_HOSTNAME", "localhost:6074")
            .WithEnvironment("ASPNETCORE_URLS", "http://+:6074");

        builder.AddAzureFunctionsProject<Projects.FunctionApp1>("functionapp1-second")
            .WithArgs($"--verbose")
            .WithEndpoint("http", (endpointBuilder) =>
            {
                endpointBuilder.Port = 6075;
                endpointBuilder.TargetPort = 6075;
                endpointBuilder.IsProxied = false;
            })
            .WithEnvironment("EXAMPLE_ENV", "I am the environment var from the second one!")
            .WithEnvironment("WEBSITE_HOSTNAME", "localhost:6075")
            .WithEnvironment("ASPNETCORE_URLS", "http://+:6075");

        builder.Build().Run();
    }
}