namespace e_Festas.Dominio.ModuloTema
{
    public class Temas : EntidadeBase<Temas>
    {
        private ItemTema itemTema;
        public decimal valor;
        public string nome;      
        public List<ItemTema> itemTemas;
        public decimal valorTotal;      

        public Temas(decimal valor, string nome, int id)
        {
            this.valor = valor;
            this.nome = nome;
            this.id = id;
            itemTemas = new List<ItemTema>();
        }

        public void AdicionarItem(ItemTema item)
        {
            itemTemas.Add(item);
        }

        public override void AtualizarInformacoes(Temas registroAtualizado)
        {
            this.valor = registroAtualizado.valor;
            this.nome= registroAtualizado.nome;
            this.id= registroAtualizado.id;
        }

        public override string[] Validar()
        {
            List<string> erros = new List<string>();

            if (string.IsNullOrEmpty(nome))
                erros.Add("O campo 'nome' é obrigatório");

            return erros.ToArray();
        }     
    }
}
