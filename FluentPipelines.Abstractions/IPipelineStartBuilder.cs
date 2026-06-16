using System;

namespace FluentPipelines
{
    /// <summary>
    /// Defines methods for a builder that constructs the beginning of pipelines with no input data.
    /// </summary>
    public interface IPipelineStartBuilder
    {
        /// <summary>
        /// Defines the first step of the pipeline.
        /// </summary>
        /// <typeparam name="TNext">
        /// The type of data returned from the step.
        /// This will be passed onto the next step (or returned as the output of the pipeline, if no more steps are added).
        /// </typeparam>
        /// <param name="step">The next step of the pipeline, processing the data from the previous step.</param>
        /// <returns>A builder that allows you to continue building the rest of the pipeline.</returns>
        IPipelineBuilder<TNext> Then<TNext>(Func<TNext> step);
    }
}
