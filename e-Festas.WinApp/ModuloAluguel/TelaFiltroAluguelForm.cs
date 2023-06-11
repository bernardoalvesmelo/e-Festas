using e_Festas.Dominio.ModuloAluguel;

namespace e_Festas.WinApp.ModuloAluguel
{
    public partial class TelaFiltroAluguelForm : Form
    {
        public TelaFiltroAluguelForm()
        {
            InitializeComponent();
            this.ConfigurarDialog();
            CarregarFiltros();
        }

        private void CarregarFiltros()
        {

            cmbFiltros.Items.Add("Visualizar todos os aluguéis");
            cmbFiltros.Items.Add("Visualizar todos os aluguéis em aberto");
            cmbFiltros.Items.Add("Visualizar aluguéis com mesmo endereço");
            cmbFiltros.SelectedIndex = 0;
        }

        public FiltroAluguelEnum ObterFiltro()
        {
            switch (cmbFiltros.SelectedIndex)
            {
                case 0:
                    return FiltroAluguelEnum.Aluguel;
                case 1: 
                    return FiltroAluguelEnum.Aberto;
                case 2:
                    return FiltroAluguelEnum.Endereco;
            }
            return FiltroAluguelEnum.Aluguel;
        }
    }
}
