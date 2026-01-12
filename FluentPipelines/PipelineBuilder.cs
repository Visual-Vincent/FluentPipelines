using System;
using System.Collections.Generic;

namespace FluentPipelines
{
    /// <summary>
    /// A builder that builds a pipeline with input and output data.
    /// </summary>
    /// <typeparam name="TInput">The type of data used as input to the pipeline.</typeparam>
    /// <typeparam name="TOutput">The type of data returned from the pipeline.</typeparam>
    public class PipelineBuilder<TInput, TOutput> : IPipelineBuilder<TInput, TOutput>
    {
        /// <summary>
        /// Gets the collection of steps added to the builder, which will be used to construct the pipeline.
        /// <para><b>IMPORTANT:</b> The first step must take <typeparamref name="TInput"/> as input, otherwise the built-in pipeline types will not work.</para>
        /// </summary>
        protected internal List<PipelineStep> Steps { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PipelineBuilder{TInput, TOutput}"/> class.
        /// </summary>
        /// <param name="steps">
        /// The collection of steps to add to the builder, which will be used to construct the pipeline.
        /// <para><b>IMPORTANT:</b> The first step must take <typeparamref name="TInput"/> as input, and the last must return <typeparamref name="TOutput"/>, otherwise the built-in pipeline types will not work.</para>
        /// <para><b>IMPORTANT:</b> <paramref name="steps"/> is taken by reference! The list is NOT copied!</para>
        /// </param>
        protected PipelineBuilder(List<PipelineStep> steps)
        {
            Steps = steps ?? throw new ArgumentNullException(nameof(steps));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PipelineBuilder{TInput, TOutput}"/> class.
        /// </summary>
        /// <param name="firstStep">The first step of the pipeline, processing the input data.</param>
        public PipelineBuilder(IPipelineStep<TInput, TOutput> firstStep)
        {
            if(firstStep is null)
                throw new ArgumentNullException(nameof(firstStep));

            Steps = new List<PipelineStep>() {
                new PipelineStep<TInput, TOutput>(firstStep)
            };
        }

        /// <inheritdoc/>
        public virtual IPipeline<TInput, TOutput> Build()
        {
            return new InOutPipeline<TInput, TOutput>(Steps);
        }

        /// <inheritdoc/>
        public virtual IPipelineBuilder<TInput, TNext> Then<TNext>(PipelineStepDelegate<TOutput, TNext> action)
        {
            if(action is null)
                throw new ArgumentNullException(nameof(action));

            return Then(new FunctionStep<TOutput, TNext>(action));
        }

        /// <inheritdoc/>
        public virtual IPipelineBuilder<TInput, TNext> Then<TNext>(IPipelineStep<TOutput, TNext> step)
        {
            if(step is null)
                throw new ArgumentNullException(nameof(step));

            Steps.Add(new PipelineStep<TOutput, TNext>(step));

            return new PipelineBuilder<TInput, TNext>(Steps);
        }
    }
}
