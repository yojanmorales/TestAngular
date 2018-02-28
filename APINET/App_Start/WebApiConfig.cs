using APINET.Contenedor;
using Microsoft.Practices.Unity;
using ModeloNet;
using ModeloNet.Repository;
using ModeloNet.Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace APINET
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            var container = new UnityContainer();
            container.RegisterType<IRepository<Customer>, Repository<Customer>>(new HierarchicalLifetimeManager());
            container.RegisterType<ICustomerServices, CustomerServices>(new HierarchicalLifetimeManager());
            
            config.DependencyResolver = new UnityResolver(container);

            // New code
            var cors = new EnableCorsAttribute("http://localhost:56650", "*", "*");
            config.EnableCors(cors);
            //var container = new Container();

            //container.RegisterWebApiRequest<IRepositoryAsync<Category>, Repository<Category>>();
            //container.RegisterWebApiRequest<ICategoryService, CategoryService>();
            //container.RegisterWebApiRequest<IDataContextAsync>(() => new MyContext());
            //container.Verify();


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
