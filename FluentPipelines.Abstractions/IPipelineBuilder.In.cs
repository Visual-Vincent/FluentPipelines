using System;

namespace FluentPipelines
{
    /// <summary>
    /// Defines methods for a builder that constructs pipelines with input data and no output data.
    /// </summary>
    /// <typeparam name="TIn">The type of data used as input to the pipeline.</typeparam>
    public interface IInPipelineBuilder<TIn>
    {
        /// <summary>
        /// Compiles all steps defined by the builder into a runnable pipeline.
        /// </summary>
        /// <returns>The resulting pipeline.</returns>
        IInPipeline<TIn> Build();
    }
}
