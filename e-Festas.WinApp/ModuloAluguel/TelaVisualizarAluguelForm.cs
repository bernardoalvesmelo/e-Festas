using e_Festas.Dominio.ModuloAluguel;

namespace e_Festas.WinApp.ModuloAluguel
{
    public partial class TelaVisualizarAluguelForm : Form
    {
        public TelaVisualizarAluguelForm()
        {
            InitializeComponent();
            this.ConfigurarDialog();
            CarregarVisualizacoes();
        }

        private void CarregarVisualizacoes()
        {
            foreach(
                VisualizacaoAluguelEnum visualizacao in Enum.GetValues<VisualizacaoAluguelEnum>()
                )
            {
                cmbVisualizacoes.Items.Add(visualizacao);
            }

            cmbVisualizacoes.SelectedIndex = 0;
        }

        public VisualizacaoAluguelEnum ObterVisualizacao()
        {
            return (VisualizacaoAluguelEnum)cmbVisualizacoes.SelectedItem;
        }
    }
}
