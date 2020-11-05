using System.Collections.Generic;
using System.Linq;
using AVDharma.LeilaoOnline.WebApp.Models;
using LiteDB;

namespace AVDharma.LeilaoOnline.WebApp.Dados.LiteDB
{
    public class CategoriaDaoComLiteDB : ICategoriaDao
    {
        LiteDatabase _context;

        public CategoriaDaoComLiteDB(LiteDbContext context)
        {
            _context = context.Database;
        }

        public Categoria BuscarPorId(int id)
        {
            return _context.GetCollection<Categoria>("categorias")
                .Include(c => c.Leiloes)
                .Find(c => c.Id == id).FirstOrDefault();
        }

        public IEnumerable<Categoria> BuscarTodos()
        {
            return _context.GetCollection<Categoria>("categorias")
                .Include(l => l.Leiloes)
                .FindAll();
        }

    }
}
