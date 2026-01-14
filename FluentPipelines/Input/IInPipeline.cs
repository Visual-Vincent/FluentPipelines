using System;

namespace FluentPipelines
{
    /// <summary>
    /// Defines methods for a pipeline that takes <typeparamref name="TInput"/> as input, and has no output.
    /// </summary>
    /// <typeparam name="TInput">The type of data used as input to the pipeline.</typeparam>
    public interface IInPipeline<TInput>
    {
        /// <summary>
        /// Runs the pipeline.
        /// </summary>
        /// <param name="input">The input data.</param>
        void Run(TInput input);
    }
}
