
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Npgsql;
/// <summary>
/// Summary description for Fonksiyon
/// </summary>
public class Metodlar
{
    public Metodlar()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public NpgsqlConnection baglan()
    {
        string constr = "User ID=pmcxffwcovbraz;Password=şifre;Host=ec2-54-228-139-34.eu-west-1.compute.amazonaws.com;Port=5432;Database=d4e0mf1mi5g7b4;Pooling=true;SSL Mode=Require;TrustServerCertificate=True;";
        
        //string constr =  String.Format("Server={0};Port={1};" +
        //"User Id={2};Password={3};Database={4};", "ec2-54-228-139-34.eu-west-1.compute.amazonaws.com", 5432, "pmcxffwcovbraz", "28baaf308332c943008a7377617744cacbe911ce4eb644767dbb833cd6a2a2f4", "d4e0mf1mi5g7b4", "sslmode=Require", "Trust Server Certificate=true");
        
        NpgsqlConnection baglanti = new NpgsqlConnection(constr);
        NpgsqlConnection.ClearPool(baglanti);
        NpgsqlConnection.ClearAllPools();
        if (baglanti.State != ConnectionState.Open)
            baglanti.Open();
        return (baglanti);
    }
    public int cmd(string sqlcumle)
    {
        NpgsqlConnection baglan = this.baglan();
        NpgsqlCommand sorgu = new NpgsqlCommand(sqlcumle);
        sorgu.Connection = baglan;
        int sonuc = 0;
        try
        {
            sonuc = sorgu.ExecuteNonQuery();
        }
        catch (Exception)
        {

        }
        sorgu.Dispose();
        baglan.Close();
        baglan.Dispose();
        return (sonuc);
    }

    public DataTable GetDataTable(string sql)
    {
        NpgsqlConnection baglanti = this.baglan();
        NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(sql, baglanti);
        DataTable dt = new DataTable();
        try
        {
            adapter.Fill(dt);
        }
        catch (Exception)
        {
        }
        
        adapter.Dispose();
        baglanti.Close();
        baglanti.Dispose();
        return dt;

    }

    public DataRow GetDataRow(string sql)
    {
        DataTable table = GetDataTable(sql);
        if (table.Rows.Count == 0) return null;
        return table.Rows[0];
    }

    public string GetDataCell(string sql)
    {
        DataTable table = GetDataTable(sql);
        if (table.Rows.Count == 0) return null;
        string cell = table.Rows[0][0].ToString();


        return cell;
    }
    public int GetScalar(string sql)
    {
        NpgsqlConnection baglan = this.baglan();
        NpgsqlCommand sorgu = new NpgsqlCommand(sql, baglan);

        var sonuc = sorgu.ExecuteScalar();
        sorgu.Dispose();
        baglan.Close();
        baglan.Dispose();

        return Convert.ToInt16(sonuc);
    }
    public void CloseConnection() {
        string constr = String.Format("Server={0};Port={1};" +
        "User Id={2};Password={3};Database={4};", "ec2-54-228-139-34.eu-west-1.compute.amazonaws.com", 5432, "pmcxffwcovbraz", "28baaf308332c943008a7377617744cacbe911ce4eb644767dbb833cd6a2a2f4", "d4e0mf1mi5g7b4");
    NpgsqlConnection baglanti = new NpgsqlConnection(constr);
        NpgsqlConnection.ClearPool(baglanti);
        NpgsqlConnection.ClearAllPools();
        if (baglanti.State == ConnectionState.Open)
        {
            baglanti.Close();
            baglanti.Dispose();
        }
    }
}

