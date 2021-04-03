using GalaSoft.MvvmLight.Messaging;
using OlympicGames.Messages;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicGames.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class OlympicGamesVM : BaseVM
    {
        public Messenger Messenger { get; set; }
        public OlympicGamesVM()
        {
            Messenger = App.Container.GetInstance<Messenger>();
            CurrentVM = App.Container.GetInstance<SignInVM>();
            Messenger.Register<NavigationM>(this, x => { CurrentVM = x.CurrentVM; });
        }
    }
}
