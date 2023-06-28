using e_Festas.Dominio.ModuloAluguel;
using e_Festas.Dominio.ModuloCliente;
using e_Festas.Dominio.ModuloTema;
using e_Festas.Infra.Dados.BancoDeDados.ModuloAluguel;
using Microsoft.Data.SqlClient;

namespace e_Festas.Infra.Dados.BancoDeDados.ModuloCliente
{
    public class RepositorioClienteEmBancoDeDados : IRepositorioCliente
    {      
        private const string INSERT_TEXTO =
                        @"INSERT INTO [TBCLIENTE] 
	                            (
		                            [NOME], 
		                            [TELEFONE],
                                    [EMAIL]
	                            )
	                            VALUES 
	                            (
		                            @NOME, 
		                            @TELEFONE,
                                    @EMAIL
	                            );

                          Select Scope_Identity();";

        private const string UPDATE_TEXTO =
           @"UPDATE [TBCLIENTE] 
	                        SET 
		                       [NOME] = @NOME,
		                       [TELEFONE] = @TELEFONE,
                               [EMAIL] = @EMAIL
	                           WHERE 
		                       [ID] = @ID";

        private const string DELETE_TEXTO =
                        @"DELETE FROM [TBCliente] 
	                        WHERE [ID] = @ID";

        private const string SELECT_TEXTO =
                        @"SELECT 
	                            [ID], 
	                            [NOME], 
	                            [TELEFONE],
                                [EMAIL]
                          FROM 
	                          [TBCLIENTE]";

        private const string SELECT_ID_TEXTO =
                         @"SELECT 
	                        [ID], 
	                        [NOME], 
	                        [TELEFONE],
                            [EMAIL]
                           FROM 
	                            [TBCLIENTE]
                           WHERE 
	                            [ID] = @ID";

        private const string SELECT_TEXTO_ALUGUEL =
                        @"SELECT 
	                            A.[ID]				       ALUGUEL_ID
                                ,A.[SINAL]			       ALUGUEL_SINAL
                                ,A.[DESCONTOAPLICADO]	   ALUGUEL_DESCONTO_APLICADO
                                ,A.[DESCONTOVALOR]	       ALUGUEL_DESCONTO_VALOR
                                ,A.[DESCONTOMAXIMO]		   ALUGUEL_DESCONTO_MAXIMO
                                ,A.[DATA]				   ALUGUEL_DATA
                                ,A.[DATAQUITACAO]		   ALUGUEL_DATA_QUITACAO
                                ,A.[HORARIOINICIO]	       ALUGUEL_HORARIO_INICIO
                                ,A.[HORARIOTERMINO]        ALUGUEL_HORARIO_TERMINO
                                ,A.[VALOR]				   ALUGUEL_VALOR
                                ,A.[ENTRADA]			   ALUGUEL_ENTRADA
                                ,A.[ENDERECO_CIDADE]	   ALUGUEL_ENDERECO_CIDADE
                                ,A.[ENDERECO_RUA]		   ALUGUEL_ENDERECO_RUA
                                ,A.[ENDERECO_NUMERO]	   ALUGUEL_ENDERECO_NUMERO
      
	                            ,T.[ID]                    TEMA_ID
                                ,T.[NOME]                  TEMA_NOME
	                            ,T.[VALOR]                 TEMA_VALOR
                                ,T.[VALORTOTAL]            TEMA_VALOR_TOTAL

                                ,C.[ID]                    CLIENTE_ID
                                ,C.[NOME]                  CLIENTE_NOME
                                ,C.[TELEFONE]              CLIENTE_TELEFONE
                                ,C.[EMAIL]                 CLIENTE_EMAIL
                        FROM
                            [DBO].[TBALUGUEL] AS A INNER JOIN [DBO].[TBTEMA] AS T
                        ON
                           A.TEMA_ID = T.ID INNER JOIN [DBO].[TBCLIENTE] AS C
                        ON
                           A.CLIENTE_ID = C.ID
						WHERE               
							C.ID = @CLIENTE_ID";


        public void Editar(int id, Cliente cliente)
        {
            SqlConnection conexao = ObterConexao();
            conexao.Open();

            SqlCommand comandoEdicao = ObterComando(UPDATE_TEXTO, conexao, cliente);

            comandoEdicao.ExecuteNonQuery();

            conexao.Close();
        }

        public void Excluir(Cliente cliente)
        {
            SqlConnection conexao = ObterConexao();
            conexao.Open();

            SqlCommand comandoExclusao = ObterComando(DELETE_TEXTO, conexao, cliente);

            comandoExclusao.ExecuteNonQuery();

            conexao.Close();
        }

        public void Inserir(Cliente novoCliente)
        {
            SqlConnection conexao = ObterConexao();
            conexao.Open();

            SqlCommand comandoInsercao = ObterComando(INSERT_TEXTO, conexao, novoCliente);

            object id = comandoInsercao.ExecuteScalar();
            novoCliente.id = Convert.ToInt32(id);

            conexao.Close();
        }

        public Cliente SelecionarPorId(int id)
        {
            SqlConnection conexao = ObterConexao();
            conexao.Open();

            SqlCommand comandoSelecao = ObterComando(SELECT_ID_TEXTO, conexao);

            comandoSelecao.Parameters.AddWithValue("ID", id);

            SqlDataReader leitorClientes = comandoSelecao.ExecuteReader();

            Cliente cliente = null;

            if (leitorClientes.Read())
            {
                cliente = ObterCliente(leitorClientes);
                cliente.alugueis = SelecionarTodosAlugueis(cliente);
            }

            conexao.Close();

            return cliente;
        }

        public List<Cliente> SelecionarTodos()
        {
            SqlConnection conexao = ObterConexao();
            conexao.Open();

            SqlCommand comandoSelecao = ObterComando(SELECT_TEXTO, conexao);

            SqlDataReader leitorClientes = comandoSelecao.ExecuteReader();

            List<Cliente> clientes = new List<Cliente>();

            while (leitorClientes.Read())
            {
                Cliente cliente = ObterCliente(leitorClientes);
                cliente.alugueis = SelecionarTodosAlugueis(cliente);
                clientes.Add(cliente);
            }           

            conexao.Close();

            return clientes;
        }
        private Cliente ObterCliente(SqlDataReader leitorClientes)
        {
            int idCliente = Convert.ToInt32(leitorClientes["ID"]);
            string nome = Convert.ToString(leitorClientes["NOME"]);
            string telefone = Convert.ToString(leitorClientes["TELEFONE"]);
            string email = Convert.ToString(leitorClientes["EMAIL"]);

            return new Cliente(idCliente, nome, telefone, email);
        }

        private static SqlConnection ObterConexao()
        {
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString =
                @"Data Source=(LocalDb)\MSSqlLocalDb;
                Initial Catalog=eFestasDb;
                Integrated Security=True;
                Pooling=False";
            return conexao;
        }

        private static SqlCommand ObterComando(string tipoComando, SqlConnection conexao, Cliente cliente = null)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            comando.CommandText = tipoComando;

            if(cliente != null)
            {
                comando.Parameters.AddWithValue("ID", cliente.id);
                comando.Parameters.AddWithValue("NOME", cliente.nome);
                comando.Parameters.AddWithValue("TELEFONE", cliente.telefone);
                comando.Parameters.AddWithValue("EMAIL", cliente.email);
            }

            return comando;
        }

        public List<Aluguel> SelecionarTodosAlugueis(Cliente cliente)
        {
            SqlConnection conexao = ObterConexao();
            conexao.Open();

            SqlCommand comandoSelecao = ObterComando(SELECT_TEXTO_ALUGUEL, conexao);
            comandoSelecao.Parameters.AddWithValue("CLIENTE_ID", cliente.id);

            SqlDataReader leitorAlugueis = comandoSelecao.ExecuteReader();

            List<Aluguel> alugueis = new List<Aluguel>();

            while (leitorAlugueis.Read())
            {
                alugueis.Add(ObterAluguel(leitorAlugueis, cliente));
            }

            conexao.Close();

            return alugueis;
        }

        private Aluguel ObterAluguel(SqlDataReader leitorAlugueis, Cliente cliente)
        {
            int id = Convert.ToInt32(leitorAlugueis["ALUGUEL_ID"]);

            decimal sinal = Convert.ToDecimal(leitorAlugueis["ALUGUEL_SINAL"]);

            bool descontoAplicado = Convert.ToBoolean(leitorAlugueis["ALUGUEL_DESCONTO_APLICADO"]);

            decimal descontoValor = Convert.ToDecimal(leitorAlugueis["ALUGUEL_DESCONTO_VALOR"]);

            decimal descontoMaximo = Convert.ToDecimal(leitorAlugueis["ALUGUEL_DESCONTO_MAXIMO"]);

            DateTime data = Convert.ToDateTime(leitorAlugueis["ALUGUEL_DATA"]);

            DateTime dataQuitacao = Convert.ToDateTime(leitorAlugueis["ALUGUEL_DATA_QUITACAO"]);

            dataQuitacao = data.Equals(dataQuitacao) ? new DateTime() : dataQuitacao;

            DateTime horarioInicio = Convert.ToDateTime(leitorAlugueis["ALUGUEL_HORARIO_INICIO"]);

            DateTime horarioTermino = Convert.ToDateTime(leitorAlugueis["ALUGUEL_HORARIO_TERMINO"]);

            Tema tema = ObterTemaAluguel(leitorAlugueis);

            string cidade = Convert.ToString(leitorAlugueis["ALUGUEL_ENDERECO_CIDADE"]);

            string rua = Convert.ToString(leitorAlugueis["ALUGUEL_ENDERECO_RUA"]);

            string numero = Convert.ToString(leitorAlugueis["ALUGUEL_ENDERECO_NUMERO"]);

            Endereco endereco = new Endereco(cidade, rua, numero);

            return new Aluguel(id, sinal, descontoAplicado, descontoValor, descontoMaximo, data, dataQuitacao, horarioInicio, horarioTermino, cliente, tema, endereco);
        }

        private Tema ObterTemaAluguel(SqlDataReader leitorTemas)
        {
            int idTema = Convert.ToInt32(leitorTemas["TEMA_ID"]);
            string nome = Convert.ToString(leitorTemas["TEMA_NOME"]);
            decimal valor = Convert.ToDecimal(leitorTemas["TEMA_VALOR"]);
            decimal valorTotal = Convert.ToDecimal(leitorTemas["TEMA_VALOR_TOTAL"]);

            Tema tema = new Tema(valor, nome, idTema, new List<ItemTema>());
            tema.valorTotal = valorTotal;

            return tema;
        }

    }
}
