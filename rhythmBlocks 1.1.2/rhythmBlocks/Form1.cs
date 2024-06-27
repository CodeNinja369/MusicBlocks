using System.Media;
namespace rhythmBlocks
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        public string[] rhythmList = new string[4];
        public string selectedRhythm;

        public string GetPath(string name, string type)
        {
            if (type == "audio")
            {
                if (name == "ta")
                {
                    return "ta.wav";
                }
                if (name == "titi")
                {
                    return "ti-ti.wav";
                }
                if (name == "rest")
                {
                    return "rest.wav";
                }
                return "UH_OH.wav";
            }
            if (type == "cursor")
            {
                if (name == "ta")
                {
                    return "ta.cur";
                }
                if (name == "titi")
                {
                    return "ti-ti.cur";
                }
                if (name == "rest")
                {
                    return "rest.cur";
                }
                return "UH_OH.cur";
            }
            else
            {
                if (name == "ta")
                {
                    return "ta_block.png";
                }
                if (name == "titi")
                {
                    return "titi_block.jpg";
                }
                if (name == "rest")
                {
                    return "rest_block.jpg";
                }
                return "UH_OH.jpg";
            }

        }
        private void playButton_Click(object sender, EventArgs e)
        {
            foreach (var sound in rhythmList)
            {
                string audioPath = GetPath(sound, "audio");
                SoundPlayer simpleSound = new SoundPlayer(audioPath);
                simpleSound.PlaySync();
            }
        }
        private void slotClick(PictureBox slot, int slotnum)
        {
            string imagePath = GetPath(selectedRhythm, "image");
            Image newImage = Image.FromFile(imagePath);
            slot.Visible = true;
            slot.Image = newImage;
            slot.Refresh();
            rhythmList[slotnum] = selectedRhythm;
        }
        private void buttonClick(string type)
        {
            selectedRhythm = type;
            string cursorPath = GetPath(type, "cursor");

            //resizing of cursor image so it matches required size and can be loaded, was written by Chat GPT. Bitmaps are complicated and fiddly
            using (Bitmap bitmap = new Bitmap(cursorPath))
            {
                int newWidth = 32;
                int newHeight = 32;
                Bitmap resizedBitmap = new Bitmap(bitmap, new Size(newWidth, newHeight));
                IntPtr ptr = resizedBitmap.GetHicon();
                this.Cursor = new Cursor(ptr);
            }
        }

        private void taButton_Click(object sender, EventArgs e)
        {
            buttonClick("ta");
        }
        private void fCover1_Click(object sender, EventArgs e)
        {
            slotClick(fSlot1, 0);
        }
        private void fCover2_Click(object sender, EventArgs e)
        {
            slotClick(fSlot2, 1);
        }
        private void fCover3_Click(object sender, EventArgs e)
        {
            slotClick(fSlot3, 2);
        }
        private void fCover4_Click(object sender, EventArgs e)
        {
            slotClick(fSlot4, 3);
        }

        private void titiButton_Click(object sender, EventArgs e)
        {
            buttonClick("titi");
        }

        private void restButton_Click(object sender, EventArgs e)
        {
            buttonClick("rest");
        }

        private void fSlot1_Click(object sender, EventArgs e)
        {
            slotClick(fSlot1, 0);
        }

        private void fSlot2_Click(object sender, EventArgs e)
        {
            slotClick(fSlot2, 1);
        }

        private void fSlot3_Click(object sender, EventArgs e)
        {
            slotClick(fSlot3, 2);
        }

        private void fSlot4_Click(object sender, EventArgs e)
        {
            slotClick(fSlot4, 3);
        }

        private void oCover1_Click(object sender, EventArgs e)
        {
            slotClick(oSlot1, 0);
        }

        private void oSlot1_Click(object sender, EventArgs e)
        {
            slotClick(oSlot1, 0);
        }

        private void oSlot2_Click(object sender, EventArgs e)
        {
            slotClick(oSlot2, 1);
        }

        private void oCover2_Click(object sender, EventArgs e)
        {
            slotClick(oSlot2, 1);
        }

        private void oSlot4_Click(object sender, EventArgs e)
        {
            slotClick(oSlot4, 3);
        }

        private void oCover4_Click(object sender, EventArgs e)
        {
            slotClick(oSlot4, 3);
        }

        private void oSlot3_Click(object sender, EventArgs e)
        {
            slotClick(oSlot3, 2);
        }

        private void oCover3_Click(object sender, EventArgs e)
        {
            slotClick(oSlot3, 2);
        }

        private void tSlot1_Click(object sender, EventArgs e)
        {
            slotClick(tSlot1, 0);
        }

        private void tSlot2_Click(object sender, EventArgs e)
        {
            slotClick(tSlot2, 1);
        }

        private void tSlot3_Click(object sender, EventArgs e)
        {
            slotClick(tSlot3, 2);
        }

        private void tSlot4_Click(object sender, EventArgs e)
        {
            slotClick(tSlot4, 3);
        }

        private void tCover1_Click(object sender, EventArgs e)
        {
            slotClick(tSlot1, 0);
        }

        private void tCover2_Click(object sender, EventArgs e)
        {
            slotClick(tSlot2, 1);
        }

        private void tCover4_Click(object sender, EventArgs e)
        {
            slotClick(tSlot4, 3);
        }

        private void tCover3_Click(object sender, EventArgs e)
        {
            slotClick(tSlot3, 2);
        }
    }
}
