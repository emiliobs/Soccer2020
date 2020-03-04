using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Soccer.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Soccer.Prism.ViewModels
{
    public class TournamentTabbedPageViewModel : ViewModelBase
    {
        private TournamentResponse _tournament;
        public TournamentTabbedPageViewModel(INavigationService navigationService):base(navigationService)
        {
            Title = "Soccer";
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            _tournament = parameters.GetValue<TournamentResponse>("tournament");
            Title = _tournament.Name;
        }
    }
}
