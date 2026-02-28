using Xunit;
using FluentAssertions;
using ControleTarefas.Model.Builders;
using ControleTarefas.Model.Enumerators;

namespace ControleTarefas.Model.Tests.Tarefas;

public class CriarTarefasTests
{
    [Fact]
    public void Nao_Deve_Criar_Tarefa_Quando_Titulo_For_Nulo()
    {
        // Arrange
        var builder = new TarefaBuilder()
            .ComTitulo(null!)
            .ComDescricao("Descrição válida")
            .ComPrioridade(PrioridadeTarefaEnum.Alta);

        // Act
        Action act = () => builder.Build();

        // Assert
        act.Should()
           .Throw<ArgumentException>()
           .WithMessage("O título é obrigatório.");
    }
}