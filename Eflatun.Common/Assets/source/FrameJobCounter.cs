using UnityEngine;

namespace Eflatun.Common
{
    /// <summary>
    /// A job counter for jobs that has limits per frame.
    /// </summary>
    public class FrameJobCounter
    {
        /// <summary>
        /// The last frame <see cref="JobCountThisFrame"/> was called.
        /// </summary>
        private int _lastFrame;

        /// <summary>
        /// Frame agnostic current job count. <para/>
        /// If you want to know job count for *this* frame, use <see cref="JobCountThisFrame"/> instead.
        /// </summary>
        private int _jobCounter;

        /// <summary>
        /// Maximum job count which can be done in a single frame.
        /// </summary>
        public int JobLimitPerFrame { get; private set; }

        /// <summary>
        /// Count of jobs done this frame.
        /// </summary>
        public int JobCountThisFrame
        {
            get
            {
                // Get the current frame number.
                int currentFrame = Time.frameCount;

                // If the last frame number and current frame number are different (which means at least one frame has been passed)...
                if (_lastFrame != currentFrame)
                {
                    // Reset the job counter.
                    _jobCounter = 0;

                    // Save the frame number.
                    _lastFrame = currentFrame;
                }

                return _jobCounter;
            }

            set { _jobCounter = value; }
        }

        /// <summary>
        /// <c>true</c> if job limit is 'not' reached for this frame; <c>false</c> otherwise.
        /// </summary>
        public bool CanWork
        {
            get
            {
                // Return whether the job limit is *not* reached.
                return JobCountThisFrame < JobLimitPerFrame;
            }
        }

        public FrameJobCounter(int jobLimitPerFrame)
        {
            JobLimitPerFrame = jobLimitPerFrame;
            JobCountThisFrame = 0;
        }

        /// <summary>
        /// Call this when a job is finished.
        /// </summary>
        public void JobDone()
        {
            JobCountThisFrame++;
        }
    }
}
