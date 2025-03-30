namespace HexColourSlider
{
    public partial class Form1 : Form
    {
        private int value; // temporarily store the RGB values in the full range 1-10000000
        private int index; // index of the control
        private int ratio; // ratio of value to range times 255
        private float basic; // basic ratio of value to range
        private const float range = 10000000.0f; //4294967295 //2147483647
        private const int TrackBarIndexOffset = 8;
        private const int NumericUpDownIndexOffset = 13;
        private int[] RGB = new int[3]; // store values for RGB numericUpDowns 4, 5 & 6
        private bool inProgress; // is calculation in progress
        private TrackBar[] trackBars;
        private NumericUpDown[] numericUpDowns;
        private PictureBox[] pictureBoxes;
        private TextBox[] floatboxes;
        private TextBox[] hexboxes;
        private uint uintValue;
        private string hexString = String.Empty; // value represented as a hexadecimal string float 32 value
        public Form1()
        {
            InitializeComponent();
            trackBars = new TrackBar[] { trackBar0, trackBar1, trackBar2 };
            numericUpDowns = new NumericUpDown[] { numericUpDown0, numericUpDown1, numericUpDown2, numericUpDown3, numericUpDown4, numericUpDown5 };
            pictureBoxes = new PictureBox[] { pictureBox0, pictureBox1, pictureBox2, pictureBox3 };
            floatboxes = new TextBox[] { textBox0, textBox1, textBox2 };
            hexboxes = new TextBox[] { textBox3, textBox4, textBox5 };
        }
        private void calculate(object sender, EventArgs e)
        {
            if (inProgress) return;
            inProgress = true;

            if (sender is TrackBar trackBar)
            {
                index = int.Parse(trackBar.Name.Substring(TrackBarIndexOffset));
                value = trackBar.Value;
                numericUpDowns[index].Value = value;

                basic = (float)value / range; // duplication of code
                ratio = (int)(basic * 255); // duplication of code

                numericUpDowns[index + 3].Value = ratio; // duplicate code // add three to account for the rgb numericUpDown controls
            }
            else if (sender is NumericUpDown numericUpDown)
            {
                index = int.Parse(numericUpDown.Name.Substring(NumericUpDownIndexOffset));
                if (index > 2)
                {
                    value = (int)(((float)numericUpDown.Value / 255.0f) * range);
                    index -= 3; // remove three from the index when the index is greater than two to account for the rgb numericUpDown controls
                    trackBars[index].Value = value;
                    numericUpDowns[index].Value = value; // reason for duplicate code

                    basic = (float)value / range; // duplication of code
                    ratio = (int)(basic * 255); // duplication of code
                }
                else
                {
                    value = (int)numericUpDown.Value;
                    trackBars[index].Value = value;

                    basic = (float)value / range; // duplication of code
                    ratio = (int)(basic * 255); // duplication of code

                    numericUpDowns[index + 3].Value = ratio; // duplicate code // add three to account for the rgb numericUpDown controls
                }
            }
            RGB[index] = ratio;

            pictureBoxes[index].BackColor = Color.FromArgb((index == 0) ? RGB[0] : 0, (index == 1) ? RGB[1] : 0, (index == 2) ? RGB[2] : 0);
            pictureBoxes[3].BackColor = Color.FromArgb(RGB[0], RGB[1], RGB[2]);

            floatboxes[index].Text = basic.ToString();
            uintValue = BitConverter.ToUInt32(BitConverter.GetBytes(basic), 0);
            hexString = uintValue.ToString("X8");
            hexboxes[index].Text = hexString.Insert(2, " ").Insert(5, " ").Insert(8, " ");

            inProgress = false;
        }
    }
}