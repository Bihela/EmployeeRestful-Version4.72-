﻿using System.Web.Mvc;
using System.Web.Routing;

namespace Dotnet4Swagger
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "Employees", action = "GetEmployees", id = UrlParameter.Optional }
			);
		}
	}
}
