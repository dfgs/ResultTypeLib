using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResultTypeLib
{
    public interface IResult<T>
    {
        bool Match(Action<T> OnSuccess, Action<Exception> OnFailure);
        bool Succeeded();

    }
}
