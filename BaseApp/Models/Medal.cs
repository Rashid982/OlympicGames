using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseApp.Models
{
    public enum MedalType
    {
        Bronze = 1,
        Silver = 2,
        Gold = 3
    }
    [AddINotifyPropertyChangedInterface]
    public class Medal : Entity
    {
        public MedalType MedalType { get; set; }

        public virtual ICollection<Athlet> Athlets { get; set; }


    }
}
