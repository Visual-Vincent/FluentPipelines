using System;
using System.Threading.Tasks;

namespace FluentPipelines.Async
{
    /// <summary>
    /// A builder that builds an asynchronous pipeline with input and output data.
    /// </summary>
    /// <typeparam name="TIn">The type of data used as input to the pipeline.</typeparam>
    /// <typeparam name="TOut">The type of data returned from the pipeline.</typeparam>
    public class AsyncPipelineBuilder<TIn, TOut> : IAsyncPipelineBuilder<TIn, TOut>
    {
        /// <summary>
        /// Gets the chain of delegates making up the steps of the pipeline.
        /// </summary>
        protected Func<TIn, Task<TOut>> Chain { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AsyncPipelineBuilder{TIn, TOut}"/> class.
        /// </summary>
        /// <param name="chain">The chain of delegates making up the steps of the pipeline.</param>
        public AsyncPipelineBuilder(Func<TIn, Task<TOut>> chain)
        {
            Chain = chain ?? throw new ArgumentNullException(nameof(chain));
        }

        /// <inheritdoc/>
        public virtual IAsyncPipeline<TIn, TOut> Build()
        {
            return new AsyncPipeline<TIn, TOut>(Chain);
        }

        /// <inheritdoc/>
        public virtual IAsyncPipelineBuilder<TIn, TNext> Then<TNext>(Func<TOut, TNext> step)
        {
            if(step is null)
                throw new ArgumentNullException(nameof(step));

            return new AsyncPipelineBuilder<TIn, TNext>(async (input) => step(await Chain(input)));
        }

        /// <inheritdoc/>
        public virtual IAsyncPipelineBuilder<TIn, TNext> Then<TNext>(Func<TOut, Task<TNext>> step)
        {
            if(step is null)
                throw new ArgumentNullException(nameof(step));

            return new AsyncPipelineBuilder<TIn, TNext>(async (input) => await step(await Chain(input)));
        }

        /// <inheritdoc/>
        public virtual IAsyncInPipelineBuilder<TIn> Then(Action<TOut> step)
        {
            if(step is null)
                throw new ArgumentNullException(nameof(step));

            return new AsyncInPipelineBuilder<TIn>(async (input) => step(await Chain(input)));
        }

        /// <inheritdoc/>
        public virtual IAsyncInPipelineBuilder<TIn> Then(Func<TOut, Task> step)
        {
            if(step is null)
                throw new ArgumentNullException(nameof(step));

            return new AsyncInPipelineBuilder<TIn>(async (input) => await step(await Chain(input)));
        }
    }
}
