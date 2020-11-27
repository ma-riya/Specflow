using SpecflowTests.Configuration;
using SpecflowTests.Builders;
using System.Net.Http;
using SpecflowTests.Builders.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net;
using System;
using RestSharp;

namespace SpecflowTests.Steps
{
    public class BaseTestsSteps
    {
        protected ConfigModel config;
        protected string baseUrl;
        public RestClient restClient;
        protected const string menuPath = "menu/";
        protected const string categoryPath = "/category/";
        protected Menu menuz;
        protected IRestResponse menuResponse;
        protected RestRequest request;


        protected Menu createMenuRequest;
        protected IRestResponse lastResponse;


        public BaseTestsSteps()
        {
            config = ConfigAccessor.GetApplicationConfiguration();
            baseUrl = config.BaseUrl;
            restClient = new RestClient(baseUrl);
            createMenuRequest = new MenuBuilder().SetDefaultValues("Yumido Menu").Build();
        }

        public IRestResponse sendCreateMenuRequest()
        {
            var json = JsonConvert.SerializeObject(menuz);
            request = new RestRequest(menuPath, Method.POST);
            request.AddParameter("application/json", json, ParameterType.RequestBody);
            lastResponse = restClient.Execute(request);
            Console.WriteLine("Response resppnse" + lastResponse.Content);
            return lastResponse;
        }

        public IRestResponse sendGetMenuRequest(IRestResponse response)
        {
            menuz = JsonConvert.DeserializeObject<Menu>(response.Content);
            Console.WriteLine(menuz.id+ "THIS IS MENUZ ID");
            request = new RestRequest($"{menuPath}{menuz.id}", Method.GET);
            Console.WriteLine($"{menuPath}{menuz.id}" + "THIS IS PATH URL");

            lastResponse = restClient.Execute(request);
            return lastResponse;
        }


        /*
        protected Menu createMenuRequest;
        protected Menu menuResponse;
        protected Menu menuz;
        protected const string menuPath = "menu/";
        protected const string categoryPath = "/category/";

        public BaseTestsSteps()
        {
            createMenuRequest = new MenuBuilder().SetDefaultValues("Yumido Menu").Build();
        }

        public async Task<HttpResponseMessage> sendCreateMenu()
        {
            HttpResponseMessage lastResponse = await HttpRequestFactory.Post(baseUrl, menuPath, createMenuRequest);
            try
            {
                if (lastResponse.StatusCode == HttpStatusCode.Created)
                {
                    menuResponse = JsonConvert.DeserializeObject<Menu>(await lastResponse.Content.ReadAsStringAsync());
                    menuz.id = menuResponse.id;
                }
                else
                {
                    throw new Exception();
                }
            }
            catch
            {
                throw new Exception($"Menu could not be created. API response: {await lastResponse.Content.ReadAsStringAsync()}");
            }
            menuz.id = menuResponse.id;
            return lastResponse;
    }


        public async Task<HttpResponseMessage> sendCreateCategory()
        {
            HttpResponseMessage lastResponse =await sendCreateMenu();
             lastResponse = await HttpRequestFactory.Post(baseUrl, $"{menuPath}{menuResponse.id}{categoryPath}", createCategoryRequest);
            try
            {
                if (lastResponse.StatusCode == HttpStatusCode.Created)
                {
                    categoryResponse = JsonConvert.DeserializeObject<Category>(await lastResponse.Content.ReadAsStringAsync());
                    menuz.id = menuResponse.id;
                }
                else
                {
                    throw new Exception();
                }
            }
            catch
            {
                throw new Exception($"Category could not be created. API response: {await lastResponse.Content.ReadAsStringAsync()}");
            }
            return lastResponse;
        }
    */

    }

}
