using System;

namespace FluentPipelines
{
    /// <summary>
    /// Defines methods for a step in a pipeline.
    /// </summary>
    /// <typeparam name="TInput">The type of data used as input to the step.</typeparam>
    /// <typeparam name="TOutput">The type of data returned from the step.</typeparam>
    public interface IPipelineStep<TInput, TOutput>
    {
        /// <summary>
        /// Executes the step.
        /// </summary>
        /// <param name="input">The input data to process.</param>
        /// <returns>The resulting output data from the step.</returns>
        TOutput Run(TInput input);
    }
}
