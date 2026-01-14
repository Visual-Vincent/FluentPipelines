using System;

namespace FluentPipelines
{
    /// <summary>
    /// A pipeline step that executes a delegate method.
    /// </summary>
    /// <typeparam name="TInput">The type of data used as input to the step.</typeparam>
    public class InFunctionStep<TInput> : IInPipelineStep<TInput>
    {
        private readonly InPipelineStepDelegate<TInput> function;

        /// <summary>
        /// Initializes a new instance of the <see cref="InFunctionStep{TInput}"/> class.
        /// </summary>
        /// <param name="function">The delegate method to execute.</param>
        public InFunctionStep(InPipelineStepDelegate<TInput> function)
        {
            this.function = function ?? throw new ArgumentNullException(nameof(function));
        }

        /// <inheritdoc/>
        public void Run(TInput input)
        {
            function(input);
        }
    }
}
