namespace HexColourSlider
{
    public partial class Form1 : Form
    {
        private int[] values = new int[3];
        private int index;
        private const float range = 255.0f;
        private const int TrackBarIndexOffset = 8;
        private const int NumericUpDownIndexOffset = 13;
        public Form1()
        {
            InitializeComponent();
            calculate(this, EventArgs.Empty);
        }
        private void LocateIndex(Control Type, int IndexOffset) { index = int.Parse(Type.Name.Substring(IndexOffset)) - 1; }
        private void calculate(object sender, EventArgs e)
        {
            TrackBar[] trackBars = new TrackBar[] { trackBar1, trackBar2, trackBar3 };
            NumericUpDown[] numericUpDowns = new NumericUpDown[] { numericUpDown1, numericUpDown2, numericUpDown3 };
            if (sender is TrackBar trackBar)
            {
                LocateIndex(trackBar, TrackBarIndexOffset);
                numericUpDowns[index].Value = trackBars[index].Value;
                values[index] = (int)numericUpDowns[index].Value;
                //GetValueFrom(numericUpDowns, trackBars);
            }
            else if (sender is NumericUpDown numericUpDown)
            {
                LocateIndex(numericUpDown, NumericUpDownIndexOffset);
                trackBars[index].Value = (int)numericUpDowns[index].Value;
                values[index] = (int)trackBars[index].Value;
                //GetValueFrom(trackBars, numericUpDowns);
            }/*
            void GetValueFrom(Control[] TargetControl, Control[] SourceControl)
            {
                dynamic giveValueTo = TargetControl[index];
                dynamic getValueFrom = SourceControl[index];
                giveValueTo.Value = (int)getValueFrom.Value;
                values[index] = (int)giveValueTo.Value;
            }*/
            pictureBox1.BackColor = Color.FromArgb(values[0], values[1], values[2]);
            pictureBox2.BackColor = Color.FromArgb(values[0], 0, 0);
            pictureBox3.BackColor = Color.FromArgb(0, values[1], 0);
            pictureBox4.BackColor = Color.FromArgb(0, 0, values[2]);
            TextBox[] textboxes = new TextBox[] { textBox1, textBox2, textBox3 };
            TextBox[] hexboxes = new TextBox[] { textBox4, textBox5, textBox6 };
            float component = (float)values[index] / range;
            textboxes[index].Text = component.ToString();
            uint uintValue = return_uint(component);
            string hexString = return_string(uintValue);
            hexboxes[index].Text = prepare_string(hexString);
        }
        private static uint return_uint(float value) { return BitConverter.ToUInt32(BitConverter.GetBytes(value), 0); }
        private static string return_string(uint uintValue) { return uintValue.ToString("X8"); }
        private static string prepare_string(string hexString) { return hexString.Insert(2, " ").Insert(5, " ").Insert(8, " "); }
    }
}
