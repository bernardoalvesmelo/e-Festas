namespace e_Festas.Dominio.ModuloTema
{
    public interface IRepositorioTema
    {
        void Inserir(Tema novoTema);
        void Editar(int id, Tema tema);
        void Excluir(Tema temaSelecionado);
        List<Tema> SelecionarTodos();
        Tema SelecionarPorId(int id);
    }
}
