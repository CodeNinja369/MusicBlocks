using System.Media;
namespace rhythmBlocks
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        //define arrays for different dificulty levels

        public string[] rhythmList = new string[4];
        public string[] rhythmList1 = new string[4];
        public string[] rhythmList2 = new string[4];
        //initialize selectedRhythm
        public string selectedRhythm;

        public string GetPath(string name, string type)
        {
            //get path for audio
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
                if (name == "saa")
                {
                    return "sa-a.wav";
                }
                if (name == "taa")
                {
                    return "ta-a.wav";
                }
                if (name == "tikatika")
                {
                    return "tika-tika.wav";
                }
                //if sound not found, return rest
                return "rest.wav";
            }
            //get paths for cursors
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
                if(name == "taa")
                {
                    return "ta-a.cur";
                }
                if(name == "saa")
                {
                    return "sa-a.cur";
                }
                if(name == "tikatika")
                {
                    return "tika-tika.cur";
                }
                //if not found, returns rest cursor
                return "rest.cur";
            }
            //get path for images
            else
            {
                if (name == "ta")
                {
                    return "ta_block.png";
                }
                if (name == "titi")
                {
                    return "titi_block.png";
                }
                if (name == "rest")
                {
                    return "rest_block.png";
                }
                if (name == "saa")
                {
                    return "saa_block.png";
                }
                if (name == "taa")
                {
                    return "taa_block.png";
                }
                if (name == "tikatika")
                {
                    return "tikatika_block.png";
                }
                //if not found, return rest image
                return "rest_block.png";
            }

        }
        private void playbtn(string[] list)
        {
            foreach (var sound in list)
            {
                //get audio path, creating sound player that loads audio at the specific path, plays sound 
                string audioPath = GetPath(sound, "audio");
                SoundPlayer simpleSound = new SoundPlayer(audioPath);
                simpleSound.PlaySync();
            }
        }

        //plays sound list specific to which page the play button was clicked on
        private void playButton_Click(object sender, EventArgs e)
        {
            playbtn(rhythmList);
        }
        private void playButton1_Click(object sender, EventArgs e)
        {
            playbtn(rhythmList1);
        }
        private void playButton2_Click(object sender, EventArgs e)
        {
            playbtn(rhythmList2);
        }

        //general function for updating
        private void basicChange(PictureBox slot, int slotnum, string[] list)
        {
            //gets path for image, creates image variable
            string imagePath = GetPath(selectedRhythm, "image");
            Image newImage = Image.FromFile(imagePath);

            //makes picture box visible, changes image, refreshes picturebox
            slot.Visible = true;
            slot.Image = newImage;
            slot.Refresh();

            //updates rhythm list
            list[slotnum] = selectedRhythm;
        }

        //specific logic for two slot blocks
        private void addDouble(PictureBox slot, PictureBox nextslot, Panel nextpanel, int slotnum, string[] list)
        {
            //stops two slot block from being at the end, which would break logic
            if (slotnum == 3)
            {
                list[slotnum] = "rest";
            }
            else
            {
                //performs basic  change, add a rest to the array value next to the slot clicked, making it so the block takes up to spaces
                basicChange(slot, slotnum, list);
                list[slotnum + 1] = "rest";
                //makes picture box and panel next to clicked slot invisible, so they can't be clicked
                //this is how the block takes up two spaces "visually" without the pain of microsoft bs
                nextslot.Image = null;
                nextslot.Visible = false;
                nextpanel.Visible = false;

            }

        }
        //function for when a slot is clicked.
        //input is: slot clicked, that slot's position in the level arrray, the level array
        private void slotClick(PictureBox slot, PictureBox nextslot, Panel nextpanel, int slotnum, string[] list)
        {
            //checks if block is a type that takes up two spaces and applies function
            if (selectedRhythm == "taa" || selectedRhythm == "saa")
            {
                addDouble(slot, nextslot, nextpanel, slotnum, list);
            }
            else
            {
                //checks if the slot is taken up by a two slot box, if so, turn neighbor back to visible
                if (list[slotnum] == "taa" || list[slotnum] == "saa")
                {
                    nextpanel.Visible = true;
                    nextslot.Visible = true;
                    nextslot.BackColor = Color.Transparent;
                    nextpanel.BackColor = Color.Transparent;

                }
                //calling basic change function
                basicChange(slot, slotnum, list);
            }

        }

        //changes selected rhythm to a inputted type, finds path for cursor of that type, changes cursor to found cursor image
        private void buttonClick(string type)
        {
            selectedRhythm = type;
            string cursorPath = GetPath(type, "cursor");

            //resizing of cursor image so it matches required size and can be loaded, this was written by Chat GPT. Bitmaps are complicated and fiddly
            using (Bitmap bitmap = new Bitmap(cursorPath))
            {
                int newWidth = 32;
                int newHeight = 32;
                Bitmap resizedBitmap = new Bitmap(bitmap, new Size(newWidth, newHeight));
                IntPtr ptr = resizedBitmap.GetHicon();
                this.Cursor = new Cursor(ptr);
            }
        }

        //because these are linked to the form, they are a pain to move and thus are not very organized
        //logic for buttons, slots and covers clicked
        private void taButton_Click(object sender, EventArgs e)
        {
            buttonClick("ta");
        }
        private void fCover1_Click(object sender, EventArgs e)
        {
            slotClick(fSlot1, fSlot2, fCover2, 0, rhythmList);
        }
        private void fCover2_Click(object sender, EventArgs e)
        {
            slotClick(fSlot2, fSlot3, fCover3, 1, rhythmList);
        }
        private void fCover3_Click(object sender, EventArgs e)
        {
            slotClick(fSlot3, fSlot4, fCover4, 2, rhythmList);
        }
        private void fCover4_Click(object sender, EventArgs e)
        {
            slotClick(fSlot4, fSlot4, fCover4, 3, rhythmList);
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
            slotClick(fSlot1, fSlot2, fCover2, 0, rhythmList);
        }

        private void fSlot2_Click(object sender, EventArgs e)
        {
            slotClick(fSlot2, fSlot3, fCover3, 1, rhythmList);
        }

        private void fSlot3_Click(object sender, EventArgs e)
        {
            slotClick(fSlot3, fSlot4, fCover4, 2, rhythmList);
        }
        private void fSlot4_Click(object sender, EventArgs e)
        {
            slotClick(fSlot4, fSlot4, fCover4, 3, rhythmList);
        }



        private void oCover1_Click(object sender, EventArgs e)
        {
            slotClick(oSlot1, oSlot2, oCover2, 0, rhythmList1);
        }

        private void oSlot1_Click(object sender, EventArgs e)
        {
            slotClick(oSlot1, oSlot2, oCover2, 0, rhythmList1);
        }

        private void oSlot2_Click(object sender, EventArgs e)
        {
            slotClick(oSlot2, oSlot3, oCover3, 1, rhythmList1);
        }

        private void oCover2_Click(object sender, EventArgs e)
        {
            slotClick(oSlot2, oSlot3, oCover3, 1, rhythmList1);
        }

        private void oSlot4_Click(object sender, EventArgs e)
        {
            slotClick(oSlot4, oSlot4, oCover4, 3, rhythmList1);
        }

        private void oCover4_Click(object sender, EventArgs e)
        {
            slotClick(oSlot4, oSlot4, oCover4, 3, rhythmList1);
        }

        private void oSlot3_Click(object sender, EventArgs e)
        {
            slotClick(oSlot3, oSlot4, oCover4, 2, rhythmList1);
        }

        private void oCover3_Click(object sender, EventArgs e)
        {
            slotClick(oSlot3, oSlot4, oCover4, 2, rhythmList1);
        }


        private void tSlot1_Click(object sender, EventArgs e)
        {
            slotClick(tSlot1, tSlot2, tCover2, 0, rhythmList2);

        }

        private void tCover1_Click(object sender, EventArgs e)
        {
            slotClick(tSlot1, tSlot2, tCover2, 0, rhythmList2);
        }

        private void tSlot2_Click(object sender, EventArgs e)
        {
            slotClick(tSlot2, tSlot3, tCover3, 1, rhythmList2);
        }

        private void tSlot3_Click(object sender, EventArgs e)
        {
            slotClick(tSlot3, tSlot4, tCover4, 2, rhythmList2);
        }

        private void tSlot4_Click(object sender, EventArgs e)
        {
            slotClick(tSlot4, tSlot4, tCover4, 3, rhythmList2);
        }

        private void tCover2_Click(object sender, EventArgs e)
        {
            slotClick(tSlot2, tSlot3, tCover3, 1, rhythmList2);
        }

        private void tCover3_Click(object sender, EventArgs e)
        {
            slotClick(tSlot3, tSlot4, tCover4, 2, rhythmList2);
        }

        private void tCover4_Click(object sender, EventArgs e)
        {
            slotClick(tSlot4, tSlot4, tCover4, 3, rhythmList2);
        }

        private void taaButton1_Click(object sender, EventArgs e)
        {
            buttonClick("taa");
        }

        private void longRestButton1_Click(object sender, EventArgs e)
        {
            buttonClick("saa");
        }

        private void tikatikaButton2_Click(object sender, EventArgs e)
        {
            buttonClick("tikatika");
        }

        //stops blocks from other levels escaping to where they shouldn't be
        private void levelSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonClick("rest");
        }

        //resets values of array, changes pictureboxes to empty, turns picture boxes invisible
        private void clearButton_Click(object sender, EventArgs e)
        {
            rhythmList = ["rest", "rest", "rest", "rest"];
            fSlot1.Image = null;
            fSlot2.Image = null;
            fSlot3.Image = null;
            fSlot4.Image = null;
            fSlot1.Visible = false;
            fSlot2.Visible = false;
            fSlot3.Visible = false;
            fSlot4.Visible = false;

        }

        private void clearButton2_Click(object sender, EventArgs e)
        {
            rhythmList2 = ["rest", "rest", "rest", "rest"];
            tSlot1.Image = null;
            tSlot2.Image = null;
            tSlot3.Image = null;
            tSlot4.Image = null;
            tSlot1.Visible = false;
            tSlot2.Visible = false;
            tSlot3.Visible = false;
            tSlot4.Visible = false;
        }

        private void clearButton1_Click(object sender, EventArgs e)
        {
            rhythmList1 = ["rest", "rest", "rest", "rest"];
            oSlot1.Image = null;
            oSlot2.Image = null;
            oSlot3.Image = null;
            oSlot4.Image = null;
            oSlot1.Visible = false;
            oSlot2.Visible = false;
            oSlot3.Visible = false;
            oSlot4.Visible = false;
        }
    }
}
