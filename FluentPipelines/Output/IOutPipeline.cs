using System;

namespace FluentPipelines
{
    /// <summary>
    /// Defines methods for a pipeline that takes no input, and returns <typeparamref name="TOutput"/>.
    /// </summary>
    /// <typeparam name="TOutput">The type of data returned from the pipeline.</typeparam>
    public interface IOutPipeline<TOutput>
    {
        /// <summary>
        /// Runs the pipeline.
        /// </summary>
        /// <returns>The result of the pipeline.</returns>
        TOutput Run();
    }
}
