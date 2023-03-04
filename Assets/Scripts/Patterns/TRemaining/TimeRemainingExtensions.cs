using System.Collections.Generic;

namespace AndreyGritsenko.ExtensionCollection.Patterns.TRemaining
{
    public static class TimeRemainingExtensions
    {
        private static readonly List<ITimeRemaining> _timeRemaining = new List<ITimeRemaining>(10);

        public static List<ITimeRemaining> TimeRemaining => _timeRemaining;

        public static void AddTimeRemaining(this ITimeRemaining value)
        {
            if (_timeRemaining.Contains(value))
            {
                return;
            }

            value.CurrentTime = value.Time;
            
            _timeRemaining.Add(value);
        }

        public static void RemoveTimeRemaining(this ITimeRemaining value)
        {
            if (!_timeRemaining.Contains(value))
            {
                return;
            }
            _timeRemaining.Remove(value);
        }
    }
}