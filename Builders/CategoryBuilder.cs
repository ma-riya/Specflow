using System;
using System.Collections.Generic;
using SpecflowTests.Models;

namespace SpecflowTests.Builders
{
    public class CategoryBuilder : IBuilder<Category>

    {
        private Category category;

        public CategoryBuilder()
        {
            category = new Category();
        }

        public CategoryBuilder SetDefaultValues(string name)
        {
            //    var itemBuilder = new ItemBuilder();

            category.Id = Guid.NewGuid().ToString();
            category.Name = name;
            //   category.items = new List<Item>()
            //   {
            //       itemBuilder.SetDefaultValues("Burger")
            //     .Build()
            //  };
            return this;
        }

        public CategoryBuilder WithId(Guid id)
        {
            category.Id = id.ToString();
            return this;
        }

        public CategoryBuilder WithName(string name)
        {
            category.Name = name;
            return this;
        }

   
        public CategoryBuilder WithNoItems()
        {
            category.Items = new List<Item>();
            return this;
        }


        public CategoryBuilder WithItems(List<Item> items)
        {
            category.Items = items;
            return this;
        }
              

        public Category Build()
        {
            return category;
        }
    }
}