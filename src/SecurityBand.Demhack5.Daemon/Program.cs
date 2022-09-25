using SecurityBand.DemHack5.Daemon;

const string defaultCliRoute = "cli";
const string defaultEventRoute = "evt";
const string stopPhrase = "stop";

var controllerName = nameof(AppController).Replace("Controller", "");

var builder = WebApplication.CreateBuilder(args);
var routes = new RoutesConfig();

builder.Services.AddMvcCore();

builder.Configuration
    .GetSection(nameof(RoutesConfig))
    .Bind(routes);

var app = builder.Build();

app.MapControllerRoute(
    nameof(RoutesConfig.Cli),
    routes.Cli ?? defaultCliRoute,
    new {controller = controllerName, action = nameof(AppController.InstallCli)});

app.MapControllerRoute(
    nameof(RoutesConfig.Event),
    routes.Cli ?? defaultEventRoute,
    new {controller = controllerName, action = nameof(AppController.RegisterEvent)});

app.Run();