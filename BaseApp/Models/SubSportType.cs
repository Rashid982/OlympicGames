using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseApp.Models
{
    [AddINotifyPropertyChangedInterface]
    public class SubSportType : Entity
    {
        public string Name { get; set; }

        [Required]
        public virtual SportType SportType { get; set; }
        public virtual ICollection<WeightLimite> WeightLimite { get; set; }
        public virtual ICollection<LengthLimite> LengthLimite { get; set; }
        public Gender Gender { get; set; }


    }
}
