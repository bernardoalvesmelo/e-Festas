using e_Festas.Dominio.ModuloAluguel;

namespace e_Festas.Infra.Dados.Arquivo.ModuloAluguel
{
    public class RepositorioAluguelEmArquivo : RepositorioEmArquivoBase<Aluguel>, IRepositorioAluguel
    {
        public RepositorioAluguelEmArquivo(ContextoDados contexto) : base(contexto)
        {
            
        }

        public List<Aluguel> SelecionarTodosEmAberto()
        {
            return contextoDados.alugueis.FindAll(a => a.dataQuitacao == new DateTime());
        }

        public List<Aluguel> SelecionarTodosPorEndereco(Aluguel aluguel)
        {
            return contextoDados.alugueis.FindAll(a => a.endereco.Equals(aluguel.endereco));
        }

        protected override List<Aluguel> ObterRegistros()
        {
            return contextoDados.alugueis;
        }
    }
}
