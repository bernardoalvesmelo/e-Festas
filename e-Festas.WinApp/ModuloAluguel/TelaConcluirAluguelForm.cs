using e_Festas.Dominio.ModuloAluguel;

namespace e_Festas.WinApp.ModuloAluguel
{
    public partial class TelaConcluirAluguelForm : Form
    {
        private Aluguel aluguel;

        public TelaConcluirAluguelForm()
        {
            InitializeComponent();
            this.ConfigurarDialog();
        }

        public void ConfigurarTela(Aluguel aluguel)
        {
            this.aluguel = new Aluguel
                (
                    aluguel.id,
                    aluguel.sinal,
                    aluguel.descontoAplicado,
                    aluguel.descontoValor,
                    aluguel.descontoMaximo,
                    aluguel.data,
                    aluguel.dataQuitacao,
                    aluguel.horarioInicio,
                    aluguel.horarioTermino,
                    aluguel.cliente,
                    aluguel.tema,
                    aluguel.endereco
                );
        }

        public Aluguel ObterAluguel()
        {
            return this.aluguel;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            Aluguel aluguel = ObterAluguel();

            string[] erros = aluguel.Validar();

            if (erros.Length > 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(erros[0]);
                this.DialogResult = DialogResult.None;
            }
        }
    }
}
