﻿using e_Festas.Dominio.ModuloCliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace e_Festas.Dominio.ModuloCliente
{
    public class Cliente :  EntidadeBase<Cliente>
    {
        public string nome { get; set; }

        public string telefone;
        public string email;
        
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

            if (string.IsNullOrEmpty(nome))
                erros.Add("O campo 'nome' é obrigatório");

            if (string.IsNullOrEmpty(telefone))
                erros.Add("O campo 'telefone' é obrigatório");

            if (string.IsNullOrEmpty(email))
                erros.Add("O campo 'email' é obrigatório");

            if (MailAddress.TryCreate(email, out _) == false)
            {
                erros.Add("O campo email não esta em formato valido.");
            }

            return erros.ToArray();

        }

        public override bool Equals(object? obj)
        {
            return obj is Cliente Cliente &&
                   id == Cliente.id &&
                   nome == Cliente.nome &&
                   telefone == Cliente.telefone &&
                   email == Cliente.email;
        }
    }
}
