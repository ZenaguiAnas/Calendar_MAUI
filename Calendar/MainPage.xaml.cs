using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using Plugin.Maui.Calendar.Models;

namespace Calendar
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        private EventCollection _events;
        private EventDatabase _eventDatabase;

        public MainPage()
        {
            InitializeComponent();

            // Initialize EventCollection and EventDatabase (dummy initialization for demonstration)
            _events = new EventCollection();
            _eventDatabase = new EventDatabase();

            // Set the BindingContext to this page
            BindingContext = this;
        }

        public EventCollection Events
        {
            get { return _events; }
            set { _events = value; }
        }

        private async void OnAddEventClicked(object sender, EventArgs e)
        {
            var addEventPopup = new AddEventPopup(Events, _eventDatabase);
            await addEventPopup.ShowAsync();
        }
    }
}
