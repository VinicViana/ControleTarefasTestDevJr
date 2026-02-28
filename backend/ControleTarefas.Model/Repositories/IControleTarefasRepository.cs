using ControleTarefas.Model.Entities;

namespace ControleTarefas.Model.Repositories;
public interface IControleTarefasRepository
{
    Task<IEnumerable<Tarefa>> ListarTarefasAsync();
    Task<Tarefa> ListarTarefasPorIdAsync(int id);
    Task<Tarefa> AlterarTarefaAsync(Tarefa tarefa);
    Task<Tarefa> CriarTarefaAsync(Tarefa tarefa);
    Task ExcluirTarefaAsync(int id);
}
