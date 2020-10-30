using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EBANK.Models.AdministratorRepository
{
    interface IAdministratori
    {
        public Task<Administrator> DajAdministratora(string? korisnickoIme);
        public Task<Administrator> DajAdministratora(int? id);

    }
}
