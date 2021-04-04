using GalaSoft.MvvmLight.CommandWpf;
using OlympicGames.Validations;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace OlympicGames.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class RegistrVM  : BaseVM, IDataErrorInfo
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Age { get; set; } = "18";
        public string UserName { get; set; }       
        public RegistrValidation ValidationRules { get; set; }
        public Regex LetterValidations { get; set; }
        public Regex DigitValidations { get; set; }
        public RelayCommand<object> RegisterCmd { get; set; }

        public string Error
        {
            get
            {
                if (ValidationRules != null)
                {
                    var results = ValidationRules.Validate(this);
                    if (results != null && results.Errors.Any())
                    {
                        var errors = string.Join(" ", results.Errors.Select(x => x.ErrorMessage).ToArray());
                        return errors;
                    }
                }
                return string.Empty;
            }
        }

        public string this[string columnName]
        {
            get
            {
                var firstOrDefault = ValidationRules.Validate(this).Errors.FirstOrDefault(lol => lol.PropertyName == columnName);
                if (firstOrDefault != null)
                    return ValidationRules != null ? firstOrDefault.ErrorMessage : "";
                return "";
            }
        }

        public RegistrVM()
        {
            ValidationRules = new RegistrValidation();
            LetterValidations = new Regex("[^a-zA-Z]+$");
            DigitValidations = new Regex("[^0-9.-]+");
            
            RegisterCmd = new RelayCommand<object>((x) =>
            {
                var passwordBox = x as PasswordBox;
                var Password = passwordBox.Password;
                
            }, (x) => !string.IsNullOrWhiteSpace(Name) && !string.IsNullOrWhiteSpace(Surname) && !string.IsNullOrWhiteSpace(UserName) 
            && !LetterValidations.IsMatch(Name) && !LetterValidations.IsMatch(Surname) && !DigitValidations.IsMatch(Age) && string.IsNullOrEmpty(Error));
        }
    }
}
