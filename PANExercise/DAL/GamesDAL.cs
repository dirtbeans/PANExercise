using PANExercise.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
//added Client to be able to use SqlConnection
using System.Linq;
using System.Web;

namespace PANExercise.DAL
{
    public class GamesDAL
    {
        private readonly string connectionString;
        const string SQL_GetAllGames = "SELECT * FROM games";
        const string SQL_GetOneGame = "SELECT * FROM games WHERE game_code = @gameCode";
        const string SQL_EditGame = "UPDATE games SET game_name = @GameName, min_player = @MinPlayer, max_player = @MaxPlayer WHERE game_code = @gameCode";
        //const string SQL_Check_For_Duplicates = "SELECT COUNT (game_code) FROM games WHERE game_name = @GameName";


        public GamesDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Game> GetAllGames()
        {
            List<Game> games = new List<Game>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_GetAllGames, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Game g = new Game();

                        g.GameCode = Convert.ToInt32(reader["game_code"]);
                        g.GameName = Convert.ToString(reader["game_name"]);
                        g.MinPlayer = Convert.ToInt32(reader["min_player"]);
                        g.MaxPlayer = Convert.ToInt32(reader["max_player"]);

                        games.Add(g);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return games;
        }

        public Game GetOneGame(int gameCode)
        {
            Game game = new Game();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_GetOneGame, conn);

                    cmd.Parameters.AddWithValue("@gameCode", gameCode);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        game.GameCode = Convert.ToInt32(reader["game_code"]);
                        game.GameName = Convert.ToString(reader["game_name"]);
                        game.MinPlayer = Convert.ToInt32(reader["min_player"]);
                        game.MaxPlayer = Convert.ToInt32(reader["max_player"]);

                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            return game;

        }

        public void AddGame(Game game)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(@"INSERT INTO games VALUES (@game_name, @min_player, @max_player)", conn);
                    cmd.Parameters.AddWithValue("@game_name", game.GameName);
                    cmd.Parameters.AddWithValue("@min_player", game.MinPlayer);
                    cmd.Parameters.AddWithValue("@max_player", game.MaxPlayer);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

        }

        public void EditTheGame(Game gameCode)
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_EditGame, conn);
                    cmd.Parameters.AddWithValue("@gameCode", gameCode.GameCode);
                    cmd.Parameters.AddWithValue("@GameName", gameCode.GameName);
                    cmd.Parameters.AddWithValue("@MinPlayer", gameCode.MinPlayer);
                    cmd.Parameters.AddWithValue("@MaxPlayer", gameCode.MaxPlayer);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        //public bool CheckForDuplicates(Game game)
        //{
        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        conn.Open();

        //        SqlCommand cmd = new SqlCommand(SQL_Check_For_Duplicates, conn);
        //        cmd.Parameters.AddWithValue("@game_code", game.GameCode);
        //        cmd.Parameters.AddWithValue("@game_name", game.GameName);
        //        cmd.Parameters.AddWithValue("@min_player", game.MinPlayer);
        //        cmd.Parameters.AddWithValue("@max_player", game.MaxPlayer);

        //        int value = (int)cmd.ExecuteScalar();
        //        if (value == 0)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }

        //}

        //public void DeleteGame(int gameCode)
        //{
        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(connectionString))
        //        {
        //            conn.Open();

        //            SqlCommand cmd = new SqlCommand(SQL_DeleteGame, conn);
        //            cmd.Parameters.AddWithValue("@game_code", gameCode);
        //            cmd.ExecuteNonQuery();
        //        }
        //    }
        //    catch (SqlException ex)
        //    {
        //        throw ex;
        //    }

        //}




    }
    }
