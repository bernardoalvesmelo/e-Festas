using e_Festas.Dominio.ModuloTema;

namespace e_Festas.WinApp.ModuloTema
{
    public class ControladorTema : ControladorBase
    {
        private TabelaTemaControl tabelaTema;
        protected List<Temas> listaregistros;
        private IRepositorioTema repositorioTema;

        public ControladorTema(IRepositorioTema repositorioTema)
        {
            this.repositorioTema = repositorioTema;
        }

        public override string ToolTipInserir => "Inserir novo Tema";

        public override string ToolTipEditar => "Editar Tema Existente";

        public override string ToolTipExcluir => "Excluir Tema Existente";

        public override string ToolTipAdicionarItens => "Adicionar Itens";

        public override bool AdicionarItensHabilitado => true;

        public override void Inserir()
        {          
            TelaCadastroTemaForm telaCadastroTema = new TelaCadastroTemaForm();

            DialogResult opcaoEscolhida = telaCadastroTema.ShowDialog();

            if (opcaoEscolhida == DialogResult.OK)
            {              
                Temas tema = telaCadastroTema.ObterTema();

                repositorioTema.Inserir(tema);

                CarregarTemas();
            }
        }

        public override void Editar()
        {
            Temas temaSelecionado = ObterTemaSelecionado();

            if (temaSelecionado == null)
            {
                MessageBox.Show("Selecione um Tema primeiro", "Edição de Tema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

            TelaCadastroTemaForm telatema = new TelaCadastroTemaForm();

            telatema.ConfigurarTela(temaSelecionado);

            DialogResult opcaoEscolhida = telatema.ShowDialog();

            if (opcaoEscolhida == DialogResult.OK)
            {
                Temas tema = telatema.ObterTema();

                repositorioTema.Editar(tema.id,tema);

                CarregarTemas();
            }
        }

        private Temas ObterTemaSelecionado()
        {
            int id = tabelaTema.ObterIdSelecionado();

            return repositorioTema.SelecionarPorId(id);
        }

        public override void Excluir()
        {
            Temas tema = ObterTemaSelecionado();

            if (tema == null)
            {
                MessageBox.Show("Selecione um Tema Primeiro!", "Exclusão de Temas",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            DialogResult opcaoEscolhida = MessageBox.Show("Deseja excluir o Tema" + tema.nome, "Excluir Temas",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (opcaoEscolhida == DialogResult.OK)
            {
                repositorioTema.Excluir(tema);

                CarregarTemas();
            }
        }        

        public override UserControl ObterListagem()
        {
            if (tabelaTema == null)
            {
                tabelaTema = new TabelaTemaControl();
            }

            CarregarTemas();

            return tabelaTema;
        }

        private void CarregarTemas()
        {
            List<Temas> temas = repositorioTema.SelecionarTodos();

            tabelaTema.AtualizarRegistros(temas);
        }

        public override string ObterTipoCadastro()
        {
            return "Cadastro de Temas";
        }

        public override void Adicionar()
        {
            Temas temaSelecionado = ObterTemaSelecionado();

            if (temaSelecionado == null)
            {
                MessageBox.Show("Selecione uma Tema primeiro", "Adição de Itens do Tema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

            TelaCadastroItemForm telaCadastroItem = new TelaCadastroItemForm(temaSelecionado);

            DialogResult opcaoEscolhida = telaCadastroItem.ShowDialog();

            if (opcaoEscolhida == DialogResult.OK)
            {
                List<ItemTema> itensParaAdicionar = telaCadastroItem.ObterItensCadastrados();

                foreach (ItemTema item in itensParaAdicionar)
                {
                    temaSelecionado.AdicionarItem(item);
                }

                repositorioTema.Editar(temaSelecionado.id, temaSelecionado);
                CarregarTemas();
            }
        }
    }
}
