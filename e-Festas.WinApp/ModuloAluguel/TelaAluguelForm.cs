using e_Festas.Dominio.ModuloCliente;
using e_Festas.Dominio.ModuloAluguel;
using e_Festas.Dominio.ModuloTema;

namespace e_Festas.WinApp.ModuloAluguel
{
    public partial class TelaAluguelForm : Form
    {
        private List<Aluguel> alugueis;
        private List<Cliente> clientes;
        private List<Tema> temas;

        public TelaAluguelForm(List<Aluguel> alugueis, List<Cliente> clientes, List<Tema> temas)
        {
            InitializeComponent();
            this.ConfigurarDialog();

            this.alugueis = alugueis;
            this.clientes = clientes;
            this.temas = temas;

            CarregarComboBoxes(clientes, temas);
        }

        private void CarregarComboBoxes(List<Cliente> clientes, List<Tema> temas)
        {
            foreach (Cliente cliente in clientes)
            {
                cmbClientes.Items.Add(cliente.nome);
            }

            if (cmbClientes.Items.Count > 0)
                cmbClientes.SelectedIndex = 0;

            foreach (Tema tema in temas)
            {
                cmbTemas.Items.Add(tema.nome);
            }
            if (cmbTemas.Items.Count > 0)
                cmbTemas.SelectedIndex = 0;
        }

        public Aluguel ObterAluguel()
        {
            int id = Convert.ToInt32(txtId.Text);

            decimal sinal = Convert.ToDecimal(txtSinal.Text);

            bool descontoAplicado = cbDesconto.Checked;

            decimal descontoValor = Convert.ToDecimal(txtDesconto.Text);

            decimal descontoMaximo = Convert.ToDecimal(txtDescontoMaximo.Text);

            DateTime data = txtData.Value.Date;

            DateTime dataQuitacao = new DateTime();

            DateTime horarioInicio = txtHorarioInicio.Value;

            DateTime horarioTermino = txtHorarioTermino.Value;

            Cliente cliente = clientes.Find(c => c.nome == cmbClientes.SelectedItem);

            Tema tema = temas.Find(t => t.nome == cmbTemas.SelectedItem);

            Endereco endereco = ObterEndereco();

            Aluguel aluguel = new Aluguel(sinal, descontoAplicado, descontoValor, descontoMaximo, data, dataQuitacao, horarioInicio, horarioTermino, cliente, tema, endereco);

            if (id > 0)
                aluguel.id = id;

            if (cbDesconto.Checked)
                aluguel.DescontarValor();

            return aluguel;
        }

        public void ConfigurarTela(Aluguel aluguel)
        {
            txtId.Text = aluguel.id.ToString();
            txtSinal.Text = aluguel.sinal.ToString();
            txtDesconto.Text = aluguel.descontoValor.ToString();
            cbDesconto.Checked = aluguel.descontoAplicado;
            txtDescontoMaximo.Text = aluguel.descontoMaximo.ToString();

            txtData.Value = aluguel.data;
            txtHorarioInicio.Value = aluguel.horarioInicio;
            txtHorarioTermino.Value = aluguel.horarioTermino;

            cmbClientes.SelectedItem = aluguel.cliente.nome;
            cmbTemas.SelectedItem = aluguel.tema.nome;

            btnGravar.Enabled = true;

            ConfigurarTela(aluguel.endereco);
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            Aluguel aluguel = ObterAluguel();

            string[] erros = aluguel.Validar();

            if (erros.Length == 0)
                erros = Validar(aluguel);

            if (erros.Length == 0)
                erros = aluguel.endereco.Validar();

            if (erros.Length > 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(erros[0]);
                this.DialogResult = DialogResult.None;
            }
        }

        private string[] Validar(Aluguel aluguel)
        {
            List<string> erros = new List<string>();

            if (alugueis.FindAll(a => a.id != aluguel.id && a.data == aluguel.data).Count > 0)
            {
                erros.Add("Data já reservada!");
            }

            if (aluguel.endereco == null)
            {
                erros.Add("Cadastre um endereço!");
            }
            return erros.ToArray();
        }

        public Endereco ObterEndereco()
        {
            string cidade = txtCidade.Text;

            string rua = txtRua.Text;

            string numero = txtNumero.Text;


            Endereco endereco = new Endereco(cidade, rua, numero);

            return endereco;
        }

        public void ConfigurarTela(Endereco endereco)
        {
            txtCidade.Text = endereco.cidade;

            txtRua.Text = endereco.rua;

            txtNumero.Text = endereco.numero;
        }

        private void btnlGravar_Click(object sender, EventArgs e)
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
