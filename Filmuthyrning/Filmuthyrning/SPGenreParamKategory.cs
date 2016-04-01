using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

public partial class StoredProcedures
{
    [Microsoft.SqlServer.Server.SqlProcedure]
    public static void SPGenreParamKategory (String ParamGenre)
    {
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = "Context Connection=true";
        SqlCommand cmd = new SqlCommand(); cmd.Connection = conn;
        conn.Open();
        cmd.CommandText = "select count(*) as Antal, dbo.Film.Kategori from[dbo].[UthyrningKundFilm] join[dbo].[Film] on[dbo].[UthyrningKundFilm].FilmID = [dbo].[Film].FilmID where Kategori = @ParamGenre group by dbo.Film.Kategori";

        SqlParameter paramNumberGenre = new SqlParameter();
        paramNumberGenre.Value = ParamGenre;
        paramNumberGenre.Direction = ParameterDirection.Input;
        paramNumberGenre.DbType = DbType.String;
        paramNumberGenre.ParameterName = "@ParamGenre";

        cmd.Parameters.Add(paramNumberGenre);
        SqlDataReader sqldr = cmd.ExecuteReader();
        SqlContext.Pipe.Send(sqldr);
        sqldr.Close();
        conn.Close();
    }
}
