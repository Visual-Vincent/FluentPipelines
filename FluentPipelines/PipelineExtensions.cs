using System;
using System.Collections.Generic;
using System.Linq;

namespace FluentPipelines
{
    /// <summary>
    /// A static class containing extension methods for pipelines.
    /// </summary>
    public static class PipelineExtensions
    {
        /// <summary>
        /// Executes the collection of steps in sequential order.
        /// </summary>
        /// <param name="steps">The collection of steps to execute.</param>
        /// <param name="input">The input data to the first step.</param>
        /// <returns>The output data returned from the final step.</returns>
        public static object Execute(this IEnumerable<PipelineStep> steps, object input)
        {
            if(steps is null)
                throw new ArgumentNullException(nameof(steps));

            if(!steps.Any())
                throw new ArgumentException("No steps specified", nameof(steps));

            object output = input;

            foreach(var step in steps)
            {
                output = step.Run(output);
            }

            return output;
        }
    }
}
