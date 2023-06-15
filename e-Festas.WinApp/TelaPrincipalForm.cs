using e_Festas.Dominio.ModuloAluguel;
using e_Festas.Dominio.ModuloTema;
using e_Festas.Dominio.ModuloCliente;

using e_Festas.Infra.Dados.Arquivo.Compartilhado;
using e_Festas.Infra.Dados.Arquivo.ModuloAluguel;
using e_Festas.Infra.Dados.Arquivo.ModuloCliente;
using e_Festas.Infra.Dados.Arquivo.ModuloTema;

using e_Festas.WinApp.ModuloAluguel;
using e_Festas.WinApp.ModuloTema;
using e_Festas.WinApp.ModuloCliente;

namespace e_Festas.WinApp
{
    public partial class TelaPrincipalForm : Form
    {
        private ControladorBase controlador;

        static ContextoDados contextoDados = new ContextoDados(carregarDados: true);


        private IRepositorioAluguel repositorioAluguel = new RepositorioAluguelEmArquivo(contextoDados);
        private IRepositorioTema repositorioTema = new RepositorioTemaEmArquivo(contextoDados);
        private IRepositorioCliente repositorioCliente = new RepositorioClienteEmArquivo(contextoDados);
        private IRepositorioItem repositorioItem = new RepositorioItemEmArquivo(contextoDados);

        private static TelaPrincipalForm telaPrincipal;

        public TelaPrincipalForm()
        {
            InitializeComponent();

            telaPrincipal = this;
        }

        public void AtualizarRodape(string mensagem)
        {
            labelRodape.Text = mensagem;
        }

        public static TelaPrincipalForm Instancia
        {
            get
            {
                if (telaPrincipal == null)
                    telaPrincipal = new TelaPrincipalForm();

                return telaPrincipal;
            }
        }

        private void alugueisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlador = new ControladorAluguel(repositorioAluguel, repositorioTema, repositorioCliente);

            ConfigurarTelaPrincipal(controlador);
        }
        private void clientesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            controlador = new ControladorCliente(repositorioCliente);

            ConfigurarTelaPrincipal(controlador);
        }

        //private void temasToolStripMenuItem_Click_1(object sender, EventArgs e)
        //{
        //    controlador = new ControladorTema(repositorioTema);

        //    ConfigurarTelaPrincipal(controlador);
        //}

        private void itensToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controlador = new ControladorTema(repositorioTema);

            ConfigurarTelaPrincipal(controlador);
        }
        private void itensToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            controlador = new ControladorItem(repositorioItem);

            ConfigurarTelaPrincipal(controlador);
        }

        private void ConfigurarTelaPrincipal(ControladorBase controladorBase)
        {
            labelTipoCadastro.Text = controladorBase.ObterTipoCadastro();

            ConfigurarBarraFerramentas(controlador);

            ConfigurarListagem(controlador);
        }

        private void ConfigurarBarraFerramentas(ControladorBase controlador)
        {
            barraFerramentas.Enabled = true;

            ConfigurarToolTips(controlador);

            ConfigurarEstados(controlador);
        }

        private void ConfigurarListagem(ControladorBase controladorBase)
        {
            UserControl listagem = controladorBase.ObterListagem();

            listagem.Dock = DockStyle.Fill;

            panelRegistros.Controls.Clear();

            panelRegistros.Controls.Add(listagem);
        }

        private void ConfigurarToolTips(ControladorBase controlador)
        {
            btnInserir.ToolTipText = controlador.ToolTipInserir;
            btnEditar.ToolTipText = controlador.ToolTipEditar;
            btnExcluir.ToolTipText = controlador.ToolTipExcluir;
            btnVisualizar.ToolTipText = controlador.ToolTipVisualizar;
            btnAdicionarItens.ToolTipText = controlador.ToolTipAdicionarItens;
            btnFiltrar.ToolTipText = controlador.ToolTipFiltrar;
        }

        private void ConfigurarEstados(ControladorBase controlador)
        {
            btnInserir.Enabled = controlador.InserirHabilitado;
            btnEditar.Enabled = controlador.EditarHabilitado;
            btnExcluir.Enabled = controlador.ExcluirHabilitado;
            btnVisualizar.Enabled = controlador.VisualizarHabilitado;
            btnAdicionarItens.Enabled = controlador.AdicionarItensHabilitado;
            btnFiltrar.Enabled = controlador.FiltrarHabilitado;
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            controlador.Inserir();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            controlador.Editar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            controlador.Excluir();
        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            controlador.Visualizar();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            controlador.Adicionar();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            controlador.Filtrar();
        }     
    }
}