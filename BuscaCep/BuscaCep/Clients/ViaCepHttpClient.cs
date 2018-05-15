using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BuscaCep.Clients
{
    public class ViaCepHttpClient
    {
        private static Lazy<ViaCepHttpClient> _lazy = new Lazy<ViaCepHttpClient>(() => new ViaCepHttpClient());
        private readonly HttpClient _httpClient;    

        public static ViaCepHttpClient Current { get => _lazy.Value; }

        private ViaCepHttpClient()
        {
            _httpClient = new HttpClient();
        }

        public async Task<string> BuscarCep(string cep)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(cep))
                {
                    throw new InvalidOperationException("Digite um CEP válido para a busca.");
                }


                using (var response = await _httpClient.GetAsync($"http://viacep.com.br/ws/{cep}/json/"))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        throw new InvalidOperationException("Algo de errado não deu certo na sua consulta do CEP.");
                    }

                    return await response.Content.ReadAsStringAsync();
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
