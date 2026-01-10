using System;

namespace FluentPipelines
{
    /// <summary>
    /// A generic pipeline step.
    /// </summary>
    /// <typeparam name="TInput">The type of data used as input to the step.</typeparam>
    /// <typeparam name="TOutput">The type of data returned from the step.</typeparam>
    public sealed class PipelineStep<TInput, TOutput> : PipelineStep
    {
        private readonly IPipelineStep<TInput, TOutput> step;

        /// <summary>
        /// Initializes a new instance of the <see cref="PipelineStep{TInput, TOutput}"/> class.
        /// </summary>
        /// <param name="step">The base step to create this generic step from.</param>
        public PipelineStep(IPipelineStep<TInput, TOutput> step)
        {
            this.step = step ?? throw new ArgumentNullException(nameof(step));
        }

        internal override object Run(object input)
        {
            return step.Run((TInput)input);
        }
    }

    /// <summary>
    /// The base class for generic, typeless pipeline steps. Also contains helper methods to create strongly typed generic steps.
    /// </summary>
    public class PipelineStep
    {
        /// <summary>
        /// Creates a <see cref="PipelineStep{TInput, TOutput}"/>.
        /// </summary>
        /// <typeparam name="TInput">The type of data used as input to the step.</typeparam>
        /// <typeparam name="TOutput">The type of data returned from the step.</typeparam>
        /// <param name="step">The base step to create the generic step from.</param>
        /// <returns>A generic pipeline step.</returns>
        public static PipelineStep<TInput, TOutput> Create<TInput, TOutput>(IPipelineStep<TInput, TOutput> step)
        {
            return new PipelineStep<TInput, TOutput>(step);
        }

        internal PipelineStep()
        {
        }

        internal virtual object Run(object input)
        {
            throw new NotImplementedException();
        }
    }
}
