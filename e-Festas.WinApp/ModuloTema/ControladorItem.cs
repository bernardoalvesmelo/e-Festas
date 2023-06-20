using e_Festas.Dominio.ModuloAluguel;
using e_Festas.Dominio.ModuloTema;

namespace e_Festas.WinApp.ModuloTema
{
    public class ControladorItem : ControladorBase
    {
        private TabelaItemTemaControl tabelaItem;
        protected List<ItemTema> listaregistros;
        private IRepositorioItem repositorioItem;
        private IRepositorioTema repositorioTema;

        public ControladorItem(IRepositorioItem repositorioItem,IRepositorioTema repositorioTema)
        {                    
            this.repositorioItem = repositorioItem;
            this.repositorioTema = repositorioTema;
        }

        public override string ToolTipInserir => "Inserir novo Item";

        public override string ToolTipEditar => "Editar Item Existente";

        public override string ToolTipExcluir => "Excluir Item Existente";

        public override void Inserir()
        {
            TelaCadastroItemForm telaCadastroItem = new TelaCadastroItemForm(repositorioItem.SelecionarTodos());

            DialogResult opcaoEscolhida = telaCadastroItem.ShowDialog();

            if (opcaoEscolhida == DialogResult.OK)
            {
                ItemTema item = telaCadastroItem.ObterItem();
               
                repositorioItem.Inserir(item);

                CarregarItens();
            }
        }

        public override void Editar()
        {
            ItemTema itemSelecionado = ObterItemSelecionado();

            if (itemSelecionado == null)
            {
                MessageBox.Show("Selecione um Item primeiro", "Edição de Itens", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

            TelaCadastroItemForm item = new TelaCadastroItemForm(repositorioItem.SelecionarTodos());

            item.ConfigurarTela(itemSelecionado);

            DialogResult opcaoEscolhida = item.ShowDialog();

            if (opcaoEscolhida == DialogResult.OK)
            {            
                ItemTema itemTema = item.ObterItem();

                repositorioItem.Editar(itemTema.id, itemTema);

                CarregarItens();
            }
        }

        private ItemTema ObterItemSelecionado()
        {
            int id = tabelaItem.ObterIdSelecionado();

            return repositorioItem.SelecionarPorId(id);
        }

        public override void Excluir()
        {
            ItemTema itemTema = ObterItemSelecionado();

            if (itemTema == null)
            {
                MessageBox.Show("Selecione um Item Primeiro!", "Exclusão de Itens",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            if (repositorioTema.SelecionarTodos().Find(t => t.id == itemTema.id) != null)
            {
                MessageBox.Show("O Item não pode ser Excluído pois esta em um Tema", "Exclusão de Itens",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            DialogResult opcaoEscolhida = MessageBox.Show("Deseja excluir o Item" + itemTema.nome, "Excluir Itens",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (opcaoEscolhida == DialogResult.OK)
            {
                repositorioItem.Excluir(itemTema);

                CarregarItens();
            }
        }
    
        public override UserControl ObterListagem()
        {
            if (tabelaItem == null)
            {
                tabelaItem = new TabelaItemTemaControl();
            }

            CarregarItens();

            return tabelaItem;
        }

        private void CarregarItens()
        {
            List<ItemTema> itens = repositorioItem.SelecionarTodos();

            tabelaItem.AtualizarRegistros(itens);

            TelaPrincipalForm.Instancia.AtualizarRodape("Visualizando" + " " + itens.Count + " " + "Itens");
        }

        public override string ObterTipoCadastro()
        {
            return "Cadastro de Itens";
        }
    }
}
