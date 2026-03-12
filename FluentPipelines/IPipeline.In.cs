using System;

namespace FluentPipelines
{
    /// <summary>
    /// Defines methods for a pipeline that takes <typeparamref name="TIn"/> as input, and has no output.
    /// </summary>
    /// <typeparam name="TIn">The type of data used as input to the pipeline.</typeparam>
    public interface IInPipeline<TIn>
    {
        /// <summary>
        /// Runs the pipeline.
        /// </summary>
        /// <param name="input">The input data.</param>
        void Run(TIn input);
    }
}
