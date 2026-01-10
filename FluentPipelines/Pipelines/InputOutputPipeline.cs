using System;
using System.Collections.Generic;
using System.Linq;

namespace FluentPipelines.Pipelines
{
    /// <summary>
    /// A pipeline that takes <typeparamref name="TInput"/> as input, and returns <typeparamref name="TOutput"/>.
    /// </summary>
    /// <typeparam name="TInput">The type of data used as input to the pipeline.</typeparam>
    /// <typeparam name="TOutput">The type of data returned from the pipeline.</typeparam>
    public sealed class InputOutputPipeline<TInput, TOutput> : IPipeline<TInput, TOutput>
    {
        private readonly PipelineStep[] steps;

        /// <summary>
        /// Initializes a new instance of the <see cref="InputOutputPipeline{TInput, TOutput}"/> class.
        /// </summary>
        /// <param name="steps">
        /// The steps to be executed as part of the pipeline.
        /// It is important that the first step takes <typeparamref name="TInput"/> as input, 
        /// and that the final step returns <typeparamref name="TOutput"/>.
        /// </param>
        public InputOutputPipeline(IEnumerable<PipelineStep> steps)
        {
            if(steps is null)
                throw new ArgumentNullException(nameof(steps));

            if(!steps.Any())
                throw new ArgumentException("No steps specified", nameof(steps));

            this.steps = steps.ToArray();
        }

        /// <inheritdoc/>
        public TOutput Run(TInput input)
        {
            return (TOutput)steps.Execute(input);
        }
    }

    /// <summary>
    /// A static class containing helper methods for <see cref="InputOutputPipeline{TInput, TOutput}"/>.
    /// </summary>
    public static class InputOutputPipeline
    {
        /// <summary>
        /// Creates an <see cref="InputOutputPipeline{TInput, TOutput}"/> from a <see cref="PipelineBuilder{TInput, TOutput}"/>.
        /// </summary>
        /// <typeparam name="TInput">The type of data used as input to the pipeline.</typeparam>
        /// <typeparam name="TOutput">The type of data returned from the pipeline.</typeparam>
        /// <param name="builder">The builder containing the steps to be executed as part of the pipeline.</param>
        /// <returns>The resulting pipeline.</returns>
        public static InputOutputPipeline<TInput, TOutput> CreateFrom<TInput, TOutput>(PipelineBuilder<TInput, TOutput> builder)
        {
            return new InputOutputPipeline<TInput, TOutput>(builder.Steps);
        }
    }
}
