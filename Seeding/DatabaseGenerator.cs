using System;
using System.Linq;
using AVDharma.LeilaoOnline.WebApp.Models;
using LiteDB;

namespace AVDharma.LeilaoOnline.WebApp.Seeding
{
    public static class DatabaseGenerator
    {
        public static void Seed()
        {
            using (var ctx = new LiteDatabase("Dados/AVDharmaLeilao.db"))
            {
                if (!ctx.CollectionExists("categorias"))
                {
                    var categorias = ctx.GetCollection<Categoria>("categorias");
                    var leiloes = ctx.GetCollection<Leilao>("leiloes");
                    var generator = new LeilaoRandomGenerator(new Random());
                    for (var i = 1; i <= 200; i++)
                    {
                        var novoLeilao = generator.NovoLeilao;
                        leiloes.Insert(novoLeilao);
                        var existe = categorias.Find(x => x.Id == novoLeilao.IdCategoria)
                            .FirstOrDefault();
                        if (existe == null)
                        {
                            categorias.Insert(novoLeilao.Categoria);
                        }
                    }
                }
            }
        }
    }
}