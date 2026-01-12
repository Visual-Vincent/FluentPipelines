using System;

namespace FluentPipelines
{
    /// <summary>
    /// Defines methods for a pipeline step with an output and no input.
    /// </summary>
    /// <typeparam name="TOutput">The type of data returned from the step.</typeparam>
    public interface IOutPipelineStep<TOutput>
    {
        /// <summary>
        /// Executes the step.
        /// </summary>
        /// <returns>The resulting output data from the step.</returns>
        TOutput Run();
    }
}
