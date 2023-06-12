using e_Festas.Dominio.ModuloContato;
using e_Festas.Dominio.ModuloAluguel;
using System.Text.Json;
using System.Text.Json.Serialization;
using e_Festas.Dominio.ModuloTema;
using e_Festas.Infra.Dados.Arquivo.ModuloTema;

namespace e_Festas.Infra.Dados.Arquivo.Compartilhado
{
    public class ContextoDados
    {
        private const string NOME_ARQUIVO = "Compartilhado\\e-Festas.json";

        public List<Contato> contatos;

        public List<Aluguel> alugueis;
       
        public List<Temas> temas;
        
        public ContextoDados()
        {
            contatos = new List<Contato>();
            alugueis = new List<Aluguel>();
            temas = new List<Temas>();
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

                    this.contatos = ctx.contatos;
                    this.alugueis = ctx.alugueis;
                    this.temas = ctx.temas;
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
