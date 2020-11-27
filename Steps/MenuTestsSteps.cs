namespace SpecflowTests.Steps
{
    using Newtonsoft.Json;
    using RestSharp;
    using Shouldly;
    using SpecflowTests.Builders.Http;
    using SpecflowTests.Configuration;
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using TechTalk.SpecFlow;
    using SpecflowTests.Builders;
    using NUnit.Framework;

    [Binding]
    public class MenuTestsSteps : BaseTestsSteps
    {
        public readonly ScenarioContext scenarioContext;

        public MenuTestsSteps(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
            scenarioContext.Add("RestClient", restClient);
        }


        /*
        [AfterScenario("@menuTest")]
        public async Task DeleteMenu(ScenarioContext scenarioContext)
        { 
               if (scenarioContext.ContainsKey("Menu")){
                if (menuz.id != null)
                {
                    try
                    {
                        lastResponse = await HttpRequestFactory.Delete(baseUrl, $"{menuPath}{menuResponse.id}");
                        lastResponse.StatusCode.ShouldBe(HttpStatusCode.NoContent,
                   $"Response from {lastResponse.RequestMessage.Method} {lastResponse.RequestMessage.RequestUri} was not as expected");
                    }
                    catch
                    {
                        throw new Exception($"Menu could not be deleted. API response: {await lastResponse.Content.ReadAsStringAsync()}");
                    }
                }
            }
        }
        */

        [Given(@"an admin")]
        public void GivenAnAdmin()
        {
            // TODO
        }

        [Given(@"I have specified a full menu")]
        public void GivenIHaveSpecifiedAFullMenu()
        {
            scenarioContext.Add("Menu", createMenuRequest);
        }

        [Given(@"a menu already exists")]
        public async Task GivenAMenuAlreadyExists()
        {
            scenarioContext.Add("Menu", createMenuRequest);
            menuz = scenarioContext.Get<Menu>("Menu");
          //  lastResponse = await sendCreateMenu();
        }

        [When(@"I create the menu")]
        public void WhenICreateTheMenu()
        {
            menuz = scenarioContext.Get<Menu>("Menu");
            lastResponse = sendCreateMenuRequest();
            scenarioContext.Add("Response", lastResponse);
        }

        [When(@"I delete the menu")]
        public async Task WhenIDeleteTheMenu()
        {
        //    lastResponse = await HttpRequestFactory.Delete(baseUrl, $"{menuPath}{menuResponse.id}");
        }

        [When(@"I send an update menu request")]
        public async Task WhenISendAnUpdateMenuRequest()
        {
         //   lastResponse = await HttpRequestFactory.Put(baseUrl, $"{menuPath}{menuResponse.id}", createMenuRequest);
        }

        [Then(@"the menu has been created")]
        public void ThenTheMenuHasBeenCreated()
        {
            lastResponse = scenarioContext.Get<IRestResponse>("Response");
            lastResponse.StatusCode.ShouldBe(HttpStatusCode.Created, $"Response from {lastResponse.ResponseUri} was not as expected");
        }

        [Then(@"I can read the menu returned")]
        public void ThenICanReadTheMenuReturned()
        {
            menuResponse = sendGetMenuRequest(lastResponse);
            Console.WriteLine("this is reponse" + menuResponse.ResponseUri);

            lastResponse.StatusCode.ShouldBe(HttpStatusCode.OK, $"Response from  {lastResponse.ResponseUri} was not as expected");
            var menuResponsesSer = JsonConvert.DeserializeObject<Menu>(lastResponse.Content);
            Console.WriteLine("this is reponse" + menuResponsesSer.id);
            Console.WriteLine("this is reponse" + menuResponsesSer.name);




            /*
            var responseMenu = JsonConvert.DeserializeObject<Menu>(await lastResponse.Content.ReadAsStringAsync());
            responseMenu.name.ShouldBe(createMenuRequest.name,
    $"{lastResponse.RequestMessage.Method} {lastResponse.RequestMessage.RequestUri} did not create the menu as expected");
            responseMenu.description.ShouldBe(createMenuRequest.description,
    $"{lastResponse.RequestMessage.Method} {lastResponse.RequestMessage.RequestUri} did not create the menu as expected");
            responseMenu.enabled.ShouldBe(createMenuRequest.enabled,
    $"{lastResponse.RequestMessage.Method} {lastResponse.RequestMessage.RequestUri} did not create the menu as expected");
    */
        }

        /*
        [Then(@"the menu has been deleted")]
        public void ThenTheMenuHasBeenDeleted()
        {
            lastResponse.StatusCode.ShouldBe(HttpStatusCode.NoContent,
                         $"Response from {lastResponse.RequestMessage.Method} {lastResponse.RequestMessage.RequestUri} was not as expected");
            menuz = scenarioContext.Get<Menu>("Menu");
            menuz.id = null;
        }


        [Then(@"the menu is updated correctly")]
        public async Task ThenTheMenuIsUpdatedCorrectly()
        {
            lastResponse.StatusCode.ShouldBe(HttpStatusCode.NoContent,
                         $"Response from {lastResponse.RequestMessage.Method} {lastResponse.RequestMessage.RequestUri} was not as expected");

            var updatedResponse = await HttpRequestFactory.Get(baseUrl, $"{menuPath}{menuResponse.id}");

            if (updatedResponse.StatusCode == HttpStatusCode.OK)
            {
                var updateMenuResponse = JsonConvert.DeserializeObject<Menu>(await updatedResponse.Content.ReadAsStringAsync());

                updateMenuResponse.name.ShouldBe(createMenuRequest.name,
                    $"{lastResponse.RequestMessage.Method} {lastResponse.RequestMessage.RequestUri} did not create the menu as expected");

                updateMenuResponse.description.ShouldBe(createMenuRequest.description,
                    $"{lastResponse.RequestMessage.Method} {lastResponse.RequestMessage.RequestUri} did not create the menu as expected");

                updateMenuResponse.enabled.ShouldBe(createMenuRequest.enabled,
                    $"{lastResponse.RequestMessage.Method} {lastResponse.RequestMessage.RequestUri} did not create the menu as expected");
            }
            else
            {
                //throw exception rather than use assertions if the GET request fails as GET is not the subject of the test
                //Assertions should only be used on the subject of the test
                throw new Exception($"Could not retrieve the updated menu using GET /menu/{menuResponse.id}");
            }
        }
        */
    }
}
