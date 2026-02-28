using ControleTarefas.Model.Entities;

namespace ControleTarefas.Model.Dtos;
public class TarefaResponseDto
{
    public int Id { get; private set; }
    public string Titulo { get; private set; }
    public string Descricao { get; private set; }
    public string Prioridade { get; private set; }
    public string Status { get; private set; }
    public DateTime DataCriacao { get; private set; }

    public TarefaResponseDto(Tarefa tarefa)
    {
        Id = tarefa.Id;
        Titulo = tarefa.Titulo;
        Descricao = tarefa.Descricao;
        Prioridade = tarefa.Prioridade.ToString();
        Status = tarefa.Status.ToString();
        DataCriacao = tarefa.DataCriacao;
    }
}