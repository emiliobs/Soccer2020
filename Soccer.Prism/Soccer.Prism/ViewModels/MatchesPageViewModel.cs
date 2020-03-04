﻿using Prism.Navigation;
using Soccer.Common.Models;
using System.Collections.Generic;
using System.Linq;

namespace Soccer.Prism.ViewModels
{
    public class MatchesPageViewModel : ViewModelBase
    {
        //private readonly INavigationService _navigationService;
        private TournamentResponse _tournament;
        private List<MatchResponse> _matches;

        public MatchesPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Matches";
            //_navigationService = navigationService;
        }

        public List<MatchResponse> Matches
        {
            get => _matches;
            set => SetProperty(ref _matches, value);
        }



        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            _tournament = parameters.GetValue<TournamentResponse>("tournament");
            Title = _tournament.Name;
            List<MatchResponse> matches = new List<MatchResponse>();
            foreach (GroupResponse group in _tournament.Groups)
            {
                matches.AddRange(group.Matches);
            }

            Matches = matches.Where(m => !m.IsClosed).OrderBy(m => m.Date).ToList();
        }
    }
}
