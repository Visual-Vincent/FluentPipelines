using System;

namespace FluentPipelines
{
    /// <summary>
    /// A pipeline step that executes a delegate method.
    /// </summary>
    /// <typeparam name="TInput">The type of data used as input to the step.</typeparam>
    /// <typeparam name="TOutput">The type of data returned from the step.</typeparam>
    public class FunctionStep<TInput, TOutput> : IPipelineStep<TInput, TOutput>
    {
        private readonly PipelineStepDelegate<TInput, TOutput> function;

        /// <summary>
        /// Initializes a new instance of the <see cref="FunctionStep{TInput, TOutput}"/> class.
        /// </summary>
        /// <param name="function">The delegate method to execute.</param>
        public FunctionStep(PipelineStepDelegate<TInput, TOutput> function)
        {
            this.function = function ?? throw new ArgumentNullException(nameof(function));
        }

        /// <inheritdoc/>
        public TOutput Run(TInput input)
        {
            return function(input);
        }
    }
}
