using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using Testando.DTOs;
using Newtonsoft.Json;

namespace Testando.Servicos
{
    public class ApiDeTeste
    {
        public HttpClient IniciarCliente()
        {
            try
            {
                HttpClient cliente = new HttpClient();

                cliente.Timeout = new TimeSpan(12000000);
                cliente.BaseAddress = new Uri("https://jsonplaceholder.typicode.com");
                cliente.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                return cliente;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public HttpResponseMessage ClienteChamarAAPI(DtoObjetoExemplo dtoObjetoExemplo)
        {
            try
            {
                HttpClient cliente = IniciarCliente();
                StringContent parametro = prepararParametroParaEnviarNoPost(dtoObjetoExemplo);
                HttpResponseMessage resposta = cliente.PostAsync("/posts", parametro).Result;

                return resposta;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public StringContent prepararParametroParaEnviarNoPost(DtoObjetoExemplo dtoObjetoExemplo)
        {
            var content = Newtonsoft.Json.JsonConvert.SerializeObject(dtoObjetoExemplo);
            StringContent httpContent = new System.Net.Http.StringContent(content, Encoding.UTF8, "application/json");

            return httpContent;
        }

        public int PegarRetornoDaAPI(DtoObjetoExemplo dtoObjetoExemplo)
        {
            try
            {
                HttpResponseMessage resposta = ClienteChamarAAPI(dtoObjetoExemplo);

                if (resposta.IsSuccessStatusCode)
                {
                    string stringRetornoDaApi = resposta.Content.ReadAsStringAsync().Result.ToString();
                    DtoObjetoExemplo retornoDaAPI = JsonConvert.DeserializeObject<DtoObjetoExemplo>(stringRetornoDaApi);

                    return 200;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
