using ControleTarefas.Model.Entities;

namespace ControleTarefas.Model.Dtos;
public class TarefaResponseDto
{
    public int Id { get; private set; }
    public string Titulo { get; private set; }
    public string Descricao { get; private set; }
    public int Prioridade { get; private set; }
    public int Status { get; private set; }
    public DateTime DataCriacao { get; private set; }

    public TarefaResponseDto(Tarefa tarefa)
    {
        Id = tarefa.Id;
        Titulo = tarefa.Titulo;
        Descricao = tarefa.Descricao;
        Prioridade = (int)tarefa.Prioridade;
        Status = (int)tarefa.Status;
        DataCriacao = tarefa.DataCriacao;
    }
}