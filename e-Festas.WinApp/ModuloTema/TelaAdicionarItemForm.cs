using e_Festas.Dominio.ModuloAluguel;
using e_Festas.Dominio.ModuloTema;
using System.Data;

namespace e_Festas.WinApp.ModuloTema
{
    public partial class TelaAdicionarItemForm : Form
    {
        public TelaAdicionarItemForm(Tema tema)
        {
            InitializeComponent();

            this.ConfigurarDialog();

            ConfigurarTela(tema);
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);

            string nome = TxtItem.Text;

            decimal valorItem;

            try
            {
                valorItem = Convert.ToDecimal(txtValorItem.Text);

            }
            catch
            {
                TelaPrincipalForm.Instancia.AtualizarRodape("O campo 'VALOR' precisa ser um número.");
                DialogResult = DialogResult.None;
                return;
            }

            ItemTema item = new ItemTema(id, nome, valorItem);

            if (id > 0)
                item.id = id;

            listTema.Items.Add(item);
        }

        private void ConfigurarTela(Tema tema)
        {
            txtId.Text = tema.id.ToString();

            TxtItem.Text = tema.nome;

            listTema.Items.AddRange(tema.itemTemas.ToArray());
        }
        public List<ItemTema> ObterItensCadastrados()
        {
            return listTema.Items.Cast<ItemTema>().ToList();
        }
        //private void CarregarItens(List<ItemTema> itens)
        //{
        //    foreach (ItemTema item in itens)
        //    {
        //       listTema.Items.Add(itens);
        //    }
        //}

        //private void btnGravarItem_Click(object sender, EventArgs e)
        //{
        //    ItemTema tema;

        //    string[] erros = tema.Validar();

        //    if (erros.Length > 0)
        //    {
        //        TelaPrincipalForm.Instancia.AtualizarRodape(erros[0]);

        //        DialogResult = DialogResult.None;
        //    }
        //}
    }
}
