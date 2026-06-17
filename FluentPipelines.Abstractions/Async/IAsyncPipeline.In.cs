using System;
using System.Threading.Tasks;

namespace FluentPipelines.Async
{
    /// <summary>
    /// Defines methods for an asynchronous pipeline that takes <typeparamref name="TIn"/> as input, and has no output.
    /// </summary>
    /// <typeparam name="TIn">The type of data used as input to the pipeline.</typeparam>
    public interface IAsyncInPipeline<TIn>
    {
        /// <summary>
        /// Asynchronously runs the pipeline.
        /// </summary>
        /// <param name="input">The input data.</param>
        Task RunAsync(TIn input);
    }
}
