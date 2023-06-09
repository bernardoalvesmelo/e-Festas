using e_Festas.Dominio.ModuloAluguel;
using e_Festas.Dominio.ModuloContato;

namespace e_Festas.WinApp.ModuloAluguel
{
    public partial class TabelaAluguelControl : UserControl
    {
        public TabelaAluguelControl()
        {
            InitializeComponent();
            ConfigurarColunas();

            gridAlugueis.ConfigurarGridZebrado();

            gridAlugueis.ConfigurarGridSomenteLeitura();
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
                    Name = "valor",
                    HeaderText = "Valor R$"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "entrada",
                    HeaderText = "Entrada R$"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "data",
                    HeaderText = "Data"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "dataQuitacao",
                    HeaderText = "Quitação"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "horarioInicio",
                    HeaderText = "Inicio"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "horarioTermino",
                    HeaderText = "Término"
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

            gridAlugueis.Columns.AddRange(colunas);
        }

        public void AtualizarRegistros(List<Aluguel> alugueis)
        {
            gridAlugueis.Rows.Clear();

            foreach (Aluguel aluguel in alugueis)
            {
                gridAlugueis.Rows.Add(
                    aluguel.id,
                    Math.Round(aluguel.valor, 2),
                    Math.Round(aluguel.entrada, 2),
                    aluguel.data.ToString("dd/MM/yyyy"),
                    aluguel.dataQuitacao == new DateTime() ? "Em Aberto" :
                        aluguel.dataQuitacao.ToString("dd/MM/yyyy"),
                    aluguel.horarioInicio.ToString("HH:mm"),
                    aluguel.horarioTermino.ToString("HH:mm"),
                    aluguel.cliente.nome,
                    aluguel.tema.estilo);
            }
        }

        public int ObterIdSelecionado()
        {
            if (gridAlugueis.SelectedRows.Count == 0)
                return -1;

            int id = Convert.ToInt32(gridAlugueis.SelectedRows[0].Cells["id"].Value);

            return id;
        }
    }
}
