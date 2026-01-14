using System;
using System.Collections.Generic;
using System.Linq;

namespace FluentPipelines
{
    /// <summary>
    /// A pipeline that takes <typeparamref name="TInput"/> as input, and has no output.
    /// </summary>
    /// <typeparam name="TInput">The type of data used as input to the pipeline.</typeparam>
    public sealed class InPipeline<TInput> : IInPipeline<TInput>
    {
        private readonly PipelineStep[] steps;

        /// <summary>
        /// Initializes a new instance of the <see cref="InPipeline{TInput}"/> class.
        /// </summary>
        /// <param name="steps">
        /// The steps to be executed as part of the pipeline.
        /// It is important that the first step takes <typeparamref name="TInput"/> as input.
        /// </param>
        public InPipeline(IEnumerable<PipelineStep> steps)
        {
            if(steps is null)
                throw new ArgumentNullException(nameof(steps));

            if(!steps.Any())
                throw new ArgumentException("No steps specified", nameof(steps));

            this.steps = steps.ToArray();
        }

        /// <inheritdoc/>
        public void Run(TInput input)
        {
            steps.Execute(input);
        }
    }

    /// <summary>
    /// A static class containing helper methods for <see cref="InPipeline{TInput}"/>.
    /// </summary>
    public static class InputPipeline
    {
        /// <summary>
        /// Creates an <see cref="InPipeline{TInput}"/> from a <see cref="InPipelineBuilder{TInput}"/>.
        /// </summary>
        /// <typeparam name="TInput">The type of data used as input to the pipeline.</typeparam>
        /// <param name="builder">The builder containing the steps to be executed as part of the pipeline.</param>
        /// <returns>The resulting pipeline.</returns>
        public static InPipeline<TInput> CreateFrom<TInput>(InPipelineBuilder<TInput> builder)
        {
            return new InPipeline<TInput>(builder.Steps);
        }
    }
}
