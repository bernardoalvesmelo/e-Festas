using e_Festas.Dominio.ModuloAluguel;
using e_Festas.Dominio.ModuloCliente;
using e_Festas.Dominio.ModuloTema;
using Microsoft.Data.SqlClient;

namespace e_Festas.Infra.Dados.BancoDeDados.ModuloAluguel
{
    public class RepositorioAluguelEmBancoDeDados : IRepositorioAluguel
    {
        private const string INSERT_TEXTO =
                        @"INSERT INTO [TBALUGUEL] 
	                            (
		                            [SINAL]
                                    ,[DESCONTOAPLICADO]
                                    ,[DESCONTOVALOR]
                                    ,[DESCONTOMAXIMO]
                                    ,[DATA]
                                    ,[DATAQUITACAO]
                                    ,[HORARIOINICIO]
                                    ,[HORARIOTERMINO]
                                    ,[VALOR]
                                    ,[ENTRADA]
                                    ,[ENDERECO_CIDADE]
                                    ,[ENDERECO_RUA]
                                    ,[ENDERECO_NUMERO]
                                    ,[CLIENTE_ID]
                                    ,[TEMA_ID]
	                            )
	                            VALUES 
	                            (
		                            @SINAL
                                    ,@DESCONTOAPLICADO
                                    ,@DESCONTOVALOR
                                    ,@DESCONTOMAXIMO
                                    ,@DATA
                                    ,@DATAQUITACAO
                                    ,@HORARIOINICIO
                                    ,@HORARIOTERMINO
                                    ,@VALOR
                                    ,@ENTRADA
                                    ,@ENDERECOCIDADE
                                    ,@ENDERECORUA
                                    ,@ENDERECONUMERO
                                    ,@CLIENTE_ID
                                    ,@TEMA_ID
	                            );

                          Select Scope_Identity();";

        private const string UPDATE_TEXTO =
           @"UPDATE [TBALUGUEL] 
	                        SET 
		                       [SINAL] = @SINAL
                               ,[DESCONTOAPLICADO] = @DESCONTOAPLICADO
                               ,[DESCONTOVALOR] = @DESCONTOVALOR
                               ,[DESCONTOMAXIMO] = @DESCONTOMAXIMO
                               ,[DATA] = @DATA
                               ,[DATAQUITACAO] = @DATAQUITACAO
                               ,[HORARIOINICIO] = @HORARIOINICIO
                               ,[HORARIOTERMINO] = @HORARIOTERMINO
                               ,[VALOR] = @VALOR
                               ,[ENTRADA] = @ENTRADA
                               ,[ENDERECO_CIDADE] = @ENDERECOCIDADE
                               ,[ENDERECO_RUA] = @ENDERECORUA
                               ,[ENDERECO_NUMERO] = @ENDERECONUMERO
                               ,[CLIENTE_ID] = @CLIENTE_ID
                               ,[TEMA_ID] = @TEMA_ID
                            WHERE
		                         [ID] = @ID";

        private const string DELETE_TEXTO =
                        @"DELETE FROM [TBALUGUEL] 
	                        WHERE [ID] = @ID";

        private const string SELECT_TEXTO =
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
                           A.CLIENTE_ID = C.ID";

        private const string SELECT_ID_TEXTO =
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
	                          [ID] = @ID";
               
        public void Editar(int id, Aluguel aluguel)
        {
            SqlConnection conexao = ObterConexao();
            conexao.Open();

            SqlCommand comandoEdicao = ObterComando(UPDATE_TEXTO, conexao, aluguel);

            comandoEdicao.ExecuteNonQuery();

            conexao.Close();
        }

        public void Excluir(Aluguel aluguel)
        {
            SqlConnection conexao = ObterConexao();
            conexao.Open();

            SqlCommand comandoExclusao = ObterComando(DELETE_TEXTO, conexao, aluguel);

            comandoExclusao.ExecuteNonQuery();

            conexao.Close();
        }

        public void Inserir(Aluguel novoAluguel)
        {
            SqlConnection conexao = ObterConexao();
            conexao.Open();

            SqlCommand comandoInsercao = ObterComando(INSERT_TEXTO, conexao, novoAluguel);

            object id = comandoInsercao.ExecuteScalar();
            novoAluguel.id = Convert.ToInt32(id);

            conexao.Close();
        }

        public Aluguel SelecionarPorId(int id)
        {
            Aluguel aluguel = SelecionarTodos().Find(a => a.id == id);

            return aluguel;
        }

        public List<Aluguel> SelecionarTodos()
        {
            SqlConnection conexao = ObterConexao();
            conexao.Open();

            SqlCommand comandoSelecao = ObterComando(SELECT_TEXTO, conexao);

            SqlDataReader leitorAlugueis = comandoSelecao.ExecuteReader();

            List<Aluguel> alugueis = new List<Aluguel>();

            while (leitorAlugueis.Read())
            {
                alugueis.Add(ObterAluguel(leitorAlugueis));
            }

            foreach(Aluguel aluguel in alugueis)
            {
                aluguel.cliente.alugueis = alugueis.FindAll(a => a.cliente.id == aluguel.cliente.id);
                aluguel.AtualizarInformacoes(aluguel);
            }

            conexao.Close();

            return alugueis;
        }

        private Aluguel ObterAluguel(SqlDataReader leitorAlugueis)
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

            Cliente cliente = ObterCliente(leitorAlugueis);

            Tema tema = ObterTema(leitorAlugueis);

            string cidade = Convert.ToString(leitorAlugueis["ALUGUEL_ENDERECO_CIDADE"]);

            string rua = Convert.ToString(leitorAlugueis["ALUGUEL_ENDERECO_RUA"]);

            string numero = Convert.ToString(leitorAlugueis["ALUGUEL_ENDERECO_NUMERO"]);

            Endereco endereco = new Endereco(cidade, rua, numero);

            return new Aluguel(id, sinal, descontoAplicado, descontoValor, descontoMaximo, data, dataQuitacao, horarioInicio, horarioTermino, cliente, tema, endereco);
        }
        private Cliente ObterCliente(SqlDataReader leitorClientes)
        {

            int idCliente = Convert.ToInt32(leitorClientes["CLIENTE_ID"]);
            string nome = Convert.ToString(leitorClientes["CLIENTE_NOME"]);
            string telefone = Convert.ToString(leitorClientes["CLIENTE_TELEFONE"]);
            string email = Convert.ToString(leitorClientes["CLIENTE_EMAIL"]);

            return new Cliente(idCliente, nome, telefone, email);
        }

        private Tema ObterTema(SqlDataReader leitorTemas)
        {
            int idTema = Convert.ToInt32(leitorTemas["TEMA_ID"]);
            string nome = Convert.ToString(leitorTemas["TEMA_NOME"]);
            decimal valor = Convert.ToDecimal(leitorTemas["TEMA_VALOR"]);
            decimal valorTotal = Convert.ToDecimal(leitorTemas["TEMA_VALOR_TOTAL"]);

            Tema tema = new Tema(valor, nome, idTema, new List<ItemTema>());
            tema.valorTotal = valorTotal;

            return tema;
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

        private static SqlCommand ObterComando(string tipoComando, SqlConnection conexao, Aluguel aluguel = null)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            comando.CommandText = tipoComando;

            if(aluguel != null)
            {
                comando.Parameters.AddWithValue("ID", aluguel.id);

                comando.Parameters.AddWithValue("SINAL", aluguel.sinal);

                comando.Parameters.AddWithValue("DESCONTOAPLICADO", aluguel.descontoAplicado);

                comando.Parameters.AddWithValue("DESCONTOVALOR", aluguel.descontoValor);

                comando.Parameters.AddWithValue("DESCONTOMAXIMO", aluguel.descontoMaximo);

                comando.Parameters.AddWithValue("DATA", aluguel.data);

                DateTime dataQuitacaoAtualizada = aluguel.dataQuitacao == new DateTime() ?
                   aluguel.data : aluguel.dataQuitacao; 

                comando.Parameters.AddWithValue("DATAQUITACAO", dataQuitacaoAtualizada);

                comando.Parameters.AddWithValue("HORARIOINICIO", aluguel.horarioInicio);

                comando.Parameters.AddWithValue("HORARIOTERMINO", aluguel.horarioTermino);

                comando.Parameters.AddWithValue("VALOR", aluguel.valor);

                comando.Parameters.AddWithValue("ENTRADA", aluguel.entrada);

                comando.Parameters.AddWithValue("ENDERECOCIDADE", aluguel.endereco.cidade);

                comando.Parameters.AddWithValue("ENDERECORUA", aluguel.endereco.rua);

                comando.Parameters.AddWithValue("ENDERECONUMERO", aluguel.endereco.numero);

                comando.Parameters.AddWithValue("CLIENTE_ID", aluguel.cliente.id);

                comando.Parameters.AddWithValue("TEMA_ID", aluguel.tema.id);
            }

            return comando;
        }

        public List<Aluguel> SelecionarTodosEmAberto()
        {
            return SelecionarTodos().FindAll(a => a.dataQuitacao == new DateTime());
        }

        public List<Aluguel> SelecionarTodosPorEndereco(Aluguel aluguel)
        {
            return SelecionarTodos().FindAll(a => a.endereco.Equals(aluguel.endereco));
        }

    }
}
