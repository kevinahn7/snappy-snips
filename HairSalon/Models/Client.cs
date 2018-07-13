using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairSalon.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Client(string name, int id = 0)
        {
            this.Id = id;
            this.Name = name;
        }

        public override bool Equals(System.Object otherClient)
        {
            if (!(otherClient is Client))
            {
                return false;
            }
            else
            {
                Client newClient = (Client)otherClient;
                bool idEquality = (this.Id == newClient.Id);
                bool nameEquality = (this.Name == newClient.Name);
                return (idEquality && nameEquality);
            }
        }


    }
}
