using System.Collections.Generic;

namespace AndreyGritsenko.ExtensionCollection.Patterns.TRemaining
{
    public sealed class TimeRemainingController : IExecute
    {
        private readonly List<ITimeRemaining> _timeRemaining;
        private readonly ITimeService _timeService;

        public TimeRemainingController()
        {
            _timeRemaining = TimeRemainingExtensions.TimeRemaining;
            _timeService = new UnityTimeService();
        }

        public void Execute()
        {
            float time = _timeService.DeltaTime();
            
            for (var i = 0; i < _timeRemaining.Count; i++)
            {
                ITimeRemaining obj = _timeRemaining[i];
                
                obj.CurrentTime -= time;
                
                if (obj.CurrentTime <= 0.0f)
                {
                    obj?.Method?.Invoke();
                    
                    if (!obj.IsRepeating)
                    {
                        obj.RemoveTimeRemaining();
                    }
                    else
                    {
                        obj.CurrentTime = obj.Time;
                    }
                }
            }
        }
    }
}