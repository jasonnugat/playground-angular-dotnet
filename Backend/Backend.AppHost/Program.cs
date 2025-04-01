var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");

var apiService = builder.AddProject<Projects.Backend_ApiService>("apiservice");

builder.AddProject<Projects.Backend_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(cache)
    .WaitFor(cache)
    .WithReference(apiService)
    .WaitFor(apiService);

builder.AddNpmApp("frontend-angular", "../../Frontend")
     .WithReference(apiService)
     .WithHttpEndpoint(port: 7005, env: "PORT")
     .WithExternalHttpEndpoints()
     .PublishAsDockerFile();

builder.Build().Run();
