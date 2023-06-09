﻿using e_Festas.Dominio.ModuloCliente;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace e_Festas.WinApp.ModuloCliente
{
    public partial class TelaClienteForm : Form
    {

        List<Cliente> Clientes = new List<Cliente>();
        public TelaClienteForm(List<Cliente> Clientes)
        {
            InitializeComponent();
            this.ConfigurarDialog();
            this.Clientes = Clientes;

        }
        public Cliente ObterCliente()
        {
            int id = Convert.ToInt32(txtIdCliente.Text);

            string nome = txtNomeCliente.Text;

            string telefone = txtTelefoneCliente.Text;

            string email = txtEmailCliente.Text;

            Cliente Cliente = new Cliente(nome, telefone, email);

            if (id > 0)
                Cliente.id = id;

            return Cliente;
        }

        public void ConfigurarTela(Cliente Cliente)
        {
            txtIdCliente.Text = Cliente.id.ToString();

            txtNomeCliente.Text = Cliente.nome;

            txtTelefoneCliente.Text = Cliente.telefone;

            txtEmailCliente.Text = Cliente.email;

        }

        private void btnGravarCliente_Click(object sender, EventArgs e)
        {
            Cliente Cliente = ObterCliente();

            string[] erros = Cliente.Validar();

            if (erros.Length > 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(erros[0]);

                DialogResult = DialogResult.None;
            }

            int numero = Clientes.FindAll(c => c.nome == txtNomeCliente.Text && c.id != Cliente.id ).Count();


            if (numero > 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape("Nome de 'Cliente' já existente");

                DialogResult = DialogResult.None;
            }
        }

    }
}
