using BaseApp.Entity;
using GalaSoft.MvvmLight.Messaging;
using OlympicGames.ViewModels;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace OlympicGames
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Container Container { get; set; }
        public App()
        {
            Container = new Container();
            Container.RegisterSingleton<Messenger>();
            Container.Register<OlympicGamesVM>();
            Container.Register<CompetitionVM>();
            Container.Register<StatisticsVM>();
            Container.RegisterSingleton<OlympicDB>();
        }
    }
}
