using BaseApp.Entity;
using BaseApp.Models;
using GalaSoft.MvvmLight.Command;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OlympicGames.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class CompetitionVM : BaseVM
    {
        //public Messenger Messenger { get; set; }
        public RelayCommand SaveCmd { get; set; }
        public RelayCommand SelectionChangedCmd { get; set; }
        public List<Country> Countries { get; set; }
        public List<SportType> SportTypes { get; set; }
        public List<SportType> Categories { get; set; }
        public SportType SelectedSportType { get; set; }        
        public List<Athlet> Athlets { get; set; }

        public CompetitionVM()
        {           
            //Messenger = App.Container.GetInstance<Messenger>();
            SportTypes = new List<SportType>();
            Categories = new List<SportType>();
            
            SelectionChangedCmd = new RelayCommand(() =>
            {
                
            });
            
            SaveCmd = new RelayCommand(() =>
            {
                using (var db = new OlympicDB())
                {

                }
            });
        }

    }
}
