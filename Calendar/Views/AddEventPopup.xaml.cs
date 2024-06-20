using System;
using System.Collections.Generic;
using System.Windows.Input;
using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Controls;
using Plugin.Maui.Calendar.Models;

namespace Calendar
{
    public partial class AddEventPopup : Popup
    {
        private readonly EventDatabase _eventDatabase;

        public AddEventPopup(EventCollection events, EventDatabase eventDatabase)
        {
            InitializeComponent();

            Events = events ?? throw new ArgumentNullException(nameof(events));
            _eventDatabase = eventDatabase ?? throw new ArgumentNullException(nameof(eventDatabase));

            BindingContext = this;
        }

        public EventCollection Events { get; }

        public ICommand SaveEventCommand => new Command(async () =>
        {
            var newEvent = new EventModel
            {
                Name = NameEntry.Text,
                Description = DescriptionEntry.Text,
                Date = DatePicker.Date
            };

            await SaveEventAsync(newEvent);
        });

        private async Task SaveEventAsync(EventModel newEvent)
        {
            await _eventDatabase.SaveEventAsync(newEvent);

            if (!Events.ContainsKey(DatePicker.Date))
            {
                Events[DatePicker.Date] = new List<EventModel>();
            }

            Events[DatePicker.Date].Add(newEvent);
        }
    }
}
