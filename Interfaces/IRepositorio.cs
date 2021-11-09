namespace dio.series.Interfaces
{
    public interface IRepositorio
    {
         List<T> Lista();
         T RetornaPorId();
         void Insere(T entidade);
         void Excluir(int ind);

         void Atualizar(int ind, T entidade);
         int ProximoId();


    }
}