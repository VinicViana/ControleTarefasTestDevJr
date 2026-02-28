using ControleTarefas.Application.Services;
using ControleTarefas.Model.Repositories;
using ControleTarefas.Model.Services;
using ControleTarefas.Repository.Repositories;

namespace ControleTarefas.API.Setup;
public static class DependencyInjectionConfiguration
{
    public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
    {
        services.AddScoped<IControleTarefasService, ControleTarefasService>();
        services.AddScoped<IControleTarefasRepository, ControleTarefasRepository>();
    }
}
