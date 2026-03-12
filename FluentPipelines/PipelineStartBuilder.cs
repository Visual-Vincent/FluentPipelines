using System;

namespace FluentPipelines
{
    /// <summary>
    /// A builder that constructs the beginning of pipelines with no input data.
    /// </summary>
    public class PipelineStartBuilder : IPipelineStartBuilder
    {
        /// <inheritdoc/>
        public virtual IPipelineBuilder<TNext> Then<TNext>(Func<TNext> step)
        {
            return new PipelineBuilder<TNext>(step);
        }
    }
}
