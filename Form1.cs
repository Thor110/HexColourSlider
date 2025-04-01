using System.Diagnostics;

namespace HexColourSlider
{
    public partial class Form1 : Form
    {
        private int value; // temporarily store the RGB values in the full range 1-2147483647
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
            // inform user of limitations of not using the editable executable.
            // Disc // LegacyPC (Steam) // Legacy (GoG)
            if (File.Exists("swupdate.exe") || File.Exists("DirectX/DSETUP.dll"))
            {
                MessageBox.Show("If using any of the following versions of the game : Disc or LegacyPC (Steam). Please be sure to use the editable executable!");
                Process.Start(new ProcessStartInfo("https://deadlystream.com/files/file/1321-kotor-2-editable-executable/") { UseShellExecute = true });
            }
            // some hard coded updates to the form controls to limit the range of the colour values to ~0.1 - ~0.9 and force a value update call.
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
            hexboxes[index].Text = BitConverter.ToUInt32(BitConverter.GetBytes(basic), 0).ToString("X8").Insert(2, " ").Insert(5, " ").Insert(8, " ");
        }
        private void CalculateBasicRatio(int value)
        {
            basic = (float)value / range;
            ratio = (int)(basic * 255);
        }
        private void R3D_Click()
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
                    CalculateBasicRatio(current);
                    trackBar0.Value = current;
                    numericUpDown3.Text = ratio.ToString();
                    break;
                }
            }
        }
        private void patch_Click(object sender, EventArgs e)
        {
            if(!File.Exists("swkotor2.exe"))
            {
                MessageBox.Show("Executable file not found, please place this program inside the game folder next to the swkotor2.exe file.");
                return;
            }
            R3D_Click(); // update red value to one that ends in the bytes 3D to prevent breaking the camera on Aspyr versions of the game.
            if (radioButton1.Checked) // dialog colour
            {
                DialogChanges();
            }
            else if (radioButton2.Checked) // button border colour
            {
                ButtonChanges();
            }
            else if (radioButton3.Checked) // status effects colour
            {
                StatusChanges();
            }
            else if (radioButton4.Checked) // text highlight colour
            {
                HighlightChanges();
            }
            else if (radioButton5.Checked) // patch all colour values
            {
                DialogChanges();
                ButtonChanges();
                StatusChanges();
                HighlightChanges();
            }
            MessageBox.Show("The executable has been patched.");
        }
        // find the offsets in the LegacyPC Executable or advise changing to the editable executable.
        // currently relying on the user to be using the editable executable.
        private void DialogChanges()
        {
            // version check
            var offsets = new Dictionary<string, (long, long, long)>
            {
                ["steam_api.dll"] = (0x5862FCL, 0x58575CL, 0x59DBB0L),      //Steam Aspyr
                ["gog.ico"] = (0x585084L, 0x584B24L, 0x5850C8L),            //GoG Aspyr
                ["kwrapper.dll"] = (0x585084L, 0x584B24L, 0x5850C8L),       //Amazon Aspyr
                ["swupdate.exe"] = (0x425D34L, 0x425D38L, 0x425D3CL),       //Disc 1.0b Editable Executable Version
                //["DirectX/DSETUP.dll"] = (0x425D34L, 0x425D38L, 0x425D3CL), //Disc 1.0b Editable Executable Version
                //["DirectX/DSETUP.dll"] = (0x426E34L, 0x426E38L, 0x426E3CL), //LegacyPC actual offsets
            };
            PatchChanges(offsets);
        }
        // TO-DO : find LegacyPC Offsets
        private void ButtonChanges()
        {
            // version check
            var offsets = new Dictionary<string, (long, long, long)>
            {
                ["steam_api.dll"] = (0x58C530L, 0x58AA98L, 0x5A03ACL),      //Steam Aspyr
                ["gog.ico"] = (0x5864ACL, 0x589ED8L, 0x589F08L),            //GoG Aspyr
                ["kwrapper.dll"] = (0x5864ACL, 0x589ED8L, 0x589F08L),       //Amazon Aspyr
                ["swupdate.exe"] = (0x425D1CL, 0x425D20L, 0x425D24L),       //Disc 1.0b Editable Executable Version
                //["DirectX/DSETUP.dll"] = (0x425D1CL, 0x425D20L, 0x425D24L), //Disc 1.0b Editable Executable Version
                //["DirectX/DSETUP.dll"] = (0xL, 0xL, 0xL), //LegacyPC actual offsets are unknown
            };
            PatchChanges(offsets);
        }
        private void StatusChanges()
        {
            // version check
            var offsets = new Dictionary<string, (long, long, long)>
            {
                ["steam_api.dll"] = (0x59AF70L, 0x59CE40L, 0x585760L),      //Steam Aspyr
                ["gog.ico"] = (0x589F04L, 0x589EE8L, 0x584B28L),            //GoG Aspyr
                ["kwrapper.dll"] = (0x589F04L, 0x589EE8L, 0x584B28L),       //Amazon Aspyr
                ["swupdate.exe"] = (0x425D40L, 0x425D44L, 0x425D48L),       //Disc 1.0b Editable Executable Version
                //["DirectX/DSETUP.dll"] = (0x425D40L, 0x425D44L, 0x425D48L), //Disc 1.0b Editable Executable Version
                //["DirectX/DSETUP.dll"] = (0xL, 0xL, 0xL), //LegacyPC actual offsets are unknown
            };
            PatchChanges(offsets);
        }
        private void HighlightChanges()
        {
            // version check
            var offsets = new Dictionary<string, (long, long, long)>
            {
                ["steam_api.dll"] = (0x58575CL, 0x58575CL, 0x58A978L),      //Steam Aspyr
                ["gog.ico"] = (0x584B24L, 0x584B24L, 0x587BD0L),            //GoG Aspyr
                ["kwrapper.dll"] = (0x584B24L, 0x584B24L, 0x587BD0L),       //Amazon Aspyr
                ["swupdate.exe"] = (0x425D28L, 0x425D2CL, 0x425D30L),       //Disc 1.0b Editable Executable Version
                //["DirectX/DSETUP.dll"] = (0x425D28L, 0x425D2CL, 0x425D30L), //Disc 1.0b Editable Executable Version
                //["DirectX/DSETUP.dll"] = (0xL, 0xL, 0xL), //LegacyPC actual offsets are unknown
            };
            PatchChanges(offsets);
        }
        private void PatchChanges(Dictionary<string, (long, long, long)> offsets)
        {
            //RED
            string[] hexValuesR = textBox3.Text.Split(' ');
            byte[] bytesR = {   Convert.ToByte(hexValuesR[0], 16),
                                Convert.ToByte(hexValuesR[1], 16),
                                Convert.ToByte(hexValuesR[2], 16),
                                Convert.ToByte(hexValuesR[3], 16) };
            //GREEN
            string[] hexValuesG = textBox4.Text.Split(' ');
            byte[] bytesG = {   Convert.ToByte(hexValuesG[0], 16),
                                Convert.ToByte(hexValuesG[1], 16),
                                Convert.ToByte(hexValuesG[2], 16),
                                Convert.ToByte(hexValuesG[3], 16) };
            //BLUE
            string[] hexValuesB = textBox5.Text.Split(' ');
            byte[] bytesB = {   Convert.ToByte(hexValuesB[0], 16),
                                Convert.ToByte(hexValuesB[1], 16),
                                Convert.ToByte(hexValuesB[2], 16),
                                Convert.ToByte(hexValuesB[3], 16) };
            // patch changes
            foreach (var (file, offset) in offsets)
            {
                if (File.Exists("Miles/Mssa3d.m3d")) // if this file is found, the version is LegacyPC (Steam), Legacy (GoG) or Disc.
                {
                    var fourthElement = offsets.ElementAt(3);
                    replacements = new List<Tuple<long, byte[]>>()
                    {
                        Tuple.Create(fourthElement.Value.Item1, bytesR),
                        Tuple.Create(fourthElement.Value.Item2, bytesG),
                        Tuple.Create(fourthElement.Value.Item3, bytesB),
                    };
                    break;
                }
                if (File.Exists(file)) // otherwise, the version is Steam, GoG or Amazon Aspyr.
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