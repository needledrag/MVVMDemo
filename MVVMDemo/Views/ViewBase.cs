
using MVVMDemo.Helpers;
using MVVMDemo.ViewModels;

namespace MVVMDemo.Views.Base
{
    public class ViewBase<TViewModel> : MVVMDemo.Views.PageBase where TViewModel : AppViewModelBase
    {
        protected bool _isLoaded = false;

        protected TViewModel ViewModel { get; set; }
        protected object ViewModelParameters { get; set; }

        protected event EventHandler ViewModelInitialized;

        // basic constructor
        public ViewBase() : base()
        {
        }
        // constructor passing in parameters 
        public ViewBase(object initParameters) : base() =>
            ViewModelParameters = initParameters;

        protected override void OnAppearing()
        {
            if (!_isLoaded)
            {
                base.OnAppearing();

                BindingContext = ViewModel = ServiceHelpers.GetService<TViewModel>();

                ViewModel.NavigationService = this.Navigation;
                ViewModel.PageService = this;

                // raise event to notify viewmodel is initialised
                ViewModelInitialized?.Invoke(this, new EventArgs());

                // navigate to viewmodels OnNavigation method
                ViewModel.OnNavigatedTo(ViewModelParameters);

                _isLoaded = true;
            }
        }
    }
}

