using System;

namespace FluentPipelines
{
    /// <summary>
    /// A pipeline that takes no input, and returns <typeparamref name="TOut"/>.
    /// </summary>
    /// <typeparam name="TOut">The type of data returned from the pipeline.</typeparam>
    public class Pipeline<TOut> : IPipeline<TOut>
    {
        /// <summary>
        /// Gets the chain of delegates making up the steps of the pipeline.
        /// </summary>
        protected Func<TOut> Chain { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Pipeline{TOut}"/> class.
        /// </summary>
        /// <param name="chain">The chain of delegates making up the steps of the pipeline.</param>
        public Pipeline(Func<TOut> chain)
        {
            Chain = chain ?? throw new ArgumentNullException(nameof(chain));
        }

        /// <inheritdoc/>
        public virtual TOut Run()
        {
            return Chain();
        }
    }
}
