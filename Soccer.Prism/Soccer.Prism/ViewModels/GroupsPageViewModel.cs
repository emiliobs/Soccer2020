using Prism.Navigation;
using Soccer.Common.Helpers;
using Soccer.Common.Models;
using System.Collections.Generic;

namespace Soccer.Prism.ViewModels
{
    public class GroupsPageViewModel : ViewModelBase
    {
        private TournamentResponse _tournament;
        public List<Group> _groups;
        private readonly ITransformHelper _transformHelper;

        public GroupsPageViewModel(INavigationService navigationService, ITransformHelper transformHelper) : base(navigationService)
        {
            Title = "Groups";
            _transformHelper = transformHelper;
        }

        public List<Group> Groups
        {
            get => _groups;
            set => SetProperty(ref _groups, value);
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
                Groups = _transformHelper.TopGroups(_tournament.Groups);
            }
        }

    }
}
