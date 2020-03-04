using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Soccer.Common.Helpers;
using Soccer.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Soccer.Prism.ViewModels
{
    public class ClosedMatchesPageViewModel : ViewModelBase
    {
        private TournamentResponse _tournament;
        private List<MatchResponse> _matches;

        public ClosedMatchesPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Close";
            //_navigationService = navigationService;
            LoadMatches();
        }

       

        public List<MatchResponse> Matches
        {
            get => _matches;
            set => SetProperty(ref _matches, value);
        }


        private void LoadMatches()
        {
            _tournament = JsonConvert.DeserializeObject<TournamentResponse>(Setting.Tournament);

            //Title = _tournament.Name;
            List<MatchResponse> matches = new List<MatchResponse>();
            foreach (GroupResponse group in _tournament.Groups)
            {
                matches.AddRange(group.Matches);
            }

            Matches = matches.Where(m => m.IsClosed).OrderBy(m => m.Date).ToList();
        }

       
    }
}
