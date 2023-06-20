using e_Festas.Dominio.ModuloCliente;
using e_Festas.Dominio.ModuloTema;

namespace e_Festas.WinApp.ModuloTema
{
    public partial class TelaCadastroItemForm : Form
    {
        private List<ItemTema> itens = new List<ItemTema>();
        public TelaCadastroItemForm(List<ItemTema> itens)
        {
            InitializeComponent();

            this.ConfigurarDialog();

            this.itens = itens;

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
            try
            {
                Item = ObterItem();
            }
            catch
            {
                TelaPrincipalForm.Instancia.AtualizarRodape("O valor é obrigatório");
                DialogResult = DialogResult.None;
                return;
            }           
            string[] erros = Item.Validar();

            if (erros.Length > 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(erros[0]);

                DialogResult = DialogResult.None;
            }

            int numero = itens.FindAll(i => i.nome == txtNome.Text && i.id != Item.id).Count();

            if (numero > 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape("Nome do 'Item' já existente");

                DialogResult = DialogResult.None;
            }
        }
    }
}
