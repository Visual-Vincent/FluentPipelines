using System;

namespace FluentPipelines.Async
{
    /// <summary>
    /// Defines methods for a builder that constructs asynchronous pipelines with no input nor output data.
    /// </summary>
    public interface IAsyncPipelineBuilder
    {
        /// <summary>
        /// Compiles all steps defined by the builder into a runnable pipeline.
        /// </summary>
        /// <returns>The resulting pipeline.</returns>
        IAsyncPipeline Build();
    }
}
