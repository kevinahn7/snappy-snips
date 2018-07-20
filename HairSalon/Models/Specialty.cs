using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairSalon.Models
{
    public class Specialty
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Specialty(string name, int id = 0)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
