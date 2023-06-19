using e_Festas.Dominio.ModuloCliente;
using e_Festas.Dominio.ModuloTema;

namespace e_Festas.WinApp.ModuloTema
{
    public partial class TelaCadastroItemForm : Form
    {
        public TelaCadastroItemForm()
        {
            InitializeComponent();

            this.ConfigurarDialog();

        }
        public ItemTema ObterItem()
        {
            int id = Convert.ToInt32(txtIditem.Text);

            string nome = txtNome.Text;

            decimal valor = Convert.ToDecimal(maskedValor.Text);

            ItemTema item = new ItemTema(id, nome, valor);

            if (id > 0)
                item.id = id;

            return item;
        }

        public void ConfigurarTela(ItemTema itemSelecionado)
        {
            txtIditem.Text = itemSelecionado.id.ToString();

            txtNome.Text = itemSelecionado.nome;

            maskedValor.Text = itemSelecionado.valorItem.ToString();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            ItemTema Item;

            Item = ObterItem();
            string[] erros = Item.Validar();

            if (erros.Length > 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(erros[0]);

                DialogResult = DialogResult.None;
            }
        }
    }
}
