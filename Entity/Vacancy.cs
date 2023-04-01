using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkParser.Entity
{
    public class Vacancy
    {
        public int Id { get; set; }
        public string Position { get; set; }
        public string Salary { get; set; }
        public string Company { get; set; }
        public string Details { get; set; }
    }
}
