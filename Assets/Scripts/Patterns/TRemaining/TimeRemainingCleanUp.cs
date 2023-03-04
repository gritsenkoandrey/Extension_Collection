using System.Collections.Generic;

namespace AndreyGritsenko.ExtensionCollection.Patterns.TRemaining
{
    public sealed class TimeRemainingCleanUp : ICleanUp
    {
        private readonly List<ITimeRemaining> _timeRemaining;

        public TimeRemainingCleanUp()
        {
            _timeRemaining = TimeRemainingExtensions.TimeRemaining;
        }

        public void Cleaner()
        {
            _timeRemaining.Clear();
        }
    }
}