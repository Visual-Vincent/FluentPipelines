using System;

namespace FluentPipelines
{
    /// <summary>
    /// A pipeline that takes <typeparamref name="TIn"/> as input, and returns <typeparamref name="TOut"/>.
    /// </summary>
    /// <typeparam name="TIn">The type of data used as input to the pipeline.</typeparam>
    /// <typeparam name="TOut">The type of data returned from the pipeline.</typeparam>
    public class Pipeline<TIn, TOut> : IPipeline<TIn, TOut>
    {
        /// <summary>
        /// Gets the chain of delegates making up the steps of the pipeline.
        /// </summary>
        protected Func<TIn, TOut> Chain { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Pipeline{TIn, TOut}"/> class.
        /// </summary>
        /// <param name="chain">The chain of delegates making up the steps of the pipeline.</param>
        public Pipeline(Func<TIn, TOut> chain)
        {
            Chain = chain ?? throw new ArgumentNullException(nameof(chain));
        }

        /// <inheritdoc/>
        public virtual TOut Run(TIn input)
        {
            return Chain(input);
        }
    }
}
