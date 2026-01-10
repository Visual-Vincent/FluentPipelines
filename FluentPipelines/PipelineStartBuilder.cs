using System;

namespace FluentPipelines
{
    /// <summary>
    /// A builder that constructs the beginning of pipelines taking input data.
    /// </summary>
    /// <typeparam name="TInput">The type of data used as input to the pipeline.</typeparam>
    public class PipelineStartBuilder<TInput> : IPipelineStartBuilder<TInput>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PipelineStartBuilder{TInput}"/> class.
        /// </summary>
        public PipelineStartBuilder()
        {
        }

        /// <inheritdoc/>
        public virtual IPipelineBuilder<TInput, TNext> Start<TNext>(PipelineStepDelegate<TInput, TNext> action)
        {
            if(action is null)
                throw new ArgumentNullException(nameof(action));

            return Start(new FunctionStep<TInput, TNext>(action));
        }

        /// <inheritdoc/>
        public virtual IPipelineBuilder<TInput, TNext> Start<TNext>(IPipelineStep<TInput, TNext> step)
        {
            if(step is null)
                throw new ArgumentNullException(nameof(step));

            return new PipelineBuilder<TInput, TNext>(step);
        }
    }
}
