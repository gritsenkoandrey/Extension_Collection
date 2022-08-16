using System;

namespace Patterns.TRemaining
{
    public sealed class TimeRemaining
    {
        public Action Method { get; }
        public bool IsRepeating { get; }
        public float Time { get; }
        public float CurrentTime { get; set; }

        public TimeRemaining(Action method, float time, bool isRepeating = false)
        {
            Method = method;
            Time = time;
            CurrentTime = time;
            IsRepeating = isRepeating;
        }
    }
}