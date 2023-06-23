﻿using e_Festas.Dominio.ModuloCliente;
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
                clientes.Add(ObterCliente(leitorClientes));
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

    }
}
