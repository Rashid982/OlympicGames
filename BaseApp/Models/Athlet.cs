using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseApp.Models
{
    [AddINotifyPropertyChangedInterface]
    public class Athlet : Entity
    {       
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public double Weight { get; set; }
        public int Score { get; set; }
        public virtual Country Country { get; set; } // must
        public virtual Gender Gender { get; set; } // ?
        public virtual SportType SportType { get; set; } // ?
        public virtual ICollection<Medal> Medals { get; set; }
    }
}
