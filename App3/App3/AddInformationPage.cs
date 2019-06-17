using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace App3
{
    public class AddInformationPage : ContentPage
    {
        private Entry _text1Entry;
        private Entry _text2Entry;
        private Button _saveButton;
        readonly string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),"myDB.db3");

        public AddInformationPage()
        {
            this.Title = "Добавление информации";

            StackLayout stackLayout = new StackLayout();

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

            _saveButton = new Button
            {
                Text = "Добавить"
            };
            _saveButton.Clicked += _saveButton_Clicked;
            stackLayout.Children.Add(_saveButton);

            Content = stackLayout;
        }

        private async void _saveButton_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            db.CreateTable<Information>();

            var maxPK = db.Table<Information>().OrderByDescending(c => c.Id).FirstOrDefault();

            Information information = new Information()
            {
                Id = (maxPK == null ? 1 : maxPK.Id + 1),
                TextInformation1 = _text1Entry.Text,
                TextInformation2 = _text2Entry.Text
            };
            db.Insert(information);
            await DisplayAlert(null, information.TextInformation1 + " Сохранено", "Ок");
            await Navigation.PopAsync();
        }
    }
}