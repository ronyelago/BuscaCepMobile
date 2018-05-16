using BuscaCep.Clients;
using BuscaCep.ViewModels;
using System;
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
                var result = await ViaCepHttpClient.Current.BuscarCep(((BuscaCepViewModel)BindingContext).CEP);


                if (!string.IsNullOrWhiteSpace(result))
                {
                    await Application.Current.MainPage.DisplayAlert("Eitha!", result, "Ok");
                }
            }
            catch (Exception ex)
            {

                await Application.Current.MainPage.DisplayAlert("Deu ruim :-(", ex.Message, "Ok");
            }
        }
    }
}
