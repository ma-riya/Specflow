using EmptyFiles;
using SpecflowTests.Builders;
using SpecflowTests.Models;
using Category = SpecflowTests.Models.Category;

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

    [Binding]
    public class CategoryTestsSteps : BaseTestsSteps
    {
        private readonly ScenarioContext scenarioContext;

        public CategoryTestsSteps(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
            scenarioContext.Add("RestClient", restClient);
        }

        [AfterScenario("@categoryTest")]
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

        [Given(@"I have specified a category")]
        public void WhenIHaveSpecifiedACategory()
        {
            createMenuRequest = new MenuBuilder().SetDefaultValues("Yumido Menu").Build();
            createCategoryRequest = new CategoryBuilder().WithName("Vegan Category").Build();
            scenarioContext.Add("Menu", createMenuRequest);
            scenarioContext.Add("Category", createCategoryRequest);
        }

        [Given(@"a category in the menu already exists")]
        public void GivenACategoryInTheMenuAlreadyExists()
        {
            createMenuRequest = new MenuBuilder().SetDefaultValues("Yumido Menu").Build();
            createCategoryRequest = new CategoryBuilder().WithName("Vegan Category").Build();
            scenarioContext.Add("Menu", createMenuRequest);
            scenarioContext.Add("Category", createCategoryRequest);
      
            menu = scenarioContext.Get<Menu>("Menu");
            category = scenarioContext.Get<Category>("Category");
            lastResponse = SendCreateCategoryRequest(createMenuRequest,createCategoryRequest);
            scenarioContext.Add("Response", lastResponse);
            
            
  
        }
        
        /*
          
         
         
         
         

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
            */
    }

}
