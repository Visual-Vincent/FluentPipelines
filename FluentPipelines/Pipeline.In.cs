using System;

namespace FluentPipelines
{
    /// <summary>
    /// A pipeline that takes <typeparamref name="TIn"/> as input, and has no output.
    /// </summary>
    /// <typeparam name="TIn">The type of data used as input to the pipeline.</typeparam>
    public class InPipeline<TIn> : IInPipeline<TIn>
    {
        /// <summary>
        /// Gets the chain of delegates making up the steps of the pipeline.
        /// </summary>
        protected Action<TIn> Chain { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="InPipeline{TIn}"/> class.
        /// </summary>
        /// <param name="chain">The chain of delegates making up the steps of the pipeline.</param>
        public InPipeline(Action<TIn> chain)
        {
            Chain = chain ?? throw new ArgumentNullException(nameof(chain));
        }

        /// <inheritdoc/>
        public virtual void Run(TIn input)
        {
            Chain(input);
        }
    }
}
