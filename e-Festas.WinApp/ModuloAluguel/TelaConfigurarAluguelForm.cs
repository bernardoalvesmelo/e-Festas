
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
            txtSinal.Text = Configuracao.sinal.ToString();
           
            txtDesconto.Text = Configuracao.descontoValor.ToString();
            
            txtDescontoMaximo.Text = Configuracao.descontoMaximo.ToString();

            cbDesconto.Checked = Configuracao.descontoAplicado;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
        Configuracao.sinal = Convert.ToDecimal(txtSinal.Text);

        Configuracao.descontoValor = Convert.ToDecimal(txtDesconto.Text);

        Configuracao.descontoMaximo = Convert.ToDecimal(txtDescontoMaximo.Text);

        Configuracao.descontoAplicado = cbDesconto.Checked;
        }
    }
}
