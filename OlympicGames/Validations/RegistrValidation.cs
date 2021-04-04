using FluentValidation;
using OlympicGames.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicGames.Validations
{
    public class RegistrValidation : AbstractValidator<RegistrVM>
    {
        public RegistrValidation()
        {
            RuleFor(Name => Name.Name).MinimumLength(3).WithMessage("The name must contain min. 3 character!");
            RuleFor(Surname => Surname.Surname).MinimumLength(3).WithMessage("The surname must contain min. 3 character!");
            RuleFor(Age => Age.Age).ExclusiveBetween("17", "71");
        }       
    }   
}
