using System.Collections.Generic;

namespace AVDharma.LeilaoOnline.WebApp.Dados
{
    public interface IQuery<T>
    {
        IEnumerable<T> BuscarTodos();
        T BuscarPorId(int id);
    }
}
