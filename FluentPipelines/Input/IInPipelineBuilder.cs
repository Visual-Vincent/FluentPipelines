using System;

namespace FluentPipelines
{
    /// <summary>
    /// Defines methods for a builder that constructs pipelines with input data and no output data.
    /// </summary>
    /// <typeparam name="TInput">The type of data used as input to the pipeline.</typeparam>
    public interface IInPipelineBuilder<TInput>
    {
        /// <summary>
        /// Compiles all steps and builds a runnable pipeline.
        /// </summary>
        /// <returns>The resulting pipeline.</returns>
        IInPipeline<TInput> Build();
    }
}
