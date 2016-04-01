using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

public partial class StoredProcedures
{
    [Microsoft.SqlServer.Server.SqlProcedure]
    public static void SPCustomerReturnParamCustomer (Int32 ParamCustomerID, DateTime ParamRentDate)
    {
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = "Context Connection=true";
        SqlCommand cmd = new SqlCommand(); cmd.Connection = conn;
        conn.Open();
        cmd.CommandText = "select CONCAT(dbo.Kund.FNamn, ' ', dbo.Kund.ENamn) as kund, dbo.Film.FilmNamn, dbo.Film.FilmID, Uthyrningsdatum, Tillbakadatum from[dbo].[UthyrningKundFilm] join[dbo].[Kund] on[dbo].[UthyrningKundFilm].KundID = [dbo].[Kund].KundID join[dbo].[Film] on[dbo].[UthyrningKundFilm].FilmID = [dbo].[Film].FilmID where dbo.UthyrningKundFilm.KundID = @ParamCustomerID and Uthyrningsdatum = @ParamDate select sum(DATEDIFF(day, Uthyrningsdatum, Tillbakadatum) * Hyrkostnad) as summa from[dbo].[UthyrningKundFilm] where KundID = @ParamCustomerID SELECT sum(KundID) as 'Antal filmer hyrda vid valt datum' FROM[dbo].[UthyrningKundFilm] where KundID = @ParamCustomerID and Uthyrningsdatum = @ParamDate";
        //TODO: får inte mina subquerys att visas i browser.. 
        SqlParameter paramCustomer = new SqlParameter();
        paramCustomer.Value = ParamCustomerID;
        paramCustomer.Direction = ParameterDirection.Input;
        paramCustomer.DbType = DbType.Int32;
        paramCustomer.ParameterName = "@ParamCustomerID";
        cmd.Parameters.Add(paramCustomer);

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
