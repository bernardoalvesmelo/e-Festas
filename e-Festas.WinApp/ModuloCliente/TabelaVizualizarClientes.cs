using e_Festas.Dominio.ModuloAluguel;
using e_Festas.Dominio.ModuloCliente;
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
    public partial class TabelaVizualizarClientes : UserControl
    {
      public  string tabelasAlugueis = "Clientes";
        public TabelaVizualizarClientes()
        {


            InitializeComponent();
            ConfigurarColunas();

            GridClienteVizualizar.ConfigurarGridZebrado();

            GridClienteVizualizar.ConfigurarGridSomenteLeitura();
        }



        private void ConfigurarColunasAlugueis()
        {
            DataGridViewColumn[] colunas = new DataGridViewColumn[]
            {
                  new DataGridViewTextBoxColumn()
                {
                    Name = "id",
                    HeaderText = "Id"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "cliente",
                    HeaderText = "Cliente"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "tema",
                    HeaderText = "Tema"
                },

            };
            GridClienteVizualizar.Columns.Clear();
            GridClienteVizualizar.Columns.AddRange(colunas);
        }

        public void AtualizarRegistrosAlugueis(List<Aluguel> Aluguel)
        {
            GridClienteVizualizar.Rows.Clear();

            foreach (Aluguel aluguel in Aluguel)
            {
                GridClienteVizualizar.Rows.Add(aluguel.id, aluguel.cliente, aluguel.tema);
            }
        }

        public int ObterIdSelecionado()
        {
            if (GridClienteVizualizar.SelectedRows.Count == 0)
                return -1;

            int id = Convert.ToInt32(GridClienteVizualizar.SelectedRows[0].Cells["id"].Value);

            return id;
        }

        private void ConfigurarColunas()
        {

            switch (tabelasAlugueis)
            {
                case "Clientes":
                    ConfigurarColunasClientes();
                    break;
                case "Alugueis":
                    ConfigurarColunasAlugueis();
                    break;
            }

        }
        private void ConfigurarColunasClientes()
        {
            DataGridViewColumn[] colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn()
                {
                    Name = "id",
                    HeaderText = "Id"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "nome",
                    HeaderText = "Nome"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "",
                    HeaderText = "Telefone"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "email",
                    HeaderText = "E-mail"
                },
                  new DataGridViewTextBoxColumn()
                {
                    Name = "Alugueis",
                    HeaderText = "Alugueis"
                },

            };
            GridClienteVizualizar.Columns.Clear();
            GridClienteVizualizar.Columns.AddRange(colunas);
        }

        public void AtualizarRegistrosClientes(List<Cliente> Cliente)
        {
            GridClienteVizualizar.Rows.Clear();

            foreach (Cliente cliente in Cliente)
            {
                GridClienteVizualizar.Rows.Add(cliente.id, cliente.nome, cliente.telefone, cliente.email, cliente.alugueis.Count);
            }

        }
        public void AtualizarRegistros(List<Cliente> Cliente)
        {
            int id = ObterIdSelecionado();
            Cliente cliente = Cliente.Find(x => x.id == id);
            ConfigurarColunas();
            switch (tabelasAlugueis)
            {
                case "Clientes":
                    AtualizarRegistrosClientes(Cliente);
                    break;


                case "Alugueis":
                    AtualizarRegistrosAlugueis(cliente.alugueis);
                    break;

            }
         

        }
    }
}

