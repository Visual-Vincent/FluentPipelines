using System;
using System.Threading.Tasks;

namespace FluentPipelines.Async
{
    /// <summary>
    /// Defines methods for an asynchronous pipeline that takes <typeparamref name="TIn"/> as input, and returns <typeparamref name="TOut"/>.
    /// </summary>
    /// <typeparam name="TIn">The type of data used as input to the pipeline.</typeparam>
    /// <typeparam name="TOut">The type of data returned from the pipeline.</typeparam>
    public interface IAsyncPipeline<TIn, TOut>
    {
        /// <summary>
        /// Asynchronously runs the pipeline.
        /// </summary>
        /// <param name="input">The input data.</param>
        /// <returns>The result of the pipeline.</returns>
        Task<TOut> RunAsync(TIn input);
    }
}
