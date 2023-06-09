﻿using e_Festas.Dominio.ModuloAluguel;

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
                cmbTemas.Items.Add(tema.estilo);
            }
            if (cmbTemas.Items.Count > 0)
                cmbTemas.SelectedIndex = 0;
        }

        public Aluguel ObterAluguel()
        {
            int id = Convert.ToInt32(txtId.Text);

            decimal sinal = Convert.ToDecimal(txtSinal.Text);

            bool descontoAplicado = cbDesconto.Checked;

            DateTime data = txtData.Value.Date;

            DateTime dataQuitacao = cbDataQuitacao.Checked ? txtDataQuitacao.Value.Date :
                new DateTime();

            DateTime horarioInicio = txtHorarioInicio.Value;

            DateTime horarioTermino = txtHorarioTermino.Value;

            Cliente cliente = clientes.Find(c => c.nome == cmbClientes.SelectedItem);

            Tema tema = temas.Find(t => t.estilo == cmbTemas.SelectedItem);

            Aluguel aluguel = new Aluguel(sinal, descontoAplicado, data, dataQuitacao, horarioInicio, horarioTermino, cliente, tema);

            if (id > 0)
                aluguel.id = id;

            if (cbDesconto.Checked)
                aluguel.DescontarValor(alugueis);

            return aluguel;
        }

        public void ConfigurarTela(Aluguel aluguel)
        {
            txtId.Text = aluguel.id.ToString();
            txtSinal.Text = aluguel.sinal.ToString();
            cbDesconto.Checked = aluguel.descontoAplicado;
            txtData.Value = aluguel.data;

            if(aluguel.dataQuitacao != new DateTime())
            {
                cbDataQuitacao.Checked = true;
                txtDataQuitacao.Value = aluguel.dataQuitacao;
                txtDataQuitacao.Enabled = true;
            }
           
            txtHorarioInicio.Value = aluguel.horarioInicio;
            txtHorarioTermino.Value = aluguel.horarioTermino;
            cmbClientes.SelectedItem = aluguel.cliente.nome;
            cmbTemas.SelectedItem = aluguel.tema.estilo;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            Aluguel aluguel = ObterAluguel();

            string[] erros = aluguel.Validar();

            if (erros.Length > 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(erros[0]);

                DialogResult = DialogResult.None;
            }
        }

        private void cbDataQuitacao_CheckedChanged(object sender, EventArgs e)
        {
            txtDataQuitacao.Enabled = !txtDataQuitacao.Enabled;
        }
    }
}