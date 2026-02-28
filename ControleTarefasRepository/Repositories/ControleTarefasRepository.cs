using Microsoft.EntityFrameworkCore;
using ControleTarefas.Model.Entities;
using ControleTarefas.Model.Repositories;
using ControleTarefas.Data;

namespace ControleTarefas.Repository.Repositories
{
    public class ControleTarefasRepository : IControleTarefasRepository
    {
        private readonly AppDbContext _context;

        public ControleTarefasRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tarefa>> ListarTarefasAsync()
        {
            return await _context.Tarefas
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Tarefa> ListarTarefasPorIdAsync(int id)
        {
            return await _context.Tarefas
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<Tarefa> CriarTarefaAsync(Tarefa tarefa)
        {
            await _context.Tarefas.AddAsync(tarefa);
            await _context.SaveChangesAsync();
            return tarefa;
        }

        public async Task<Tarefa> AlterarTarefaAsync(Tarefa tarefa)
        {
            await _context.SaveChangesAsync();

            return tarefa;
        }

        public async Task ExcluirTarefaAsync(int id)
        {
            var tarefa = await _context.Tarefas.FindAsync(id);

            if (tarefa == null)
                throw new Exception("Tarefa não encontrada");

            _context.Tarefas.Remove(tarefa);
            await _context.SaveChangesAsync();
        }
    }
}