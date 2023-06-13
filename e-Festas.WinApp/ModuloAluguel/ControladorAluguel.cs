﻿using e_Festas.Dominio.ModuloCliente;
using e_Festas.Dominio.ModuloAluguel;

namespace e_Festas.WinApp.ModuloAluguel
{
    public class ControladorAluguel : ControladorBase
    {
        private IRepositorioAluguel repositorioAluguel;
        private TabelaAluguelControl tabelaAluguel;

        public ControladorAluguel(IRepositorioAluguel repositorioAluguel)
        {
            this.repositorioAluguel = repositorioAluguel;
        }

        public override string ToolTipInserir { get { return "Inserir novo Aluguel";  } }

        public override string ToolTipEditar { get { return "Editar Aluguel existente"; } }

        public override string ToolTipExcluir { get { return "Excluir Aluguel existente"; } }

        public override string ToolTipVisualizar { get { return "Visualizar Endereços"; } }

        public override bool VisualizarHabilitado { get { return true; } }

        public override void Inserir()
        {
            List<Cliente> clientes = new List<Cliente>();
           
          

            if (clientes.Count == 0)
            {
                MessageBox.Show($"Cadastre um cliente primeiro!",
                    "Criação de Aluguéis",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }

            List<Tema> temas = new List<Tema>
            {
                Tema.Instancia
            };

            if (temas.Count == 0)
            {
                MessageBox.Show($"Cadastre um tema primeiro!",
                    "Criação de Aluguéis",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }

            TelaAluguelForm telaAluguel = new TelaAluguelForm(
                repositorioAluguel.SelecionarTodos(),
                clientes,
                temas);

            DialogResult opcaoEscolhida = telaAluguel.ShowDialog();

            if (opcaoEscolhida == DialogResult.OK)
            {
                Aluguel aluguel = telaAluguel.ObterAluguel();

                repositorioAluguel.Inserir(aluguel);                
            }
            CarregarAlugueis();
        }

        public override void Editar()
        {
            //editar não está funcionando para poder testar filtrar sem botão
            {
                Filtrar();
                return;
            }
            Aluguel aluguel = ObterAluguelSelecionado();

            if (aluguel == null)
            {
                MessageBox.Show($"Selecione um aluguel primeiro!", 
                    "Edição de Aluguéis",
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Exclamation);

                return;
            }

            List<Cliente> clientes = new List<Cliente>();
           

            if (clientes.Count == 0)
            {
                MessageBox.Show($"Cadastre um cliente primeiro!",
                    "Edição de Aluguéis",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }

            List<Tema> temas = new List<Tema>
            {
                Tema.Instancia
            };

            if (temas.Count == 0)
            {
                MessageBox.Show($"Cadastre um tema primeiro!",
                    "Edição de Aluguéis",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                return;
            }

            TelaAluguelForm telaAluguel = new TelaAluguelForm(
                repositorioAluguel.SelecionarTodos(),
                clientes,
                temas);

            telaAluguel.ConfigurarTela(aluguel);

            DialogResult opcaoEscolhida = telaAluguel.ShowDialog();

            if (opcaoEscolhida == DialogResult.OK)
            {
                Aluguel aluguelAtualizado = telaAluguel.ObterAluguel();
                repositorioAluguel.Editar(aluguelAtualizado.id, aluguelAtualizado);                
            }
            CarregarAlugueis();
        }

        private Aluguel ObterAluguelSelecionado()
        {
            int id = tabelaAluguel.ObterIdSelecionado();

            return repositorioAluguel.SelecionarPorId(id);
        }

        public override void Excluir()
        {            
            Aluguel aluguel = ObterAluguelSelecionado();

            if (aluguel == null)
            {
                MessageBox.Show($"Selecione um aluguel primeiro!", 
                    "Exclusão de Aluguéis",
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Exclamation);

                return;
            }

            DialogResult opcaoEscolhida = MessageBox.Show($"Deseja excluir o aluguel {aluguel.id}?", "Exclusão de Aluguéis",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (opcaoEscolhida == DialogResult.OK)
            {
                repositorioAluguel.Excluir(aluguel);                
            }
            CarregarAlugueis();
        }

        public override void Visualizar()
        {

            TelaVisualizarAluguelForm telaVisualizar = new TelaVisualizarAluguelForm();
            DialogResult opcaoEscolhida = telaVisualizar.ShowDialog();

            if (opcaoEscolhida == DialogResult.OK)
            {
                tabelaAluguel.ConfigurarVisualizacao(telaVisualizar.ObterVisualizacao());
            }
            CarregarAlugueis();
        }

        public void Filtrar()
        {
            Aluguel aluguel = ObterAluguelSelecionado();

            List<Aluguel> alugueis = repositorioAluguel.SelecionarTodos();

            TelaFiltroAluguelForm telaFiltro = new TelaFiltroAluguelForm();
            DialogResult opcaoEscolhida = telaFiltro.ShowDialog();

            if (opcaoEscolhida == DialogResult.OK)
            {
                switch(telaFiltro.ObterFiltro())
                {
                    case FiltroAluguelEnum.Aluguel:
                        alugueis = repositorioAluguel.SelecionarTodos();
                        break;
                    case FiltroAluguelEnum.Aberto:
                        alugueis = repositorioAluguel.SelecionarTodosEmAberto();
                        break;
                    case FiltroAluguelEnum.Endereco:
                        if(aluguel == null)
                        {
                            alugueis = new List<Aluguel>();
                            break;
                        }
                        alugueis = repositorioAluguel.SelecionarTodosPorEndereco(aluguel);
                        break;
                }
            }
            CarregarAlugueis(alugueis);
        }

        private void CarregarAlugueis()
        {
            List<Aluguel> alugueis = repositorioAluguel.SelecionarTodos();

            tabelaAluguel.AtualizarRegistros(alugueis);

            string mensagem = $"Visualizando {alugueis.Count} " + (alugueis.Count == 1 ?
                "aluguel" : "aluguéis");
            TelaPrincipalForm.Instancia.AtualizarRodape(mensagem);
        }

        private void CarregarAlugueis(List<Aluguel> alugueis)
        { 
            tabelaAluguel.AtualizarRegistros(alugueis);

            string mensagem = $"Visualizando {alugueis.Count} " + (alugueis.Count == 1 ?
                "aluguel" : "aluguéis");
            TelaPrincipalForm.Instancia.AtualizarRodape(mensagem);
        }

        public override UserControl ObterListagem()
        {
            if (tabelaAluguel == null)
                tabelaAluguel = new TabelaAluguelControl();

            CarregarAlugueis();

            return tabelaAluguel;
        }

        public override string ObterTipoCadastro()
        {
            return "Cadastro de Aluguéis";            
        }        
    }
}
