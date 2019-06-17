using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace App3
{
	public class HomePage : ContentPage
	{
		public HomePage ()
		{
            this.Title = "Информация";
            StackLayout stackLayout = new StackLayout();
            Button button = new Button
            {
                Text = "Добавление информации"
            };
            button.Clicked += Button_Clicked;
            stackLayout.Children.Add(button);

            button = new Button
            {
                Text = "Просмотр информации"
            };
            button.Clicked += Button_View_Clicked;
            stackLayout.Children.Add(button);

            button = new Button
            {
                Text = "Изменение информации"
            };
            button.Clicked += Button_Edit_Clicked;
            stackLayout.Children.Add(button);

            Content = stackLayout;
		}

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddInformationPage());
        }

        private async void Button_View_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ViewAllInformationPage());
        }

        private async void Button_Edit_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditInformationPage());
        }
    }
}