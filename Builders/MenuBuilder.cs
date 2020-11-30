using System;
using System.Collections.Generic;
using System.Text;
using SpecflowTests.Models;

namespace SpecflowTests.Builders
{
    public class MenuBuilder : IBuilder<Menu>
    {
        private Menu menu;

        public MenuBuilder()
        {
            menu = new Menu();
        }


        public MenuBuilder SetDefaultValues(string name)
        {
           menu.id = Guid.NewGuid().ToString();
            menu.name = name;
            menu.description = "Default test menu description";
            menu.enabled = true;
            return this;
           
        }

        public MenuBuilder WithId(Guid id)
        {
            menu.id = id.ToString();
            return this;
        }

        public MenuBuilder WithName(string name)
        {
            menu.name = name;
            return this;
        }

        public MenuBuilder WithDescription(string description)
        {
            menu.description = description;
            return this;
        }
      
        public MenuBuilder SetEnabled(bool enabled)
        {
            menu.enabled = enabled;
            return this;
        }

        public Menu Build()
        {
            return menu;
        }
    }
}