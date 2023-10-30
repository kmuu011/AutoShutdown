using System.Diagnostics;
using System.Timers;

namespace AutoShutdown.Handler
{
    public class Timer
    {
        private System.Timers.Timer shutdownTimer;

        public void ShutdownNow(object sender, ElapsedEventArgs e)
        {
            Process.Start("shutdown", "/s /f /t 0");
        }

        public void SetTimer()
        {
            shutdownTimer = new System.Timers.Timer(Program.ConfigInstance.ShutdownMinute * 60 * 1000);
            shutdownTimer.Elapsed += ShutdownNow;
            shutdownTimer.Start();
        }

        public void ResetTimer()
        {
            shutdownTimer.Stop();
            this.SetTimer();
        }
    }
}