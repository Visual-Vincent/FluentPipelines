using System;

namespace FluentPipelines
{
    /// <summary>
    /// A pipeline with no input nor no output. Also contains static helper methods for creating pipelines.
    /// </summary>
    public partial class Pipeline : IPipeline
    {
        /// <summary>
        /// Gets the chain of delegates making up the steps of the pipeline.
        /// </summary>
        protected Action Chain { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Pipeline"/> class.
        /// </summary>
        /// <param name="chain">The chain of delegates making up the steps of the pipeline.</param>
        public Pipeline(Action chain)
        {
            Chain = chain ?? throw new ArgumentNullException(nameof(chain));
        }

        /// <inheritdoc/>
        public virtual void Run()
        {
            Chain();
        }
    }
}
