using System;

namespace FluentPipelines
{
    /// <summary>
    /// A pipeline step that executes a delegate method.
    /// </summary>
    /// <typeparam name="TOutput">The type of data returned from the step.</typeparam>
    public class OutFunctionStep<TOutput> : IOutPipelineStep<TOutput>
    {
        private readonly OutPipelineStepDelegate<TOutput> function;

        /// <summary>
        /// Initializes a new instance of the <see cref="OutFunctionStep{TOutput}"/> class.
        /// </summary>
        /// <param name="function">The delegate method to execute.</param>
        public OutFunctionStep(OutPipelineStepDelegate<TOutput> function)
        {
            this.function = function ?? throw new ArgumentNullException(nameof(function));
        }

        /// <inheritdoc/>
        public TOutput Run()
        {
            return function();
        }
    }
}
