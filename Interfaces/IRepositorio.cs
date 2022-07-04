using System.Collections.Generic;
namespace AppCadSerie.Interfaces
{
    public interface IRepositorio<T>
    {
        List<T> lista();
        T RetornaPorId(int id);
        void insere(T entidade);
        void Exclui(int id);
        void Atualiza(int id, T entidade);
        int ProximoId();
    }
}