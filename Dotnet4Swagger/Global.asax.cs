using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using EmployeeManagment.Api.Models;
using System.Data.Entity;
using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;

namespace Dotnet4Swagger
{
	public class WebApiApplication : HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			GlobalConfiguration.Configure(WebApiConfig.Register);

			// Register routes defined in RouteConfig.cs
			RouteConfig.RegisterRoutes(RouteTable.Routes);

			// Add your DbContext configuration here
			Database.SetInitializer(new CreateDatabaseIfNotExists<AppDbContext>());

			var builder = new ContainerBuilder();

			// Register your repository
			builder.RegisterType<EmployeeRepository>().As<IEmployeeRepository>().InstancePerLifetimeScope();

			// Register your DbContext
			builder.RegisterType<AppDbContext>().InstancePerLifetimeScope();

			// Register your controllers
			builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

			var container = builder.Build();

			GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
		}
	}
}
