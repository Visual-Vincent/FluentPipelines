using System;
using System.Threading.Tasks;

namespace FluentPipelines.Async
{
    /// <summary>
    /// Defines methods for a builder that constructs asynchronous pipelines with input and output data.
    /// </summary>
    /// <typeparam name="TIn">The type of data used as input to the pipeline.</typeparam>
    /// <typeparam name="TOut">The type of data returned as the output of the pipeline.</typeparam>
    public interface IAsyncPipelineBuilder<TIn, TOut>
    {
        /// <summary>
        /// Compiles all steps defined by the builder into a runnable pipeline.
        /// </summary>
        /// <returns>The resulting pipeline.</returns>
        IAsyncPipeline<TIn, TOut> Build();

        /// <summary>
        /// Defines the next step of the pipeline.
        /// </summary>
        /// <typeparam name="TNext">
        /// The type of data returned from the step.
        /// This will be passed onto the next step (or returned as the output of the pipeline, if no more steps are added).
        /// </typeparam>
        /// <param name="step">The next step of the pipeline, processing the data from the previous step.</param>
        /// <returns>A builder that allows you to continue building the rest of the pipeline.</returns>
        IAsyncPipelineBuilder<TIn, TNext> Then<TNext>(Func<TOut, TNext> step);

        /// <summary>
        /// Defines the next step of the pipeline.
        /// </summary>
        /// <typeparam name="TNext">
        /// The type of data returned from the step.
        /// This will be passed onto the next step (or returned as the output of the pipeline, if no more steps are added).
        /// </typeparam>
        /// <param name="step">The next step of the pipeline, processing the data from the previous step.</param>
        /// <returns>A builder that allows you to continue building the rest of the pipeline.</returns>
        IAsyncPipelineBuilder<TIn, TNext> Then<TNext>(Func<TOut, Task<TNext>> step);

        /// <summary>
        /// Defines the final step of the pipeline, returning no output data.
        /// </summary>
        /// <param name="step">The final step of the pipeline, processing the data from the previous step and completing the pipeline.</param>
        /// <returns>A builder that allows you to build the pipeline.</returns>
        IAsyncInPipelineBuilder<TIn> Then(Action<TOut> step);

        /// <summary>
        /// Defines the final step of the pipeline, returning no output data.
        /// </summary>
        /// <param name="step">The final step of the pipeline, processing the data from the previous step and completing the pipeline.</param>
        /// <returns>A builder that allows you to build the pipeline.</returns>
        IAsyncInPipelineBuilder<TIn> Then(Func<TOut, Task> step);
    }
}
