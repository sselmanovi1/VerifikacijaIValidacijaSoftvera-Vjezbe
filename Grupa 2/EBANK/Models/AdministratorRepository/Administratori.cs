using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EBANK.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EBANK.Models.AdministratorRepository
{
    public class Administratori : IAdministratori
    {

        private OOADContext _context;

        public Administratori(OOADContext context)
        {
            _context = context;
        }

        public async Task<Administrator> DajAdministratora(string korisnickoIme)
        {
            return await _context.Administrator.Where(m => m.KorisnickoIme == korisnickoIme).FirstOrDefaultAsync();
        }

        public async Task<Administrator> DajAdministratora(int? id)
        {
            return await _context.Administrator.Where(m => m.Id == id).FirstOrDefaultAsync();
        }
    }
}
