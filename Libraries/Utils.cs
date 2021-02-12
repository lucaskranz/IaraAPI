using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IaraAPI.Models;
using RestSharp;
using RestSharp.Serialization.Json;

namespace IaraAPI.Libraries
{
    public class Utils
    {
        public static DadosRetorno GetViaCEP(string CEP)
        {
            RestClient restClient = new RestClient(string.Format("https://viacep.com.br/ws/{0}/json/", CEP));
            RestRequest restRequest = new RestRequest(Method.GET);

            IRestResponse restResponse = restClient.Execute(restRequest);

            if (restResponse.StatusCode != System.Net.HttpStatusCode.BadRequest)
            {
                return new JsonDeserializer().Deserialize<DadosRetorno>(restResponse);                
            }
            else
            {
                return null;
            }
}


    }
}
