using Npgsql;
using project.Exception;
using project.Models;
using project.Models.Data_Transfer_Object;

namespace project.Services
{
    public class DbService : IOperations
    {


        private const string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=123456;Database=Door";


        // Add
        public Response Add(DoorDto Add_doorDto)
        {
            Response response = new Response();
            try
            {

                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    using (var cmd = new NpgsqlCommand("INSERT INTO doors (name, x, y) VALUES (@name, @x, @y)", connection))
                    {
                     
                        cmd.Parameters.AddWithValue("x", Add_doorDto.x);
                        cmd.Parameters.AddWithValue("y", Add_doorDto.y);
                        cmd.Parameters.AddWithValue("name", Add_doorDto.name);

                        cmd.ExecuteNonQuery();
                    }
                }
              
            }
            catch (System.Exception exception)
            {
                response = new Response { Message = exception.Message };

            }
            return response;

        }
        public List<Door> GetAll()
        {
            List<Door> doors = new List<Door>();
            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    using (var cmd = new NpgsqlCommand("SELECT id, name, x, y FROM doors ORDER BY id", connection))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Door door = new Door
                                {
                                    id = reader.GetInt32(0),
                                    name = reader.GetString(1),
                                    x = reader.GetDouble(2),
                                    y = reader.GetDouble(3)
                                };

                                doors.Add(door);
                            }
                        }
                    }
                }
            }
            catch (System.Exception)
            {
                // Handle exceptions
            }
            return doors;
        }



        // Update
        public Response Update(DoorDto updateDoorDto)
        {
            Response response = new Response();
            try
            {

                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    using (var cmd = new NpgsqlCommand("UPDATE doors SET x = @x, y = @y, name = @name WHERE id = @id", connection))
                    {
                        cmd.Parameters.AddWithValue("id", updateDoorDto.id);
                        cmd.Parameters.AddWithValue("x", updateDoorDto.x);
                        cmd.Parameters.AddWithValue("y", updateDoorDto.y);
                        cmd.Parameters.AddWithValue("name", updateDoorDto.name);

                        cmd.ExecuteNonQuery();
                    }
                }
               
            }
            catch (System.Exception)
            {
                response = new Response();

            }
            return response;

        }

        // Delete
        public Response Delete(int id)
        {
            Response response = new Response();
            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    using (var cmd = new NpgsqlCommand("DELETE FROM doors WHERE id = @id", connection))
                    {
                        cmd.Parameters.AddWithValue("id", id);

                        cmd.ExecuteNonQuery();
                    }
                  
                }

            }
            catch (System.Exception exception)
            {
                response = new Response { Message = exception.Message };

            }
            return response;
        }

        // GetById
        public Response GetById(int id)
        {
            Response response = new Response();
            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    using (var cmd = new NpgsqlCommand("SELECT id, x, y, name FROM doors WHERE id = @id", connection))
                    {
                        cmd.Parameters.AddWithValue("id", id);

                        cmd.ExecuteNonQuery();
                        using var reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            var door = new Door
                            {
                                id = reader.GetInt32(0),
                                x = reader.GetInt32(1),
                                y = reader.GetInt32(2),
                                name = reader.GetString(3)
                            };
                        }
                    }

                }

            }
            catch (System.Exception)
            {
                response = new Response();
            }
            return response;
        }

  
    }
}
