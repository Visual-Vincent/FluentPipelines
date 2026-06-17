using System;
using System.Threading.Tasks;

namespace FluentPipelines.Async
{
    /// <summary>
    /// A builder that builds an asynchronous pipeline with input data and no output data.
    /// </summary>
    /// <typeparam name="TIn">The type of data used as input to the pipeline.</typeparam>
    public class AsyncInPipelineBuilder<TIn> : IAsyncInPipelineBuilder<TIn>
    {
        /// <summary>
        /// Gets the chain of delegates making up the steps of the pipeline.
        /// </summary>
        protected Func<TIn, Task> Chain { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AsyncInPipelineBuilder{TIn}"/> class.
        /// </summary>
        /// <param name="chain">The chain of delegates making up the steps which will be used to construct the pipeline.</param>
        public AsyncInPipelineBuilder(Func<TIn, Task> chain)
        {
            Chain = chain ?? throw new ArgumentNullException(nameof(chain));
        }

        /// <inheritdoc/>
        public virtual IAsyncInPipeline<TIn> Build()
        {
            return new AsyncInPipeline<TIn>(Chain);
        }
    }
}
