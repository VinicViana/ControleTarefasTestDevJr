using ControleTarefas.Model.Dtos;

namespace ControleTarefas.Model.Services;
public interface IControleTarefasService
{
    Task<IEnumerable<TarefaResponseDto>> ListarTarefasAsync();
    Task<TarefaResponseDto> ListarTarefasPorIdAsync(int id);
    Task<TarefaResponseDto> AlterarTarefaAsync(TarefaDto tarefa);
    Task<TarefaResponseDto> CriarTarefaAsync(TarefaDto tarefa);
    Task ExcluirTarefa(int id);
}
