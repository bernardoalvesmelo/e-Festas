namespace e_Festas.Dominio.ModuloAluguel
{
    [Serializable]
    public class Endereco
    {
        public string cidade;
        public string rua;
        public string numero;

        public Endereco()
        {
            
        }

        public Endereco(string cidade, string rua, string numero)
        {
            this.cidade = cidade;
            this.rua = rua;
            this.numero = numero;
        }

        public void AtualizarInformacoes(Endereco registroAtualizado)
        {     
            this.cidade = registroAtualizado.cidade;
            this.rua = registroAtualizado.rua;
            this.numero = registroAtualizado.numero;
        }

        public override string ToString()
        {
            return
               ", Cidade: " + cidade +
               ", Rua: " + rua +
               ", Número: " + numero;
        }

        public string[] Validar()
        {
            List<string> erros = new List<string>();

            if (this.cidade.Trim() == "")
                erros.Add("Campo Cidade não pode ser vazio!");

            if (this.rua.Trim().Length < 5)
                erros.Add("Campo Rua precisa de pelo menos 5 characteres!");

            if (this.numero.Trim() == "")
                erros.Add("Campo Número não pode ser vazio!");

            return erros.ToArray();
        }

        public override bool Equals(object? obj)
        {
            return obj is Endereco endereco &&
                   cidade == endereco.cidade &
                   rua == endereco.rua &&
                   numero == endereco.numero;
        }
    }
}
