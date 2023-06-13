using e_Festas.Dominio.ModuloAluguel;
using e_Festas.Dominio.ModuloTema;
using System.Data;

namespace e_Festas.WinApp.ModuloTema
{
    public partial class TelaCadastroItemForm : Form
    {
        private Temas temas;
        public TelaCadastroItemForm(Temas tema)
        {
            InitializeComponent();

            this.ConfigurarDialog();

            ConfigurarTela(tema);
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            string nome = TxtItem.Text;

            decimal valorItem = Convert.ToDecimal(txtValorItem.Text);

            ItemTema item = new ItemTema(nome, valorItem);

            CalcularValorTotal();

            listTema.Items.Add(item);
        }
        private void ConfigurarTela(Temas tema)
        {
            txtId.Text = tema.id.ToString();

            TxtItem.Text = tema.nome;

            listTema.Items.AddRange(tema.itemTemas.ToArray());
        }
        public List<ItemTema> ObterItensCadastrados()
        {
            return listTema.Items.Cast<ItemTema>().ToList();
        }

        public void CalcularValorTotal()
        {
            foreach (ItemTema item in listTema.Items)
            {
                temas.valorTotal += item.valorItem + temas.valor;
            }
        }    
    }
}
