using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResultTypeLib
{
    public static class ResultExtension
    {
        public static IResult<TOut> Select<TIn, TOut>(this IResult<TIn> SourceResult, Func<TIn, TOut> OnSuccess)
        {
            IResult<TOut>? result = null;

            SourceResult.Match(
                (inVal) => result = Result.Success(OnSuccess(inVal)),
                (ex) => result = Result.Fail<TOut>(ex)
            );

            return result!;
        }
        public static IResult<TOut> Select<TIn, TOut>(this IResult<TIn> SourceResult, Func<TIn, TOut> OnSuccess, Func<Exception, Exception> OnFail)
        {
            IResult<TOut>? result = null;

            SourceResult.Match(
                (inVal) => result = Result.Success(OnSuccess(inVal)),
                (ex) => result = Result.Fail<TOut>(OnFail(ex))
            );

            return result!;
        }

        public static IResult<TOut> SelectResult<TIn, TOut>(this IResult<TIn> SourceResult, Func<TIn, IResult<TOut>> OnSuccess, Func<Exception, Exception> OnFail)
        {
            IResult<TOut>? result = null;

            SourceResult.Match(
                (inVal) => result = OnSuccess(inVal),
                (ex) => result = Result.Fail<TOut>(OnFail(ex))
            );

            return result!;
        }
        public static IResult<TOut> Then<TIn, TOut>(this IResult<TIn> FirstResult, IResult<TOut> NextResult)
        {
            return FirstResult.SelectResult(
                (_) => NextResult,
                (ex) => ex
            );
        }
        public static IResult<TOut> Then<TIn, TOut>(this IResult<TIn> FirstResult, Func<TIn, IResult<TOut>> NextResult)
        {
            return FirstResult.SelectResult(
                (r) => NextResult(r),
                (ex) => ex
            );
        }

    }

}