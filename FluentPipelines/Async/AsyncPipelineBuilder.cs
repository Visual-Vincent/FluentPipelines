using System;
using System.Threading.Tasks;

namespace FluentPipelines.Async
{
    /// <summary>
    /// A builder that builds an asynchronous pipeline with no input nor output data.
    /// </summary>
    public class AsyncPipelineBuilder : IAsyncPipelineBuilder
    {
        /// <summary>
        /// Gets the chain of delegates making up the steps of the pipeline.
        /// </summary>
        protected Func<Task> Chain { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AsyncPipelineBuilder"/> class.
        /// </summary>
        /// <param name="chain">The chain of delegates making up the steps of the pipeline.</param>
        public AsyncPipelineBuilder(Func<Task> chain)
        {
            Chain = chain ?? throw new ArgumentNullException(nameof(chain));
        }

        /// <inheritdoc/>
        public virtual IAsyncPipeline Build()
        {
            return new AsyncPipeline(Chain);
        }
    }
}
