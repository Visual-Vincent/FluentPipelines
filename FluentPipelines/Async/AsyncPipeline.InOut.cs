using System;
using System.Threading.Tasks;

namespace FluentPipelines.Async
{
    /// <summary>
    /// An asynchronous pipeline that takes <typeparamref name="TIn"/> as input, and returns <typeparamref name="TOut"/>.
    /// </summary>
    /// <typeparam name="TIn">The type of data used as input to the pipeline.</typeparam>
    /// <typeparam name="TOut">The type of data returned from the pipeline.</typeparam>
    public class AsyncPipeline<TIn, TOut> : IAsyncPipeline<TIn, TOut>
    {
        /// <summary>
        /// Gets the chain of delegates making up the steps of the pipeline.
        /// </summary>
        protected Func<TIn, Task<TOut>> Chain { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AsyncPipeline{TIn, TOut}"/> class.
        /// </summary>
        /// <param name="chain">The chain of delegates making up the steps of the pipeline.</param>
        public AsyncPipeline(Func<TIn, Task<TOut>> chain)
        {
            Chain = chain ?? throw new ArgumentNullException(nameof(chain));
        }

        /// <inheritdoc/>
        public virtual Task<TOut> RunAsync(TIn input)
        {
            return Chain(input);
        }
    }
}
