using Prism.Navigation;
using Soccer.Common.Models;
using Soccer.Common.Service;
using System;
using System.Collections.Generic;

namespace Soccer.Prism.ViewModels
{
    public class TournamentsPageViewModel : ViewModelBase
    {

        private List<TournamentResponse> _tournaments;
        private readonly IApiService _apiService;


        public TournamentsPageViewModel(INavigationService navigationService, IApiService apiService) : base(navigationService)
        {
            Title = "Soccer";
            this._apiService = apiService;

            LoadTournamentAsync();
        }

        public List<TournamentResponse> Tournaments
        {
            get { return _tournaments; }
            set => SetProperty(ref _tournaments, value);
        }

        private async void LoadTournamentAsync()
        {
            var url = App.Current.Resources["UrlAPI"].ToString();
            var response = await _apiService.GetListAsync<TournamentResponse>(url,"/api","/Tournaments");
            if (!response.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert("Error",response.Message,"Accept");
            }

            Tournaments = (List<TournamentResponse>)response.Result;
        }



    }
}
