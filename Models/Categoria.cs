using LiteDB;
using System.Collections.Generic;

namespace AVDharma.LeilaoOnline.WebApp.Models
{
    public class Categoria
    {
        private static int id_Counter = 0;
        public Categoria()
        {
            Leiloes = new List<Leilao>();
            this.Id = System.Threading.Interlocked.Increment(ref id_Counter);
        }
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }
        public IList<Leilao> Leiloes { get; set; }
    }

    public class CategoriaComInfoLeilao : Categoria
    {
        public int EmRascunho { get; set; }
        public int EmPregao { get; set; }
        public int Finalizados { get; set; }
    }
}