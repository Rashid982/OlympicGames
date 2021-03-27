using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseApp.Models
{
    [AddINotifyPropertyChangedInterface]
    public class Gender : Entity
    {
        //Add Comment
        public string Name { get; set; }

        public virtual ICollection<Athlet> Athlets { get; set; }
        public virtual ICollection<SubSportType> SubSportTypes { get; set; }


    }
}
