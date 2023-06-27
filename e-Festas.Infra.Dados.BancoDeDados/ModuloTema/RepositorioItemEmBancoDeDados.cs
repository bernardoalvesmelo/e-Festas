using e_Festas.Dominio.ModuloTema;
using Microsoft.Data.SqlClient;

namespace e_Festas.Infra.Dados.BancoDeDados.ModuloTema
{
    public class RepositorioItemEmBancoDeDados : IRepositorioItem
    {      
        private const string INSERT_TEXTO =
                        @"INSERT INTO [TbItemTema] 
	                            (
		                            [NOME], 
		                            [VALORITEM]
	                            )
	                            VALUES 
	                            (
		                            @NOME, 
		                            @VALORITEM
	                            );

                          Select Scope_Identity();";

        private const string UPDATE_TEXTO =
           @"UPDATE [TbItemTema] 
	                        SET 
		                       [NOME] = @NOME,
		                       [VALORITEM] = @VALORITEM
	                           WHERE 
		                       [ID] = @ID";

        private const string DELETE_TEXTO =
                        @"DELETE FROM [TbItemTema] 
	                        WHERE [ID] = @ID";

        private const string SELECT_TEXTO =
                        @"SELECT 
	                            [ID], 
	                            [NOME], 
	                            [VALORITEM]
                          FROM 
	                          [TbItemTema]";

        private const string SELECT_ID_TEXTO =
                         @"SELECT 
	                        [ID], 
	                        [NOME],
                            [VALORITEM]
                           FROM 
	                            [TbItemTema]
                           WHERE 
	                            [ID] = @ID";


        public void Editar(int id, ItemTema item)
        {
            SqlConnection conexao = ObterConexao();
            conexao.Open();

            SqlCommand comandoEdicao = ObterComando(UPDATE_TEXTO, conexao, item);

            comandoEdicao.ExecuteNonQuery();

            conexao.Close();
        }

        public void Excluir(ItemTema item)
        {
            SqlConnection conexao = ObterConexao();
            conexao.Open();

            SqlCommand comandoExclusao = ObterComando(DELETE_TEXTO, conexao, item);

            comandoExclusao.ExecuteNonQuery();

            conexao.Close();
        }

        public void Inserir(ItemTema item)
        {
            SqlConnection conexao = ObterConexao();
            conexao.Open();

            SqlCommand comandoInsercao = ObterComando(INSERT_TEXTO, conexao, item);

            object id = comandoInsercao.ExecuteScalar();
            item.id = Convert.ToInt32(id);

            conexao.Close();
        }

        public ItemTema SelecionarPorId(int id)
        {
            SqlConnection conexao = ObterConexao();
            conexao.Open();

            SqlCommand comandoSelecao = ObterComando(SELECT_ID_TEXTO, conexao);

            comandoSelecao.Parameters.AddWithValue("ID", id);

            SqlDataReader leitorItens = comandoSelecao.ExecuteReader();

            ItemTema item = null;

            if (leitorItens.Read())
            {
                item = ObterItem(leitorItens);
            }

            conexao.Close();

            return item;
        }

        public List<ItemTema> SelecionarTodos()
        {
            SqlConnection conexao = ObterConexao();
            conexao.Open();

            SqlCommand comandoSelecao = ObterComando(SELECT_TEXTO, conexao);

            SqlDataReader leitorItens = comandoSelecao.ExecuteReader();

            List<ItemTema> itens = new List<ItemTema>();

            while (leitorItens.Read())
            {
                itens.Add(ObterItem(leitorItens));
            }

            conexao.Close();

            return itens;
        }
        private ItemTema ObterItem(SqlDataReader leitorItens)
        {
            int id = Convert.ToInt32(leitorItens["ID"]);
            string nome = Convert.ToString(leitorItens["NOME"]);
            decimal valorItem = Convert.ToDecimal(leitorItens["VALORITEM"]);

            return new ItemTema(id, nome, valorItem);
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

        private static SqlCommand ObterComando(string tipoComando, SqlConnection conexao, ItemTema item = null)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;
            comando.CommandText = tipoComando;

            if(item != null)
            {
                comando.Parameters.AddWithValue("ID", item.id);
                comando.Parameters.AddWithValue("NOME", item.nome);
                comando.Parameters.AddWithValue("VALORITEM", item.valorItem);
            }

            return comando;
        }
    }
}
