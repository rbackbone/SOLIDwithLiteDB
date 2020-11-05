using AVDharma.LeilaoOnline.WebApp.Models;

namespace AVDharma.LeilaoOnline.WebApp.Dados
{
    public interface ILeilaoDao : ICommand<Leilao>, IQuery<Leilao>
    {
    }
}
