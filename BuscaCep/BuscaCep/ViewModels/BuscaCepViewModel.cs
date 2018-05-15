using BuscaCep.Clients;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BuscaCep.ViewModels
{
    public class BuscaCepViewModel : ViewModelBase
    {
        public BuscaCepViewModel() : base()
        {

        }

        private string _cep;

        public string CEP
        {
            get => _cep;
            set
            {
                _cep = value;
                OnPropertyChanged();
            }
        }

        private Command _buscarCommand;

        public Command BuscarCommand
        {
            get
            {
                if (_buscarCommand == null)
                {
                    _buscarCommand = new Command(async () => await BuscarCommandExecute());
                }

                return _buscarCommand;
            }
        }

        //public Command BuscarCommand => 
        //    _buscarCommand ?? (_buscarCommand = new Command(async () => await BuscarCommandExecute())); 

        private async Task BuscarCommandExecute()
        {
            try
            {
                var result = await ViaCepHttpClient.Current.BuscarCep(_cep);

                if (!string.IsNullOrWhiteSpace(result))
                {
                    await App.Current.MainPage.DisplayAlert("Eitha!", result, "Ok");
                }
            }
            catch (Exception ex)
            {

                await App.Current.MainPage.DisplayAlert("Deu ruim :-(", ex.Message, "Ok");
            }
        }
    }
}
