using System;

namespace FluentPipelines
{
    /// <summary>
    /// A delegate method representing a pipeline step.
    /// </summary>
    /// <typeparam name="TInput">The type of data used as input to the step.</typeparam>
    /// <param name="input">The input data to process.</param>
    public delegate void InPipelineStepDelegate<in TInput>(TInput input);
}
