using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EBANK.Data;
using Microsoft.AspNetCore.Mvc;

namespace EBANK.Models.AdministratorRepository
{
    public class AdministratoriProxy : IAdministratori
    {
        IAdministratori administratori;

        public AdministratoriProxy(OOADContext context)
        {
            administratori = new Administratori(context);
        }

        public Task<Administrator> DajAdministratora(string korisnickoIme)
        {
            return administratori.DajAdministratora(korisnickoIme);
        }
        public Task<Administrator> DajAdministratora(int? id)
        {
            return administratori.DajAdministratora(id);
        }
    }
}
