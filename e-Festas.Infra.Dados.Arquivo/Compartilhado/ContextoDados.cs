﻿using e_Festas.Dominio.ModuloAluguel;
using System.Text.Json;
using System.Text.Json.Serialization;
using e_Festas.Dominio.ModuloTema;
using e_Festas.Dominio.ModuloCliente;

namespace e_Festas.Infra.Dados.Arquivo.Compartilhado
{
    public class ContextoDados
    {
        private const string NOME_ARQUIVO = "Compartilhado\\e-Festas.json";

        public List<Aluguel> alugueis;
       
        public List<Tema> temas;
        
        public List<Cliente> clientes;

        public List<ItemTema> itemTemas;

        public ContextoDados()
        {
            alugueis = new List<Aluguel>();
            temas = new List<Tema>();
            clientes = new List<Cliente>();
            itemTemas = new List<ItemTema>();
        }

        public ContextoDados(bool carregarDados) : this()
        {
            if (carregarDados)
                CarregarDoArquivoJson();
        }

        public void GravarEmArquivoJson()
        {
            JsonSerializerOptions config = ObterConfiguracoes();

            string registrosJson = JsonSerializer.Serialize(this, config);            

            File.WriteAllText(NOME_ARQUIVO, registrosJson);
        }

        private void CarregarDoArquivoJson()
        {
            JsonSerializerOptions config = ObterConfiguracoes();

            if (File.Exists(NOME_ARQUIVO))
            {
                string registrosJson = File.ReadAllText(NOME_ARQUIVO);

                if (registrosJson.Length > 0)
                {
                    ContextoDados ctx = JsonSerializer.Deserialize<ContextoDados>(registrosJson, config);

                    this.alugueis = ctx.alugueis;
                    this.temas = ctx.temas;
                    this.clientes = ctx.clientes;
                    this.itemTemas = ctx.itemTemas;
                }
            }
        }

        private static JsonSerializerOptions ObterConfiguracoes()
        {
            JsonSerializerOptions opcoes = new JsonSerializerOptions();
            opcoes.IncludeFields = true;
            opcoes.WriteIndented = true;
            opcoes.ReferenceHandler = ReferenceHandler.Preserve;

            return opcoes;
        }
    }
}
