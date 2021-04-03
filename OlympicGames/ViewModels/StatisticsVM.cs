using BaseApp.Entity;
using BaseApp.Models;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using OlympicGames.Messages;
using PropertyChanged;
using System.Collections.Generic;
using System.Linq;
namespace OlympicGames.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class StatisticsVM : BaseVM
    {
        private readonly OlympicDB context = App.Container.GetInstance<OlympicDB>();
        public Messenger Messenger { get; set; }
        public RelayCommand CountryCmd { get; set; }
        public RelayCommand GeneralCmd { get; set; }
        public RelayCommand SportTypeCmd { get; set; }
        public RelayCommand BackCmd { get; set; }
        public List<Athlet> AthletsMedal { get; set; }       

        public StatisticsVM()
        {
            Messenger = App.Container.GetInstance<Messenger>();
            Messenger.Register<NavigationM>(this, x => { CurrentVM = x.CurrentVM; });

            CountryCmd = new RelayCommand(() =>
            {
                CurrentVM = App.Container.GetInstance<CountryDataGridVM>();             
            });
            
            SportTypeCmd = new RelayCommand(() =>
            {
                CurrentVM = App.Container.GetInstance<SportTypeDataGridVM>();          
            });

            BackCmd = new RelayCommand(() =>
            {
                
            });

            GeneralCmd = new RelayCommand(() =>
            {
            });
        }
    }
}
