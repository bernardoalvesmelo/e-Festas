using e_Festas.Dominio.ModuloAluguel;

namespace e_Festas.WinApp.ModuloAluguel
{
    public partial class TabelaAluguelControl : UserControl
    {

        private VisualizacaoAluguelEnum visualizacao;
        public TabelaAluguelControl()
        {
            InitializeComponent();
            ConfigurarColunas();
            this.visualizacao = VisualizacaoAluguelEnum.Alugueis;

            gridAlugueis.ConfigurarGridZebrado();

            gridAlugueis.ConfigurarGridSomenteLeitura();
        }

        public void ConfigurarVisualizacao(VisualizacaoAluguelEnum visualizacao)
        {
            this.visualizacao = visualizacao;
        }

        private void ConfigurarColunas()
        {
            switch (this.visualizacao)
            {
                case VisualizacaoAluguelEnum.Alugueis:
                    ConfigurarColunasAlugueis();
                    break;
                case VisualizacaoAluguelEnum.Enderecos:
                    ConfigurarColunasEnderecos();
                    break;
            }
        }

        public void AtualizarRegistros(List<Aluguel> alugueis)
        {
            switch (this.visualizacao)
            {
                case VisualizacaoAluguelEnum.Alugueis:
                    AtualizarRegistrosAlugueis(alugueis);
                    break;
                case VisualizacaoAluguelEnum.Enderecos:
                    AtualizarRegistrosEnderecos(alugueis);
                    break;
            }
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
                    Name = "telefone",
                    HeaderText = "Telefone"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "tema",
                    HeaderText = "Tema"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "valor",
                    HeaderText = "Valor-R$"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "entrada",
                    HeaderText = "Entrada-R$"
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
                }
    };

            gridAlugueis.Columns.Clear();
            gridAlugueis.Columns.AddRange(colunas);
        }

        public void AtualizarRegistrosAlugueis(List<Aluguel> alugueis)
        {
            ConfigurarColunasAlugueis();
            gridAlugueis.Rows.Clear();

            foreach (Aluguel aluguel in alugueis)
            {
                gridAlugueis.Rows.Add(
                    aluguel.id,
                    aluguel.cliente.nome,
                    aluguel.cliente.telefone,
                    aluguel.tema.nome,
                    Math.Round(aluguel.valor, 2),
                    Math.Round(aluguel.entrada, 2),
                    aluguel.data.ToString("dd/MM/yyyy"),
                    aluguel.dataQuitacao == new DateTime() ? "Em Aberto" :
                        aluguel.dataQuitacao.ToString("dd/MM/yyyy"));
            }
        }

        private void ConfigurarColunasEnderecos()
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
                    Name = "cidade",
                    HeaderText = "Cidade"
                },             
                new DataGridViewTextBoxColumn()
                {
                    Name = "rua",
                    HeaderText = "Rua"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "numero",
                    HeaderText = "Número"
                }

    };

            gridAlugueis.Columns.Clear();
            gridAlugueis.Columns.AddRange(colunas);
        }

        public void AtualizarRegistrosEnderecos(List<Aluguel> alugueis)
        {
            ConfigurarColunasEnderecos();
            gridAlugueis.Rows.Clear();

            foreach (Aluguel aluguel in alugueis)
            {
                Endereco endereco = aluguel.endereco;
                gridAlugueis.Rows.Add(
                    aluguel.id,
                    endereco.cidade,
                    endereco.rua,
                    endereco.numero
                    );
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