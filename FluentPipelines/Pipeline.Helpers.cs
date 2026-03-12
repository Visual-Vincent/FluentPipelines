using System;

namespace FluentPipelines
{
    public partial class Pipeline
    {
        /// <summary>
        /// Creates a new pipeline with no input.
        /// </summary>
        /// <returns>A builder used to construct the pipeline.</returns>
        public static IPipelineStartBuilder Create()
        {
            return new PipelineStartBuilder();
        }

        /// <summary>
        /// Creates a new pipeline.
        /// </summary>
        /// <typeparam name="T">The type of data used as input to the pipeline.</typeparam>
        /// <returns>A builder used to construct the pipeline.</returns>
        public static IPipelineBuilder<T, T> Create<T>()
        {
            return new PipelineBuilder<T, T>(input => input);
        }
    }
}
