using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseApp.Models
{
    [AddINotifyPropertyChangedInterface]
    public class Entity
    {
        public int Id { get; set; }
    }
}
