using e_Festas.Dominio.ModuloTema;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace e_Festas.WinApp.ModuloTema
{
    public partial class TabelaItemTemaControl : UserControl
    {
        public TabelaItemTemaControl()
        {
            InitializeComponent();

            ConfigurarColunas();

            gridItem.ConfigurarGridSomenteLeitura();

            gridItem.ConfigurarGridZebrado();
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
                    Name = "Valor",
                    HeaderText = "Valor"
                },              
            };

            gridItem.Columns.AddRange(colunas);
        }
        public void AtualizarRegistros(List<ItemTema> itens)
        {
            gridItem.Rows.Clear();

            foreach (ItemTema item in itens)
            {
                gridItem.Rows.Add(item.id, item.nome, item.valorItem);
            }
        }

        public int ObterIdSelecionado()
        {
            int id;

            try
            {
                id = Convert.ToInt32(gridItem.SelectedRows[0].Cells["id"].Value);
            }
            catch
            {
                id = -1;
            }

            return id;
        }
    }
}
