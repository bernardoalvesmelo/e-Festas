namespace e_Festas.Dominio.ModuloTema
{
    public class ItemTema 
    {
        public string nome;
        public decimal valorItem;

        public ItemTema(string nome,decimal valorItem)
        {
           this.nome = nome;
           this.valorItem = valorItem;
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

    }
}
