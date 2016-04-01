using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

public partial class StoredProcedures
{
    [Microsoft.SqlServer.Server.SqlProcedure]
    public static void SPReturnMovieParamDate (DateTime ParamRentDate)
    {
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = "Context Connection=true";
        SqlCommand cmd = new SqlCommand(); cmd.Connection = conn;
        conn.Open();
        cmd.CommandText = "select CONCAT(dbo.Kund.FNamn, ' ', dbo.Kund.ENamn) AS Kund, dbo.Film.FilmNamn AS Titel, dbo.Film.FilmID AS KopiaNr, Uthyrningsdatum, Tillbakadatum from[dbo].[UthyrningKundFilm] join[dbo].[Kund] on[dbo].[UthyrningKundFilm].KundID = [dbo].[Kund].KundID join[dbo].[Film] on[dbo].[UthyrningKundFilm].FilmID = [dbo].[Film].FilmID where Tillbakadatum = @ParamDate";

        SqlParameter paramRent = new SqlParameter();
        paramRent.Value = ParamRentDate;
        paramRent.Direction = ParameterDirection.Input;
        paramRent.DbType = DbType.Date;
        paramRent.ParameterName = "@ParamDate";
        cmd.Parameters.Add(paramRent);

        SqlDataReader sqldr = cmd.ExecuteReader();
        SqlContext.Pipe.Send(sqldr);
        sqldr.Close();
        conn.Close();
    }
}
