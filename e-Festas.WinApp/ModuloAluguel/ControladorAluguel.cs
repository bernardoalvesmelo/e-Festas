using e_Festas.Dominio.ModuloCliente;
using e_Festas.Dominio.ModuloAluguel;
using e_Festas.Dominio.ModuloTema;

namespace e_Festas.WinApp.ModuloAluguel
{
    public class ControladorAluguel : ControladorBase
    {
        private IRepositorioAluguel repositorioAluguel;
        private IRepositorioTema repositorioTema;
        private IRepositorioCliente repositorioCliente;
        private TabelaAluguelControl tabelaAluguel;

        VisualizacaoAluguelEnum tipoVisualizacao;

        private string visualizar;

        public ControladorAluguel(
            IRepositorioAluguel repositorioAluguel, 
            IRepositorioTema repositorioTema, 
            IRepositorioCliente repositorioCliente)
        {
            this.repositorioAluguel = repositorioAluguel;
            this.repositorioCliente = repositorioCliente;
            this.repositorioTema = repositorioTema;

            this.tipoVisualizacao = VisualizacaoAluguelEnum.Alugueis;
            this.visualizar = "Visualizar Endereços";
        }

        public override string ToolTipInserir { get { return "Inserir novo Aluguel";  } }

        public override string ToolTipEditar { get { return "Editar Aluguel existente"; } }

        public override string ToolTipExcluir { get { return "Excluir Aluguel existente"; } }

        public override string ToolTipVisualizar { get { return visualizar; } }

        public override string ToolTipFiltrar { get { return "Filtrar Aluguéis"; } }

        public override string ToolTipConcluir { get { return "Concluir Aluguel Existente"; } }

        public override string ToolTipConfigurar { get { return "Configurar Aluguéis"; } }

        public override bool FiltrarHabilitado { get { return true; } }

        public override bool VisualizarHabilitado { get { return true; } }

        public override bool ConcluirHabilitado { get { return true; } }

        public override bool ConfigurarHabilitado { get { return true; } }

        public override void Inserir()
        {
            List<Cliente> clientes = repositorioCliente.SelecionarTodos();
                  
            if (clientes.Count == 0)
            {
                MessageBox.Show($"Cadastre um cliente primeiro!",
                    "Criação de Aluguéis",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }

            List<Tema> temas = repositorioTema.SelecionarTodos();

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

            telaAluguel.CarregarConfiguracao();
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

            if (aluguel.dataQuitacao != new DateTime())
            {
                MessageBox.Show($"Não pode editar um aluguel concluído!",
                    "Edição de Aluguéis",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }

            List<Cliente> clientes = repositorioCliente.SelecionarTodos();
           

            if (clientes.Count == 0)
            {
                MessageBox.Show($"Cadastre um cliente primeiro!",
                    "Edição de Aluguéis",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }

            List<Tema> temas = repositorioTema.SelecionarTodos();

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

        public override void Concluir()
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

            if (aluguel.dataQuitacao != new DateTime())
            {
                MessageBox.Show($"Não pode concluir um aluguel concluído!",
                    "Edição de Aluguéis",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }

            DialogResult opcaoEscolhida = MessageBox.Show($"Deseja fechar o aluguel {aluguel.id}?", "Conclusão de Aluguéis",
               MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (opcaoEscolhida != DialogResult.OK)
                return;


            TelaConcluirAluguelForm telaConcluir = new TelaConcluirAluguelForm();

            opcaoEscolhida = telaConcluir.ShowDialog();

            if (opcaoEscolhida == DialogResult.OK)
            {
                Aluguel aluguelAtualizado = telaConcluir.ObterAluguel();
                repositorioAluguel.Editar(aluguelAtualizado.id, aluguelAtualizado);
            }
            CarregarAlugueis();
        }

        public override void Configurar()
        {
            TelaConfigurarAluguelForm telaConfigurar = new TelaConfigurarAluguelForm();

            telaConfigurar.ShowDialog();
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

            if (aluguel.dataQuitacao == new DateTime())
            {
                MessageBox.Show($"Não pode excluir um aluguel em aberto!",
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
            if (this.tipoVisualizacao == VisualizacaoAluguelEnum.Alugueis)
            {
                tipoVisualizacao = VisualizacaoAluguelEnum.Enderecos;
                this.visualizar = "Visualizar Aluguéis";
            }

            else if (this.tipoVisualizacao == VisualizacaoAluguelEnum.Enderecos)
            {
                tipoVisualizacao = VisualizacaoAluguelEnum.Alugueis;
                this.visualizar = "Visualizar Endereços";
            }

            tabelaAluguel.ConfigurarVisualizacao(this.tipoVisualizacao);
            CarregarAlugueis();
        }

        public override void Filtrar()
        {
            Aluguel aluguel = ObterAluguelSelecionado();

            List<Aluguel> alugueis = repositorioAluguel.SelecionarTodos();

            TelaFiltroAluguelForm telaFiltro = new TelaFiltroAluguelForm();
            DialogResult opcaoEscolhida = telaFiltro.ShowDialog();

            if (opcaoEscolhida == DialogResult.OK)
            {
                switch(telaFiltro.ObterFiltro())
                {
                    case FiltroAluguelEnum.Aluguel:
                        alugueis = repositorioAluguel.SelecionarTodos();
                        break;
                    case FiltroAluguelEnum.Aberto:
                        alugueis = repositorioAluguel.SelecionarTodosEmAberto();
                        break;
                    case FiltroAluguelEnum.Endereco:
                        if(aluguel == null)
                        {
                            alugueis = new List<Aluguel>();
                            break;
                        }
                        alugueis = repositorioAluguel.SelecionarTodosPorEndereco(aluguel);
                        break;
                }
            }
            CarregarAlugueis(alugueis);
        }

        private void CarregarAlugueis()
        {
            List<Aluguel> alugueis = repositorioAluguel.SelecionarTodos();

            tabelaAluguel.AtualizarRegistros(alugueis);

            string mensagem = $"Visualizando {alugueis.Count} " + (alugueis.Count == 1 ?
                "aluguel" : "aluguéis");
            TelaPrincipalForm.Instancia.AtualizarRodape(mensagem);
        }

        private void CarregarAlugueis(List<Aluguel> alugueis)
        { 
            tabelaAluguel.AtualizarRegistros(alugueis);

            string mensagem = $"Visualizando {alugueis.Count} " + (alugueis.Count == 1 ?
                "aluguel" : "aluguéis");
            TelaPrincipalForm.Instancia.AtualizarRodape(mensagem);
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
