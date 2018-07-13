using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairSalon.Models
{
    public class Stylist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public int ClientId { get; set; }

        public Stylist(int id, string name, string details, int clientId)
        {
            this.Id = id;
            this.Name = name;
            this.Details = details;
            this.ClientId = clientId;
        }





    }
}
