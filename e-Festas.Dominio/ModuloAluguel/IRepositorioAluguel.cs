namespace e_Festas.Dominio.ModuloAluguel
{
    public interface IRepositorioAluguel
    {
        void Inserir(Aluguel novoAluguel);
        void Editar(int id, Aluguel aluguel);
        void Excluir(Aluguel aluguelSelecionado);
        List<Aluguel> SelecionarTodos();
        Aluguel SelecionarPorId(int id);
    }
}