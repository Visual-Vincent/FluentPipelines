using System;

namespace FluentPipelines
{
    /// <summary>
    /// A static class containing helper methods for building pipelines.
    /// </summary>
    public static class Pipeline
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
        /// <typeparam name="TInput">The type of data used as input to the pipeline.</typeparam>
        /// <returns>A builder used to construct the pipeline.</returns>
        public static IPipelineStartBuilder<TInput> Create<TInput>()
        {
            return new PipelineStartBuilder<TInput>();
        }
    }
}
