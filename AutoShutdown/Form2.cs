using System;
using System.Windows.Forms;

namespace AutoShutdown
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.textBox1.Text = Program.ConfigInstance.ShutdownMinute.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var minute = int.Parse(textBox1.Text);

            if (minute <= 0)
            {
                MessageBox.Show("1분 이상으로 설정해주세요.");
            }

            if (minute > 240)
            {
                MessageBox.Show("240분 이상은 설정할 수 없습니다.");
            }

            Program.ConfigInstance.ShutdownMinute = minute;
            Program.ConfigInstance.Save();
            Program.TimerInstance.ResetTimer();
            this.Hide();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}