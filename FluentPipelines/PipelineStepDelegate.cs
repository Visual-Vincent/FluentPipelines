using System;

namespace FluentPipelines
{
    /// <summary>
    /// A delegate method representing a pipeline step.
    /// </summary>
    /// <typeparam name="TInput">The type of data used as input to the step.</typeparam>
    /// <typeparam name="TOutput">The type of data returned from the step.</typeparam>
    /// <param name="input">The input data to process.</param>
    /// <returns>The resulting output data from the step.</returns>
    public delegate TOutput PipelineStepDelegate<in TInput, out TOutput>(TInput input);
}
