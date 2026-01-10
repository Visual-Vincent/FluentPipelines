using System;

namespace FluentPipelines
{
    /// <summary>
    /// Defines methods for a pipeline that takes <typeparamref name="TInput"/> as input, and returns <typeparamref name="TOutput"/>.
    /// </summary>
    /// <typeparam name="TInput">The type of data used as input to the pipeline.</typeparam>
    /// <typeparam name="TOutput">The type of data returned from the pipeline.</typeparam>
    public interface IPipeline<TInput, TOutput>
    {
        /// <summary>
        /// Runs the pipeline.
        /// </summary>
        /// <param name="input">The input data.</param>
        /// <returns>The result of the pipeline.</returns>
        TOutput Run(TInput input);
    }
}
