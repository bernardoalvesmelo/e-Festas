namespace e_Festas.Dominio.ModuloTema
{
    public interface IRepositorioItem
    {
        void Inserir(ItemTema novoItem);
        void Editar(int id, ItemTema item);
        void Excluir(ItemTema itemSelecionado);
        List<ItemTema> SelecionarTodos();
        ItemTema SelecionarPorId(int id);
    }
}
