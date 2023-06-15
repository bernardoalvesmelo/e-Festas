using e_Festas.Dominio.ModuloTema;

namespace e_Festas.Infra.Dados.Arquivo.ModuloTema
{
    public class RepositorioItemEmArquivo : RepositorioEmArquivoBase<ItemTema>, IRepositorioItem
    {
        public RepositorioItemEmArquivo(ContextoDados contexto) : base(contexto)
        {

        }

        protected override List<ItemTema> ObterRegistros()
        {
            return contextoDados.itemTemas;
        }
    }
}
