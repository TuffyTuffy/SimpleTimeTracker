using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace SimpleTimeTracker.Helpers
{
    public class CustomTimer
    {
        private readonly Timer _timer;
        private readonly Stopwatch _stopwatch;
        public Action<TimeSpan> OnTick;
        public Action<TimerState> OnStateChanged;

        public TimerState State { get; set; }

        public enum TimerState
        {
            Stopped,
            Running
        }

        private void FireTick()
        {
            if (OnTick != null)
            {
                OnTick(_stopwatch.Elapsed);
            }
        }

        private void ChangeState(TimerState state)
        {
            if (state != State)
            {
                if (OnStateChanged != null)
                {
                    OnStateChanged(state);
                }

                State = state;
            }
        }

        public TimeSpan Elapsed
        {
            get { return _stopwatch.Elapsed; }
        }

        public CustomTimer()
        {
            _timer = new Timer {Interval = 1000};
            _timer.Tick += (sender, args) => OnTick(Elapsed);
            _stopwatch = new Stopwatch();
            ChangeState(TimerState.Stopped);
        }

        public void Resume()
        {
            ChangeState(TimerState.Running);
            _stopwatch.Start();
            _timer.Start();

            FireTick();
        }

        public void ReStart()
        {
            ChangeState(TimerState.Running);
            _stopwatch.Restart();
            _timer.Start();

            FireTick();
        }

        public void Stop()
        {
            ChangeState(TimerState.Stopped);
            _stopwatch.Reset();
            _timer.Stop();

            FireTick();
        }

        public void Pause()
        {
            ChangeState(TimerState.Running);
            _stopwatch.Stop();
            _timer.Stop();

            FireTick();
        }
    }
}