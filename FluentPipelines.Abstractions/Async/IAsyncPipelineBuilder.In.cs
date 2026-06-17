using System;

namespace FluentPipelines.Async
{
    /// <summary>
    /// Defines methods for a builder that constructs asynchronous pipelines with input data and no output data.
    /// </summary>
    /// <typeparam name="TIn">The type of data used as input to the pipeline.</typeparam>
    public interface IAsyncInPipelineBuilder<TIn>
    {
        /// <summary>
        /// Compiles all steps defined by the builder into a runnable pipeline.
        /// </summary>
        /// <returns>The resulting pipeline.</returns>
        IAsyncInPipeline<TIn> Build();
    }
}
