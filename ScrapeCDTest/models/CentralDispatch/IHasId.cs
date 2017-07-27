using System;
using System.Collections.Generic;
using System.Text;

namespace ScrapeCDTest.models.CentralDispatch
{
    public interface IHasId<T>
    {
        T Id { get; }
    }
}
