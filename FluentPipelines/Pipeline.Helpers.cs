using System;
using System.Threading.Tasks;
using FluentPipelines.Async;

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

        /// <summary>
        /// Creates a new asynchronous pipeline with no input.
        /// </summary>
        /// <returns>A builder used to construct the pipeline.</returns>
        public static IAsyncPipelineStartBuilder CreateAsynchronous()
        {
            return new AsyncPipelineStartBuilder();
        }

        /// <summary>
        /// Creates a new asynchronous pipeline.
        /// </summary>
        /// <typeparam name="T">The type of data used as input to the pipeline.</typeparam>
        /// <returns>A builder used to construct the pipeline.</returns>
        public static IAsyncPipelineBuilder<T, T> CreateAsynchronous<T>()
        {
            return new AsyncPipelineBuilder<T, T>(input => Task.FromResult(input));
        }
    }
}
