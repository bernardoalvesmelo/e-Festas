using e_Festas.Dominio.ModuloAluguel;

namespace e_Festas.Dominio.ModuloTema
{
    public class ItemTema : EntidadeBase<ItemTema>
    {
        public int id;
        public string nome;
        public decimal valorItem;

        public ItemTema(int id,string nome,decimal valorItem)
        {
           this.id = id;
           this.nome = nome;
           this.valorItem = valorItem;
        }

        public ItemTema()
        {

        }

        public override string ToString()
        {
            return nome;
        }

        public override bool Equals(object? obj)
        {
           return obj is ItemTema itemTema && 
                nome == itemTema.nome && 
                valorItem == itemTema.valorItem;
        }

        public override void AtualizarInformacoes(ItemTema registroAtualizado)
        {
            this.id = registroAtualizado.id;
            this.nome = registroAtualizado.nome;
            this.valorItem = registroAtualizado .valorItem;
        }

        public override string[] Validar()
        {
            List<string> erros = new List<string>();
          
            if (string.IsNullOrEmpty(nome))
                erros.Add("O campo 'nome' é obrigatório");
            if (string.IsNullOrEmpty(id.ToString()))
                erros.Add("O campo 'Id' é obrigatório");
            if (string.IsNullOrEmpty(valorItem.ToString()))
                erros.Add("O campo 'Valor' é obrigatório");

            return erros.ToArray();
        }
    }
}
