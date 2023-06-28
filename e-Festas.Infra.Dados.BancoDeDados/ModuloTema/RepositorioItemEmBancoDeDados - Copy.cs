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


        private const string INSERT_ITEM_TEXTO =
            @"INSERT INTO [TBTema_TBItemTema]
                (
                    [Tema_Id]
                   ,[ItemTema_Id])
            VALUES
                (
                    @Tema_Id
                   ,@ItemTema_Id
                )";

        private const string SELECT_ITEM_TEXTO =
            @"SELECT 
	            I.ID            ITEM_ID, 
	            I.NOME          ITEM_NOME, 
	            I.VALORITEM     ITEM_VALORITEM
            FROM 
	            TBITEMTEMA AS I 
	
	            INNER JOIN TBTEMA_TBITEMTEMA AS TI
		
		            ON I.ID = TI.ITEMTEMA_ID
            WHERE 

	            TI.TEMA_ID = @TEMA_ID";

        private const string DELETE_ITEM_TEXTO =
            @"DELETE FROM TBTEMA_TBITEMTEMA 
                WHERE TEMA_ID = @TEMA_ID AND ITEMTEMA_ID = @ITEMTEMA_ID";



        public void Editar(int id, Tema tema)
        {
            tema.CalcularValorTotal();

            List<ItemTema> itensNovos = tema.itemTemas;
            List<ItemTema> itensPassados = SelecionarPorId(id).itemTemas;

            foreach (ItemTema item in itensNovos)
            {
                if (itensPassados.Find(i => i.id == item.id) != null)
                    AdicionarItem(item, tema);
            }

            foreach (ItemTema item in itensPassados)
            {
                if (itensNovos.Find(i => i.id == item.id) == null)
                    RemoverItem(item, tema);
            }

            SqlConnection conexao = ObterConexao();
            conexao.Open();

            SqlCommand comandoEdicao = ObterComando(UPDATE_TEXTO, conexao, tema);

            comandoEdicao.ExecuteNonQuery();

            conexao.Close();
        }

        public void Excluir(Tema tema)
        {
            List<ItemTema> itensPassados = tema.itemTemas;

            foreach(ItemTema item in itensPassados)
            {
                RemoverItem(item, tema);
            }

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

            List<ItemTema> itensNovos = tema.itemTemas;

            foreach (ItemTema item in itensNovos)
            {
                AdicionarItem(item, tema);
            }
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

            if(tema != null)
            {
                tema.itemTemas = SelecionarTodosItens(tema.id);
            }

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

        private void AdicionarItem(ItemTema item, Tema tema)
        {
            SqlConnection conexao = ObterConexao();
            conexao.Open();

            SqlCommand comandoAdicionar = ObterComando(INSERT_ITEM_TEXTO, conexao);

            comandoAdicionar.Parameters.AddWithValue("Tema_Id", tema.id);
            comandoAdicionar.Parameters.AddWithValue("ItemTema_Id", item.id);

            comandoAdicionar.ExecuteNonQuery();

            conexao.Close();
        }

        private void RemoverItem(ItemTema item, Tema tema)
        {
            SqlConnection conexao = ObterConexao();
            conexao.Open();

            SqlCommand comandoAdicionar = ObterComando(DELETE_ITEM_TEXTO, conexao);

            comandoAdicionar.Parameters.AddWithValue("Tema_Id", tema.id);
            comandoAdicionar.Parameters.AddWithValue("ItemTema_Id", item.id);

            comandoAdicionar.ExecuteNonQuery();

            conexao.Close();
        }

        private List<ItemTema> SelecionarTodosItens(int id)
        {
            SqlConnection conexao = ObterConexao();
            conexao.Open();

            SqlCommand comandoSelecao = ObterComando(SELECT_ITEM_TEXTO, conexao);

            comandoSelecao.Parameters.AddWithValue("TEMA_ID", id);
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
            int id = Convert.ToInt32(leitorItens["ITEM_ID"]);
            string nome = Convert.ToString(leitorItens["ITEM_NOME"]);
            decimal valorItem = Convert.ToDecimal(leitorItens["ITEM_VALORITEM"]);

            return new ItemTema(id, nome, valorItem);
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
