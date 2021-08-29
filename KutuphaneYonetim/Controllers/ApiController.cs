using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions.Common;
using KutuphaneYonetim.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace KutuphaneYonetim.Controllers
{
    public class ApiController
    {
        private static string connString = String.Format("Server={0};Port={1};" +
        "User Id={2};Password={3};Database={4};", "ec2-54-228-139-34.eu-west-1.compute.amazonaws.com", 5432, "pmcxffwcovbraz", "şifre", "d4e0mf1mi5g7b4");

        IHttpContextAccessor _httpContextAccessor;
        public ApiController(IHttpContextAccessor httpContextAccessor)
        {
            this._httpContextAccessor = httpContextAccessor;
        }
        [HttpGet]
        [Route("API/Kitaplar")]
        public string Kitaplar(int kitapid, string kitapadi, string kitapozet, string yazar, bool begeni, bool okuma)
        {
            var db = new KitaplarDB(_httpContextAccessor);

            return JsonConvert.SerializeObject(db.KitaplariListele());


        }
        [HttpGet]
        [Route("API/OkumaDurum")]
        public string OkumaDurum(int kitapid)
        {
            var db = new KitaplarDB(_httpContextAccessor);

            return JsonConvert.SerializeObject(db.OkumaDurum(kitapid));


        }

        [HttpGet]
        [Route("API/OkumaDurumDegis")]
        public string OkumaDurumDegis(int kitapid, bool okuma)
        {
            var db = new KitaplarDB(_httpContextAccessor);

            return JsonConvert.SerializeObject(db.OkumaDurumDegis(kitapid, okuma));


        }

        [HttpGet]
        [Route("API/KitapEkle")]
        public string KitapEkle(int kitapid, string kitapadi, string kitapozet, string yazar, bool begeni, bool okuma)
        {
            var db = new KitaplarDB(_httpContextAccessor);

            return JsonConvert.SerializeObject(db.KitapEkle(kitapid, kitapadi, kitapozet, yazar, begeni, okuma));


        }
        [HttpGet]
        [Route("API/BegenmeDurum")]
        public string BegenmeDurum(int kitapid)
        {
            var db = new KitaplarDB(_httpContextAccessor);

            return JsonConvert.SerializeObject(db.BegenmeDurum(kitapid));
        }


        [HttpGet]
        [Route("API/BegenmeDurumDegis")]
        public string BegenmeDurumDegis(int kitapid, bool begeni)
        {
            var db = new KitaplarDB(_httpContextAccessor);

            return JsonConvert.SerializeObject(db.BegenmeDurumDegis(kitapid, begeni));


        }
        [HttpGet]
        [Route("API/Okunanlar")]
        public string Okunanlar()
        {
            var db = new KitaplarDB(_httpContextAccessor);

            return JsonConvert.SerializeObject(db.Okunanlar());


        }
        [HttpGet]
        [Route("API/Begenilenler")]
        public string Begenilenler()
        {
            var db = new KitaplarDB(_httpContextAccessor);

            return JsonConvert.SerializeObject(db.Begenilenler());


        }

        



    }
}
