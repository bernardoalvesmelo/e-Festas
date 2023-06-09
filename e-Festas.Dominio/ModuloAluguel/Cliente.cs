namespace e_Festas.Dominio.ModuloAluguel
{
    public class Cliente
    {
        public int id;
        public string nome;
        static Cliente instancia;

        static public Cliente Instancia
        {
            get
            {
                if(instancia == null)
                    instancia = new Cliente();
                return instancia;
            }
        }

        public Cliente()
        {
            this.id = 1;
            this.nome = "clienteTemporario";
        }

    }
}
