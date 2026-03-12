using System;

namespace FluentPipelines
{
    /// <summary>
    /// A builder that builds a pipeline with output data and no input data.
    /// </summary>
    /// <typeparam name="TOut">The type of data returned from the pipeline.</typeparam>
    public class PipelineBuilder<TOut> : IPipelineBuilder<TOut>
    {
        /// <summary>
        /// Gets the chain of delegates making up the steps of the pipeline.
        /// </summary>
        protected Func<TOut> Chain { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PipelineBuilder{TOut}"/> class.
        /// </summary>
        /// <param name="chain">The chain of delegates making up the steps of the pipeline.</param>
        public PipelineBuilder(Func<TOut> chain)
        {
            Chain = chain ?? throw new ArgumentNullException(nameof(chain));
        }

        /// <inheritdoc/>
        public virtual IPipeline<TOut> Build()
        {
            return new Pipeline<TOut>(() => Chain());
        }

        /// <inheritdoc/>
        public virtual IPipelineBuilder<TNext> Then<TNext>(Func<TOut, TNext> step)
        {
            if(step is null)
                throw new ArgumentNullException(nameof(step));

            return new PipelineBuilder<TNext>(() => step(Chain()));
        }

        /// <inheritdoc/>
        public virtual IPipelineBuilder Then(Action<TOut> step)
        {
            if(step is null)
                throw new ArgumentNullException(nameof(step));

            return new PipelineBuilder(() => step(Chain()));
        }
    }
}
