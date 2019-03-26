using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;


using System.Web.Http.OData.Builder;
using System.Web.Http.OData.Extensions;
using MedicineService.Models;
    
namespace MedicineService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.

            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();

            builder.EntitySet<UserDetail>("UserDetails");
            builder.EntitySet<Company>("Companies");
            builder.EntitySet<Purchase>("Purchases");
            builder.EntitySet<Generic>("Generics");
            builder.EntitySet<DosageFormat>("DosageFormats");
            builder.EntitySet<Stock>("Stocks");
            builder.EntitySet<Order>("Orders");
            builder.EntitySet<OrderDetail>("OrderDetails");
           

            config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
