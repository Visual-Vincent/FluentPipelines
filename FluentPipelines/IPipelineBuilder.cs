using System;

namespace FluentPipelines
{
    /// <summary>
    /// Defines methods for a builder that constructs pipelines with input and output data.
    /// </summary>
    /// <typeparam name="TInput">The type of data used as input to the pipeline.</typeparam>
    /// <typeparam name="TOutput">The type of data returned as the output of the pipeline.</typeparam>
    public interface IPipelineBuilder<TInput, TOutput>
    {
        /// <summary>
        /// Compiles all steps and builds a runnable pipeline.
        /// </summary>
        /// <returns>The resulting pipeline.</returns>
        IPipeline<TInput, TOutput> Build();

        /// <summary>
        /// Defines the next step of the pipeline.
        /// </summary>
        /// <typeparam name="TNext">
        /// The type of data returned from the step.
        /// This will be passed onto the next step (or returned as the output of the pipeline, if no more steps are added).
        /// </typeparam>
        /// <param name="action">A function acting as the next step of the pipeline, processing the data from the previous step.</param>
        /// <returns>A builder that allows you to continue building the rest of the pipeline.</returns>
        IPipelineBuilder<TInput, TNext> Then<TNext>(PipelineStepDelegate<TOutput, TNext> action);

        /// <summary>
        /// Defines the next step of the pipeline.
        /// </summary>
        /// <typeparam name="TNext">
        /// The type of data returned from the step.
        /// This will be passed onto the next step (or returned as the output of the pipeline, if no more steps are added).
        /// </typeparam>
        /// <param name="step">The next step of the pipeline, processing the data from the previous step.</param>
        /// <returns>A builder that allows you to continue building the rest of the pipeline.</returns>
        IPipelineBuilder<TInput, TNext> Then<TNext>(IPipelineStep<TOutput, TNext> step);

        /// <summary>
        /// Defines the final step of the pipeline, returning no output data.
        /// </summary>
        /// <param name="action">A function acting as the next step of the pipeline, processing the data from the previous step and completing the pipeline.</param>
        /// <returns>A builder that allows you to build the pipeline.</returns>
        IInPipelineBuilder<TInput> Then(InPipelineStepDelegate<TOutput> action);

        /// <summary>
        /// Defines the final step of the pipeline, returning no output data.
        /// </summary>
        /// <param name="step">The next step of the pipeline, processing the data from the previous step and completing the pipeline.</param>
        /// <returns>A builder that allows you to build the pipeline.</returns>
        IInPipelineBuilder<TInput> Then(IInPipelineStep<TOutput> step);
    }
}
