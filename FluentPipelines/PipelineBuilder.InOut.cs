using System;

namespace FluentPipelines
{
    /// <summary>
    /// A builder that builds a pipeline with input and output data.
    /// </summary>
    /// <typeparam name="TIn">The type of data used as input to the pipeline.</typeparam>
    /// <typeparam name="TOut">The type of data returned from the pipeline.</typeparam>
    public class PipelineBuilder<TIn, TOut> : IPipelineBuilder<TIn, TOut>
    {
        /// <summary>
        /// Gets the chain of delegates making up the steps of the pipeline.
        /// </summary>
        protected Func<TIn, TOut> Chain { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PipelineBuilder{TIn, TOut}"/> class.
        /// </summary>
        /// <param name="chain">The chain of delegates making up the steps of the pipeline.</param>
        public PipelineBuilder(Func<TIn, TOut> chain)
        {
            Chain = chain ?? throw new ArgumentNullException(nameof(chain));
        }

        /// <inheritdoc/>
        public virtual IPipeline<TIn, TOut> Build()
        {
            return new Pipeline<TIn, TOut>(Chain);
        }

        /// <inheritdoc/>
        public virtual IPipelineBuilder<TIn, TNext> Then<TNext>(Func<TOut, TNext> step)
        {
            if(step is null)
                throw new ArgumentNullException(nameof(step));

            return new PipelineBuilder<TIn, TNext>(input => step(Chain(input)));
        }

        /// <inheritdoc/>
        public virtual IInPipelineBuilder<TIn> Then(Action<TOut> step)
        {
            if(step is null)
                throw new ArgumentNullException(nameof(step));

            return new InPipelineBuilder<TIn>(input => step(Chain(input)));
        }
    }
}
