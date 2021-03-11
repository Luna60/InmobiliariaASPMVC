using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaASPMVC.Datos
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly InmobiliariaDbContext _context;

        public UnitOfWork(InmobiliariaDbContext context)
        {
            _context = context;
        }

        public void Save() 
        {
            _context.SaveChanges();

        }
    }
}
