using ControleTarefas.Model.Entities;
using ControleTarefas.Model.Enumerators;

namespace ControleTarefas.Model.Builders
{
    public class TarefaBuilder
    {
        private string _titulo;
        private string _descricao;
        private PrioridadeTarefaEnum _prioridade;
        private StatusTarefaEnum _status = StatusTarefaEnum.Pendente;

        public TarefaBuilder ComTitulo(string titulo)
        {
            _titulo = titulo;
            return this;
        }

        public TarefaBuilder ComDescricao(string descricao)
        {
            _descricao = descricao;
            return this;
        }

        public TarefaBuilder ComPrioridade(PrioridadeTarefaEnum prioridade)
        {
            _prioridade = prioridade;
            return this;
        }

        public TarefaBuilder ComStatus(StatusTarefaEnum status)
        {
            _status = status;
            return this;
        }

        public Tarefa Build()
        {
            if (string.IsNullOrWhiteSpace(_titulo))
                throw new ArgumentException("O título é obrigatório.");

            return new Tarefa(
                _titulo,
                _descricao,
                _prioridade,
                _status
            );
        }
    }
}