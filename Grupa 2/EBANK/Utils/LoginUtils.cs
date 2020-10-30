using EBANK.Data;
using EBANK.Models;
using EBANK.Models.AdministratorRepository;
using EBANK.Models.BankarRepository;
using EBANK.Models.KlijentRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBANK.Utils
{
    public class LoginUtils
    {
        
        public static async Task<Korisnik> Authenticate(HttpRequest Request, OOADContext Context, Controller Controller)
        {
            IAdministratori _administratori = new Administratori(Context);
            IBankari _bankari = new Bankari(Context);
            IKlijenti _klijenti = new Klijenti(Context);

            if (Request.Cookies["userId"] == null || Request.Cookies["userId"].Equals("")) return null;
            

            var userId = int.Parse(Request.Cookies["userId"]);
            var role = Request.Cookies["role"];

            if (role == "Administrator") return await _administratori.DajAdministratora(userId);
            else if (role == "Bankar") return await _bankari.DajBankara(userId);
            else if (role == "Klijent") return await _klijenti.DajKlijenta(userId);
            else return null;
        }
    }
}
