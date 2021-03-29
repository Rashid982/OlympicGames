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
        private readonly OlympicDB context = App.Container.GetInstance<OlympicDB>();
        private bool ısCheckedMen;
        private bool ısCheckedWomen;
        private SportType selectedSportType;

        public bool IsCheckedMen
        {
            get => ısCheckedMen;
            set
            {
                ısCheckedMen = value;
                if (IsCheckedMen)
                {
                    Categories = context.SubSportTypes.Where(x => x.SportType.Id == SelectedSportType.Id).Where(x => x.Gender.Id == 1).ToList();
                }
            }
        }
        public bool IsCheckedWomen
        {
            get => ısCheckedWomen;
            set
            {
                ısCheckedWomen = value;
                if (IsCheckedWomen)
                {
                    Categories = context.SubSportTypes.Where(x => x.SportType.Id == SelectedSportType.Id).Where(x => x.Gender.Id == 2).ToList();
                }
            }
        }
        public RelayCommand SaveCmd { get; set; }
        public RelayCommand SelectionChangedCmd { get; set; }
        public List<Country> Countries { get; set; }
        public List<SportType> SportTypes { get; set; }
        public List<SubSportType> Categories { get; set; }
        public SportType SelectedSportType 
        {
            get => selectedSportType; 
            set
            {
                selectedSportType = value;
                IsCheckedMen = false;
                IsCheckedWomen = false;
            }
        }
        public List<Athlet> Athlets { get; set; }

        public CompetitionVM()
        {
            //Messenger = App.Container.GetInstance<Messenger>();

            Countries = context.Countries.ToList();
            SportTypes = context.SportTypes.ToList();

            SaveCmd = new RelayCommand(() =>
            {

            });
        }
    }
}
