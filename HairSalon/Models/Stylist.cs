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

        public override bool Equals(System.Object otherStylist)
        {
            if (!(otherStylist is Stylist))
            {
                return false;
            }
            else
            {
                Stylist newStylist = (Stylist)otherStylist;
                bool nameEquality = (this.Name == newStylist.Name);
                bool detailsEquality = (this.Details == newStylist.Details);
                bool clientIdEquality = (this.ClientId == newStylist.ClientId);
                return (nameEquality && detailsEquality && clientIdEquality);
            }
        }



    }
}
