using System;
using System.Threading.Tasks;

namespace FluentPipelines.Async
{
    /// <summary>
    /// An asynchronous pipeline that takes <typeparamref name="TIn"/> as input, and has no output.
    /// </summary>
    /// <typeparam name="TIn">The type of data used as input to the pipeline.</typeparam>
    public class AsyncInPipeline<TIn> : IAsyncInPipeline<TIn>
    {
        /// <summary>
        /// Gets the chain of delegates making up the steps of the pipeline.
        /// </summary>
        protected Func<TIn, Task> Chain { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AsyncInPipeline{TIn}"/> class.
        /// </summary>
        /// <param name="chain">The chain of delegates making up the steps of the pipeline.</param>
        public AsyncInPipeline(Func<TIn, Task> chain)
        {
            Chain = chain ?? throw new ArgumentNullException(nameof(chain));
        }

        /// <inheritdoc/>
        public virtual Task RunAsync(TIn input)
        {
            return Chain(input);
        }
    }
}
