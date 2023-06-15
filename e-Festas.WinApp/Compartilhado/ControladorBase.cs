﻿namespace e_Festas.WinApp.Compartilhado
{
    public abstract class ControladorBase
    {
        public abstract string ToolTipInserir { get; }

        public abstract string ToolTipEditar { get; }

        public abstract string ToolTipExcluir { get; }

        public virtual string? ToolTipVisualizar { get; }

        public virtual string? ToolTipFiltrar  {get; }

        public virtual string? ToolTipAdicionarItens { get; }

        public virtual string? ToolTipConcluir { get; }

        public virtual string? ToolTipConfigurar { get; }

        public virtual bool InserirHabilitado { get { return true; } }
        public virtual bool EditarHabilitado { get { return true; } }
        public virtual bool ExcluirHabilitado { get { return true; } }
        public virtual bool VisualizarHabilitado { get { return false; } }
        public virtual bool AdicionarItensHabilitado { get { return false; } }
        public virtual bool FiltrarHabilitado { get { return false; } }
        public virtual bool ConcluirHabilitado { get { return false; } }
        public virtual bool ConfigurarHabilitado { get { return false; } }

        public abstract void Inserir();

        public abstract void Editar();

        public abstract void Excluir();

        public virtual void Visualizar()
        {

        }

        public virtual void Adicionar()
        {

        }

        public virtual void Filtrar()
        {

        }

        public virtual void Concluir()
        {
            
        }

        public virtual void Configurar()
        {

        }

        public abstract UserControl ObterListagem();

        public abstract string ObterTipoCadastro();
    }
}
