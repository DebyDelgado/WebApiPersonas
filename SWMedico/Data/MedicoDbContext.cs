using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SWMedico.Models;

namespace SWMedico.Data
{
    public class MedicoDbContext
    {
        public MedicoDbContext(DBContextOptions<MedicoDbContext> options): base (options)
        { }
        public DbSet<Medico> Medicos { get; set; }
    }
}
