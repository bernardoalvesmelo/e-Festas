using e_Festas.Dominio.ModuloAluguel;
using e_Festas.Dominio.ModuloContato;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using e_Festas.Dominio.ModuloCliente;

namespace e_Festas.WinApp.ModuloCliente
{
    public partial class TabelaClienteControl : UserControl
    {
        public TabelaClienteControl()
        {
            InitializeComponent();
            ConfigurarColunas();

            gridCliente.ConfigurarGridZebrado();

            gridCliente.ConfigurarGridSomenteLeitura();
        }



        private void ConfigurarColunas()
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
                    Name = "telefone",
                    HeaderText = "Telefone"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "email",
                    HeaderText = "E-mail"
                },
               
                
            };

            gridCliente.Columns.AddRange(colunas);
        }

        public void AtualizarRegistros(List<Cliente> Cliente)
        {
            gridCliente.Rows.Clear();

            foreach (Cliente cliente in Cliente)
            {
                gridCliente.Rows.Add(cliente.id, cliente.nome,cliente.telefone,cliente.email);
            }
        }

        public int ObterIdSelecionado()
        {
            if (gridCliente.SelectedRows.Count == 0)
                return -1;

            int id = Convert.ToInt32(gridCliente.SelectedRows[0].Cells["id"].Value);

            return id;
        }
    }
}

