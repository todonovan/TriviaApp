using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStore
{
    public class Team
    {
        public int Id { get; set; }
        public List<Person> Persons { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
    }
}
