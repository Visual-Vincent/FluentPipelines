using System;

namespace FluentPipelines
{
    /// <summary>
    /// Defines methods for a step in a pipeline with input data and no output data.
    /// </summary>
    /// <typeparam name="TInput">The type of data used as input to the step.</typeparam>
    public interface IInPipelineStep<TInput>
    {
        /// <summary>
        /// Executes the step.
        /// </summary>
        /// <param name="input">The input data to process.</param>
        void Run(TInput input);
    }
}
