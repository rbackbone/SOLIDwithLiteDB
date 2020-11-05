using System.Collections.Generic;
using System.Linq;
using AVDharma.LeilaoOnline.WebApp.Models;
using LiteDB;

namespace AVDharma.LeilaoOnline.WebApp.Dados.LiteDB
{
    public class LeilaoDaoComLiteDB : ILeilaoDao
    {
        LiteDatabase _context;

        public LeilaoDaoComLiteDB(LiteDbContext context)
        {
            _context = context.Database;
        }

        public Leilao BuscarPorId(int id)
        {
            return _context.GetCollection<Leilao>("leiloes")
                .Find(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Leilao> BuscarTodos()
        {     
            return _context
            .GetCollection<Leilao>("leiloes")
            .Include(l => l.Categoria)
            .FindAll();
        }
        public void Incluir(Leilao obj)
        {
            _context.GetCollection<Leilao>("leiloes")
                .Insert(obj);
        }

        public void Alterar(Leilao obj)
        {
            _context.GetCollection<Leilao>("leiloes")
                .Update(obj);
        }

        public void Excluir(Leilao leilao)
        {
            _context.GetCollection<Leilao>("leiloes")
                .Delete(leilao.Id);
        }
    }
}
