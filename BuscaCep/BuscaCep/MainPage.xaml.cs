using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
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
                if (string.IsNullOrWhiteSpace(txtCep.Text))
                {
                    throw new InvalidOperationException("Digite um CEP válido para a busca.");
                }

                using (var client = new HttpClient())
                {
                    using (var response = await client.GetAsync($"http://viacep.com.br/ws/{txtCep.Text}/json/"))
                    {
                        if (!response.IsSuccessStatusCode)
                        {
                            throw new InvalidOperationException("Algo de errado não deu certo na sua consulta do CEP.");
                        }

                        var result = await response.Content.ReadAsStringAsync();

                        if (!string.IsNullOrWhiteSpace(result))
                        {
                            await DisplayAlert("Eitha!", result, "Ok");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Deu ruim :-(", ex.Message, "Ok");
            }
        }
    }
}
