using Prism.Navigation;
using Soccer.Common.Models;
using Soccer.Common.Service;
using System.Collections.Generic;
using System.Linq;

namespace Soccer.Prism.ViewModels
{
    public class TournamentsPageViewModel : ViewModelBase
    {

        private List<TournamentItemViewModel> _tournaments;
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;


        public TournamentsPageViewModel(INavigationService navigationService, IApiService apiService) : base(navigationService)
        {
            Title = "Soccer";
            this._navigationService = navigationService;
            this._apiService = apiService;

            LoadTournamentAsync();
        }

        public List<TournamentItemViewModel> Tournaments
        {
            get { return _tournaments; }
            set => SetProperty(ref _tournaments, value);
        }

        private async void LoadTournamentAsync()
        {
            var url = App.Current.Resources["UrlAPI"].ToString();
            var response = await _apiService.GetListAsync<TournamentResponse>(url, "/api", "/Tournaments");
            if (!response.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert("Error", response.Message, "Accept");
            }

            var tournaments = (List<TournamentResponse>)response.Result;
            Tournaments = tournaments.Select(t => new TournamentItemViewModel(_navigationService)
            {

                EndDate = t.EndDate,
                Groups = t.Groups,
                Id = t.Id,
                IsActive = t.IsActive,
                LogoPath = t.LogoPath,
                Name = t.Name,
                StartDate = t.StartDate


            }).ToList();
        }



    }
}
