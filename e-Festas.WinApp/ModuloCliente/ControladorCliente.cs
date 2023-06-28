using e_Festas.Dominio.ModuloAluguel;
using e_Festas.Dominio.ModuloCliente;
using e_Festas.WinApp.ModuloAluguel;
using e_Festas.WinApp.ModuloCliente;
using e_Festas.WinApp.ModuloTema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using e_Festas.Dominio.ModuloAluguel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using e_Festas.Dominio.ModuloCliente;
namespace e_Festas.WinApp.ModuloCliente
{
    public class ControladorCliente : ControladorBase
    {
        private IRepositorioCliente repositorioCliente;
        private IRepositorioAluguel repositorioAluguel;
        private TabelaVizualizarClientes tabelaCliente;

        public ControladorCliente(IRepositorioCliente repositorioCliente)
        {
            this.repositorioCliente = repositorioCliente;
        }

        public override string ToolTipInserir { get { return "Inserir novo Cliente"; } }
        public override string ToolTipEditar { get { return "Editar Cliente existente"; } }
        public override bool InserirHabilitado { get { return visualizar == "Vizualizar Alugueis do Cliente existente";} }
        public override bool ExcluirHabilitado { get { return visualizar == "Vizualizar Alugueis do Cliente existente"; } }
        public override bool EditarHabilitado { get { return visualizar == "Vizualizar Alugueis do Cliente existente"; } }
        public override bool VisualizarHabilitado { get { return true; } }
        public override string ToolTipExcluir { get { return "Excluir Cliente existente"; } }
        public override string ToolTipVisualizar { get { return visualizar; } }
        public string visualizar = "Vizualizar Alugueis do Cliente existente";
        public override void Inserir()
        {
            TelaClienteForm telaCliente = new TelaClienteForm(repositorioCliente.SelecionarTodos());

            DialogResult opcaoEscolhida = telaCliente.ShowDialog();

            if (opcaoEscolhida == DialogResult.OK)
            {
                Cliente Cliente = telaCliente.ObterCliente();

                repositorioCliente.Inserir(Cliente);
            }
            CarregarClientes();
        }

        public override void Editar()
        {
            Cliente Cliente = ObterClienteSelecionado();

            if (Cliente == null)
            {
                MessageBox.Show($"Selecione um Cliente primeiro!",
                    "Edição de Clientes",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }


            TelaClienteForm telaCliente = new TelaClienteForm(repositorioCliente.SelecionarTodos());
            telaCliente.ConfigurarTela(Cliente);

            DialogResult opcaoEscolhida = telaCliente.ShowDialog();

            if (opcaoEscolhida == DialogResult.OK)
            {
                Cliente ClienteAtualizado = telaCliente.ObterCliente();
                repositorioCliente.Editar(ClienteAtualizado.id, ClienteAtualizado);
            }
            CarregarClientes();
        }

        private Cliente ObterClienteSelecionado()
        {
            int id = tabelaCliente.ObterIdSelecionado();

            return repositorioCliente.SelecionarPorId(id);
        }

        public override void Excluir()
        {
            Cliente Cliente = ObterClienteSelecionado();

            if (Cliente == null)
            {
                MessageBox.Show($"Selecione um Cliente primeiro!",
                    "Exclusão de Clientes",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }

            DialogResult opcaoEscolhida = MessageBox.Show($"Deseja excluir o Cliente {Cliente.nome}?", "Exclusão de Clientes",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);


            if (Cliente.alugueis.Count > 0)
            {
                MessageBox.Show($"Cliente não pode ser excluido com alugueis em aberto!!!",
                    "Exclusão de Clientes",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }

            if (opcaoEscolhida == DialogResult.OK)
            {
                repositorioCliente.Excluir(Cliente);
            }
            CarregarClientes();
        }


        private void CarregarClientes()
        {
            List<Cliente> clientes = repositorioCliente.SelecionarTodos();

            tabelaCliente.AtualizarRegistros(clientes);

            string mensagem = $"Visualizando {clientes.Count} " + (clientes.Count == 1 ?
                "cliente" : "clientes");
            TelaPrincipalForm.Instancia.AtualizarRodape(mensagem);
        }

        public override UserControl ObterListagem()
        {
            if (tabelaCliente == null)
                tabelaCliente = new TabelaVizualizarClientes();

            CarregarClientes();

            return tabelaCliente;
        }

       

        public override string ObterTipoCadastro()
        {
            return "Cadastro de Clientes";
        }

        public override void Visualizar()
        {
            Cliente Cliente = ObterClienteSelecionado();
          
            if (Cliente == null)
            {
                MessageBox.Show($"Selecione um cliente!!!",
                    "Visualização de alkugueis de clientes",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }

            if (Cliente.alugueis.Count == 0 && tabelaCliente.tabelasAlugueis == "Clientes")
            {
                MessageBox.Show($"O cliente não tem alugueis!!!",
                    "Visualização de alkugueis de clientes",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }

          if (tabelaCliente.tabelasAlugueis == "Alugueis")
            {
                tabelaCliente.tabelasAlugueis = "Clientes";
                visualizar = "Vizualizar Alugueis do Cliente existente";
            }

           else if (tabelaCliente.tabelasAlugueis == "Clientes")
            {
                tabelaCliente.tabelasAlugueis = "Alugueis";
                visualizar = "Vizualizar Clientes";
            }

            CarregarClientes();
        }


    }
}