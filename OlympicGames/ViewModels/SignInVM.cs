using GalaSoft.MvvmLight.Command;
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
    public class SignInVM : BaseVM
    {
        private readonly Messenger messenger = App.Container.GetInstance<Messenger>();
        public RelayCommand SignInCmd { get; set; }
        public RelayCommand RegistrationCmd { get; set; }
        
        public SignInVM()
        {
            SignInCmd = new RelayCommand(() =>
            {

            });

            RegistrationCmd = new RelayCommand(() =>
            {
                messenger.Send(new NavigationM() { CurrentVM = App.Container.GetInstance<RegistrVM>() });
            });
        }
    }
}
