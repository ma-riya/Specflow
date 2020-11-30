using SpecflowTests.Builders;
using SpecflowTests.Models;

namespace SpecflowTests.Steps
{
    using RestSharp;
    using Shouldly;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using TechTalk.SpecFlow;

    [Binding]
    public class MenuTestsSteps : BaseTestsSteps
    {
        private readonly ScenarioContext scenarioContext;

        public MenuTestsSteps(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
            scenarioContext.Add("RestClient", restClient);
        }

        [AfterScenario("@menuTest")]
        public void DeleteMenu(ScenarioContext context)
        {
            if (context.ContainsKey("Menu"))
            {
                if (menu.id != null)
                {
                    try
                    {
                        lastResponse = SendDeleteMenuRequest();
                        lastResponse.StatusCode.ShouldBe(HttpStatusCode.NoContent,
                            $"Response from {lastResponse.Request.Method} {lastResponse.ResponseUri} was not as expected");
                    }
                    catch
                    {
                        throw new Exception($"Menu could not be deleted. API response: {lastResponse.Content}");
                    }
                }
            }
        }

        [Given(@"an admin")]
        public void GivenAnAdmin()
        {
            // TODO
        }

        [Given(@"I have specified a full menu")]
        public void GivenIHaveSpecifiedAFullMenu()
        {
            createMenuRequest = new MenuBuilder().SetDefaultValues("Yumido Menu").Build();
            scenarioContext.Add("Menu", createMenuRequest);
        }

        [Given(@"a menu already exists")]
        public void GivenAMenuAlreadyExists()
        {
            createMenuRequest = new MenuBuilder().SetDefaultValues("Yumido Menu").Build();
            scenarioContext.Add("Menu", createMenuRequest);
            menu = scenarioContext.Get<Menu>("Menu");
            lastResponse = SendCreateMenuRequest(createMenuRequest);
            scenarioContext.Add("Response", lastResponse);
            Console.WriteLine(createMenuRequest.id + " this is menuresponse");
        }

        [When(@"I create the menu")]
        public void WhenICreateTheMenu()
        {
            menu = scenarioContext.Get<Menu>("Menu");
            lastResponse = SendCreateMenuRequest(createMenuRequest);
            scenarioContext.Add("Response", lastResponse);
        }

        [When(@"I delete the menu")]
        public void WhenIDeleteTheMenu()
        {
            lastResponse = SendDeleteMenuRequest();
        }

        [When(@"I send an update menu request")]
        public void WhenISendAnUpdateMenuRequest()
        {
            updateMenuRequest = new MenuBuilder().SetDefaultValues("Lunch Menu Updated").Build();
            lastResponse = SendUpdateMenuRequest(updateMenuRequest);
        }

        [Then(@"the menu has been created")]
        public void ThenTheMenuHasBeenCreated()
        {
            lastResponse.StatusCode.ShouldBe(HttpStatusCode.Created,
                $"Response from {lastResponse.ResponseUri} was not as expected");
        }

        [Then(@"I can read the menu returned")]
        public void ThenICanReadTheMenuReturned()
        {
            lastResponse = SendGetMenuRequest();
            lastResponse.StatusCode.ShouldBe(HttpStatusCode.OK,
                $"Response from {lastResponse.Request.Method} {lastResponse.ResponseUri} was not as expected");
            menuResponse.name.ShouldBe(createMenuRequest.name,
                $"{lastResponse.Request.Method} did not get the menu as expected");
            menuResponse.description.ShouldBe(createMenuRequest.description,
                $"{lastResponse.Request.Method} did not get the menu as expected");
            menuResponse.enabled.ShouldBe(createMenuRequest.enabled,
                $"{lastResponse.Request.Method} did not get the menu as expected");
        }

        [Then(@"the menu has been deleted")]
        public void ThenTheMenuHasBeenDeleted()
        {
            lastResponse.StatusCode.ShouldBe(HttpStatusCode.NoContent,
                $"Response from {lastResponse.Request.Method} {lastResponse.ResponseUri} was not as expected");
            menu = scenarioContext.Get<Menu>("Menu");
            menu.id = null;
        }


        [Then(@"the menu is updated correctly")]
        public void ThenTheMenuIsUpdatedCorrectly()
        {
            lastResponse.StatusCode.ShouldBe(HttpStatusCode.NoContent,
                $"Response from {lastResponse.Request.Method} {lastResponse.ResponseUri} was not as expected");
        }

        [Then(@"I can read the updated menu")]
        public void ThenICanReadTheUpdatedMenu()
        {
            lastResponse = SendGetMenuRequest();
            if (lastResponse.StatusCode == HttpStatusCode.OK)
            {
                menuResponse.name.ShouldBe(updateMenuRequest.name,
                    $"{lastResponse.Request.Method} did not get the menu as expected");
                menuResponse.description.ShouldBe(updateMenuRequest.description,
                    $"Response from {lastResponse.Request.Method} {lastResponse.ResponseUri} did not update the menu as expected");

                menuResponse.enabled.ShouldBe(updateMenuRequest.enabled,
                    $"{lastResponse.Request.Method} {lastResponse.ResponseUri} did not update the menu as expected");
            }
            else
            {
                throw new Exception($"Could not retrieve the updated menu using GET /menu/{menuResponse.id}");
            }

        }
    }
}