using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace App3
{
	public class ViewAllInformationPage : ContentPage
	{

        private readonly ListView _listView;
        readonly string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");

        public ViewAllInformationPage ()
		{
            this.Title = "Добавленная информация";

            var db = new SQLiteConnection(_dbPath);

            StackLayout stackLayout = new StackLayout();

            _listView = new ListView
            {
                ItemsSource = db.Table<Information>().OrderBy(x => x.TextInformation1).ToList()
            };
            stackLayout.Children.Add(_listView);

            Content = stackLayout;
        }
	}
}