using System.Collections.Generic;

namespace CRUDSeries.Interface
{
    public interface IRepositorio<T>
    {
         List<T> Lista();
         T RetornaId(int id);
         void Insere(T entidade);
         void Exclui(int id);
         void Atualiza(int id, T entidade);
         int ProximoId();
    }
}