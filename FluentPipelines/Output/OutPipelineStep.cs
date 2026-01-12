using System;

namespace FluentPipelines
{
    /// <summary>
    /// A pipeline step with an output and no input.
    /// </summary>
    /// <typeparam name="TOutput">The type of data returned from the step.</typeparam>
    public sealed class OutPipelineStep<TOutput> : OutPipelineStep
    {
        private readonly IOutPipelineStep<TOutput> step;

        /// <summary>
        /// Initializes a new instance of the <see cref="OutPipelineStep{TOutput}"/> class.
        /// </summary>
        /// <param name="step">The base step to create this generic step from.</param>
        public OutPipelineStep(IOutPipelineStep<TOutput> step)
        {
            this.step = step ?? throw new ArgumentNullException(nameof(step));
        }

        internal override object Run()
        {
            return step.Run();
        }
    }

    /// <summary>
    /// The base class for generic, typeless pipeline steps. Also contains helper methods to create strongly typed generic steps.
    /// </summary>
    public class OutPipelineStep
    {
        /// <summary>
        /// Creates a <see cref="OutPipelineStep{TOutput}"/>.
        /// </summary>
        /// <typeparam name="TOutput">The type of data returned from the step.</typeparam>
        /// <param name="step">The base step to create the generic step from.</param>
        /// <returns>A generic pipeline step.</returns>
        public static OutPipelineStep<TOutput> Create<TOutput>(IOutPipelineStep<TOutput> step)
        {
            return new OutPipelineStep<TOutput>(step);
        }

        internal OutPipelineStep()
        {
        }

        internal virtual object Run()
        {
            throw new NotImplementedException();
        }
    }
}
