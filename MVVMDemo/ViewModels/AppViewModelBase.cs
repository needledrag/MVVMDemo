
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.Input;

namespace MVVMDemo.ViewModels
{
    public partial class AppViewModelBase : ViewModelBase
    {
        public TimeSpan ShortDuration = TimeSpan.FromSeconds(2);
        public TimeSpan LongDuration = TimeSpan.FromSeconds(3);

        public SnackbarOptions SnackOptions => new SnackbarOptions
        {
            BackgroundColor = Colors.WhiteSmoke,
            TextColor = Colors.Black,
            ActionButtonTextColor = Colors.Black,
            CornerRadius = new CornerRadius(10),
            Font = Microsoft.Maui.Font.SystemFontOfSize(14),
            ActionButtonFont = Microsoft.Maui.Font.SystemFontOfSize(14)
        };

        // this is specific to an implementation, usually ViewModelBase is enough
        public INavigation NavigationService { get; set; }
        public Page PageService { get; set; }

        public AppViewModelBase() : base()
        {

        }

        [RelayCommand]
        private async Task NavigateBack() =>
            await NavigationService.PopAsync();

        [RelayCommand]
        private async Task CloseModal() =>
            await NavigationService.PopModalAsync();

    }
}

