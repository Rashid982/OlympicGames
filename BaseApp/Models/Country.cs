using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseApp.Models
{
    [AddINotifyPropertyChangedInterface]
    public class Country : Entity
    {
        //Add comment
        public string Name { get; set; }
        public virtual ICollection<Athlet> Athlets { get; set; }
    }
}
