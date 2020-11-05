using LiteDB;

namespace AVDharma.LeilaoOnline.WebApp.Dados.LiteDB
{
    public interface ILiteDbContext
    {
        LiteDatabase Database { get; }
    }
}
