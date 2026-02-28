using ControleTarefas.Model.Enumerators;

namespace ControleTarefas.Model.Entities
{
    public class Tarefa
    {
        private Tarefa() { }

        public int Id { get; private set; }
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public PrioridadeTarefaEnum Prioridade { get; private set; }
        public StatusTarefaEnum Status { get; private set; }
        public DateTime DataCriacao { get; private set; }

        internal Tarefa(
            string titulo,
            string descricao,
            PrioridadeTarefaEnum prioridade,
            StatusTarefaEnum status)
        {
            Titulo = titulo;
            Descricao = descricao;
            Prioridade = prioridade;
            Status = status;
            DataCriacao = DateTime.UtcNow;
        }

        public void Atualizar(string titulo, string descricao, PrioridadeTarefaEnum prioridade, StatusTarefaEnum status)
        {
            if (string.IsNullOrWhiteSpace(titulo))
                throw new ArgumentException("O título é obrigatório.");

            if (string.IsNullOrWhiteSpace(descricao))
                throw new ArgumentException("A descrição é obrigatória.");

            Titulo = titulo;
            Descricao = descricao;
            Prioridade = prioridade;
            Status = status;
        }
    }
}