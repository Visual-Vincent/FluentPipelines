using System;
using System.Threading.Tasks;

namespace FluentPipelines.Async
{
    /// <summary>
    /// An asynchronous pipeline with no input nor no output.
    /// </summary>
    public partial class AsyncPipeline : IAsyncPipeline
    {
        /// <summary>
        /// Gets the chain of delegates making up the steps of the pipeline.
        /// </summary>
        protected Func<Task> Chain { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AsyncPipeline"/> class.
        /// </summary>
        /// <param name="chain">The chain of delegates making up the steps of the pipeline.</param>
        public AsyncPipeline(Func<Task> chain)
        {
            Chain = chain ?? throw new ArgumentNullException(nameof(chain));
        }

        /// <inheritdoc/>
        public virtual Task RunAsync()
        {
            return Chain();
        }
    }
}
