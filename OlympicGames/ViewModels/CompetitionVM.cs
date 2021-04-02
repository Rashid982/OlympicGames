using BaseApp.Entity;
using BaseApp.Models;
using GalaSoft.MvvmLight.Command;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private Country selectedCountry;
        private Country selectedCountry2;

        public bool IsCheckedMen
        {
            get => ısCheckedMen;
            set
            {
                ısCheckedMen = value;
                if (IsCheckedMen)
                {
                    Categories = context.SubSportTypes.Where(x => x.SportType.Id == SelectedSportType.Id).Where(x => x.Gender.Id == 1).ToList();
                    if(SelectedSportType.Id == 9 || SelectedSportType.Id == 27 || SelectedSportType.Id == 28 || SelectedSportType.Id == 40 ||
                        SelectedSportType.Id==46|| SelectedSportType.Id == 47|| SelectedSportType.Id == 48)
                    {
                        foreach (var weight in context.WeightLimites.ToList())
                        {
                            WeightLimites.Add(weight);
                        }                        
                    }
                    else { WeightLimites.Clear(); }
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
                    if (SelectedSportType.Id == 9 || SelectedSportType.Id == 27 || SelectedSportType.Id == 28 || SelectedSportType.Id == 40 ||
                        SelectedSportType.Id == 46 || SelectedSportType.Id == 47 || SelectedSportType.Id == 48)
                    {
                        foreach (var weight in context.WeightLimites.ToList())
                        {
                            WeightLimites.Add(weight);
                        }                        
                    }
                    else { WeightLimites.Clear(); }
                }
            }
        }
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
        public Country SelectedCountry1
        {
            get => selectedCountry;
            set
            {
                selectedCountry = value;
                Athlets = context.Athlets.Where(x => x.Country.Id == SelectedCountry1.Id).ToList();
            }
        }
        public Country SelectedCountry2 
        {
            get => selectedCountry2;
            set 
            {
                selectedCountry2 = value;
                Athlets2 = context.Athlets.Where(x => x.Country.Id == SelectedCountry2.Id).ToList();
            }  
        }
        public RelayCommand SaveCmd { get; set; }
        public List<Country> Countries { get; set; }
        public List<SportType> SportTypes { get; set; }
        public List<SubSportType> Categories { get; set; }
        public List<Athlet> Athlets { get; set; }
        public List<Athlet> Athlets2 { get; set; }
        public ObservableCollection<WeightLimite> WeightLimites { get; set; }
        public List<LengthLimite> LengthLimites { get; set; }
        public SubSportType SelectedCategory { get; set; }
        public Athlet SelectedAthlet1 { get; set; }
        public Athlet SelectedAthlet2 { get; set; }
        public WeightLimite SelectedWeightLimite { get; set; }
        public LengthLimite SelectedLengthLimite { get; set; }
        public DateTime DateTime { get; set; }
        public Competition Competition { get; set; }

        public CompetitionVM()
        {
            //Messenger = App.Container.GetInstance<Messenger>();
            WeightLimites = new ObservableCollection<WeightLimite>();
            Competition = new Competition();
            Countries = context.Countries.ToList();
            SportTypes = context.SportTypes.ToList();
            DateTime = DateTime.Now;

            SaveCmd = new RelayCommand(() =>
            {
                
            });
        }
    }
}
