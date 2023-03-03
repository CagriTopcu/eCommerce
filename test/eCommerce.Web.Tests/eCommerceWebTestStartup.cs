using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volo.Abp;

namespace eCommerce;

public class eCommerceWebTestStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddApplication<eCommerceWebTestModule>();
    }

    public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
    {
        app.InitializeApplication();
    }
}
