using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseApp.Models
{
    [AddINotifyPropertyChangedInterface]
    public class LengthLimite : Entity
    {
        public double MaxLength { get; set; }
        public double MinLength { get; set; }

        public virtual ICollection<SubSportType> SubSportTypes { get; set; }

    }
}
