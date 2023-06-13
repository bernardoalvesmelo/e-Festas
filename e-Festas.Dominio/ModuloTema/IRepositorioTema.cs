namespace e_Festas.Dominio.ModuloTema
{
    public interface IRepositorioTema
    {
        void Inserir(Temas novoTema);
        void Editar(int id, Temas tema);
        void Excluir(Temas temaSelecionado);
        List<Temas> SelecionarTodos();
        Temas SelecionarPorId(int id);
    }
}
