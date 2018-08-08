# ContentRecommendationBlock
Example block for displaying recommended content on a page.

## Create NuGet package
run __build\buildNugetPackage.bat__ to create NuGet package

## Installation
Add the following route config
```
            System.Web.Http.GlobalConfiguration.Configure(config =>
            {
                config.MapHttpAttributeRoutes();
                config.Routes.MapHttpRoute(name: "DefaultApi", routeTemplate: "api/{controller}/{action}", defaults: new { id = RouteParameter.Optional });
            });
```