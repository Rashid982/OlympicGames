using OlympicGames.ViewModels;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicGames.Messages
{    
     [AddINotifyPropertyChangedInterface]
     public class NavigationM
     {
         public BaseVM CurrentVM { get; set; }
     }    
}
