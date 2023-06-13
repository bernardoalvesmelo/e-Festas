using e_Festas.Dominio.ModuloTema;

namespace e_Festas.WinApp.ModuloTema
{
    public partial class TelaCadastroTemaForm : Form
    {
        public TelaCadastroTemaForm()
        {
            InitializeComponent();

            this.ConfigurarDialog();

        }

        public Tema ObterTema()
        {
            int id = Convert.ToInt32(txtIdTema.Text);

            string nome = txtNomeTema.Text;

            decimal valor = Convert.ToDecimal(txtValorTema.Text);

            Tema tema = new Tema(valor, nome, id);

            return tema;
        }

        public void ConfigurarTela(Tema temaSelecionada)
        {
            txtIdTema.Text = temaSelecionada.id.ToString();

            txtNomeTema.Text = temaSelecionada.nome;

            txtValorTema.Text = temaSelecionada.valor.ToString();
        }
    }
}
