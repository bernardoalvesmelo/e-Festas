
using e_Festas.Dominio.ModuloAluguel;

namespace e_Festas.WinApp.ModuloAluguel
{
    public partial class TelaConfigurarAluguelForm : Form
    {
        public TelaConfigurarAluguelForm()
        {
            InitializeComponent();
            this.ConfigurarDialog();
        }

        public void CarregarConfiguracao()
        {
            txtSinal.Value = Configuracao.sinal;
           
            txtDesconto.Value = Configuracao.descontoValor;
            
            txtDescontoMaximo.Value = Configuracao.descontoMaximo;

            cbDesconto.Checked = Configuracao.descontoAplicado;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            Configuracao.sinal = txtSinal.Value;

            Configuracao.descontoValor = txtDesconto.Value;

            Configuracao.descontoMaximo = txtDescontoMaximo.Value;

            Configuracao.descontoAplicado = cbDesconto.Checked;
        }
    }
}
