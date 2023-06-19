using e_Festas.Dominio.ModuloTema;

namespace e_Festas.WinApp.ModuloTema
{
    public class ControladorTema : ControladorBase
    {
        private TabelaTemaControl tabelaTema;
        protected List<Tema> listaregistros;
        private IRepositorioTema repositorioTema;
        private IRepositorioItem repositorioItem;   
        
        public ControladorTema(IRepositorioTema repositorioTema, IRepositorioItem repositorio)
        {
            this.repositorioTema = repositorioTema;
            this.repositorioItem = repositorio;
        }

        public override string ToolTipInserir => "Inserir novo Tema";

        public override string ToolTipEditar => "Editar Tema Existente";

        public override string ToolTipExcluir => "Excluir Tema Existente";

        public override void Inserir()
        {                              
            TelaCadastroTemaForm telaCadastroTema = new TelaCadastroTemaForm(repositorioItem);

            DialogResult opcaoEscolhida = telaCadastroTema.ShowDialog();
         
            if (opcaoEscolhida == DialogResult.OK)
            {              
                Tema tema = telaCadastroTema.ObterTema();
                tema.CalcularValorTotal();
               
                repositorioTema.Inserir(tema);

                CarregarTemas();
            }
        }

        public override void Editar()
        {           
            Tema temaSelecionado = ObterTemaSelecionado();

            if (temaSelecionado == null)
            {
                MessageBox.Show("Selecione um Tema primeiro", "Edição de Tema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

            TelaCadastroTemaForm telatema = new TelaCadastroTemaForm(temaSelecionado, repositorioItem);

            telatema.ConfigurarTela(temaSelecionado);

            DialogResult opcaoEscolhida = telatema.ShowDialog();

            if (opcaoEscolhida == DialogResult.OK)
            {
                Tema tema = telatema.ObterTema();

                repositorioTema.Editar(tema.id,tema);

                CarregarTemas();
            }
        }

        private Tema ObterTemaSelecionado()
        {
            int id = tabelaTema.ObterIdSelecionado();

            return repositorioTema.SelecionarPorId(id);
        }

        public override void Excluir()
        {
            Tema tema = ObterTemaSelecionado();

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
            List<Tema> temas = repositorioTema.SelecionarTodos();

            tabelaTema.AtualizarRegistros(temas);

            TelaPrincipalForm.Instancia.AtualizarRodape("Visualizando"+ " " + temas.Count + " " + "Temas");
        }

        public override string ObterTipoCadastro()
        {
            return "Cadastro de Temas";
        }

        public override void Adicionar()
        {
            Tema temaSelecionado = ObterTemaSelecionado();

            if (temaSelecionado == null)
            {
                MessageBox.Show("Selecione uma Tema primeiro", "Adição de Itens do Tema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

            TelaAdicionarItemForm telaCadastroItem = new TelaAdicionarItemForm(temaSelecionado);

            DialogResult opcaoEscolhida = telaCadastroItem.ShowDialog();

            if (opcaoEscolhida == DialogResult.OK)
            {
                List<ItemTema> itensParaAdicionar = telaCadastroItem.ObterItensCadastrados();

                temaSelecionado.itemTemas = new List<ItemTema>();

                foreach (ItemTema item in itensParaAdicionar)
                {
                    temaSelecionado.AdicionarItem(item);
                }

                temaSelecionado.CalcularValorTotal();

                repositorioTema.Editar(temaSelecionado.id, temaSelecionado);
                CarregarTemas();           
            }

           
        }     
    }
}
