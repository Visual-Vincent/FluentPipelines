using System;

namespace FluentPipelines
{
    /// <summary>
    /// A pipeline step with input data and no output data.
    /// </summary>
    /// <typeparam name="TInput">The type of data used as input to the step.</typeparam>
    public sealed class InPipelineStep<TInput> : InPipelineStep
    {
        private readonly IInPipelineStep<TInput> step;

        /// <summary>
        /// Initializes a new instance of the <see cref="InPipelineStep{TInput}"/> class.
        /// </summary>
        /// <param name="step">The base step to create this generic step from.</param>
        public InPipelineStep(IInPipelineStep<TInput> step)
        {
            this.step = step ?? throw new ArgumentNullException(nameof(step));
        }

        internal override void Run(object input)
        {
            step.Run((TInput)input);
        }
    }

    /// <summary>
    /// The base class for generic, typeless pipeline steps. Also contains helper methods to create strongly typed generic steps.
    /// </summary>
    public class InPipelineStep
    {
        /// <summary>
        /// Creates a <see cref="InPipelineStep{TInput}"/>.
        /// </summary>
        /// <typeparam name="TInput">The type of data used as input to the step.</typeparam>
        /// <param name="step">The base step to create the generic step from.</param>
        /// <returns>A generic pipeline step.</returns>
        public static InPipelineStep<TInput> Create<TInput>(IInPipelineStep<TInput> step)
        {
            return new InPipelineStep<TInput>(step);
        }

        internal InPipelineStep()
        {
        }

        internal virtual void Run(object input)
        {
            throw new NotImplementedException();
        }
    }
}
