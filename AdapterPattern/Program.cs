using AdapterPattern.Adapter;
using AdapterPattern.Aggregation;
using AdapterPattern.ThirdPartyService;

namespace AdapterPattern
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Register third-party provider services
            builder.Services.AddSingleton<ProviderAService>();
            builder.Services.AddSingleton<ProviderBService>();

            // Register adapters
            builder.Services.AddTransient<IInsuranceProviderAdapter, ProviderAAdapter>();
            builder.Services.AddTransient<IInsuranceProviderAdapter, ProviderBAdapter>();

            // Register InsuranceAggregator
            builder.Services.AddTransient<InsuranceAggregator>();

            var app = builder.Build();

            app.MapGet("/insurance-plans", (InsuranceAggregator aggregator) =>
            {
                var plans = aggregator.GetAllPlans();
                return Results.Ok(plans);
            });

            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}