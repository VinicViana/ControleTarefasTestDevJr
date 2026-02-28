using Xunit;
using FluentAssertions;
using ControleTarefas.Model.Builders;
using ControleTarefas.Model.Enumerators;

namespace ControleTarefas.Model.Tests.Tarefas;

public class AlterarTarefasTests
{
    [Fact]
    public void Nao_Deve_Alterar_Tarefa_Quando_Descricao_For_Nula()
    {
        // Arrange
        var tarefa = new TarefaBuilder()
            .ComTitulo("Título válido")
            .ComDescricao("Descrição válida")
            .ComPrioridade(PrioridadeTarefaEnum.Media)
            .Build();

        // Act
        Action act = () => tarefa.Alterar(
            "Novo título",
            null!,
            PrioridadeTarefaEnum.Alta,
            StatusTarefaEnum.EmAndamento
        );

        // Assert
        act.Should()
           .Throw<ArgumentException>()
           .WithMessage("A descrição é obrigatória.");
    }
}