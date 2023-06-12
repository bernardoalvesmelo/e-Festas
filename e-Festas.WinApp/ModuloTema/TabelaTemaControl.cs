using e_Festas.Dominio.ModuloTema;

namespace e_Festas.WinApp.ModuloTema
{
    public partial class TabelaTemaControl : UserControl
    {
        public TabelaTemaControl()
        {
            InitializeComponent();

            ConfigurarColunas();

            gridTema.ConfigurarGridZebrado();

            gridTema.ConfigurarGridSomenteLeitura();
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
                new DataGridViewTextBoxColumn()
                {
                    Name = "valor",
                    HeaderText = "Valor total"
                }
            };

            gridTema.Columns.AddRange(colunas);
        }
        public void AtualizarRegistros(List<Temas> temas)
        {
            gridTema.Rows.Clear();

            foreach (Temas tema in temas)
            {
                gridTema.Rows.Add(tema.id, tema.nome, tema.valor, tema.valorTotal);
            }
        }

        public int ObterIdSelecionado()
        {
            int id;

            try
            {
                id = Convert.ToInt32(gridTema.SelectedRows[0].Cells["id"].Value);
            }
            catch
            {
                id = -1;
            }

            return id;
        }
    }
}
