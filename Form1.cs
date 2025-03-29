namespace HexColourSlider
{
    public partial class Form1 : Form
    {
        private int[] values = new int[3]; // RGB values in the full range 1-10000000
        private int index; // index of the control
        private const float range = 10000000.0f; //4294967295 //2147483647
        private const int TrackBarIndexOffset = 8;
        private const int NumericUpDownIndexOffset = 13;
        private int[] temp = new int[3]; // temporary values for RGB numericUpDowns 4, 5 & 6
        private bool inProgress; // is calculation in progress
        private TrackBar[] trackBars;
        private NumericUpDown[] numericUpDowns;
        private PictureBox[] pictureBoxes;
        private TextBox[] textboxes;
        private TextBox[] hexboxes;
        private float component;
        private uint uintValue;
        private string hexString = String.Empty; // value represented as a hexadecimal string float 32 value
        public Form1()
        {
            InitializeComponent();
            trackBars = new TrackBar[] { trackBar1, trackBar2, trackBar3 };
            numericUpDowns = new NumericUpDown[] { numericUpDown1, numericUpDown2, numericUpDown3, numericUpDown4, numericUpDown5, numericUpDown6 };
            pictureBoxes = new PictureBox[] { pictureBox1, pictureBox2, pictureBox3, pictureBox4 };
            textboxes = new TextBox[] { textBox1, textBox2, textBox3 };
            hexboxes = new TextBox[] { textBox4, textBox5, textBox6 };
        }
        private void LocateIndex(Control Type, int IndexOffset) { index = int.Parse(Type.Name.Substring(IndexOffset)) - 1; }
        private void calculate(object sender, EventArgs e)
        {
            if (inProgress) return;
            inProgress = true;

            temp[index] = (int)((values[index] / range) * 255);

            if (sender is TrackBar trackBar)
            {
                LocateIndex(trackBar, TrackBarIndexOffset);
                numericUpDowns[index].Value = trackBars[index].Value;
                values[index] = (int)numericUpDowns[index].Value;
                numericUpDowns[index + 3].Value = temp[index]; // duplicate code
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
            }
            pictureBoxes[index + 1].BackColor = Color.FromArgb((index == 0) ? temp[0] : 0, (index == 1) ? temp[1] : 0, (index == 2) ? temp[2] : 0);
            pictureBoxes[0].BackColor = Color.FromArgb(temp[0], temp[1], temp[2]);

            component = (float)values[index] / range;
            textboxes[index].Text = component.ToString();
            uintValue = return_uint(component);
            hexString = return_string(uintValue);
            hexboxes[index].Text = prepare_string(hexString);

            inProgress = false;
        }
        private static uint return_uint(float value) { return BitConverter.ToUInt32(BitConverter.GetBytes(value), 0); }
        private static string return_string(uint uintValue) { return uintValue.ToString("X8"); }
        private static string prepare_string(string hexString) { return hexString.Insert(2, " ").Insert(5, " ").Insert(8, " "); }
    }
}
