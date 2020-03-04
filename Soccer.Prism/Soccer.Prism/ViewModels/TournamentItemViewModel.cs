using Newtonsoft.Json;
using Prism.Commands;
using Prism.Navigation;
using Soccer.Common.Helpers;
using Soccer.Common.Models;
using Soccer.Prism.Views;

namespace Soccer.Prism.ViewModels
{
	public class TournamentItemViewModel : TournamentResponse
	{
		private readonly INavigationService _navigationService;
		private DelegateCommand _selectTournamentCommand;

		public TournamentItemViewModel(INavigationService navigationService)
		{
			_navigationService = navigationService;
		}

		public DelegateCommand SelectTournamentCommand => _selectTournamentCommand ?? (_selectTournamentCommand = new DelegateCommand(SelectTournament));

		private async void SelectTournament()
		{
			NavigationParameters parameters = new NavigationParameters
			{
				{ "tournament" ,this}
			};

			Setting.Tournament = JsonConvert.SerializeObject(this);
			await _navigationService.NavigateAsync("TournamentTabbedPage", parameters);
		}
	}
}
