using BaseApp.Entity;
using BaseApp.Models;
using PropertyChanged;
using System.Collections.Generic;
using System.Linq;

namespace OlympicGames.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class CountryDataGridVM : BaseVM
    {
        private readonly OlympicDB context = App.Container.GetInstance<OlympicDB>();
        public List<Athlet> AthletsMedal { get; set; }
        public CountryDataGridVM()
        {
            AthletsMedal = context.Athlets.ToList();
        }
    }
}
