using e_Festas.Dominio.ModuloTema;
using Microsoft.Data.SqlClient;

namespace e_Festas.Infra.Dados.BancoDeDados.ModuloTema
{
    public class RepositorioTemaEmBancoDeDados : IRepositorioTema
    {      
        private const string INSERT_TEXTO =
                        @"INSERT INTO [TbTema] 
	                            (
		                            [NOME], 
		                            [VALOR],
                                    [VALORTOTAL]
	                            )
	                            VALUES 
	                            (
		                            @NOME, 
		                            @VALOR,
                                    @VALORTOTAL
	                            );

                          Select Scope_Identity();";

        private const string UPDATE_TEXTO =
           @"UPDATE [TbTema] 
	                        SET 
		                       [NOME] = @NOME,
                               [VALOR] = @VALOR,
		                       [VALORTOTAL] = @VALORTOTAL
	                           WHERE 
		                       [ID] = @ID";

        private const string DELETE_TEXTO =
                        @"DELETE FROM [TbTema] 
	                        WHERE [ID] = @ID";

        private const string SELECT_TEXTO =
                        @"SELECT 
	                            [ID], 
	                            [NOME], 
	                            [VALOR],
                                [VALORTOTAL]
                          FROM 
	                          [TbTema]";

        private const string SELECT_ID_TEXTO =
                         @"SELECT 
	                        [ID], 
	                        [NOME],
                            [VALOR],
                            [VALORTOTAL]
                           FROM 
	                            [TbTema]
                           WHERE 
	                            [ID] = @ID";


        public void Editar(int id, Tema tema)
        {
            tema.CalcularValorTotal();
            SqlConnection conexao = ObterConexao();
            conexao.Open();

            SqlCommand comandoEdicao = ObterComando(UPDATE_TEXTO, conexao, tema);

            comandoEdicao.ExecuteNonQuery();

            conexao.Close();
        }

        public void Excluir(Tema tema)
        {
            SqlConnection conexao = ObterConexao();
            conexao.Open();

            SqlCommand comandoExclusao = ObterComando(DELETE_TEXTO, conexao, tema);

            comandoExclusao.ExecuteNonQuery();

            conexao.Close();
        }

        public void Inserir(Tema tema)
        {
            tema.CalcularValorTotal();
            SqlConnection conexao = ObterConexao();
            conexao.Open();

            SqlCommand comandoInsercao = ObterComando(INSERT_TEXTO, conexao, tema);

            object id = comandoInsercao.ExecuteScalar();
            tema.id = Convert.ToInt32(id);

            conexao.Close();
        }

        public Tema SelecionarPorId(int id)
        {
            SqlConnection conexao = ObterConexao();
            conexao.Open();

            SqlCommand comandoSelecao = ObterComando(SELECT_ID_TEXTO, conexao);

            comandoSelecao.Parameters.AddWithValue("ID", id);

            SqlDataReader leitorTemas = comandoSelecao.ExecuteReader();

            Tema tema = null;

            if (leitorTemas.Read())
            {
                tema = ObterTema(leitorTemas);
            }

            conexao.Close();

            return tema;
        }

        public List<Tema> SelecionarTodos()
        {
            SqlConnection conexao = ObterConexao();
            conexao.Open();

            SqlCommand comandoSelecao = ObterComando(SELECT_TEXTO, conexao);

            SqlDataReader leitorTemas = comandoSelecao.ExecuteReader();

            List<Tema> temas = new List<Tema>();

            while (leitorTemas.Read())
            {
                temas.Add(ObterTema(leitorTemas));
            }

            conexao.Close();

            return temas;
        }
        private Tema ObterTema(SqlDataReader leitorTemas)
        {
            int id = Convert.ToInt32(leitorTemas["ID"]);
            string nome = Convert.ToString(leitorTemas["NOME"]);
            decimal valor = Convert.ToDecimal(leitorTemas["VALOR"]); 
            decimal valorTotal = Convert.ToDecimal(leitorTemas["VALORTOTAL"]);

            Tema tema = new Tema(valor, nome, id, new List<ItemTema>());
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

        private static SqlCommand ObterComando(string tipoComando, SqlConnection conexao, Tema tema = null)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            comando.CommandText = tipoComando;

            if(tema != null)
            {
                comando.Parameters.AddWithValue("ID", tema.id);
                comando.Parameters.AddWithValue("NOME", tema.nome);
                comando.Parameters.AddWithValue("VALOR", tema.valor);
                comando.Parameters.AddWithValue("VALORTOTAL", tema.valorTotal);
            }

            return comando;
        }
    }
}
