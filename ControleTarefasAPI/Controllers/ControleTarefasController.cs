using ControleTarefas.Model.Dtos;
using ControleTarefas.Model.Services;
using Microsoft.AspNetCore.Mvc;

namespace ControleTarefas.API.Controllers;

[ApiController]
[Route("tarefas")]
public class ControleTarefasController : ControllerBase
{
    private readonly IControleTarefasService _service;

    public ControleTarefasController(IControleTarefasService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TarefaResponseDto>>> ListarTarefas()
    {
        var tarefas = await _service.ListarTarefasAsync();
        return Ok(tarefas);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TarefaResponseDto>> ListarTarefaPorId(int id)
    {
        var tarefa = await _service.ListarTarefasPorIdAsync(id);

        if (tarefa == null)
            return NotFound();

        return Ok(tarefa);
    }

    [HttpPost]
    public async Task<ActionResult<TarefaResponseDto>> CriarTarefa([FromBody] TarefaDto dto)
    {
        var tarefaCriada = await _service.CriarTarefaAsync(dto);
        return StatusCode(201, tarefaCriada);
    }

    [HttpPut]
    public async Task<ActionResult<TarefaResponseDto>> AlterarTarefa([FromBody] TarefaDto dto)
    {
        var tarefaAtualizada = await _service.AlterarTarefaAsync(dto);

        if (tarefaAtualizada == null)
            return NotFound();

        return Ok(tarefaAtualizada);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> ExcluirTarefa(int id)
    {
        await _service.ExcluirTarefa(id);
        return NoContent();
    }
}