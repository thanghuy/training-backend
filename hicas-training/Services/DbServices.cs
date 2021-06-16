using hicas_training.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hicas_training.Services
{
    public class DbServices
    {
           
        public readonly DbContextTraining _context;
        public DbServices(DbContextTraining context) => _context = context;
    }
}
