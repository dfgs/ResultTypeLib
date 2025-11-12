using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResultTypeLib
{
    public interface IResult<T>
    {
        IResult<T> Match(Action<T> OnSuccess, Action<Exception> OnFailure);
		bool Succeeded();
		bool Succeeded(out T Value);


	}
}
