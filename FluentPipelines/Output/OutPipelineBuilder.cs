using System;
using System.Collections.Generic;

namespace FluentPipelines
{
    /// <summary>
    /// A builder that builds a pipeline with output data and no input data.
    /// </summary>
    /// <typeparam name="TOutput">The type of data returned from the pipeline.</typeparam>
    public class OutPipelineBuilder<TOutput> : IOutPipelineBuilder<TOutput>
    {
        /// <summary>
        /// Gets the first step of the pipeline.
        /// </summary>
        protected internal OutPipelineStep FirstStep { get; }

        /// <summary>
        /// Gets the collection of steps added to the builder, which will be used to construct the pipeline.
        /// </summary>
        protected internal List<PipelineStep> Steps { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="OutPipelineBuilder{TOutput}"/> class.
        /// </summary>
        /// <param name="firstStep">
        /// The first step of the pipeline.
        /// <para><b>IMPORTANT:</b> If this is the only step, it must return <typeparamref name="TOutput"/>, otherwise the built-in pipeline types will not work.</para>
        /// </param>
        /// <param name="steps">
        /// The collection of steps to add to the builder, which will be used to construct the pipeline.
        /// <para><b>IMPORTANT:</b> The the last step must return <typeparamref name="TOutput"/>, otherwise the built-in pipeline types will not work.</para>
        /// <para><b>IMPORTANT:</b> <paramref name="steps"/> is taken by reference! The list is NOT copied!</para>
        /// </param>
        protected OutPipelineBuilder(OutPipelineStep firstStep, List<PipelineStep> steps)
        {
            FirstStep = firstStep ?? throw new ArgumentNullException(nameof(firstStep));
            Steps = steps ?? throw new ArgumentNullException(nameof(steps));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OutPipelineBuilder{TOutput}"/> class.
        /// </summary>
        /// <param name="firstStep">The first step of the pipeline, processing the input data.</param>
        public OutPipelineBuilder(IOutPipelineStep<TOutput> firstStep)
        {
            if(firstStep is null)
                throw new ArgumentNullException(nameof(firstStep));

            FirstStep = new OutPipelineStep<TOutput>(firstStep);
            Steps = new List<PipelineStep>();
        }

        /// <inheritdoc/>
        public virtual IOutPipeline<TOutput> Build()
        {
            return new OutPipeline<TOutput>(FirstStep, Steps);
        }

        /// <inheritdoc/>
        public virtual IOutPipelineBuilder<TNext> Then<TNext>(PipelineStepDelegate<TOutput, TNext> action)
        {
            if(action is null)
                throw new ArgumentNullException(nameof(action));

            return Then(new FunctionStep<TOutput, TNext>(action));
        }

        /// <inheritdoc/>
        public virtual IOutPipelineBuilder<TNext> Then<TNext>(IPipelineStep<TOutput, TNext> step)
        {
            if(step is null)
                throw new ArgumentNullException(nameof(step));

            Steps.Add(new PipelineStep<TOutput, TNext>(step));

            return new OutPipelineBuilder<TNext>(FirstStep, Steps);
        }
    }
}
