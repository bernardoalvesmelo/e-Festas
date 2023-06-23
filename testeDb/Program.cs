using e_Festas.Dominio.ModuloCliente;
using System.Data.SqlClient;

namespace testeDb
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cliente novoCliente = ObterCliente();

            Inserir(novoCliente);
        }

        private static List<Cliente> SelecionarTodos()
        {
            SqlConnection conexao = ObterConexao();
            conexao.Open();

            SqlCommand comandoSelecao = ObterComando(ComandoEnum.SELECT, conexao);

            SqlDataReader leitorClientes = comandoSelecao.ExecuteReader();

            List<Cliente> clientes = new List<Cliente>();

            while (leitorClientes.Read())
            {
                int idCliente = Convert.ToInt32(leitorClientes["ID"]);
                string nome = Convert.ToString(leitorClientes["NOME"]);
                string telefone = Convert.ToString(leitorClientes["TELEFONE"]);
                string email = Convert.ToString(leitorClientes["EMAIL"]);

                Cliente cliente = new Cliente(idCliente, nome, telefone, email);

                clientes.Add(cliente);
            }

            conexao.Close();

            return clientes;
        }

        private static void Excluir(int id)
        {
            SqlConnection conexao = ObterConexao();
            conexao.Open();

            SqlCommand comandoExclusao = ObterComando(ComandoEnum.DELETE, conexao);
            comandoExclusao.Parameters.AddWithValue("ID", id);

            int linhasAfetadas = comandoExclusao.ExecuteNonQuery();

            conexao.Close();
        }

        private static void Editar(Cliente cliente)
        {
            SqlConnection conexao = ObterConexao();
            conexao.Open();

            SqlCommand comandoEdicao = ObterComando(ComandoEnum.UPDATE, conexao);

            comandoEdicao.Parameters.AddWithValue("ID", cliente.id);
            comandoEdicao.Parameters.AddWithValue("N", cliente.nome);
            comandoEdicao.Parameters.AddWithValue("T", cliente.telefone);
            comandoEdicao.Parameters.AddWithValue("E", cliente.email);
                
            int linhasAfetadas = comandoEdicao.ExecuteNonQuery();

            conexao.Close();
        }

        private static Cliente SelecionarPorId(int idPesquisado)
        {
            SqlConnection conexao = ObterConexao();
            conexao.Open();

            SqlCommand comandoSelecao = ObterComando(ComandoEnum.SELECT_ID, conexao);

            comandoSelecao.Parameters.AddWithValue("ID", idPesquisado);

            SqlDataReader leitorClientes = comandoSelecao.ExecuteReader();

            Cliente cliente = null;

            if (leitorClientes.Read())
            {
                int idCliente = Convert.ToInt32(leitorClientes["ID"]);
                string nome = Convert.ToString(leitorClientes["NOME"]);
                string telefone = Convert.ToString(leitorClientes["TELEFONE"]);
                string email = Convert.ToString(leitorClientes["EMAIL"]); 
                
                cliente = new Cliente(idCliente, nome, telefone, email);
            }

            conexao.Close();

            return cliente;
        }

        private static void Inserir(Cliente novoCliente)
        {
            SqlConnection conexao = ObterConexao();
            conexao.Open();

            SqlCommand comandoInsercao = ObterComando(ComandoEnum.INSERT, conexao);

            comandoInsercao.Parameters.AddWithValue("N", novoCliente.nome);
            comandoInsercao.Parameters.AddWithValue("T", novoCliente.telefone);
            comandoInsercao.Parameters.AddWithValue("E", novoCliente.email);

            object id = comandoInsercao.ExecuteScalar();

            novoCliente.id = Convert.ToInt32(id);
            conexao.Close();
        }

        private static SqlCommand ObterComando(ComandoEnum tipoComando, SqlConnection conexao)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexao;

            switch (tipoComando)
            {
                case ComandoEnum.INSERT:
                    comando.CommandText =
                        @"INSERT INTO [TBCLIENTE] 
	                            (
		                            [NOME], 
		                            [TELEFONE],
                                    [EMAIL]
	                            )
	                            VALUES 
	                            (
		                            @N, 
		                            @T,
                                    @E
	                            );";

                    comando.CommandText += "Select Scope_Identity();";
                    break;
                case ComandoEnum.UPDATE:
                    comando.CommandText =
                    @"UPDATE [TBCLIENTE] 
	                        SET 
		                       [NOME] = @N,
		                       [TELEFONE] = @T
                               [EMAIL] = @E
	                           WHERE 
		                       [ID] = @ID";
                    break;
                case ComandoEnum.DELETE:
                    comando.CommandText =
                        @"DELETE FROM [TBCliente] 
	                        WHERE [ID] = @ID";
                    break;
                case ComandoEnum.SELECT:
                    comando.CommandText =
                        @"SELECT 
	                            [ID], 
	                            [NOME], 
	                            [TELEFONE],
                                [EMAIL]
                          FROM 
	                          [TBCLIENTE]";
                    break;
                case ComandoEnum.SELECT_ID:
                    comando.CommandText =
                        @"SELECT 
	                        [ID], 
	                        [NOME], 
	                        [TELEFONE]
                            [EMAIL]
                      FROM 
	                      [TBCLIENTE]
                      WHERE 
	                       [ID] = @ID";
                    break;
            }

            return comando;
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

        private static Cliente ObterCliente()
        {
            Console.Write("Digite o nome: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o telefone: ");
            string telefone = Console.ReadLine();

            Console.Write("Digite o email: ");
            string email = Console.ReadLine();

            return new Cliente(nome, telefone, email);
        }

        public enum ComandoEnum
        {
            INSERT,
            UPDATE,
            DELETE,
            SELECT,
            SELECT_ID
        }
    }
}