using e_Festas.Dominio.ModuloCliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using e_Festas.Dominio.ModuloAluguel;

namespace e_Festas.Dominio.ModuloCliente
{
    public class Cliente :  EntidadeBase<Cliente>
    {
        public string nome { get; set; }

        public string telefone;
        public string email;

        public List<Aluguel> alugueis = new List<Aluguel>();
        
        public Cliente()
        {

        }

        public Cliente(int id, string nome, string telefone, string email)
        {
            this.id = id;
            this.nome = nome;
            this.telefone = telefone;
            this.email = email;
        }
        public Cliente(string nome, string telefone, string email )
        {
            this.nome = nome;
            this.telefone = telefone;
            this.email = email;
           
        }

        public override void AtualizarInformacoes(Cliente registroAtualizado)
        {
            this.nome = registroAtualizado.nome;
            this.telefone = registroAtualizado.telefone;
            this.email = registroAtualizado.email;
            
        }

        public override string ToString()
        {
            return "Id: " + id + ", " + nome + ", Email: " + email;
        }

        public override string[] Validar()
        {
            List<string> erros = new List<string>();
            

           int nomeerro = nome.Count(); 

            if (string.IsNullOrEmpty(nome))
                erros.Add("O campo 'nome' é obrigatório");

            if (string.IsNullOrEmpty(telefone))
                erros.Add("O campo 'telefone' é obrigatório");

            if (string.IsNullOrEmpty(email))
                erros.Add("O campo 'email' é obrigatório");
         

            if (nomeerro < 4)
            {
                erros.Add("O campo 'NOME', deve ter pelo menos 4 caracteres.");
            }

            if (MailAddress.TryCreate(email, out _) == false)
            {
                erros.Add("O campo 'EMAIL' não esta em formato valido.");
            }

             

            return erros.ToArray();

        }

        public override bool Equals(object? obj)
        {
            return obj is Cliente cliente &&
                   id == cliente.id &&
                   nome == cliente.nome &&
                   telefone == cliente.telefone &&
                   email == cliente.email &&
                   EqualityComparer<List<Aluguel>>.Default.Equals(alugueis, cliente.alugueis);
        }
    }
}
