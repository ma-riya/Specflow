using System;
using System.Collections.Generic;
using System.Text;

namespace SpecflowTests.Builders
{
    public interface IBuilder<T>
    {
        T Build();
    }
}
