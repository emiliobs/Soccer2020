﻿using Prism.Commands;
using Prism.Common;
using Prism.Mvvm;
using Prism.Navigation;
using Soccer.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Soccer.Prism.ViewModels
{
    public class GroupsPageViewModel : ViewModelBase
    {
        private TournamentResponse _tournament;

        public GroupsPageViewModel(INavigationService navigationService):base(navigationService)
        {
            Title = "Groups";
        }

        public TournamentResponse Tournament 
        {
            get => _tournament;
            set => SetProperty(ref _tournament, value);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.ContainsKey("tournament"))
            {

                Tournament = parameters.GetValue<TournamentResponse>("tournament");
               Title = _tournament.Name;

            }
        }

    }
}
