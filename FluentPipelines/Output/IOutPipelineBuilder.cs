using System;

namespace FluentPipelines
{
    /// <summary>
    /// Defines methods for a builder that constructs pipelines with output data and no input data.
    /// </summary>
    /// <typeparam name="TOutput">The type of data returned as the output of the pipeline.</typeparam>
    public interface IOutPipelineBuilder<TOutput>
    {
        /// <summary>
        /// Compiles all steps and builds a runnable pipeline.
        /// </summary>
        /// <returns>The resulting pipeline.</returns>
        IOutPipeline<TOutput> Build();

        /// <summary>
        /// Defines the next step of the pipeline.
        /// </summary>
        /// <typeparam name="TNext">
        /// The type of data returned from the step.
        /// This will be passed onto the next step (or returned as the output of the pipeline, if no more steps are added).
        /// </typeparam>
        /// <param name="action">A function acting as the next step of the pipeline, processing the data from the previous step.</param>
        /// <returns>A builder that allows you to continue building the rest of the pipeline.</returns>
        IOutPipelineBuilder<TNext> Then<TNext>(PipelineStepDelegate<TOutput, TNext> action);

        /// <summary>
        /// Defines the next step of the pipeline.
        /// </summary>
        /// <typeparam name="TNext">
        /// The type of data returned from the step.
        /// This will be passed onto the next step (or returned as the output of the pipeline, if no more steps are added).
        /// </typeparam>
        /// <param name="step">The next step of the pipeline, processing the data from the previous step.</param>
        /// <returns>A builder that allows you to continue building the rest of the pipeline.</returns>
        IOutPipelineBuilder<TNext> Then<TNext>(IPipelineStep<TOutput, TNext> step);
    }
}
