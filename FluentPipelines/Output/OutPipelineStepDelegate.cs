using System;

namespace FluentPipelines
{
    /// <summary>
    /// A delegate method representing a pipeline step with no input data.
    /// </summary>
    /// <typeparam name="TOutput">The type of data returned from the step.</typeparam>
    /// <returns>The resulting output data from the step.</returns>
    public delegate TOutput OutPipelineStepDelegate<out TOutput>();
}
