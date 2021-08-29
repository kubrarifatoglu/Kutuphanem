using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace KutuphaneYonetim.Models
{
    
    public class KitaplarDB
    {
        private Microsoft.AspNetCore.Http.IHttpContextAccessor _httpContextAccessor;
    public KitaplarDB(Microsoft.AspNetCore.Http.IHttpContextAccessor httpContextAccessor)
    {
            this._httpContextAccessor = httpContextAccessor;
    }
        public DataTable KitaplariListele()
        {
            Metodlar dbMethods = new Metodlar();
            return dbMethods.GetDataTable("select * from kitaplar;");
        }

        public DataTable OkumaDurum(int kitapid)
        {
            Metodlar dbMethods = new Metodlar();
            return dbMethods.GetDataTable("select okuma from kitaplar order by kitapid ");
            // return dbMethods.GetDataTable("select okuma from kitaplar where kitapid =  '" + kitapid + "' ");
        }

        public int OkumaDurumDegis(int kitapid, bool okuma)
        {
            Metodlar dbMethods = new Metodlar();
            return dbMethods.cmd("update kitaplar set okuma = '"+okuma+"' where kitapid= "+kitapid);
            // return dbMethods.GetDataTable("select okuma from kitaplar where kitapid =  '" + kitapid + "' ");
        }
        public DataTable KitapEkle(int kitapid, string kitapadi, string kitapozet, string yazar, bool begeni, bool okuma)
        {
            Metodlar dbMethods = new Metodlar();
            return dbMethods.GetDataTable(@"INSERT INTO public.kitaplar(kitapid,kitapadi,kitapozet,yazar,begeni,okuma)
                                         VALUES('" + kitapid + "','" + kitapadi + "','" + kitapozet + "', '" + yazar + "', '" + begeni + "', '" + okuma + "'); ");

    
        }
        public DataTable BegenmeDurum(int kitapid)
        {
            Metodlar dbMethods = new Metodlar();
            return dbMethods.GetDataTable("select begeni from kitaplar order by kitapid ");
            // return dbMethods.GetDataTable("select okuma from kitaplar where kitapid =  '" + kitapid + "' ");
        }
        public int BegenmeDurumDegis(int kitapid, bool begeni)
        {
            Metodlar dbMethods = new Metodlar();
            return dbMethods.cmd("update kitaplar set begeni = '" + begeni + "' where kitapid= " + kitapid);
            // return dbMethods.GetDataTable("select okuma from kitaplar where kitapid =  '" + kitapid + "' ");
        }
        public DataTable Okunanlar()
        {
            Metodlar dbMethods = new Metodlar();
            return dbMethods.GetDataTable("select * from kitaplar where okuma= true order by kitapid ");
        }
        public DataTable Begenilenler()
        {
            Metodlar dbMethods = new Metodlar();
            return dbMethods.GetDataTable("select * from kitaplar where begeni= true order by kitapid ");
        }
    }
}
