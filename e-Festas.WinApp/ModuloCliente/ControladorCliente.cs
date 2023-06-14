using e_Festas.Dominio.ModuloAluguel;
using e_Festas.Dominio.ModuloCliente;
using e_Festas.WinApp.ModuloCliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Festas.WinApp.ModuloCliente
{
    public class ControladorCliente : ControladorBase
    {
        private IRepositorioCliente repositorioCliente;
        private TabelaClienteControl tabelaCliente;

        public ControladorCliente(IRepositorioCliente repositorioCliente)
        {
            this.repositorioCliente = repositorioCliente;
        }

        public override string ToolTipInserir { get { return "Inserir novo Cliente"; } }

        public override string ToolTipEditar { get { return "Editar Cliente existente"; } }

        public override string ToolTipExcluir { get { return "Excluir Cliente existente"; } }

        public override void Inserir()
        {
            TelaClienteForm telaCliente = new TelaClienteForm();

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

            TelaClienteForm telaCliente = new TelaClienteForm();
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
                tabelaCliente = new TabelaClienteControl();

            CarregarClientes();

            return tabelaCliente;
        }

        public override string ObterTipoCadastro()
        {
            return "Cadastro de Clientes";
        }
    }
}
