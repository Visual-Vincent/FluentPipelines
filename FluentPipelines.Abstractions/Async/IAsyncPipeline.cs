using System;
using System.Threading.Tasks;

namespace FluentPipelines.Async
{
    /// <summary>
    /// Defines methods for an asynchronous pipeline with no input nor output.
    /// </summary>
    public interface IAsyncPipeline
    {
        /// <summary>
        /// Asynchronously runs the pipeline.
        /// </summary>
        Task RunAsync();
    }
}
