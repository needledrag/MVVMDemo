using MVVMDemo.Helpers;


namespace MVVMDemo.Views;

public partial class PageBase : ContentPage
{
    public IList<Microsoft.Maui.IView> PageContent => PageContentGrid.Children;
   


    public static readonly BindableProperty PageModeProperty = BindableProperty.Create(
        nameof(PageMode),
        typeof(Enums.PageMode),
        typeof(PageBase),
        Enums.PageMode.None,
        propertyChanged: OnPageModePropertyChanged);

    public Enums.PageMode PageMode
    {
        get => (Enums.PageMode)GetValue(PageModeProperty);
        set => SetValue(PageModeProperty, value);
    }

    private static void OnPageModePropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable != null && bindable is PageBase basePage)
            basePage.SetPageMode((Enums.PageMode)newValue);
    }

    private void SetPageMode(Enums.PageMode pageMode)
    {
        switch (pageMode)
        {
            case Enums.PageMode.Menu:
               
                break;
            case Enums.PageMode.Navigate:
               
                break;
            case Enums.PageMode.Modal:
               
                break;
            default:
                
                break;
        }
    }


    public static readonly BindableProperty ContentDisplayModeProperty = BindableProperty.Create(
        nameof(ContentDisplayMode),
        typeof(Enums.ContentDisplayMode),
        typeof(PageBase),
        Enums.ContentDisplayMode.NoNavigationBar,
        propertyChanged: OnContentDisplayModePropertyChanged);

    public Enums.ContentDisplayMode ContentDisplayMode
    {
        get => (Enums.ContentDisplayMode)GetValue(ContentDisplayModeProperty);
        set => SetValue(ContentDisplayModeProperty, value);
    }

    private static void OnContentDisplayModePropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable != null && bindable is PageBase basePage)
            basePage.SetContentDisplayMode((Enums.ContentDisplayMode)newValue);
    }

    private void SetContentDisplayMode(Enums.ContentDisplayMode contentDisplayMode)
    {
        switch (contentDisplayMode)
        {
            case Enums.ContentDisplayMode.NavigationBar:
                Grid.SetRow(PageContentGrid, 2);
                Grid.SetRowSpan(PageContentGrid, 1);
                break;
            case Enums.ContentDisplayMode.NoNavigationBar:
                Grid.SetRow(PageContentGrid, 0);
                Grid.SetRowSpan(PageContentGrid, 3);
                break;
            default:
                //Do Nothing
                break;
        }
    }



    public PageBase()
    {
        InitializeComponent();

        //Hide the Xamarin Forms build in navigation header
        NavigationPage.SetHasNavigationBar(this, false);

        //Set Page Mode
        SetPageMode(Enums.PageMode.None);

        //Set Content Display Mode
        SetContentDisplayMode(Enums.ContentDisplayMode.NoNavigationBar);
    }
}