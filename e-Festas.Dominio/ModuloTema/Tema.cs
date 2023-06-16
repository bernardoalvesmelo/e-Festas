using e_Festas.Dominio.ModuloAluguel;

namespace e_Festas.Dominio.ModuloTema
{
    public class Tema : EntidadeBase<Tema>
    {     
        public decimal valor;
        public string nome;      
        public List<ItemTema> itemTemas;
        public decimal valorTotal;  
        
        public Tema()
        {

        }

        public Tema(decimal valor, string nome, int id, List<ItemTema> itemTemas)
        {
            this.valor = valor;
            this.nome = nome;
            this.id = id;
            this.itemTemas = itemTemas;
        }

        public void AdicionarItem(ItemTema item)
        {
            itemTemas.Add(item);
        }

        public override void AtualizarInformacoes(Tema registroAtualizado)
        {
            this.valor = registroAtualizado.valor;
            this.nome= registroAtualizado.nome;
            this.id= registroAtualizado.id;
            this.itemTemas = registroAtualizado.itemTemas;
        }

        public override string[] Validar()
        {
            List<string> erros = new List<string>();

            if (string.IsNullOrEmpty(nome))
                erros.Add("O campo 'nome' é obrigatório");
            if (string.IsNullOrEmpty(id.ToString()))
                erros.Add("O campo 'Id' é obrigatório");

            return erros.ToArray();
        }
        
        public void CalcularValorTotal()
        {
            decimal resultado = 0;

            foreach (ItemTema item in itemTemas)
            {
                resultado += item.valorItem;
            }

            valorTotal = valor + resultado;
        }
    }
}
