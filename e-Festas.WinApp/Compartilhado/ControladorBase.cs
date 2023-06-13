namespace e_Festas.WinApp.Compartilhado
{
    public abstract class ControladorBase
    {
        public abstract string ToolTipInserir { get; }

        public abstract string ToolTipEditar { get; }

        public abstract string ToolTipExcluir { get; }

        public virtual string ToolTipVisualizar => "Indisponível";

        public virtual string? ToolTipAdicionarItens { get; }

        public virtual bool InserirHabilitado { get { return true; } }
        public virtual bool EditarHabilitado { get { return true; } }
        public virtual bool ExcluirHabilitado { get { return true; } }
        public virtual bool VisualizarHabilitado { get { return false; } }
        public virtual bool AdicionarItensHabilitado { get { return false; } }

        public abstract void Inserir();

        public abstract void Editar();

        public abstract void Excluir();

        public virtual void Visualizar()
        {

        }

        public abstract UserControl ObterListagem();

        public abstract string ObterTipoCadastro();

        public virtual void Adicionar()
        {

        }

    }

}
