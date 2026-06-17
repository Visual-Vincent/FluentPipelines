using System;
using System.Threading.Tasks;

namespace FluentPipelines.Async
{
    /// <summary>
    /// Defines methods for an asynchronous pipeline that takes no input, and returns <typeparamref name="TOut"/>.
    /// </summary>
    /// <typeparam name="TOut">The type of data returned from the pipeline.</typeparam>
    public interface IAsyncPipeline<TOut>
    {
        /// <summary>
        /// Asynchronously runs the pipeline.
        /// </summary>
        /// <returns>The result of the pipeline.</returns>
        Task<TOut> RunAsync();
    }
}
