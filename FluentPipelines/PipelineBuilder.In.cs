using System;

namespace FluentPipelines
{
    /// <summary>
    /// A builder that builds a pipeline with input data and no output data.
    /// </summary>
    /// <typeparam name="TIn">The type of data used as input to the pipeline.</typeparam>
    public class InPipelineBuilder<TIn> : IInPipelineBuilder<TIn>
    {
        /// <summary>
        /// Gets the chain of delegates making up the steps of the pipeline.
        /// </summary>
        protected Action<TIn> Chain { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="InPipelineBuilder{TIn}"/> class.
        /// </summary>
        /// <param name="chain">The chain of delegates making up the steps which will be used to construct the pipeline.</param>
        public InPipelineBuilder(Action<TIn> chain)
        {
            Chain = chain ?? throw new ArgumentNullException(nameof(chain));
        }

        /// <inheritdoc/>
        public virtual IInPipeline<TIn> Build()
        {
            return new InPipeline<TIn>(Chain);
        }
    }
}
