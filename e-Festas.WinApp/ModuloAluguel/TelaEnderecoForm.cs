using e_Festas.Dominio.ModuloAluguel;

namespace e_Festas.WinApp.ModuloAluguel
{
    public partial class TelaEnderecoForm : Form
    {
        public TelaEnderecoForm()
        {
            InitializeComponent();
            this.ConfigurarDialog();
        }

        public Endereco ObterEndereco()
        {
            string pais = txtPais.Text;

            string estado = txtEstado.Text;

            string cidade = txtCidade.Text;

            string bairro = txtBairro.Text;

            string cep = txtCep.Text;

            string rua = txtRua.Text;

            string numero = txtNumero.Text;

            string complemento = txtComplemento.Text;

            Endereco endereco = new Endereco(pais, estado, cidade, bairro, cep, rua, numero, complemento);

            return endereco;
        }

        public void ConfigurarTela(Endereco endereco)
        {
            txtPais.Text = endereco.pais;

            txtEstado.Text = endereco.estado;

            txtCidade.Text = endereco.cidade;

            txtBairro.Text = endereco.bairro;

            txtCep.Text = endereco.cep;

            txtRua.Text = endereco.rua;

            txtNumero.Text = endereco.numero;

            txtComplemento.Text = endereco.complemento;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            Endereco endereco = ObterEndereco();

            string[] erros = endereco.Validar();

            if (erros.Length > 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(erros[0]);
                this.DialogResult = DialogResult.None;
            }
        }
    }
}
