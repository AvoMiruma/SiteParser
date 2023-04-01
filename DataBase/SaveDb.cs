using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkParser.Entity;

namespace WorkParser.DataBase
{
    public class SaveDb
    {
        private VacancyDbContext _context;
        public SaveDb(VacancyDbContext context) => _context = context;

        public void SaveVacancy(List<Vacancy> vacancy)
        {
            
            foreach(var temp in vacancy)
            {
                _context.AddRange(temp);

            }
            _context.SaveChanges();

        }
    }
}
