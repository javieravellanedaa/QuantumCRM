using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using BE;

namespace DAL
{
    public class TicketDAL
    {
        private string _connectionString = @"Integrated Security=SSPI;Data Source=.\SQLEXPRESS;Initial Catalog=CRM";

        public void GuardarTicket(Ticket ticket)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO Ticket (Id, UsuarioId, CategoriaId, Tipo) VALUES (@Id, @UsuarioId, @CategoriaId, @Tipo)", conn, transaction);
                        cmd.Parameters.AddWithValue("@Id", ticket.Id);
                        cmd.Parameters.AddWithValue("@UsuarioId", ticket.UsuarioCreador.Id);
                        cmd.Parameters.AddWithValue("@CategoriaId", ticket.Categoria.CategoriaId);
                        cmd.Parameters.AddWithValue("@Tipo", ticket.Tipo);
                        cmd.ExecuteNonQuery();

                       

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public Ticket ObtenerTicketPorId(Guid id)
        {
            Ticket ticket = null;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "SELECT t.Id, t.UsuarioId, t.CategoriaId, t.Tipo FROM Ticket t WHERE t.Id = @Id";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            ticket = new Ticket
                            {
                                Id = (Guid)reader["Id"],
                                UsuarioCreador = new Usuario { Id = (Guid)reader["UsuarioId"] },
                                Categoria = new Categoria { CategoriaId = (int)reader["CategoriaId"] },
                                Tipo = reader["Tipo"].ToString(),
                                
                            };
                        }
                    }
                }
            }
            return ticket;
        }

        public List<Ticket> ListarTodosLosTickets()
        {
            List<Ticket> tickets = new List<Ticket>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "SELECT t.Id, t.UsuarioId, t.CategoriaId, t.Tipo, u.Nombre as UsuarioNombre, c.Nombre as CategoriaNombre FROM Ticket t JOIN Usuario u ON t.UsuarioId = u.Id JOIN Categoria c ON t.CategoriaId = c.Id";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var ticket = new Ticket
                            {
                                Id = (Guid)reader["Id"],
                                UsuarioCreador = new Usuario { Id = (Guid)reader["UsuarioId"], Nombre = reader["UsuarioNombre"].ToString() },
                                Categoria = new Categoria { CategoriaId = (int)reader["CategoriaId"], Nombre = reader["CategoriaNombre"].ToString() },
                                Tipo = reader["Tipo"].ToString(),
                              
                            };
                            tickets.Add(ticket);
                        }
                    }
                }
            }
            return tickets;
        }

        public void ActualizarTicket(Ticket ticket)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("UPDATE Ticket SET UsuarioId = @UsuarioId, CategoriaId = @CategoriaId, Tipo = @Tipo WHERE Id = @Id", conn, transaction);
                        cmd.Parameters.AddWithValue("@Id", ticket.Id);
                        cmd.Parameters.AddWithValue("@UsuarioId", ticket.UsuarioCreador.Id);
                        cmd.Parameters.AddWithValue("@CategoriaId", ticket.Categoria.CategoriaId);
                        cmd.Parameters.AddWithValue("@Tipo", ticket.Tipo);
                        cmd.ExecuteNonQuery();

                        cmd = new SqlCommand("DELETE FROM TicketCampo WHERE TicketId = @TicketId", conn, transaction);
                        cmd.Parameters.AddWithValue("@TicketId", ticket.Id);
                        cmd.ExecuteNonQuery();

                   

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public void EliminarTicket(Guid id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmd = new SqlCommand("DELETE FROM TicketCampo WHERE TicketId = @TicketId", conn, transaction);
                        cmd.Parameters.AddWithValue("@TicketId", id);
                        cmd.ExecuteNonQuery();

                        cmd = new SqlCommand("DELETE FROM Ticket WHERE Id = @Id", conn, transaction);
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.ExecuteNonQuery();

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }


        
    }
}
