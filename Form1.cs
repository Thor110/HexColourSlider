namespace HexColourSlider
{
    public partial class Form1 : Form
    {
        private int[] values = new int[3];
        private int index;
        private const float range = 10000000.0f; //4294967295 //2147483647
        private const int TrackBarIndexOffset = 8;
        private const int NumericUpDownIndexOffset = 13;
        private int[] temp = new int[3]; // temporary values for RGB numericUpDowns 4, 5 & 6
        private bool inProgress;
        public Form1() { InitializeComponent(); }
        private void LocateIndex(Control Type, int IndexOffset) { index = int.Parse(Type.Name.Substring(IndexOffset)) - 1; }
        private void calculate(object sender, EventArgs e)
        {
            if (inProgress) return;
            inProgress = true;

            TrackBar[] trackBars = new TrackBar[] { trackBar1, trackBar2, trackBar3 };
            NumericUpDown[] numericUpDowns = new NumericUpDown[] { numericUpDown1, numericUpDown2, numericUpDown3, numericUpDown4, numericUpDown5, numericUpDown6 };

            temp[index] = (int)((values[index] / range) * 255);

            if (sender is TrackBar trackBar)
            {
                LocateIndex(trackBar, TrackBarIndexOffset);
                numericUpDowns[index].Value = trackBars[index].Value;
                values[index] = (int)numericUpDowns[index].Value;
                numericUpDowns[index + 3].Value = temp[index]; // duplicate code
                //GetValueFrom(numericUpDowns, trackBars);
            }
            else if (sender is NumericUpDown numericUpDown)
            {
                LocateIndex(numericUpDown, NumericUpDownIndexOffset);
                if(index > 2)
                {
                    index -= 3;
                    int temp = (int)(((float)numericUpDowns[index + 3].Value / 255.0f) * range);
                    trackBars[index].Value = temp;
                    numericUpDowns[index].Value = temp;
                }
                else
                {
                    trackBars[index].Value = (int)numericUpDowns[index].Value;
                    values[index] = (int)trackBars[index].Value;
                    numericUpDowns[index + 3].Value = temp[index]; // duplicate code
                }
                //GetValueFrom(trackBars, numericUpDowns);
            }/*
            void GetValueFrom(Control[] TargetControl, Control[] SourceControl)
            {
                dynamic giveValueTo = TargetControl[index];
                dynamic getValueFrom = SourceControl[index];
                giveValueTo.Value = (int)getValueFrom.Value;
                values[index] = (int)giveValueTo.Value;
            }*/
            //2147483647
            //10000000

            // update all three always
            pictureBox1.BackColor = Color.FromArgb(temp[0], temp[1], temp[2]);
            // find a way to only update the relevant PictureBox?
            pictureBox2.BackColor = Color.FromArgb(temp[0], 0, 0);
            pictureBox3.BackColor = Color.FromArgb(0, temp[1], 0);
            pictureBox4.BackColor = Color.FromArgb(0, 0, temp[2]);
            //

            TextBox[] textboxes = new TextBox[] { textBox1, textBox2, textBox3 };
            TextBox[] hexboxes = new TextBox[] { textBox4, textBox5, textBox6 };

            float component = (float)values[index] / range;
            textboxes[index].Text = component.ToString();
            uint uintValue = return_uint(component);
            string hexString = return_string(uintValue);
            hexboxes[index].Text = prepare_string(hexString);

            inProgress = false;
        }
        private static uint return_uint(float value) { return BitConverter.ToUInt32(BitConverter.GetBytes(value), 0); }
        private static string return_string(uint uintValue) { return uintValue.ToString("X8"); }
        private static string prepare_string(string hexString) { return hexString.Insert(2, " ").Insert(5, " ").Insert(8, " "); }
    }
}
