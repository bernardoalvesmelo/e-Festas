using e_Festas.Dominio.ModuloAluguel;

namespace e_Festas.Infra.Dados.Arquivo.ModuloAluguel
{
    public class RepositorioAluguelEmArquivo : RepositorioEmArquivoBase<Aluguel>, IRepositorioAluguel
    {
        public RepositorioAluguelEmArquivo(ContextoDados contexto) : base(contexto)
        {
            
        }

        public override void Inserir(Aluguel novoAluguel)
        {         
            base.Inserir(novoAluguel);
            novoAluguel.cliente.alugueis.Add(novoAluguel);
        }
        public override void Editar(int id, Aluguel Aluguel)
        {
            Aluguel aluguelAnterior = SelecionarPorId(id);

            aluguelAnterior.cliente.alugueis = 
                aluguelAnterior.cliente.alugueis.FindAll(a => a.id != id);

            base.Editar(id, Aluguel);
            aluguelAnterior.cliente.alugueis.Add(aluguelAnterior);
        }
        public override void Excluir(Aluguel aluguelSelecionado)
        {
            int id = aluguelSelecionado.id;

            Aluguel aluguelAnterior = SelecionarPorId(id);

            aluguelAnterior.cliente.alugueis =
                aluguelAnterior.cliente.alugueis.FindAll(a => a.id != id);

            base.Excluir(aluguelSelecionado);
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
