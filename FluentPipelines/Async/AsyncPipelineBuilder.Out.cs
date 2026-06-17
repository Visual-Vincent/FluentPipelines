using System;
using System.Threading.Tasks;

namespace FluentPipelines.Async
{
    /// <summary>
    /// A builder that builds an asynchronous pipeline with output data and no input data.
    /// </summary>
    /// <typeparam name="TOut">The type of data returned from the pipeline.</typeparam>
    public class AsyncPipelineBuilder<TOut> : IAsyncPipelineBuilder<TOut>
    {
        /// <summary>
        /// Gets the chain of delegates making up the steps of the pipeline.
        /// </summary>
        protected Func<Task<TOut>> Chain { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AsyncPipelineBuilder{TOut}"/> class.
        /// </summary>
        /// <param name="chain">The chain of delegates making up the steps of the pipeline.</param>
        public AsyncPipelineBuilder(Func<Task<TOut>> chain)
        {
            Chain = chain ?? throw new ArgumentNullException(nameof(chain));
        }

        /// <inheritdoc/>
        public virtual IAsyncPipeline<TOut> Build()
        {
            return new AsyncPipeline<TOut>(Chain);
        }

        /// <inheritdoc/>
        public virtual IAsyncPipelineBuilder<TNext> Then<TNext>(Func<TOut, TNext> step)
        {
            if(step is null)
                throw new ArgumentNullException(nameof(step));

            return new AsyncPipelineBuilder<TNext>(async () => step(await Chain()));
        }

        /// <inheritdoc/>
        public virtual IAsyncPipelineBuilder<TNext> Then<TNext>(Func<TOut, Task<TNext>> step)
        {
            if(step is null)
                throw new ArgumentNullException(nameof(step));

            return new AsyncPipelineBuilder<TNext>(async () => await step(await Chain()));
        }

        /// <inheritdoc/>
        public virtual IAsyncPipelineBuilder Then(Action<TOut> step)
        {
            if(step is null)
                throw new ArgumentNullException(nameof(step));

            return new AsyncPipelineBuilder(async () => step(await Chain()));
        }

        /// <inheritdoc/>
        public virtual IAsyncPipelineBuilder Then(Func<TOut, Task> step)
        {
            if(step is null)
                throw new ArgumentNullException(nameof(step));

            return new AsyncPipelineBuilder(async () => await step(await Chain()));
        }
    }
}
