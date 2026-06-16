using System;

namespace FluentPipelines
{
    /// <summary>
    /// Defines methods for a pipeline with no input nor output.
    /// </summary>
    public interface IPipeline
    {
        /// <summary>
        /// Runs the pipeline.
        /// </summary>
        void Run();
    }
}
