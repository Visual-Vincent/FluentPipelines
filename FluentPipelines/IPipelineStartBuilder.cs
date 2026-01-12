using System;

namespace FluentPipelines
{
    /// <summary>
    /// Defines methods for a builder that constructs the beginning of pipelines with no input data.
    /// </summary>
    public interface IPipelineStartBuilder
    {
        /// <summary>
        /// Defines the starting step of the pipeline.
        /// </summary>
        /// <typeparam name="TNext">
        /// The type of data returned from the step.
        /// This will be passed onto the next step (or returned as the output of the pipeline, if no more steps are added).
        /// </typeparam>
        /// <param name="action">A function acting as the first step of the pipeline.</param>
        /// <returns>A builder that allows you to continue building the rest of the pipeline.</returns>
        IOutPipelineBuilder<TNext> Start<TNext>(OutPipelineStepDelegate<TNext> action);

        /// <summary>
        /// Defines the starting step of the pipeline.
        /// </summary>
        /// <typeparam name="TNext">
        /// The type of data returned from the step.
        /// This will be passed onto the next step (or returned as the output of the pipeline, if no more steps are added).
        /// </typeparam>
        /// <param name="step">The first step of the pipeline.</param>
        /// <returns>A builder that allows you to continue building the rest of the pipeline.</returns>
        IOutPipelineBuilder<TNext> Start<TNext>(IOutPipelineStep<TNext> step);
    }

    /// <summary>
    /// Defines methods for a builder that constructs the beginning of pipelines taking input data.
    /// </summary>
    /// <typeparam name="TInput">The type of data used as input to the pipeline.</typeparam>
    public interface IPipelineStartBuilder<TInput>
    {
        /// <summary>
        /// Defines the starting step of the pipeline.
        /// </summary>
        /// <typeparam name="TNext">
        /// The type of data returned from the step.
        /// This will be passed onto the next step (or returned as the output of the pipeline, if no more steps are added).
        /// </typeparam>
        /// <param name="action">A function acting as the first step of the pipeline, processing the input data.</param>
        /// <returns>A builder that allows you to continue building the rest of the pipeline.</returns>
        IPipelineBuilder<TInput, TNext> Start<TNext>(PipelineStepDelegate<TInput, TNext> action);

        /// <summary>
        /// Defines the starting step of the pipeline.
        /// </summary>
        /// <typeparam name="TNext">
        /// The type of data returned from the step.
        /// This will be passed onto the next step (or returned as the output of the pipeline, if no more steps are added).
        /// </typeparam>
        /// <param name="step">The first step of the pipeline, processing the input data.</param>
        /// <returns>A builder that allows you to continue building the rest of the pipeline.</returns>
        IPipelineBuilder<TInput, TNext> Start<TNext>(IPipelineStep<TInput, TNext> step);
    }
}
