using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using SQLite;
using Xamarin.Forms;

namespace App3
{
	public class EditInformationPage : ContentPage
	{
        private ListView _listView;
        private Entry _idEntry;
        private Entry _text1Entry;
        private Entry _text2Entry;
        private Button _button;

        Information _information = new Information();
        readonly string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");

        public EditInformationPage ()
		{
            this.Title = "Изменение информации";

            var db = new SQLiteConnection(_dbPath);

            StackLayout stackLayout = new StackLayout();

            _listView = new ListView
            {
                ItemsSource = db.Table<Information>().OrderBy(x => x.TextInformation1).ToList()
            };
            _listView.ItemSelected += _listView_ItemSelected;
            stackLayout.Children.Add(_listView);

            _idEntry = new Entry
            {
                IsVisible = false
            };
            stackLayout.Children.Add(_idEntry);

            _text1Entry = new Entry
            {
                Keyboard = Keyboard.Text
            };
            stackLayout.Children.Add(_text1Entry);

            _text2Entry = new Entry
            {
                Keyboard = Keyboard.Text
            };
            stackLayout.Children.Add(_text2Entry);

            _button = new Button
            {
                Text = "Обновить"
            };
            _button.Clicked += _button_Clicked;
            stackLayout.Children.Add(_button);

            Content = stackLayout;

        }

        private async void _button_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);

            Information information = new Information()
            {
                Id = Convert.ToInt32(_idEntry.Text),
                TextInformation1 = _text1Entry.Text,
                TextInformation2 = _text2Entry.Text
            };
            db.Update(information);
            await Navigation.PopAsync();
        }

        private void _listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            _information = (Information)e.SelectedItem;
            _idEntry.Text = _information.Id.ToString();
            _text1Entry.Text = _information.TextInformation1;
            _text2Entry.Text = _information.TextInformation2;
        }
    }
}