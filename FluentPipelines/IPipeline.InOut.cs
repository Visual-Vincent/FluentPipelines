using System;

namespace FluentPipelines
{
    /// <summary>
    /// Defines methods for a pipeline that takes <typeparamref name="TIn"/> as input, and returns <typeparamref name="TOut"/>.
    /// </summary>
    /// <typeparam name="TIn">The type of data used as input to the pipeline.</typeparam>
    /// <typeparam name="TOut">The type of data returned from the pipeline.</typeparam>
    public interface IPipeline<TIn, TOut>
    {
        /// <summary>
        /// Runs the pipeline.
        /// </summary>
        /// <param name="input">The input data.</param>
        /// <returns>The result of the pipeline.</returns>
        TOut Run(TIn input);
    }
}
