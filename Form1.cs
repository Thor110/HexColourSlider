namespace HexColourSlider
{
    public partial class Form1 : Form
    {
        private int value; // temporarily store the RGB values in the full range 1-10000000
        private int index; // index of the control
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
        private float component;
        private uint uintValue;
        private string hexString = String.Empty; // value represented as a hexadecimal string float 32 value
        public Form1()
        {
            InitializeComponent();
            trackBars = new TrackBar[] { trackBar1, trackBar2, trackBar3 };
            numericUpDowns = new NumericUpDown[] { numericUpDown1, numericUpDown2, numericUpDown3, numericUpDown4, numericUpDown5, numericUpDown6 };
            pictureBoxes = new PictureBox[] { pictureBox2, pictureBox3, pictureBox4, pictureBox1 };
            floatboxes = new TextBox[] { textBox1, textBox2, textBox3 };
            hexboxes = new TextBox[] { textBox4, textBox5, textBox6 };
        }
        private void calculate(object sender, EventArgs e)
        {
            if (inProgress) return;
            inProgress = true;

            if (sender is TrackBar trackBar)
            {
                index = int.Parse(trackBar.Name.Substring(TrackBarIndexOffset)) - 1;
                numericUpDowns[index].Value = trackBars[index].Value;
                value = (int)numericUpDowns[index].Value;
                numericUpDowns[index + 3].Value = (int)((value / range) * 255); // duplicate code // add three to account for the rgb numericUpDown controls
            }
            else if (sender is NumericUpDown numericUpDown)
            {
                index = int.Parse(numericUpDown.Name.Substring(NumericUpDownIndexOffset)) - 1;
                if (index > 2)
                {
                    value = (int)(((float)numericUpDowns[index].Value / 255.0f) * range); // get from rgb numerics
                    index -= 3; // remove three from the index when the index is greater than two to account for the rgb numericUpDown controls
                    trackBars[index].Value = value;
                    numericUpDowns[index].Value = value; // reason for duplicate code
                }
                else
                {
                    trackBars[index].Value = (int)numericUpDowns[index].Value;
                    value = (int)trackBars[index].Value;
                    numericUpDowns[index + 3].Value = (int)((value / range) * 255); // duplicate code // add three to account for the rgb numericUpDown controls
                }
            }
            RGB[index] = (int)((value / range) * 255);

            pictureBoxes[index].BackColor = Color.FromArgb((index == 0) ? RGB[0] : 0, (index == 1) ? RGB[1] : 0, (index == 2) ? RGB[2] : 0);
            pictureBoxes[3].BackColor = Color.FromArgb(RGB[0], RGB[1], RGB[2]);

            component = (float)value / range;
            floatboxes[index].Text = component.ToString();
            uintValue = BitConverter.ToUInt32(BitConverter.GetBytes(component), 0);
            hexString = uintValue.ToString("X8");
            hexboxes[index].Text = hexString.Insert(2, " ").Insert(5, " ").Insert(8, " ");

            inProgress = false;
        }
    }
}
