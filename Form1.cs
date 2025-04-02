using System.Diagnostics;

namespace HexColourSlider
{
    public partial class Form1 : Form
    {
        private int value; // temporarily store the RGB values in the full range 1-2147483647 ( Actual Range 8421505 - 2139062144 )
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
        private List<Tuple<long, byte[]>> replacements = null!;
        public Form1()
        {
            InitializeComponent();
            trackBars = new System.Windows.Forms.TrackBar[] { trackBar0, trackBar1, trackBar2 };
            numericUpDowns = new NumericUpDown[] { numericUpDown0, numericUpDown1, numericUpDown2, numericUpDown3, numericUpDown4, numericUpDown5 };
            pictureBoxes = new PictureBox[] { pictureBox0, pictureBox1, pictureBox2, pictureBox3 };
            floatboxes = new System.Windows.Forms.TextBox[] { textBox0, textBox1, textBox2 };
            hexboxes = new System.Windows.Forms.TextBox[] { textBox3, textBox4, textBox5 };
            if (File.Exists("Miles/Mssa3d.m3d"))// Disc // LegacyPC (Steam) // Legacy (GoG)
            { // inform user of limitations of not using the editable executable.
                MessageBox.Show("If using any of the following versions of the game : Disc or LegacyPC (Steam). Please be sure to use the editable executable!");
                Process.Start(new ProcessStartInfo("https://deadlystream.com/files/file/1321-kotor-2-editable-executable/") { UseShellExecute = true });
            } // some hard coded updates to the form controls to limit the range of the colour values to ~0.1 - ~0.9 and force a value update call to calculate.
            numericUpDown3.Minimum = 1;
            numericUpDown4.Minimum = 1;
            numericUpDown5.Minimum = 1;
        }
        private void calculate(object sender, EventArgs e)
        {
            if (sender is System.Windows.Forms.TrackBar trackBar)
            {
                index = int.Parse(trackBar.Name.Substring(TrackBarIndexOffset));
                value = trackBar.Value;
                CalculateBasicRatio(value);
                numericUpDowns[index].Text = value.ToString();
                numericUpDowns[index + 3].Text = ratio.ToString(); // duplicate code // add three to account for the rgb numericUpDown controls
            }
            else if (sender is NumericUpDown numericUpDown)
            {
                index = int.Parse(numericUpDown.Name.Substring(NumericUpDownIndexOffset));
                if (index > 2)
                {
                    value = (int)(((float)numericUpDown.Value / 255.0f) * range);
                    CalculateBasicRatio(value);
                    index -= 3; // remove three from the index when the index is greater than two to account for the rgb numericUpDown controls
                    trackBars[index].Value = value;
                    numericUpDowns[index].Text = value.ToString(); // reason for duplicate code is having two sets of numericUpDown controls
                }
                else
                {
                    value = (int)numericUpDown.Value;
                    CalculateBasicRatio(value);
                    trackBars[index].Value = value;
                    numericUpDowns[index + 3].Text = ratio.ToString(); // duplicate code // add three to account for the rgb numericUpDown controls
                }
            }
            RGB[index] = ratio;
            pictureBoxes[index].BackColor = Color.FromArgb((index == 0) ? RGB[0] : 0, (index == 1) ? RGB[1] : 0, (index == 2) ? RGB[2] : 0);
            pictureBoxes[3].BackColor = Color.FromArgb(RGB[0], RGB[1], RGB[2]);
            floatboxes[index].Text = basic.ToString();
            hexboxes[index].Text = BitConverter.ToString(BitConverter.GetBytes(basic)).Replace("-", " ");
        }
        private void CalculateBasicRatio(int value)
        {
            basic = (float)value / range;
            ratio = (int)(basic * 255);
        }
        private void patch_Click(object sender, EventArgs e)
        {
            if(!File.Exists("swkotor2.exe"))
            {
                MessageBox.Show("Executable file not found, please place this program inside the game folder next to the swkotor2.exe file.");
                return;
            }
            if (radioButton1.Checked)       { DialogChanges(); }                // dialog text colour
            else if (radioButton2.Checked)  { ButtonChanges(); }                // button border colour
            else if (radioButton3.Checked)  { StatusChanges(); }                // status effects colour
            else if (radioButton4.Checked)  { HighlightChanges(); }             // text highlight colour
            MessageBox.Show("The executable has been patched.");
        }
        /// <summary>
        /// NOTES : The offsets for the LegacyPC Executable are not currently known.
        /// find the offsets in the LegacyPC Executable or advise changing to the editable executable.
        /// currently relying on the user to be using the editable executable.
        /// checking the files in the current order is required to ensure the correct offsets are used.
        /// while the order could change a little bit, the check for Miles/Mssa3d.m3d must be done before gog.ico
        /// because in the gog aspyr version of the game the gog.ico file is present but the Miles/Mssa3d.m3d file is not.
        /// so if the check for the gog.ico file would be done first the offsets would be incorrect.
        /// </summary>
        private void DialogChanges()
        {
            if (!File.Exists("Miles/Mssa3d.m3d"))                               // Aspyr version of the game
            {
                if (numericUpDown3.Value > 31 || numericUpDown3.Value < 8)
                {
                    numericUpDown3.Value = 31;
                    MessageBox.Show("When patching the Aspyr version of the game, the red value for the dialog colour is limited to between 8-31. (RGB)");//31-8 RGB//0.02 and 0.12 float
                } // update red value to one that ends in the bytes 3D to prevent breaking the camera on Aspyr versions of the game.
            }
            var offsets = new Dictionary<string, (long, long, long)>            // Version Check
            {
                ["Miles/Mssa3d.m3d"]    = (0x425D34L, 0x425D38L, 0x425D3CL),    // Disc 1.0b Editable Executable Version
                ["steam_api.dll"]       = (0x5862FCL, 0x58575CL, 0x59DBB0L),    // Steam Aspyr
                ["gog.ico"]             = (0x585084L, 0x584B24L, 0x5850C8L),    // GoG Aspyr
                ["kwrapper.dll"]        = (0x585084L, 0x584B24L, 0x5850C8L),    // Amazon Aspyr
            };
            PatchChanges(offsets);
        }
        private void ButtonChanges()
        {
            var offsets = new Dictionary<string, (long, long, long)>            // Version Check
            {
                ["Miles/Mssa3d.m3d"]    = (0x425D1CL, 0x425D20L, 0x425D24L),    // Disc 1.0b Editable Executable Version
                ["steam_api.dll"]       = (0x58C530L, 0x58AA98L, 0x5A03ACL),    // Steam Aspyr
                ["gog.ico"]             = (0x5864ACL, 0x589ED8L, 0x589F08L),    // GoG Aspyr
                ["kwrapper.dll"]        = (0x5864ACL, 0x589ED8L, 0x589F08L),    // Amazon Aspyr
            };
            PatchChanges(offsets);
        }
        private void StatusChanges()
        {
            var offsets = new Dictionary<string, (long, long, long)>            // Version Check
            {
                ["Miles/Mssa3d.m3d"]    = (0x425D40L, 0x425D44L, 0x425D48L),    // Disc 1.0b Editable Executable Version
                ["steam_api.dll"]       = (0x59AF70L, 0x59CE40L, 0x585760L),    // Steam Aspyr
                ["gog.ico"]             = (0x589F04L, 0x589EE8L, 0x584B28L),    // GoG Aspyr
                ["kwrapper.dll"]        = (0x589F04L, 0x589EE8L, 0x584B28L),    // Amazon Aspyr
            };
            PatchChanges(offsets);
        }
        private void HighlightChanges()
        {
            var offsets = new Dictionary<string, (long, long, long)>            // Version Check
            {
                ["Miles/Mssa3d.m3d"]    = (0x425D28L, 0x425D2CL, 0x425D30L),    // Disc 1.0b Editable Executable Version
                ["steam_api.dll"]       = (0x58575CL, 0x58575CL, 0x58A978L),    // Steam Aspyr
                ["gog.ico"]             = (0x584B24L, 0x584B24L, 0x587BD0L),    // GoG Aspyr
                ["kwrapper.dll"]        = (0x584B24L, 0x584B24L, 0x587BD0L),    // Amazon Aspyr
            };
            PatchChanges(offsets);
        }
        private void PatchChanges(Dictionary<string, (long, long, long)> offsets)
        {
            string[] hexValuesR = textBox3.Text.Split(' ');                     // RED
            byte[] bytesR = {   Convert.ToByte(hexValuesR[0], 16),
                                Convert.ToByte(hexValuesR[1], 16),
                                Convert.ToByte(hexValuesR[2], 16),
                                Convert.ToByte(hexValuesR[3], 16) };
            string[] hexValuesG = textBox4.Text.Split(' ');                     // GREEN
            byte[] bytesG = {   Convert.ToByte(hexValuesG[0], 16),
                                Convert.ToByte(hexValuesG[1], 16),
                                Convert.ToByte(hexValuesG[2], 16),
                                Convert.ToByte(hexValuesG[3], 16) };
            string[] hexValuesB = textBox5.Text.Split(' ');                     // BLUE
            byte[] bytesB = {   Convert.ToByte(hexValuesB[0], 16),
                                Convert.ToByte(hexValuesB[1], 16),
                                Convert.ToByte(hexValuesB[2], 16),
                                Convert.ToByte(hexValuesB[3], 16) };
            foreach (var (file, offset) in offsets)                             // Patch Changes
            {
                if (File.Exists(file))                                          // Version Check
                {
                    replacements = new List<Tuple<long, byte[]>>()
                    {
                        Tuple.Create(offset.Item1, bytesR),
                        Tuple.Create(offset.Item2, bytesG),
                        Tuple.Create(offset.Item3, bytesB),
                    };
                    break;
                }
            }
            BinaryUtility.ReplaceBytes(replacements, "swkotor2.exe");
        }
    }
}