﻿using e_Festas.Dominio.ModuloAluguel;

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

        public override void Inserir()
        {
            List<Cliente> clientes = new List<Cliente>
            {
                Cliente.Instancia
            };

            List<Tema> temas = new List<Tema>
            {
                Tema.Instancia
            };

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
            Aluguel aluguel = ObterAluguelSelecionado();

            if (aluguel == null)
            {
                MessageBox.Show($"Selecione um aluguel primeiro!", 
                    "Edição de Aluguéis",
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Exclamation);

                return;
            }

            List<Cliente> clientes = new List<Cliente>
            {
                Cliente.Instancia
            };

            List<Tema> temas = new List<Tema>
            {
                Tema.Instancia
            };

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

        private void CarregarAlugueis()
        {
            List<Aluguel> alugueis = repositorioAluguel.SelecionarTodos();

            tabelaAluguel.AtualizarRegistros(alugueis);            
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