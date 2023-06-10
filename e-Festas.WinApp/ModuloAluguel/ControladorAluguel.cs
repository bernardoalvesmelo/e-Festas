using e_Festas.Dominio.ModuloAluguel;

namespace e_Festas.WinApp.ModuloAluguel
{
    public class ControladorAluguel : ControladorBase
    {
        private IRepositorioAluguel repositorioAluguel;
        private TabelaAluguelControl tabelaAluguel;

        public ControladorAluguel(IRepositorioAluguel repositorioAluguel)
        {
            this.repositorioAluguel = repositorioAluguel;
        }

        public override string ToolTipInserir { get { return "Inserir novo Aluguel";  } }

        public override string ToolTipEditar { get { return "Editar Aluguel existente"; } }

        public override string ToolTipExcluir { get { return "Excluir Aluguel existente"; } }

        public override string ToolTipVisualizar { get { return "Visualizar Endereços"; } }

        public override bool VisualizarHabilitado { get { return true; } }

        public override void Inserir()
        {
            List<Cliente> clientes = new List<Cliente>
            {
                Cliente.Instancia
            };

            if (clientes.Count == 0)
            {
                MessageBox.Show($"Cadastre um cliente primeiro!",
                    "Criação de Aluguéis",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }

            List<Tema> temas = new List<Tema>
            {
                Tema.Instancia
            };

            if (temas.Count == 0)
            {
                MessageBox.Show($"Cadastre um tema primeiro!",
                    "Criação de Aluguéis",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }

            TelaAluguelForm telaAluguel = new TelaAluguelForm(
                repositorioAluguel.SelecionarTodos(),
                clientes,
                temas);

            DialogResult opcaoEscolhida = telaAluguel.ShowDialog();

            if (opcaoEscolhida == DialogResult.OK)
            {
                Aluguel aluguel = telaAluguel.ObterAluguel();

                repositorioAluguel.Inserir(aluguel);                
            }
            CarregarAlugueis();
        }

        public override void Editar()
        {
            Aluguel aluguel = ObterAluguelSelecionado();

            if (aluguel == null)
            {
                MessageBox.Show($"Selecione um aluguel primeiro!", 
                    "Edição de Aluguéis",
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Exclamation);

                return;
            }

            List<Cliente> clientes = new List<Cliente>
            {
                Cliente.Instancia
            };

            if (clientes.Count == 0)
            {
                MessageBox.Show($"Cadastre um cliente primeiro!",
                    "Edição de Aluguéis",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }

            List<Tema> temas = new List<Tema>
            {
                Tema.Instancia
            };

            if (temas.Count == 0)
            {
                MessageBox.Show($"Cadastre um tema primeiro!",
                    "Edição de Aluguéis",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }

            TelaAluguelForm telaAluguel = new TelaAluguelForm(
                repositorioAluguel.SelecionarTodos(),
                clientes,
                temas);

            telaAluguel.ConfigurarTela(aluguel);

            DialogResult opcaoEscolhida = telaAluguel.ShowDialog();

            if (opcaoEscolhida == DialogResult.OK)
            {
                Aluguel aluguelAtualizado = telaAluguel.ObterAluguel();
                repositorioAluguel.Editar(aluguelAtualizado.id, aluguelAtualizado);                
            }
            CarregarAlugueis();
        }

        private Aluguel ObterAluguelSelecionado()
        {
            int id = tabelaAluguel.ObterIdSelecionado();

            return repositorioAluguel.SelecionarPorId(id);
        }

        public override void Excluir()
        {            
            Aluguel aluguel = ObterAluguelSelecionado();

            if (aluguel == null)
            {
                MessageBox.Show($"Selecione um aluguel primeiro!", 
                    "Exclusão de Aluguéis",
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Exclamation);

                return;
            }

            DialogResult opcaoEscolhida = MessageBox.Show($"Deseja excluir o aluguel {aluguel.id}?", "Exclusão de Aluguéis",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (opcaoEscolhida == DialogResult.OK)
            {
                repositorioAluguel.Excluir(aluguel);                
            }
            CarregarAlugueis();
        }

        public override void Visualizar()
        {
            List<Aluguel> alugueis = repositorioAluguel.SelecionarTodos();

            TelaVisualizarAluguelForm telaVisualizar = new TelaVisualizarAluguelForm();
            telaVisualizar.AtualizarRegistros(alugueis);
            telaVisualizar.ShowDialog();
        }

        private void CarregarAlugueis()
        {
            List<Aluguel> alugueis = repositorioAluguel.SelecionarTodos();

            tabelaAluguel.AtualizarRegistros(alugueis); 
        }

        public override UserControl ObterListagem()
        {
            if (tabelaAluguel == null)
                tabelaAluguel = new TabelaAluguelControl();

            CarregarAlugueis();

            return tabelaAluguel;
        }

        public override string ObterTipoCadastro()
        {
            return "Cadastro de Aluguéis";            
        }        
    }
}
