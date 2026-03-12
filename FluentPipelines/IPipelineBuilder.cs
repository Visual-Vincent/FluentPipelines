using System;

namespace FluentPipelines
{
    /// <summary>
    /// Defines methods for a builder that constructs pipelines with no input nor output data.
    /// </summary>
    public interface IPipelineBuilder
    {
        /// <summary>
        /// Compiles all steps defined by the builder into a runnable pipeline.
        /// </summary>
        /// <returns>The resulting pipeline.</returns>
        IPipeline Build();
    }
}
