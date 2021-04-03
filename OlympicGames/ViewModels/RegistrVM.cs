using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicGames.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class RegistrVM  : BaseVM
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public RegistrVM()
        {

        }
    }
}
