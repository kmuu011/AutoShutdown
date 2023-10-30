using System.Windows.Forms;
using Gma.System.MouseKeyHook;

namespace AutoShutdown
{
    static class Program
    {
        public static Config.Config ConfigInstance = new Config.Config();
        public static Handler.Timer TimerInstance = new Handler.Timer();

        static void Main()
        {
            ConfigInstance.Load();
            TimerInstance.SetTimer();
            IKeyboardMouseEvents globalHook = Hook.GlobalEvents();
            globalHook.KeyDown += GlobalHook_Keydown;

            var hook = Hook.GlobalEvents();

            hook.MouseClick += (sender, e) => { TimerInstance.ResetTimer(); };
            hook.MouseMove += (sender, e) => { TimerInstance.ResetTimer(); };
            hook.KeyDown += (sender, e) => { TimerInstance.ResetTimer(); };
            hook.MouseWheel += (sender, e) => { TimerInstance.ResetTimer(); };

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run();
        }

        private static void GlobalHook_Keydown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.Shift && e.KeyCode == Keys.L)
            {
                foreach (Form form in Application.OpenForms)
                {
                    form.Hide();
                }

                Form1 form1 = new Form1();
                form1.Show();
            }
        }
    }
}