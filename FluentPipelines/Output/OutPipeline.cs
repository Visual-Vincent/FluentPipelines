using System;
using System.Collections.Generic;
using System.Linq;

namespace FluentPipelines
{
    /// <summary>
    /// A pipeline that takes no input, and returns <typeparamref name="TOutput"/>.
    /// </summary>
    /// <typeparam name="TOutput">The type of data returned from the pipeline.</typeparam>
    public sealed class OutPipeline<TOutput> : IOutPipeline<TOutput>
    {
        private readonly OutPipelineStep firstStep;
        private readonly PipelineStep[] steps;

        /// <summary>
        /// Initializes a new instance of the <see cref="OutPipeline{TOutput}"/> class.
        /// </summary>
        /// <param name="firstStep">
        /// The first step to execute.
        /// <para><b>IMPORTANT:</b> If this is the only step in the pipeline, it must return <typeparamref name="TOutput"/>.</para>
        /// </param>
        /// <param name="steps">
        /// The rest of the steps to be executed as part of the pipeline.
        /// It is important that the final step returns <typeparamref name="TOutput"/>.
        /// </param>
        public OutPipeline(OutPipelineStep firstStep, IEnumerable<PipelineStep> steps)
        {
            this.firstStep = firstStep ?? throw new ArgumentNullException(nameof(firstStep));
            this.steps = steps?.ToArray() ?? Array.Empty<PipelineStep>();
        }

        /// <inheritdoc/>
        public TOutput Run()
        {
            var output = firstStep.Run();

            if(steps.Length == 0)
                return (TOutput)output;

            return (TOutput)steps.Execute(output);
        }
    }

    /// <summary>
    /// A static class containing helper methods for <see cref="OutPipeline{TOutput}"/>.
    /// </summary>
    public static class OutputPipeline
    {
        /// <summary>
        /// Creates an <see cref="OutPipeline{TOutput}"/> from a <see cref="OutPipelineBuilder{TOutput}"/>.
        /// </summary>
        /// <typeparam name="TOutput">The type of data returned from the pipeline.</typeparam>
        /// <param name="builder">The builder containing the steps to be executed as part of the pipeline.</param>
        /// <returns>The resulting pipeline.</returns>
        public static OutPipeline<TOutput> CreateFrom<TOutput>(OutPipelineBuilder<TOutput> builder)
        {
            return new OutPipeline<TOutput>(builder.FirstStep, builder.Steps);
        }
    }
}
