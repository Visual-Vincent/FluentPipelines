using System;
using System.Threading.Tasks;

namespace FluentPipelines.Async
{
    /// <summary>
    /// A builder that constructs the beginning of asynchronous pipelines with no input data.
    /// </summary>
    public class AsyncPipelineStartBuilder : IAsyncPipelineStartBuilder
    {
        /// <inheritdoc/>
        public virtual IAsyncPipelineBuilder<TNext> Then<TNext>(Func<TNext> step)
        {
            return new AsyncPipelineBuilder<TNext>(() => Task.FromResult(step()));
        }

        /// <inheritdoc/>
        public virtual IAsyncPipelineBuilder<TNext> Then<TNext>(Func<Task<TNext>> step)
        {
            return new AsyncPipelineBuilder<TNext>(step);
        }
    }
}
