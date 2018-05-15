using BuscaCep.Clients;
using System;
using System.Net.Http;
using Xamarin.Forms;

namespace BuscaCep
{
    public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        private async void BtnBuscarCep_Clicked(object sender, EventArgs e)
        {
            try
            {
                var result = await ViaCepHttpClient.Current.BuscarCep(txtCep.Text);

                if (!string.IsNullOrWhiteSpace(result))
                {
                    await DisplayAlert("Eitha!", result, "Ok");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
