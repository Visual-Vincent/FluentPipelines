using System;
using System.Threading.Tasks;

namespace FluentPipelines.Async
{
    /// <summary>
    /// Defines methods for a builder that constructs the beginning of asynchronous pipelines with no input data.
    /// </summary>
    public interface IAsyncPipelineStartBuilder
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
        IAsyncPipelineBuilder<TNext> Then<TNext>(Func<TNext> step);

        /// <summary>
        /// Defines the first step of the pipeline.
        /// </summary>
        /// <typeparam name="TNext">
        /// The type of data returned from the step.
        /// This will be passed onto the next step (or returned as the output of the pipeline, if no more steps are added).
        /// </typeparam>
        /// <param name="step">The next step of the pipeline, processing the data from the previous step.</param>
        /// <returns>A builder that allows you to continue building the rest of the pipeline.</returns>
        IAsyncPipelineBuilder<TNext> Then<TNext>(Func<Task<TNext>> step);
    }
}
