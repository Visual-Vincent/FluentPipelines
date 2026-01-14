using System;
using System.Collections.Generic;

namespace FluentPipelines
{
    /// <summary>
    /// A builder that builds a pipeline with input data and no output data.
    /// </summary>
    /// <typeparam name="TInput">The type of data used as input to the pipeline.</typeparam>
    public class InPipelineBuilder<TInput> : IInPipelineBuilder<TInput>
    {
        /// <summary>
        /// Gets the collection of steps added to the builder, which will be used to construct the pipeline.
        /// <para><b>IMPORTANT:</b> The first step must take <typeparamref name="TInput"/> as input, otherwise the built-in pipeline types will not work.</para>
        /// </summary>
        protected internal List<PipelineStep> Steps { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="InPipelineBuilder{TInput}"/> class.
        /// </summary>
        /// <param name="steps">
        /// The collection of steps to add to the builder, which will be used to construct the pipeline.
        /// <para><b>IMPORTANT:</b> The first step must take <typeparamref name="TInput"/> as input, otherwise the built-in pipeline types will not work.</para>
        /// <para><b>IMPORTANT:</b> <paramref name="steps"/> is taken by reference! The list is NOT copied!</para>
        /// </param>
        protected internal InPipelineBuilder(List<PipelineStep> steps)
        {
            Steps = steps ?? throw new ArgumentNullException(nameof(steps));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InPipelineBuilder{TInput}"/> class.
        /// </summary>
        /// <param name="firstStep">
        /// The first step of the pipeline, processing the input data.
        /// <para><b>IMPORTANT:</b> This must take <typeparamref name="TInput"/> as input, otherwise the built-in pipeline types will not work.</para>
        /// </param>
        public InPipelineBuilder(PipelineStep firstStep)
        {
            if(firstStep is null)
                throw new ArgumentNullException(nameof(firstStep));

            Steps = new List<PipelineStep>() { firstStep };
        }

        /// <inheritdoc/>
        public virtual IInPipeline<TInput> Build()
        {
            return new InPipeline<TInput>(Steps);
        }
    }
}
