namespace e_Festas.Dominio.ModuloAluguel
{
    public class Tema
    {
        public int id;
        public string estilo;
        public decimal valorTotal;
        static Tema instancia;

        static public Tema Instancia
        {
            get
            {
                if(instancia == null)
                    instancia = new Tema();
                return instancia;
            }
        }

        public Tema()
        {
            this.id = 1;
            this.estilo = "temporário";
            this.valorTotal = 1000;
        }

    }
}
