using SpecflowTests.Configuration;
using SpecflowTests.Builders;
using Newtonsoft.Json;
using System.Net;
using System;
using RestSharp;
using SpecflowTests.Models;

namespace SpecflowTests.Steps
{
    public class BaseTestsSteps
    {
        protected readonly RestClient restClient;
        private readonly string baseUrl;
        private RestRequest request;
        protected Menu createMenuRequest;
        protected Menu updateMenuRequest;
        protected Category createCategoryRequest;
        protected Menu menuResponse;
        protected Category categoryResponse;
        protected Menu menu;
        protected Category category;
        private const string MenuPath = "menu/";
        private const string CategoryPath = "/category/";
        protected IRestResponse lastResponse;

        protected BaseTestsSteps()
        {
            var config = ConfigAccessor.GetApplicationConfiguration();
            baseUrl = config.BaseUrl;
            restClient = new RestClient(baseUrl);
        }

        protected IRestResponse SendCreateMenuRequest(Menu menuRequest)
        {
            var json = JsonConvert.SerializeObject(menuRequest);
            try {
                request = new RestRequest(MenuPath, Method.POST);
                request.AddParameter("application/json", json, ParameterType.RequestBody);
                lastResponse = restClient.Execute(request);
                if (lastResponse.StatusCode == HttpStatusCode.Created)
                {
                    menuResponse = JsonConvert.DeserializeObject<Menu>(lastResponse.Content);
                    menu.id = menuResponse.id;
                }
                else             
                {
                    throw new Exception();
                }
            }
            catch
            {
                throw new Exception($"Menu could not be created. API response: {lastResponse.Content}");
            }
            return lastResponse;
        }
        
        protected IRestResponse SendCreateCategoryRequest(Menu menuRequest, Category categoryRequest)
        {
            lastResponse =SendCreateMenuRequest(menuRequest);
            var json = JsonConvert.SerializeObject(categoryRequest);
            
         
            try {
                request = new RestRequest($"{MenuPath}{menuResponse.id}{CategoryPath}", Method.POST);
                request.AddParameter("application/json", json, ParameterType.RequestBody);
                lastResponse = restClient.Execute(request);
                if (lastResponse.StatusCode == HttpStatusCode.Created)
                {
                    categoryResponse = JsonConvert.DeserializeObject<Category>(lastResponse.Content);
                }
                else             
                {
                    throw new Exception();
                }
            }
            catch
            {
                throw new Exception($"Category could not be created. API response: {lastResponse.Content}");
            }
            return lastResponse;
        }
        
        protected IRestResponse SendDeleteMenuRequest() {
            try {
                request = new RestRequest($"{MenuPath}{menuResponse.id}", Method.DELETE);
                lastResponse = restClient.Execute(request);
            }
            catch
            {
                throw new Exception($"Menu could not be created. API response: {lastResponse.Content}");
            }
            return lastResponse;
        }

        protected IRestResponse SendGetMenuRequest()
        {
            request = new RestRequest($"{MenuPath}{menu.id}", Method.GET);
            lastResponse = restClient.Execute(request);
            menuResponse = JsonConvert.DeserializeObject<Menu>(lastResponse.Content);
            return lastResponse;
        }
        
        protected IRestResponse SendUpdateMenuRequest(Menu menuRequest)
        {
            var json = JsonConvert.SerializeObject(menuRequest);
            try {
                request = new RestRequest($"{MenuPath}{menuResponse.id}", Method.PUT);
                request.AddParameter("application/json", json, ParameterType.RequestBody);
                lastResponse = restClient.Execute(request);
            }
            catch
            {
                throw new Exception($"Menu could not be update. API response: {lastResponse.Content}");
            }
            return lastResponse;
        }
    }
}
