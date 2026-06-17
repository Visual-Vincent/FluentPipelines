using System;
using System.Threading.Tasks;

namespace FluentPipelines.Async
{
    /// <summary>
    /// An asynchronous pipeline that takes no input, and returns <typeparamref name="TOut"/>.
    /// </summary>
    /// <typeparam name="TOut">The type of data returned from the pipeline.</typeparam>
    public class AsyncPipeline<TOut> : IAsyncPipeline<TOut>
    {
        /// <summary>
        /// Gets the chain of delegates making up the steps of the pipeline.
        /// </summary>
        protected Func<Task<TOut>> Chain { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AsyncPipeline{TOut}"/> class.
        /// </summary>
        /// <param name="chain">The chain of delegates making up the steps of the pipeline.</param>
        public AsyncPipeline(Func<Task<TOut>> chain)
        {
            Chain = chain ?? throw new ArgumentNullException(nameof(chain));
        }

        /// <inheritdoc/>
        public virtual Task<TOut> RunAsync()
        {
            return Chain();
        }
    }
}
