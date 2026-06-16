using System;

namespace FluentPipelines
{
    /// <summary>
    /// Defines methods for a pipeline that takes no input, and returns <typeparamref name="TOut"/>.
    /// </summary>
    /// <typeparam name="TOut">The type of data returned from the pipeline.</typeparam>
    public interface IPipeline<TOut>
    {
        /// <summary>
        /// Runs the pipeline.
        /// </summary>
        /// <returns>The result of the pipeline.</returns>
        TOut Run();
    }
}
