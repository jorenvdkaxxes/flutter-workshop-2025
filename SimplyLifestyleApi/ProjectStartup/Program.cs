using ProductCatalog.Domain;
using ProductCatalog.Application;
using ProductCatalog.Infrastructure;
using ProductCatalog.Web;
using OrderManagement.Domain;
using OrderManagement.Application;
using OrderManagement.Infrastructure;
using OrderManagement.Web;
using Statistics.Domain;
using Statistics.Application;
using Statistics.Infrastructure;
using Statistics.Web;
using Identity.Application;
using Identity.Infrastructure;
using Identity.Web;
using Common.Infrastructure;
using Common.Web;
using ProjectStartup;


var builder = WebApplication.CreateBuilder(args);

builder
    .Services
    .AddProductCatalogDomain()
    .AddProductCatalogApplication(builder.Configuration)
    .AddProductCatalogInfrastructure(builder.Configuration)
    .AddProductCatalogWebComponents();

//builder
//    .Services
//    .AddOrderManagementDomain()
//    .AddOrderManagementApplication(builder.Configuration)
//    .AddOrderManagementInfrastructure(builder.Configuration)
//    .AddOrderManagementWebComponents();

//builder
//    .Services
//    .AddStatisticsDomain()
//    .AddStatisticsApplication(builder.Configuration)
//    .AddStatisticsInfrastructure(builder.Configuration)
//    .AddStatisticsWebComponents();

//builder
//    .Services
//    .AddIdentityApplication(builder.Configuration)
//    .AddIdentityInfrastructure(builder.Configuration)
//    .AddIdentityWebComponents();

builder.Services
    .AddTokenAuthentication(builder.Configuration)
    .AddEventSourcing()
    .AddModelBinders()
    .AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new() { Title = "Web API", Version = "v1" });
    })
    .AddHttpClient();

var app = builder.Build();

app
    .UseWebService(app.Environment)
    .Initialize();

app.Run();