namespace e_Festas.Dominio.ModuloAluguel
{
    [Serializable]
    public class Aluguel : EntidadeBase<Aluguel>
    {
        public decimal valor;
        public decimal sinal;
        public decimal entrada;
        public bool descontoAplicado;
        public DateTime data;
        public DateTime dataQuitacao;
        public DateTime horarioInicio;
        public DateTime horarioTermino;
        public Cliente cliente;
        public Tema tema;
        public Endereco endereco;

        public Aluguel()
        {
            
        }

        public Aluguel(decimal sinal, bool descontoAplicado, DateTime data, DateTime dataQuitacao, DateTime horarioInicio, DateTime horarioTermino, Cliente cliente, Tema tema, Endereco endereco)
        {
            this.sinal = sinal;
            this.descontoAplicado = descontoAplicado;
            this.data = data;
            this.dataQuitacao = dataQuitacao;
            this.horarioInicio = horarioInicio;
            this.horarioTermino = horarioTermino;
            this.cliente = cliente;
            this.tema = tema;
            this.endereco = endereco;
            this.valor = CalcularValor();
            this.entrada = CalcularEntrada();
        }


        public Aluguel(int id, decimal sinal, bool descontoAplicado, DateTime data, DateTime dataQuitacao, DateTime horarioInicio, DateTime horarioTermino, Cliente cliente, Tema tema, Endereco endereco)
        {
            this.id = id;
            this.sinal = sinal;
            this.descontoAplicado = descontoAplicado;
            this.data = data;
            this.dataQuitacao = dataQuitacao;
            this.horarioInicio = horarioInicio;
            this.horarioTermino = horarioTermino;
            this.cliente = cliente;
            this.tema = tema;
            this.endereco = endereco;
            this.valor = CalcularValor();
            this.entrada = CalcularEntrada();
        }


        public override void AtualizarInformacoes(Aluguel registroAtualizado)
        {
            this.valor = registroAtualizado.valor;
            this.sinal = registroAtualizado.sinal;
            this.descontoAplicado = registroAtualizado.descontoAplicado;
            this.entrada = registroAtualizado.entrada;
            this.data = registroAtualizado.data;
            this.dataQuitacao = registroAtualizado.dataQuitacao;
            this.horarioInicio = registroAtualizado.horarioInicio;
            this.horarioTermino = registroAtualizado.horarioTermino;
            this.cliente = registroAtualizado.cliente;
            this.tema = registroAtualizado.tema;
            this.endereco = registroAtualizado.endereco;
        }

        public void DescontarValor(List<Aluguel> alugueis)
        {
            int numeroAlugueis = alugueis.FindAll(
                a => a.cliente.id == this.cliente.id 
                && (a.id < this.id || this.id == 0)
                ).Count();
            double desconto = numeroAlugueis > 4 ? 0.8 :  1 - (numeroAlugueis * 0.05);
            this.valor = this.valor * (decimal)desconto;

            this.entrada = CalcularEntrada();
        }

        private decimal CalcularValor()
        {
            return tema.valorTotal * (horarioTermino.Hour + 1 - horarioInicio.Hour);
        }

        private decimal CalcularEntrada()
        {
            return this.valor * sinal / 100;
        }

        public override string ToString()
        {
            return "Id: " + id +
                ", Valor: " + Math.Round(valor, 2) +
                ", Entrada: " + Math.Round(sinal, 2) +
                ", Data: " + data.ToString("dd/MM/yyyy") +
                ", Quitação: " + (dataQuitacao == new DateTime() ? "Em Aberto" :
                dataQuitacao.ToString("dd/MM/yyyy")) +
                ", Início: " + data.ToString("HH:mm") +
                ", Término: " + data.ToString("HH:mm") +
                ", Cliente: " + cliente.nome +
                ", Tema: " + tema.estilo +
                ", Endereco: " + endereco.cep;
        }

        public override string[] Validar()
        {
            List<string> erros = new List<string>();

            if (horarioInicio >= horarioTermino)
                erros.Add("Horário de início precisa ser menor que de término!");

            if (
                data > dataQuitacao 
                && dataQuitacao != new DateTime()
               )
                erros.Add("Data não pode ser maior que data de quitação!");

            return erros.ToArray();
        }

        public override bool Equals(object? obj)
        {
            return obj is Aluguel aluguel &&
                   id == aluguel.id &&
                   valor == aluguel.valor &&
                   sinal == aluguel.sinal &&
                   descontoAplicado == aluguel.descontoAplicado &&
                   entrada == aluguel.entrada &&
                   data == aluguel.data &&
                   dataQuitacao == aluguel.dataQuitacao &&
                   horarioInicio == aluguel.horarioInicio &&
                   horarioTermino == aluguel.horarioTermino &&
                   EqualityComparer<Cliente>.Default.Equals(cliente, aluguel.cliente) &&
                   EqualityComparer<Tema>.Default.Equals(tema, aluguel.tema) &&
                   EqualityComparer<Endereco>.Default.Equals(endereco, aluguel.endereco);
        }
    }
}
