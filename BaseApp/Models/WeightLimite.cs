using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseApp.Models
{
    [AddINotifyPropertyChangedInterface]
    public class WeightLimite : Entity
    {
        public double MaxWeight { get; set; }
        public double MinWeight { get; set; }
        public override string ToString()
        {
            return $"{MaxWeight} - {MinWeight}";
        }

        public virtual ICollection<SubSportType> SubSportTypes { get; set; }
    }
}
