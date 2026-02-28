using ControleTarefas.Model.Builders;
using ControleTarefas.Model.Dtos;
using ControleTarefas.Model.Enumerators;
using ControleTarefas.Model.Repositories;
using ControleTarefas.Model.Services;

namespace ControleTarefas.Application.Services;
public class ControleTarefasService : IControleTarefasService
{
    private readonly IControleTarefasRepository _repository;

    public ControleTarefasService(IControleTarefasRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<TarefaResponseDto>> ListarTarefasAsync()
    {
        var tarefas = await _repository.ListarTarefasAsync();

        return tarefas.Select(t => new TarefaResponseDto(t)
        );
    }

    public async Task<TarefaResponseDto> ListarTarefasPorIdAsync(int id)
    {
        var tarefa = await _repository.ListarTarefasPorIdAsync(id);

        if (tarefa == null)
            throw new Exception("Tarefa não encontrada");

        return new TarefaResponseDto(tarefa);
    }

    public async Task<TarefaResponseDto> CriarTarefaAsync(TarefaDto tarefaDto)
    {
        var tarefa = new TarefaBuilder()
            .ComTitulo(tarefaDto.Titulo)
            .ComDescricao(tarefaDto.Descricao)
            .ComPrioridade((PrioridadeTarefaEnum)tarefaDto.Prioridade)
            .ComStatus((StatusTarefaEnum)tarefaDto.Status)
            .Build();

        var tarefaCriada = await _repository.CriarTarefaAsync(tarefa);

        return new TarefaResponseDto(tarefaCriada);
    }

    public async Task<TarefaResponseDto> AlterarTarefaAsync(TarefaDto tarefaDto)
    {
        var tarefaExistente = await _repository.ListarTarefasPorIdAsync(tarefaDto.Id);

        if (tarefaExistente == null)
            throw new Exception("Tarefa não encontrada");

        tarefaExistente.Atualizar(
            tarefaDto.Titulo,
            tarefaDto.Descricao,
            (PrioridadeTarefaEnum)tarefaDto.Prioridade,
            (StatusTarefaEnum)tarefaDto.Status
        );

        var tarefaAtualizada = await _repository.AlterarTarefaAsync(tarefaExistente);

        return new TarefaResponseDto(tarefaAtualizada);
    }

    public async Task ExcluirTarefa(int id)
    {
        await _repository.ExcluirTarefaAsync(id);
    }
}