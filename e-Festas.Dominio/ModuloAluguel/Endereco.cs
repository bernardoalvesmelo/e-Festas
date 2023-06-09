namespace e_Festas.Dominio.ModuloAluguel
{
    [Serializable]
    public class Endereco
    {
        public string pais;
        public string estado;
        public string cidade;
        public string bairro;
        public string cep;
        public string rua;
        public string numero;
        public string complemento;

        public Endereco()
        {
            
        }

        public Endereco(string pais, string estado, string cidade, string bairro, string cep, string rua, string numero, string complemento)
        {
            this.pais = pais;
            this.estado = estado;
            this.cidade = cidade;
            this.bairro = bairro;
            this.cep = cep;
            this.rua = rua;
            this.numero = numero;
            this.complemento = complemento;
        }

        public void AtualizarInformacoes(Endereco registroAtualizado)
        {
            this.pais = registroAtualizado.pais;
            this.estado = registroAtualizado.estado;
            this.cidade = registroAtualizado.cidade;
            this.bairro = registroAtualizado.bairro;
            this.cep = registroAtualizado.cep;
            this.rua = registroAtualizado.rua;
            this.numero = registroAtualizado.numero;
            this.complemento = registroAtualizado.complemento;
        }

        public override string ToString()
        {
            return "País: " + pais +
               ", Estado: " + estado +
               ", Cidade: " + cidade +
               ", Bairro: " + bairro +
               ", CEP: " + cep +
               ", Rua: " + rua +
               ", Número: " + numero +
               ", Complemento: " + complemento;
        }

        public string[] Validar()
        {
            List<string> erros = new List<string>();

            if (this.pais.Trim() == "")
                erros.Add("Campo País não pode ser vazio!");

            if (this.estado.Trim() == "")
                erros.Add("Campo Estado não pode ser vazio!");

            if (this.cidade.Trim() == "")
                erros.Add("Campo Cidade não pode ser vazio!");

            if (this.bairro.Trim() == "")
                erros.Add("Campo Bairro não pode ser vazio!");

            if (this.cep.Trim() == "")
                erros.Add("Campo CEP não pode ser vazio!");

            if (this.rua.Trim() == "")
                erros.Add("Campo Rua não pode ser vazio!");

            if (this.numero.Trim() == "")
                erros.Add("Campo Número não pode ser vazio!");

            return erros.ToArray();
        }

        public override bool Equals(object? obj)
        {
            return obj is Endereco endereco &&
                   pais == endereco.pais &&
                   estado == endereco.estado &&
                   cidade == endereco.cidade &&
                   bairro == endereco.bairro &&
                   cep == endereco.cep &&
                   rua == endereco.rua &&
                   numero == endereco.numero &&
                   complemento == endereco.complemento;
        }
    }
}
