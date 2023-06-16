using e_Festas.Dominio.ModuloAluguel;
using e_Festas.Dominio.ModuloTema;

namespace e_Festas.WinApp.ModuloTema
{
    public partial class TelaCadastroTemaForm : Form
    {
       
        public TelaCadastroTemaForm()
        {
            InitializeComponent();

            this.ConfigurarDialog();          
        }

        public Tema ObterTema()
        {
            int id = Convert.ToInt32(txtIdTema.Text);

            string nome = txtNomeTema.Text;

            decimal valor = Convert.ToDecimal(txtValorTema.Text);

            Tema tema = new Tema(valor, nome, id);
         
            if (id > 0)
                tema.id = id;
           
            return tema;
        }

        //public void PopularCheckBox(Tema tema)
        //{           
        //   List<ItemTema> listItens = repositorio.SelecionarTodos();

        //    foreach(ItemTema itemTema in listItens)
        //    {
        //        listItensTema.Items.Add(itemTema);
        //    }

        //    foreach(ItemTema item in tema.itemTemas)
        //    {
        //        int index = listItensTema.Items.IndexOf(item);

        //        if(index >= 0)
        //        {
        //            listItensTema.SetItemChecked(index, true);
        //        }
        //    }
        //}

        public void ConfigurarTela(Tema temaSelecionada)
        {
            txtIdTema.Text = temaSelecionada.id.ToString();

            txtNomeTema.Text = temaSelecionada.nome;

            txtValorTema.Text = temaSelecionada.valor.ToString();          
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            Tema tema;
            try
            {
                tema = ObterTema();
            }
            catch
            {
                TelaPrincipalForm.Instancia.AtualizarRodape("O valor é obrigatório");
                DialogResult = DialogResult.None;
                return;
            }

            string[] erros = tema.Validar();

            if (erros.Length > 0)
            {
                TelaPrincipalForm.Instancia.AtualizarRodape(erros[0]);

                DialogResult = DialogResult.None;
            }
        }
    }
}
