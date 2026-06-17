using System;
using System.Threading.Tasks;

namespace FluentPipelines.Async
{
    /// <summary>
    /// Defines methods for a builder that constructs asynchronous pipelines with output data and no input data.
    /// </summary>
    /// <typeparam name="TOut">The type of data returned as the output of the pipeline.</typeparam>
    public interface IAsyncPipelineBuilder<TOut>
    {
        /// <summary>
        /// Compiles all steps defined by the builder into a runnable pipeline.
        /// </summary>
        /// <returns>The resulting pipeline.</returns>
        IAsyncPipeline<TOut> Build();

        /// <summary>
        /// Defines the next step of the pipeline.
        /// </summary>
        /// <typeparam name="TNext">
        /// The type of data returned from the step.
        /// This will be passed onto the next step (or returned as the output of the pipeline, if no more steps are added).
        /// </typeparam>
        /// <param name="step">The next step of the pipeline, processing the data from the previous step.</param>
        /// <returns>A builder that allows you to continue building the rest of the pipeline.</returns>
        IAsyncPipelineBuilder<TNext> Then<TNext>(Func<TOut, TNext> step);

        /// <summary>
        /// Defines the next step of the pipeline.
        /// </summary>
        /// <typeparam name="TNext">
        /// The type of data returned from the step.
        /// This will be passed onto the next step (or returned as the output of the pipeline, if no more steps are added).
        /// </typeparam>
        /// <param name="step">The next step of the pipeline, processing the data from the previous step.</param>
        /// <returns>A builder that allows you to continue building the rest of the pipeline.</returns>
        IAsyncPipelineBuilder<TNext> Then<TNext>(Func<TOut, Task<TNext>> step);

        /// <summary>
        /// Defines the final step of the pipeline, returning no output.
        /// </summary>
        /// <param name="step">The final step of the pipeline, processing the data from the previous step.</param>
        /// <returns>A builder that allows you to build the pipeline.</returns>
        IAsyncPipelineBuilder Then(Action<TOut> step);

        /// <summary>
        /// Defines the final step of the pipeline, returning no output.
        /// </summary>
        /// <param name="step">The final step of the pipeline, processing the data from the previous step.</param>
        /// <returns>A builder that allows you to build the pipeline.</returns>
        IAsyncPipelineBuilder Then(Func<TOut, Task> step);
    }
}
