using e_Festas.Dominio.ModuloAluguel;
using e_Festas.Dominio.ModuloTema;

namespace e_Festas.WinApp.ModuloTema
{
    public partial class TelaCadastroTemaForm : Form
    {
        private List<ItemTema> itemtemas;
        private IRepositorioItem repositorio;

        public TelaCadastroTemaForm(Tema tema,IRepositorioItem repositorio)
        {
            InitializeComponent();

            this.ConfigurarDialog();

            this.repositorio = repositorio;

            PopularCheckBox(tema);         
        }

        public TelaCadastroTemaForm(IRepositorioItem repositorioItem)
        {
            InitializeComponent();

            this.ConfigurarDialog();

            this.repositorio = repositorioItem;

            PopularCheckBox();
        }

        public Tema ObterTema()
        {
            List<ItemTema> itens = new List<ItemTema>();

            foreach (ItemTema item in cbItens.CheckedItems)
            {
                itens.Add(item);
            }
                       
            int id = Convert.ToInt32(txtIdTema.Text);

            string nome = txtNomeTema.Text;

            decimal valor = Convert.ToDecimal(txtValorTema.Text);

            Tema tema = new Tema(valor, nome,id,itens);

            if (id > 0)
                tema.id = id;

            return tema;
        }

        public void PopularCheckBox()
        {
            List<ItemTema> listItens = repositorio.SelecionarTodos();

            foreach (ItemTema itemTema in listItens)
            {
                cbItens.Items.Add(itemTema);
            }           
        }

        private void PopularCheckBox(Tema tema)
        {
            List<ItemTema> listItens = repositorio.SelecionarTodos();

            foreach (ItemTema itemTema in listItens)
            {
                cbItens.Items.Add(itemTema);
            }

            foreach (ItemTema item in tema.itemTemas)
            {
                int index = cbItens.Items.IndexOf(item);

                if (index >= 0)
                {
                    cbItens.SetItemChecked(index, true);
                }
            }
        }

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
