namespace SpecflowTests.Steps
{
    using Newtonsoft.Json;
    using Shouldly;
    using SpecflowTests.Builders.Http;
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using TechTalk.SpecFlow;
    /*
    [Binding]
    public class CategoryTestsSteps : BaseTestsSteps
    {
        private HttpResponseMessage lastResponse;
        public readonly ScenarioContext scenarioContext;

        public CategoryTestsSteps(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }

        [AfterScenario("@categoryTest")]
        public async Task DeleteMenu(ScenarioContext scenarioContext)
        {

            if (scenarioContext.ContainsKey("Menu"))
            {
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

        [Given(@"I have specified a category")]
        public void WhenIHaveSpecifiedACategory()
        {
            scenarioContext.Add("Menu", createMenuRequest);
            scenarioContext.Add("Category", createCategoryRequest);
        }

        [Given(@"a category in the menu already exists")]
        public async Task GivenACategoryInTheMenuAlreadyExists()
        {
            scenarioContext.Add("Menu", createMenuRequest);
            scenarioContext.Add("Category", createCategoryRequest);
            menuz = scenarioContext.Get<Menu>("Menu");
            categoryz = scenarioContext.Get<Category>("Category");
            lastResponse = await sendCreateCategory();
        }

        [When(@"I create the category")]
        public async Task WhenICreateTheCategory()
        {
            menuz = scenarioContext.Get<Menu>("Menu");
            categoryz = scenarioContext.Get<Category>("Category");
            lastResponse = await sendCreateCategory();
        }

        [When(@"I delete the category")]
        public async Task WhenIDeleteTheCategory()
        {
            lastResponse = await HttpRequestFactory.Delete(baseUrl, $"{menuPath}{menuResponse.id}{categoryPath}{categoryResponse.id}");
        }

        [Then(@"the category has been created")]
        public void ThenTheCategoryHasBeenCreated()
        {
            categoryz = scenarioContext.Get<Category>("Category");
            categoryz.id = categoryResponse.id;
            lastResponse.StatusCode.ShouldBe(HttpStatusCode.Created,
               $"Response from {lastResponse.RequestMessage.Method} {lastResponse.RequestMessage.RequestUri} was not as expected");
            categoryz.id.ShouldNotBe(null,
                $"{lastResponse.RequestMessage.Method} {lastResponse.RequestMessage.RequestUri} did not create category as expected");
        }

        [Then(@"I can read the category returned")]
        public async Task ThenICanReadTheCategoryReturned()
        {
            lastResponse = await HttpRequestFactory.Get(baseUrl, $"{menuPath}{menuResponse.id}");
            lastResponse.StatusCode.ShouldBe(HttpStatusCode.OK, $"Response from {lastResponse.RequestMessage.Method} {lastResponse.RequestMessage.RequestUri} was not as expected");

            menuResponse = JsonConvert.DeserializeObject<Menu>(await lastResponse.Content.ReadAsStringAsync());
            menuResponse.categories[0].name.ShouldBe(categoryz.name,
    $"{lastResponse.RequestMessage.Method} {lastResponse.RequestMessage.RequestUri} did not create the menu as expected");
        }

        [Then(@"the category has been deleted")]
        public void ThenTheCategoryHasBeenDeleted()
        {
            lastResponse.StatusCode.ShouldBe(HttpStatusCode.NoContent,
          $"Response from {lastResponse.RequestMessage.Method} {lastResponse.RequestMessage.RequestUri} was not as expected");
        }
    }
    */
}
