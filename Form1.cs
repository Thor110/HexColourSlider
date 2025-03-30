using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HexColourSlider
{
    public partial class Form1 : Form
    {
        private int value; // temporarily store the RGB values in the full range 1-10000000
        private int index; // index of the control
        private int ratio; // ratio of value to range times 255
        private float basic; // basic ratio of value to range
        private const float range = 2147483647.0f; //4294967295 //2147483647 = maximum integer value
        private const int TrackBarIndexOffset = 8; // offset of the index in the object name
        private const int NumericUpDownIndexOffset = 13; // offset of the index in the object name
        private int[] RGB = new int[3]; // store values for RGB numericUpDowns 4, 5 & 6 and to update the colour in pictureBox3
        private System.Windows.Forms.TrackBar[] trackBars;
        private NumericUpDown[] numericUpDowns;
        private PictureBox[] pictureBoxes;
        private System.Windows.Forms.TextBox[] floatboxes;
        private System.Windows.Forms.TextBox[] hexboxes;
        public Form1()
        {
            InitializeComponent();
            trackBars = new System.Windows.Forms.TrackBar[] { trackBar0, trackBar1, trackBar2 };
            numericUpDowns = new NumericUpDown[] { numericUpDown0, numericUpDown1, numericUpDown2, numericUpDown3, numericUpDown4, numericUpDown5 };
            pictureBoxes = new PictureBox[] { pictureBox0, pictureBox1, pictureBox2, pictureBox3 };
            floatboxes = new System.Windows.Forms.TextBox[] { textBox0, textBox1, textBox2 };
            hexboxes = new System.Windows.Forms.TextBox[] { textBox3, textBox4, textBox5 };
        }
        private void calculate(object sender, EventArgs e)
        {
            if (sender is System.Windows.Forms.TrackBar trackBar)
            {
                index = int.Parse(trackBar.Name.Substring(TrackBarIndexOffset));
                value = trackBar.Value;
                basic = (float)value / range; // code duplication
                ratio = (int)(basic * 255); // code duplication
                numericUpDowns[index].Text = value.ToString();
                numericUpDowns[index + 3].Text = ratio.ToString(); // duplicate code // add three to account for the rgb numericUpDown controls
            }
            else if (sender is NumericUpDown numericUpDown)
            {
                index = int.Parse(numericUpDown.Name.Substring(NumericUpDownIndexOffset));
                if (index > 2)
                {
                    value = (int)(((float)numericUpDown.Value / 255.0f) * range);
                    basic = (float)value / range; // code duplication
                    ratio = (int)(basic * 255); // code duplication
                    index -= 3; // remove three from the index when the index is greater than two to account for the rgb numericUpDown controls
                    trackBars[index].Value = value;
                    numericUpDowns[index].Text = value.ToString(); // reason for duplicate code is having two sets of numericUpDown controls
                }
                else
                {
                    value = (int)numericUpDown.Value;
                    basic = (float)value / range; // code duplication
                    ratio = (int)(basic * 255); // code duplication
                    trackBars[index].Value = value;
                    numericUpDowns[index + 3].Text = ratio.ToString(); // duplicate code // add three to account for the rgb numericUpDown controls
                }
            }
            RGB[index] = ratio;
            pictureBoxes[index].BackColor = Color.FromArgb((index == 0) ? RGB[0] : 0, (index == 1) ? RGB[1] : 0, (index == 2) ? RGB[2] : 0);
            pictureBoxes[3].BackColor = Color.FromArgb(RGB[0], RGB[1], RGB[2]);
            floatboxes[index].Text = basic.ToString();
            hexboxes[index].Text = BitConverter.ToUInt32(BitConverter.GetBytes(basic), 0).ToString("X8").Insert(2, " ").Insert(5, " ").Insert(8, " ");
        }
        private void R3D_Click(object sender, EventArgs e)
        {
            int maximum = 2147483647;
            for (int current = (int)numericUpDown0.Value; current <= maximum; current++)
            {
                string message = current.ToString("X8");
                if (message.EndsWith("3D"))
                {
                    message = message.Insert(2, " ").Insert(5, " ").Insert(8, " ");
                    textBox3.Text = message;
                    numericUpDown0.Text = message;

                    basic = (float)current / range; // code duplication
                    ratio = (int)(basic * 255); // code duplication

                    trackBar0.Value = current;
                    numericUpDown3.Text = ratio.ToString();
                    MessageBox.Show("The hexadecimal value is " + message + ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                }
            }
            if ((int)numericUpDown0.Value > maximum)
            {
                MessageBox.Show("The value is too large to convert to a hexadecimal value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}