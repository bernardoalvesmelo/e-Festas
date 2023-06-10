using e_Festas.Dominio.ModuloAluguel;

namespace e_Festas.WinApp.ModuloAluguel
{
    public partial class TelaVisualizarAluguelForm : Form
    {
        public TelaVisualizarAluguelForm()
        {
            InitializeComponent();

            ConfigurarColunas();

            gridEnderecos.ConfigurarGridZebrado();

            gridEnderecos.ConfigurarGridSomenteLeitura();
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
                    Name = "pais",
                    HeaderText = "Pais"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "estado",
                    HeaderText = "Estado"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "cidade",
                    HeaderText = "Cidade"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "bairro",
                    HeaderText = "Bairro"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "cep",
                    HeaderText = "CEP"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "rua",
                    HeaderText = "Rua"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "numero",
                    HeaderText = "Numero"
                },
                new DataGridViewTextBoxColumn()
                {
                    Name = "complemento",
                    HeaderText = "Complemento"
                },

    };

            gridEnderecos.Columns.AddRange(colunas);
        }

        public void AtualizarRegistros(List<Aluguel> alugueis)
        {
            gridEnderecos.Rows.Clear();

            foreach (Aluguel aluguel in alugueis)
            {
                Endereco endereco = aluguel.endereco;
                gridEnderecos.Rows.Add(
                    aluguel.id,
                    endereco.pais,
                    endereco.estado,
                    endereco.cidade,
                    endereco.bairro,
                    endereco.cep,
                    endereco.rua,
                    endereco.numero,
                    endereco.complemento
                    );
            }
        }
    }
}
