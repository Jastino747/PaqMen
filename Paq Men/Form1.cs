using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Windows.Input;
using WMPLib;

namespace Paq_Men
{

    public partial class FormPac : Form
    {

        List<PictureBox> listObstacle = new List<PictureBox>();
        List<PictureBox> listPac = new List<PictureBox>();
        List<PictureBox> listPellet = new List<PictureBox>();
        List<PictureBox> listPower = new List<PictureBox>();

        string status = "STOP";
        int powerTime = 0;
        string gameStatus = "NORMAL";

        string statusBlinky = "STOP";
        string statusClyde = "STOP";
        string statusInky = "STOP";
        string statusPinky = "STOP";

        List<PictureBox> listBlinky = new List<PictureBox>();
        List<PictureBox> listClyde = new List<PictureBox>();
        List<PictureBox> listInky = new List<PictureBox>();
        List<PictureBox> listPinky = new List<PictureBox>();

        Random randomKey = new Random();


        string resourcesPath = Application.StartupPath + "\\Resources\\";
        WindowsMediaPlayer loopSound = new WindowsMediaPlayer();

        public FormPac()
        {
            InitializeComponent();
        }

        private void GenerateObstacle (string type, int width, int height, int x, int y)
        {
            PictureBox pictObs = new PictureBox();
            pictObs.Size = new System.Drawing.Size(width, height);
            pictObs.Location = new Point(x, y);
            pictObs.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(type);
            listObstacle.Add(pictObs);
            this.Controls.Add(pictObs);
        }

        private void PelletGenerator (int x, int y)
        {
            PictureBox pictPell = new PictureBox();
            pictPell.Size = new System.Drawing.Size(8, 8);
            pictPell.Location = new Point(x, y);
            pictPell.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject("pellet");
            listPellet.Add(pictPell);
            this.Controls.Add(pictPell);
        }

        private void PowerGenerator (int x, int y)
        {
            PictureBox pictPow = new PictureBox();
            pictPow.Size = new System.Drawing.Size(20, 20);
            pictPow.Location = new Point(x, y);
            pictPow.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject("powerPellet");
            listPower.Add(pictPow);
            this.Controls.Add(pictPow);
        }

        private void GhostGenerator (int x, int y, string name, List<PictureBox> listPic, ref string status, string action)
        {
            PictureBox pictGhost = new PictureBox();
            pictGhost.Size = new System.Drawing.Size(36, 36);
            pictGhost.Location = new Point(x, y);
            pictGhost.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name);
            listPic.Add(pictGhost);
            this.Controls.Add(pictGhost);
            status = action;
        }

        private void FormPac_Load(object sender, EventArgs e)
        {
            this.Size = new Size(617, 836);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.CenterToScreen();

            loopSound.URL = resourcesPath + "TheFatRat - Less Than Three.mp3";
            loopSound.settings.setMode("loop", true);

            // Ghost Generator
            GhostGenerator(242, 362, "blinkyUp", listBlinky, ref statusBlinky, "UP");
            GhostGenerator(322, 362, "clydeUp", listClyde, ref statusClyde, "UP");
            GhostGenerator(222, 382, "inkyLeft", listInky, ref statusInky, "LEFT");
            GhostGenerator(342, 382, "pinkyRight", listPinky, ref statusPinky, "RIGHT");

            // Obstacle Generator
            GenerateObstacle("A", 80, 90, 40, 40);
            GenerateObstacle("A", 80, 90, 160, 40);
            GenerateObstacle("A", 80, 90, 40, 170);
            GenerateObstacle("A", 80, 90, 360, 40);
            GenerateObstacle("A", 80, 90, 480, 40);
            GenerateObstacle("A", 80, 90, 480, 170);
            GenerateObstacle("B", 40, 130, 280, 0);
            GenerateObstacle("C", 160, 90, 220, 170);
            GenerateObstacle("D", 20, 210, 160, 170);
            GenerateObstacle("D", 20, 210, 420, 170);
            GenerateObstacle("E", 40, 60, 280, 260);
            GenerateObstacle("F", 60, 20, 180, 300);
            GenerateObstacle("F", 60, 20, 360, 300);
            GenerateObstacle("G", 120, 80, 0, 300);
            GenerateObstacle("G", 120, 80, 0, 420);
            GenerateObstacle("G", 120, 80, 480, 300);
            GenerateObstacle("G", 120, 80, 480, 420);
            GenerateObstacle("H", 160, 80, 220, 360);
            GenerateObstacle("I", 20, 80, 160, 420);
            GenerateObstacle("I", 20, 80, 420, 420);
            GenerateObstacle("J", 160, 20, 220, 480);
            GenerateObstacle("K", 80, 50, 40, 540);
            GenerateObstacle("K", 80, 50, 160, 540);
            GenerateObstacle("K", 80, 50, 360, 540);
            GenerateObstacle("K", 80, 50, 480, 540);
            GenerateObstacle("L", 40, 90, 280, 500);
            GenerateObstacle("M", 60, 40, 0, 630);
            GenerateObstacle("M", 60, 40, 540, 630);
            GenerateObstacle("N", 20, 80, 100, 590);
            GenerateObstacle("N", 20, 80, 160, 630);
            GenerateObstacle("N", 20, 80, 420, 630);
            GenerateObstacle("N", 20, 80, 480, 590);
            GenerateObstacle("O", 160, 40, 220, 630);
            GenerateObstacle("P", 200, 50, 40, 710);
            GenerateObstacle("P", 200, 50, 360, 710);
            GenerateObstacle("Q", 40, 90, 280, 670);

            // Pellet Generator
            PelletGenerator(16,16); PelletGenerator(46,16); PelletGenerator(76,16); PelletGenerator(106,16); PelletGenerator(136,16); PelletGenerator(166,16); PelletGenerator(196,16); PelletGenerator(226,16); PelletGenerator(256,16);
            PelletGenerator(336,16); PelletGenerator(366,16); PelletGenerator(396,16); PelletGenerator(426,16); PelletGenerator(456,16); PelletGenerator(486,16); PelletGenerator(516,16); PelletGenerator(546,16); PelletGenerator(576,16);

            PelletGenerator(136, 56); PelletGenerator(256, 56); PelletGenerator(336, 56); PelletGenerator(456, 56);
            PelletGenerator(16, 106); PelletGenerator(136, 106); PelletGenerator(256, 106); PelletGenerator(336, 106); PelletGenerator(456, 106); PelletGenerator(576, 106);

            PelletGenerator(16, 146); PelletGenerator(46, 146); PelletGenerator(76, 146); PelletGenerator(106, 146); PelletGenerator(136, 146); PelletGenerator(166, 146); PelletGenerator(196, 146); PelletGenerator(226, 146); PelletGenerator(256, 146); PelletGenerator(296, 146);
            PelletGenerator(336, 146); PelletGenerator(366, 146); PelletGenerator(396, 146); PelletGenerator(426, 146); PelletGenerator(456, 146); PelletGenerator(486, 146); PelletGenerator(516, 146); PelletGenerator(546, 146); PelletGenerator(576, 146);

            PelletGenerator(16, 186); PelletGenerator(136, 186); PelletGenerator(196, 186); PelletGenerator(396, 186); PelletGenerator(456, 186); PelletGenerator(576, 186);
            PelletGenerator(16, 236); PelletGenerator(136, 236); PelletGenerator(196, 236); PelletGenerator(396, 236); PelletGenerator(456, 236); PelletGenerator(576, 236);

            PelletGenerator(16, 276); PelletGenerator(46, 276); PelletGenerator(76, 276); PelletGenerator(106, 276); PelletGenerator(136, 276); PelletGenerator(196, 276); PelletGenerator(226, 276); PelletGenerator(256, 276);
            PelletGenerator(336, 276); PelletGenerator(366, 276); PelletGenerator(396, 276); PelletGenerator(456, 276); PelletGenerator(486, 276); PelletGenerator(516, 276); PelletGenerator(546, 276); PelletGenerator(576, 276);

            PelletGenerator(136, 306); PelletGenerator(456, 306); PelletGenerator(136, 336); PelletGenerator(456, 336); PelletGenerator(136, 366); PelletGenerator(456, 366); PelletGenerator(136, 396); PelletGenerator(456, 396);
            PelletGenerator(136, 426); PelletGenerator(456, 426); PelletGenerator(136, 456); PelletGenerator(456, 456); PelletGenerator(136, 486); PelletGenerator(456, 486);

            PelletGenerator(16, 516); PelletGenerator(46, 516); PelletGenerator(76, 516); PelletGenerator(106, 516); PelletGenerator(136, 516); PelletGenerator(166, 516); PelletGenerator(196, 516); PelletGenerator(226, 516); PelletGenerator(256, 516);
            PelletGenerator(336, 516); PelletGenerator(366, 516); PelletGenerator(396, 516); PelletGenerator(426, 516); PelletGenerator(456, 516); PelletGenerator(486, 516); PelletGenerator(516, 516); PelletGenerator(546, 516); PelletGenerator(576, 516);

            PelletGenerator(16, 546); PelletGenerator(136, 546); PelletGenerator(256, 546); PelletGenerator(336, 546); PelletGenerator(456, 546); PelletGenerator(576, 546);
            PelletGenerator(136, 576); PelletGenerator(256, 576); PelletGenerator(336, 576); PelletGenerator(456, 576);

            PelletGenerator(16, 606); PelletGenerator(46, 606); PelletGenerator(76, 606); PelletGenerator(136, 606); PelletGenerator(166, 606); PelletGenerator(196, 606); PelletGenerator(226, 606); PelletGenerator(256, 606);
            PelletGenerator(336, 606); PelletGenerator(366, 606); PelletGenerator(396, 606); PelletGenerator(426, 606); PelletGenerator(456, 606); PelletGenerator(516, 606); PelletGenerator(546, 606); PelletGenerator(576, 606);

            PelletGenerator(76, 646); PelletGenerator(136, 646); PelletGenerator(196, 646); PelletGenerator(396, 646); PelletGenerator(456, 646); PelletGenerator(516, 646);

            PelletGenerator(16, 686); PelletGenerator(46, 686); PelletGenerator(76, 686); PelletGenerator(106, 686); PelletGenerator(136, 686); PelletGenerator(196, 686); PelletGenerator(226, 686); PelletGenerator(256, 686);
            PelletGenerator(336, 686); PelletGenerator(366, 686); PelletGenerator(396, 686); PelletGenerator(456, 686); PelletGenerator(486, 686); PelletGenerator(516, 686); PelletGenerator(546, 686); PelletGenerator(576, 686);

            PelletGenerator(16, 716); PelletGenerator(256, 716); PelletGenerator(336, 716); PelletGenerator(576, 716);
            PelletGenerator(16, 746); PelletGenerator(256, 746); PelletGenerator(336, 746); PelletGenerator(576, 746);

            PelletGenerator(16, 776); PelletGenerator(46, 776); PelletGenerator(76, 776); PelletGenerator(106, 776); PelletGenerator(136, 776); PelletGenerator(166, 776); PelletGenerator(196, 776); PelletGenerator(226, 776); PelletGenerator(256, 776); PelletGenerator(296, 776);
            PelletGenerator(336, 776); PelletGenerator(366, 776); PelletGenerator(396, 776); PelletGenerator(426, 776); PelletGenerator(456, 776); PelletGenerator(486, 776); PelletGenerator(516, 776); PelletGenerator(546, 776); PelletGenerator(576, 776);

            // PowerPellet Generator
            PowerGenerator(10,50); PowerGenerator(570,50); PowerGenerator(10,570); PowerGenerator(570,570);

            // Pac Generator
            PictureBox pictPac = new PictureBox();
            pictPac.Size = new System.Drawing.Size(36, 36);
            pictPac.Location = new Point(282, 592);
            pictPac.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject("PacLeft");
            listPac.Add(pictPac);
            this.Controls.Add(pictPac);

            

        } // Map Generator

        private void timerPacMove_Tick(object sender, EventArgs e)
        {
            // Intersect Scan
            for (int i = 0; i < listObstacle.Count; i++)
            {
                if (listPac[0].Bounds.IntersectsWith(listObstacle[i].Bounds))
                {
                    if (status == "UP")
                    {
                        listPac[0].Top += 1;
                    }
                    else if (status == "DOWN")
                    {
                        listPac[0].Top -= 1;
                    }
                    else if (status == "LEFT")
                    {
                        listPac[0].Left += 1;
                    }
                    else if (status == "RIGHT")
                    {
                        listPac[0].Left -= 1;
                    }
                    status = "STOP";
                }
            }

            // Status Scan
            if (status == "UP")
            {
                listPac[0].Top -= 1;
            }
            else if (status == "DOWN")
            {
                listPac[0].Top += 1;
            }
            else if (status == "LEFT")
            {
                listPac[0].Left -= 1;
            }
            else if (status == "RIGHT")
            {
                listPac[0].Left += 1;
            }
        } // Pac Movement n Obstacle Scan

        private void timerPacScan_Tick(object sender, EventArgs e)
        {
            // Analyze Form Bound
            if (listPac[0].Top <= 0)
            {
                listPac[0].Top++;
                status = "STOP";
            }
            else if (listPac[0].Left <= 0)
            {
                listPac[0].Left++;
                status = "STOP";
            }
            else if (listPac[0].Bottom >= this.ClientSize.Height)
            {
                listPac[0].Top--;
                status = "STOP";
            }
            else if (listPac[0].Right >= this.ClientSize.Width)
            {
                listPac[0].Left--;
                status = "STOP";
            }

            // Analyze Warp Point
            else if (listPac[0].Location.X > 560 && (listPac[0].Location.Y >= 379 && listPac[0].Location.Y <= 385))
            {
                listPac[0].Location = new Point(10, 382);
            }
            else if (listPac[0].Location.X < 4 && (listPac[0].Location.Y >= 379 && listPac[0].Location.Y <= 385))
            {
                listPac[0].Location = new Point(554, 382);
            }

            // Keyboard Scan
            else
            {
                bool inter = false;
                for (int i=0; i<listObstacle.Count;i++)
                {
                    if (listPac[0].Bounds.IntersectsWith(listObstacle[i].Bounds))
                    {
                        inter = true;
                    }
                }

                if (Keyboard.IsKeyDown(Key.Up) && listPac[0].Top > 0 && status != "UP" && inter == false)
                {
                    listPac[0].Image = Properties.Resources.PacUp;
                    status = "UP";
                    PacBreak();
                }
                else if (Keyboard.IsKeyDown(Key.Down) && listPac[0].Bottom < this.ClientSize.Height && status != "DOWN" && inter == false)
                {
                    listPac[0].Image = Properties.Resources.PacDown;
                    status = "DOWN";
                    PacBreak();
                }
                else if (Keyboard.IsKeyDown(Key.Left) && listPac[0].Left > 0 && status != "LEFT" && inter == false)
                {
                    listPac[0].Image = Properties.Resources.PacLeft;
                    status = "LEFT";
                    PacBreak();
                }
                else if (Keyboard.IsKeyDown(Key.Right) && listPac[0].Left < this.ClientSize.Width && status != "RIGHT" && inter == false)
                {
                    listPac[0].Image = Properties.Resources.PacRight;
                    status = "RIGHT";
                    PacBreak();
                }
            }
            
        } // Analyze Form n Keyboard Scan

        private void PacBreak ()
        {
            timerPacBreak.Enabled = true;
            timerPacScan.Enabled = false;
        }

        private void timerPacBreak_Tick(object sender, EventArgs e)
        {
            if (Keyboard.IsKeyUp(Key.Up) && Keyboard.IsKeyUp(Key.Down) && Keyboard.IsKeyUp(Key.Left) && Keyboard.IsKeyUp(Key.Right))
            {
                timerPacBreak.Enabled = false;
                timerPacScan.Enabled = true;
            }
        } // Keyboard Break

        private void timerPelletScan_Tick(object sender, EventArgs e)
        {
            for (int i=0;i<listPellet.Count;i++)
            {
                if (listPac[0].Bounds.IntersectsWith(listPellet[i].Bounds))
                {
                    listPellet[i].Dispose();
                    listPellet.RemoveAt(i);
                }
            }

            for (int j=0;j<listPower.Count;j++)
            {
                if (listPac[0].Bounds.IntersectsWith(listPower[j].Bounds))
                {
                    listPower[j].Dispose();
                    listPower.RemoveAt(j);

                    powerTime = 0;

                    timerBlinky.Interval = 30;
                    timerClyde.Interval = 30;
                    timerInky.Interval = 30;
                    timerPinky.Interval = 30;

                    listBlinky[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject("panicGhost");
                    listClyde[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject("panicGhost");
                    listInky[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject("panicGhost");
                    listPinky[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject("panicGhost");

                    gameStatus = "POWER";
                    timerPower.Enabled = true;
                }
            }

            if (gameStatus == "NORMAL")
            {
                if (listPac[0].Bounds.IntersectsWith(listBlinky[0].Bounds) || listPac[0].Bounds.IntersectsWith(listClyde[0].Bounds)
                    || listPac[0].Bounds.IntersectsWith(listInky[0].Bounds) || listPac[0].Bounds.IntersectsWith(listPinky[0].Bounds))
                {
                    this.Close();
                }
            }
            else if (gameStatus == "POWER")
            {
                if (listPac[0].Bounds.IntersectsWith(listBlinky[0].Bounds))
                {
                    statusBlinky = "STOP";
                    listBlinky[0].Location = new Point(242, 362);
                }
                else if (listPac[0].Bounds.IntersectsWith(listClyde[0].Bounds))
                {
                    statusClyde = "STOP";
                    listClyde[0].Location = new Point(322, 362);
                }
                else if (listPac[0].Bounds.IntersectsWith(listInky[0].Bounds))
                {
                    statusInky = "STOP";
                    listInky[0].Location = new Point(222, 382);
                }
                else if (listPac[0].Bounds.IntersectsWith(listPinky[0].Bounds))
                {
                    statusPinky = "STOP";
                    listPinky[0].Location = new Point(342, 382);
                }
            }

            if (listPower.Count == 0 && listPellet.Count == 0)
            {
                timerPelletScan.Stop();

                MessageBox.Show("YOU WON. CONGRATULATIONS");
                
                this.Close();
            }
        }

        private void CornerA (int x, int y, ref string status, List<PictureBox> listGhost, string name)
        {
            if (listGhost[0].Location.X == x && listGhost[0].Location.Y == y)
            {
                if (status == "UP")
                {
                    if (gameStatus == "NORMAL") listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject( name + "Right");
                    status = "RIGHT";
                }
                else if (status == "LEFT")
                {
                    if (gameStatus == "NORMAL") listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Down");
                    status = "DOWN";
                }
            }
        }
        private void CornerB(int x, int y, ref string status, List<PictureBox> listGhost, string name)
        {
            if (listGhost[0].Location.X == x && listGhost[0].Location.Y == y)
            {
                if (status == "UP")
                {
                    if (gameStatus == "NORMAL") listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Left");
                    status = "LEFT";
                }
                else if (status == "RIGHT")
                {
                    if (gameStatus == "NORMAL") listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Down");
                    status = "DOWN";
                }
            }
        }
        private void CornerC(int x, int y, ref string status, List<PictureBox> listGhost, string name)
        {
            if (listGhost[0].Location.X == x && listGhost[0].Location.Y == y)
            {
                if (status == "DOWN")
                {
                    if (gameStatus == "NORMAL") listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Left");
                    status = "LEFT";
                }
                else if (status == "RIGHT")
                {
                    if (gameStatus == "NORMAL") listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Up");
                    status = "UP";
                }
            }
        }
        private void CornerD(int x, int y, ref string status, List<PictureBox> listGhost, string name)
        {
            if (listGhost[0].Location.X == x && listGhost[0].Location.Y == y)
            {
                if (status == "DOWN")
                {
                    if (gameStatus == "NORMAL") listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Right");
                    status = "RIGHT";
                }
                else if (status == "LEFT")
                {
                    if (gameStatus == "NORMAL") listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Up");
                    status = "UP";
                }
            }
        }

        private void TjunctionE(int x, int y, ref string status, List<PictureBox> listGhost, string name)
        {
            if (listGhost[0].Location.X == x && listGhost[0].Location.Y == y)
            {
                int num = randomKey.Next(1, 9);
                if (status == "DOWN")
                {
                    if (num >= 1 && num <= 3)
                    {
                        listGhost[0].Left++;
                        if (gameStatus == "NORMAL") listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Right");
                        status = "RIGHT";
                    }
                    else if (num >= 4 && num <= 6)
                    {
                        listGhost[0].Left--;
                        if (gameStatus == "NORMAL") listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Left");
                        status = "LEFT";
                    }
                    else
                    {
                        if (listPac[0].Location.X >= listGhost[0].Location.X)
                        {
                            listGhost[0].Left++;
                            if (gameStatus == "NORMAL") listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Right");
                            status = "RIGHT";
                        }
                        else
                        {
                            listGhost[0].Left--;
                            if (gameStatus == "NORMAL") listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Left");
                            status = "LEFT";
                        }
                    }
                }
                else if (status == "LEFT")
                {
                    if (num >= 1 && num <= 3)
                    {
                        listGhost[0].Top--;
                        if (gameStatus == "NORMAL") listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Up");
                        status = "UP";
                    }
                    else if (num >= 4 && num <= 6)
                    {
                        listGhost[0].Left--;
                        if (gameStatus == "NORMAL") listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Left");
                        status = "LEFT";
                    }
                    else
                    {
                        if (listPac[0].Location.Y <= listGhost[0].Location.Y)
                        {
                            listGhost[0].Top--;
                            if (gameStatus == "NORMAL") listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Up");
                            status = "UP";
                        }
                        else
                        {
                            listGhost[0].Left--;
                            if (gameStatus == "NORMAL") listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Left");
                            status = "LEFT";
                        }
                    }
                }
                else if (status == "RIGHT")
                {
                    if (num >= 1 && num <= 3)
                    {
                        listGhost[0].Top--;
                        if (gameStatus == "NORMAL") listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Up");
                        status = "UP";
                    }
                    else if (num >= 4 && num <= 6)
                    {
                        listGhost[0].Left++;
                        if (gameStatus == "NORMAL") listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Right");
                        status = "RIGHT";
                    }
                    else
                    {
                        if (listPac[0].Location.Y <= listGhost[0].Location.Y)
                        {
                            listGhost[0].Top--;
                            if (gameStatus == "NORMAL") listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Up");
                            status = "UP";
                        }
                        else
                        {
                            listGhost[0].Left++;
                            if (gameStatus == "NORMAL") listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Right");
                            status = "RIGHT";
                        }
                    }
                }
            }
        }

        private void TjunctionF(int x, int y, ref string status, List<PictureBox> listGhost, string name)
        {
            if (listGhost[0].Location.X == x && listGhost[0].Location.Y == y)
            {
                int num = randomKey.Next(1, 9);
                if (status == "LEFT")
                {
                    if (num >= 1 && num <= 3)
                    {
                        listGhost[0].Top--;
                        if (gameStatus == "NORMAL") listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Up");
                        status = "UP";
                    }
                    else if (num >= 4 && num <= 6)
                    {
                        listGhost[0].Top++;
                        if (gameStatus == "NORMAL") listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Down");
                        status = "DOWN";
                    }
                    else
                    {
                        if (listPac[0].Location.Y >= listGhost[0].Location.Y)
                        {
                            listGhost[0].Top++;
                            if (gameStatus == "NORMAL") listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Down");
                            status = "DOWN";
                        }
                        else
                        {
                            listGhost[0].Top--;
                            if (gameStatus == "NORMAL") listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Up");
                            status = "UP";
                        }
                    }
                }
                else if (status == "UP")
                {
                    if (num >= 1 && num <= 3)
                    {
                        listGhost[0].Top--;
                        if (gameStatus == "NORMAL") listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Up");
                        status = "UP";
                    }
                    else if (num >= 4 && num <= 6)
                    {
                        listGhost[0].Left++;
                        if (gameStatus == "NORMAL") listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Right");
                        status = "RIGHT";
                    }
                    else
                    {
                        if (listPac[0].Location.X >= listGhost[0].Location.X)
                        {
                            listGhost[0].Left++;
                            if (gameStatus == "NORMAL") listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Right");
                            status = "RIGHT";
                        }
                        else
                        {
                            listGhost[0].Top--;
                            if (gameStatus == "NORMAL") listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Up");
                            status = "UP";
                        }
                    }
                }
                else if (status == "DOWN")
                {
                    if (num >= 1 && num <= 3)
                    {
                        listGhost[0].Top++;
                        if (gameStatus == "NORMAL") listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Down");
                        status = "DOWN";
                    }
                    else if (num >= 4 && num <= 6)
                    {
                        listGhost[0].Left++;
                        if (gameStatus == "NORMAL") listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Right");
                        status = "RIGHT";
                    }
                    else
                    {
                        if (listPac[0].Location.X >= listGhost[0].Location.X)
                        {
                            listGhost[0].Left++;
                            if (gameStatus == "NORMAL") listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Right");
                            status = "RIGHT";
                        }
                        else
                        {
                            listGhost[0].Top++;
                            if (gameStatus == "NORMAL") listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Down");
                            status = "DOWN";
                        }
                    }
                }
            }
        }

        private void TjunctionG (int x, int y, ref string status, List<PictureBox> listGhost, string name)
        {
            if (listGhost[0].Location.X == x && listGhost[0].Location.Y == y)
            {
                int num = randomKey.Next(1, 9);
                if (status == "UP")
                {
                    if (num >= 1 && num <= 3)
                    {
                        listGhost[0].Left++;
                        if (gameStatus == "NORMAL") listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Right");
                        status = "RIGHT";
                    }
                    else if (num >= 4 && num <= 6)
                    {
                        listGhost[0].Left--;
                        if (gameStatus == "NORMAL") listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Left");
                        status = "LEFT";
                    }
                    else
                    {
                        if (listPac[0].Location.X >= listGhost[0].Location.X)
                        {
                            listGhost[0].Left++;
                            if (gameStatus == "NORMAL") listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Right");
                            status = "RIGHT";
                        }
                        else
                        {
                            listGhost[0].Left--;
                            if (gameStatus == "NORMAL") listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Left");
                            status = "LEFT";
                        }
                    }
                }
                else if (status == "LEFT")
                {
                    if (num >= 1 && num <= 3)
                    {
                        listGhost[0].Top++;
                        if (gameStatus == "NORMAL") listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Down");
                        status = "DOWN";
                    }
                    else if (num >= 4 && num <= 6)
                    {
                        listGhost[0].Left--;
                        if (gameStatus == "NORMAL") listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Left");
                        status = "LEFT";
                    }
                    else
                    {
                        if (listPac[0].Location.Y >= listGhost[0].Location.Y)
                        {
                            listGhost[0].Top++;
                            if (gameStatus == "NORMAL") listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Down");
                            status = "DOWN";
                        }
                        else
                        {
                            listGhost[0].Left--;
                            if (gameStatus == "NORMAL") listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Left");
                            status = "LEFT";
                        }
                    }
                }
                else if (status == "RIGHT")
                {
                    if (num >= 1 && num <= 3)
                    {
                        listGhost[0].Top++;
                        if (gameStatus == "NORMAL") listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Down");
                        status = "DOWN";
                    }
                    else if (num >= 4 && num <= 6)
                    {
                        listGhost[0].Left++;
                        if (gameStatus == "NORMAL") listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Right");
                        status = "RIGHT";
                    }
                    else
                    {
                        if (listPac[0].Location.Y >= listGhost[0].Location.Y)
                        {
                            listGhost[0].Top++;
                            if (gameStatus == "NORMAL") listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Down");
                            status = "DOWN";
                        }
                        else
                        {
                            listGhost[0].Left++;
                            if (gameStatus == "NORMAL") listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Right");
                            status = "RIGHT";
                        }
                    }
                }
            }
        }

        private void TjunctionH(int x, int y, ref string status, List<PictureBox> listGhost, string name)
        {
            if (listGhost[0].Location.X == x && listGhost[0].Location.Y == y)
            {
                int num = randomKey.Next(1, 9);
                if (status == "RIGHT")
                {
                    if (num >= 1 && num <= 3)
                    {
                        listGhost[0].Top--;
                        if (gameStatus == "NORMAL") listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Up");
                        status = "UP";
                    }
                    else if (num >= 4 && num <= 6)
                    {
                        listGhost[0].Top++;
                        if (gameStatus == "NORMAL") listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Down");
                        status = "DOWN";
                    }
                    else
                    {
                        if (listPac[0].Location.Y >= listGhost[0].Location.Y)
                        {
                            listGhost[0].Top++;
                            if (gameStatus == "NORMAL") listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Down");
                            status = "DOWN";
                        }
                        else
                        {
                            listGhost[0].Top--;
                            if (gameStatus == "NORMAL") listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Up");
                            status = "UP";
                        }
                    }
                }
                else if (status == "UP")
                {
                    if (num >= 1 && num <= 3)
                    {
                        listGhost[0].Top--;
                        if (gameStatus == "NORMAL") listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Up");
                        status = "UP";
                    }
                    else if (num >= 4 && num <= 6)
                    {
                        listGhost[0].Left--;
                        if (gameStatus == "NORMAL") listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Left");
                        status = "LEFT";
                    }
                    else
                    {
                        if (listPac[0].Location.X <= listGhost[0].Location.X)
                        {
                            listGhost[0].Left--;
                            if (gameStatus == "NORMAL") listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Left");
                            status = "LEFT";
                        }
                        else
                        {
                            listGhost[0].Top--;
                            if (gameStatus == "NORMAL") listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Up");
                            status = "UP";
                        }
                    }
                }
                else if (status == "DOWN")
                {
                    if (num >= 1 && num <= 3)
                    {
                        listGhost[0].Top++;
                        if (gameStatus == "NORMAL") listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Down");
                        status = "DOWN";
                    }
                    else if (num >= 4 && num <= 6)
                    {
                        listGhost[0].Left--;
                        if (gameStatus == "NORMAL") listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Left");
                        status = "LEFT";
                    }
                    else
                    {
                        if (listPac[0].Location.X <= listGhost[0].Location.X)
                        {
                            listGhost[0].Left--;
                            if (gameStatus == "NORMAL") listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Left");
                            status = "LEFT";
                        }
                        else
                        {
                            listGhost[0].Top++;
                            if (gameStatus == "NORMAL") listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Down");
                            status = "DOWN";
                        }
                    }
                }
            }
        }

        private void Xjunction (int x, int y, ref string status, List<PictureBox> listGhost, string name)
        {
            if (listGhost[0].Location.X == x && listGhost[0].Location.Y == y)
            {
                int num = randomKey.Next(1, 12);
                if (status == "UP")
                {
                    if (num >= 1 && num <= 3)
                    {
                        listGhost[0].Top--;
                        if (gameStatus == "NORMAL") listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Up");
                        status = "UP";
                    }
                    else if (num >= 4 && num <= 6)
                    {
                        listGhost[0].Left--;
                        if (gameStatus == "NORMAL") listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Left");
                        status = "LEFT";
                    }
                    else if (num >= 7 && num <= 9)
                    {
                        listGhost[0].Left++;
                        if (gameStatus == "NORMAL") listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Right");
                        status = "RIGHT";
                    }
                    else
                    {
                        if ((listGhost[0].Location.Y - listPac[0].Location.Y) >= Math.Abs(listGhost[0].Location.X - listPac[0].Location.X))
                        {
                            listGhost[0].Top--;
                            if (gameStatus == "NORMAL") listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Up");
                            status = "UP";
                        }
                        else
                        {
                            if (listPac[0].Location.X <= listGhost[0].Location.X)
                            {
                                listGhost[0].Left--;
                                if (gameStatus == "NORMAL") listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Left");
                                status = "LEFT";
                            }
                            else
                            {
                                listGhost[0].Left++;
                                if (gameStatus == "NORMAL") listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Right");
                                status = "RIGHT";
                            }
                        }
                    }
                }
                else if (status == "DOWN")
                {
                    if (num >= 1 && num <= 3)
                    {
                        listGhost[0].Top++;
                        if (gameStatus == "NORMAL") listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Down");
                        status = "DOWN";
                    }
                    else if (num >= 4 && num <= 6)
                    {
                        listGhost[0].Left--;
                        if (gameStatus == "NORMAL") listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Left");
                        status = "LEFT";
                    }
                    else if (num >= 7 && num <= 9)
                    {
                        listGhost[0].Left++;
                        if (gameStatus == "NORMAL") listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Right");
                        status = "RIGHT";
                    }
                    else
                    {
                        if ((listPac[0].Location.Y - listGhost[0].Location.Y) >= Math.Abs(listGhost[0].Location.X - listPac[0].Location.X))
                        {
                            listGhost[0].Top++;
                            if (gameStatus == "NORMAL") listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Down");
                            status = "DOWN";
                        }
                        else
                        {
                            if (listPac[0].Location.X <= listGhost[0].Location.X)
                            {
                                listGhost[0].Left--;
                                if (gameStatus == "NORMAL") listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Left");
                                status = "LEFT";
                            }
                            else
                            {
                                listGhost[0].Left++;
                                if (gameStatus == "NORMAL") listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Right");
                                status = "RIGHT";
                            }
                        }
                    }
                }
                else if (status == "LEFT")
                {
                    if (num >= 1 && num <= 3)
                    {
                        listGhost[0].Left--;
                        if (gameStatus == "NORMAL") listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Left");
                        status = "LEFT";
                    }
                    else if (num >= 4 && num <= 6)
                    {
                        listGhost[0].Top--;
                        if (gameStatus == "NORMAL") listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Up");
                        status = "UP";
                    }
                    else if (num >= 7 && num <= 9)
                    {
                        listGhost[0].Top++;
                        if (gameStatus == "NORMAL") listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Down");
                        status = "DOWN";
                    }
                    else
                    {
                        if ((listGhost[0].Location.X - listPac[0].Location.X) >= Math.Abs(listGhost[0].Location.Y - listPac[0].Location.Y))
                        {
                            listGhost[0].Left--;
                            if (gameStatus == "NORMAL") listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Left");
                            status = "LEFT";
                        }
                        else
                        {
                            if (listPac[0].Location.Y <= listGhost[0].Location.Y)
                            {
                                listGhost[0].Top--;
                                if (gameStatus == "NORMAL") listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Up");
                                status = "UP";
                            }
                            else
                            {
                                listGhost[0].Top++;
                                if (gameStatus == "NORMAL") listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Down");
                                status = "DOWN";
                            }
                        }
                    }
                }
                else if (status == "RIGHT")
                {
                    if (num >= 1 && num <= 3)
                    {
                        listGhost[0].Left++;
                        if (gameStatus == "NORMAL") listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Right");
                        status = "RIGHT";
                    }
                    else if (num >= 4 && num <= 6)
                    {
                        listGhost[0].Top--;
                        if (gameStatus == "NORMAL") listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Up");
                        status = "UP";
                    }
                    else if (num >= 7 && num <= 9)
                    {
                        listGhost[0].Top++;
                        if (gameStatus == "NORMAL") listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Down");
                        status = "DOWN";
                    }
                    else
                    {
                        if ((listPac[0].Location.X - listGhost[0].Location.X) >= Math.Abs(listGhost[0].Location.Y - listPac[0].Location.Y))
                        {
                            listGhost[0].Left++;
                            if (gameStatus == "NORMAL") listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Right");
                            status = "RIGHT";
                        }
                        else
                        {
                            if (listPac[0].Location.Y <= listGhost[0].Location.Y)
                            {
                                listGhost[0].Top--;
                                if (gameStatus == "NORMAL") listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Up");
                                status = "UP";
                            }
                            else
                            {
                                listGhost[0].Top++;
                                if (gameStatus == "NORMAL") listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Down");
                                status = "DOWN";
                            }
                        }
                    }
                }
            }
        }

        private void ScanWarpA (List<PictureBox> listGhost)
        {
            if (listGhost[0].Location.X == 560 && listGhost[0].Location.Y == 382)
            {
                listGhost[0].Location = new Point(10, 382);
            }
        }
        private void ScanWarpB(List<PictureBox> listGhost)
        {
            if (listGhost[0].Location.X == 4 && listGhost[0].Location.Y == 382)
            {
                listGhost[0].Location = new Point(554, 382);
            }
        }

        private void SuddenTurn(List<PictureBox> listGhost, ref string status, string name)
        {
            int num = randomKey.Next(0,1000);
            if (num == 100)
            {
                if (status == "UP" && (listPac[0].Location.Y > listGhost[0].Location.Y))
                {
                    if (gameStatus == "NORMAL") listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Down");
                    status = "DOWN";
                }
                else if (status == "DOWN" && (listPac[0].Location.Y < listGhost[0].Location.Y))
                {
                    if (gameStatus == "NORMAL") listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Up");
                    status = "UP";
                }
                else if (status == "LEFT" && (listPac[0].Location.X > listGhost[0].Location.X))
                {
                    if (gameStatus == "NORMAL") listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Right");
                    status = "RIGHT";
                }
                else if (status == "RIGHT" && (listPac[0].Location.X < listGhost[0].Location.X))
                {
                    if (gameStatus == "NORMAL") listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Left");
                    status = "LEFT";
                }
            }
            else if (num == 200)
            {
                if (status == "UP")
                {
                    status = "DOWN";
                    if (gameStatus == "NORMAL")
                    {
                        listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Down");
                    }
                }
                else if (status == "DOWN")
                {
                    status = "UP";
                    if (gameStatus == "NORMAL")
                    {
                        listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Up");
                    }
                }
                else if (status == "RIGHT")
                {
                    status = "LEFT";
                    if (gameStatus == "NORMAL")
                    {
                        listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Left");
                    }
                }
                else if (status == "LEFT")
                {
                    status = "RIGHT";
                    if (gameStatus == "NORMAL")
                    {
                        listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Right");
                    }
                }
            }
        }

        private void ScanGhost(List<PictureBox> listGhost, ref string status, string name)
        {
            if (status == "UP") listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Up");
            else if (status == "DOWN") listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Down");
            else if (status == "LEFT") listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Left");
            else if (status == "RIGHT") listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Right");
        }

        private void SpecialScan (int x, int y, List<PictureBox> listGhost, ref string status, string name)
        {
            int num = randomKey.Next(1, 3);
            if (listGhost[0].Location.X == x && listGhost[0].Location.Y == y)
            {
                if (num == 1)
                {
                    listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Right");
                    status = "RIGHT";
                }
                else
                {
                    listGhost[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(name + "Left");
                    status = "LEFT";
                }
            }
        }

        private void timerBlinky_Tick(object sender, EventArgs e)
        {
            string text = "blinky";
            if (statusBlinky == "UP")
            {
                listBlinky[0].Top -= 1;
            }
            else if (statusBlinky == "DOWN")
            {
                listBlinky[0].Top += 1;
            }
            else if (statusBlinky == "LEFT")
            {
                listBlinky[0].Left -= 1;
            }
            else if (statusBlinky == "RIGHT")
            {
                listBlinky[0].Left += 1;
            }

            CornerA(2, 2, ref statusBlinky, listBlinky, text);
            CornerA(322, 2, ref statusBlinky, listBlinky, text);
            CornerA(322, 262, ref statusBlinky, listBlinky, text);
            CornerA(182, 322, ref statusBlinky, listBlinky, text);
            CornerA(2, 502, ref statusBlinky, listBlinky, text);
            CornerA(322, 502, ref statusBlinky, listBlinky, text);
            CornerA(502, 592, ref statusBlinky, listBlinky, text);
            CornerA(2, 672, ref statusBlinky, listBlinky, text);
            CornerA(322, 672, ref statusBlinky, listBlinky, text);

            CornerB(242, 2, ref statusBlinky, listBlinky, text);
            CornerB(562, 2, ref statusBlinky, listBlinky, text);
            CornerB(242, 262, ref statusBlinky, listBlinky, text);
            CornerB(382, 322, ref statusBlinky, listBlinky, text);
            CornerB(242, 502, ref statusBlinky, listBlinky, text);
            CornerB(562, 502, ref statusBlinky, listBlinky, text);
            CornerB(62, 592, ref statusBlinky, listBlinky, text);
            CornerB(242, 672, ref statusBlinky, listBlinky, text);
            CornerB(562, 672, ref statusBlinky, listBlinky, text);

            CornerC(382, 262, ref statusBlinky, listBlinky, text);
            CornerC(562, 262, ref statusBlinky, listBlinky, text);
            CornerC(562, 592, ref statusBlinky, listBlinky, text);
            CornerC(122, 672, ref statusBlinky, listBlinky, text);
            CornerC(382, 672, ref statusBlinky, listBlinky, text);
            CornerC(562, 762, ref statusBlinky, listBlinky, text);

            CornerD(2, 262, ref statusBlinky, listBlinky, text);
            CornerD(182, 262, ref statusBlinky, listBlinky, text);
            CornerD(2, 592, ref statusBlinky, listBlinky, text);
            CornerD(182, 672, ref statusBlinky, listBlinky, text);
            CornerD(442, 672, ref statusBlinky, listBlinky, text);
            CornerD(2, 762, ref statusBlinky, listBlinky, text);

            TjunctionE(242, 132, ref statusBlinky, listBlinky, text);
            TjunctionE(322, 132, ref statusBlinky, listBlinky, text);
            TjunctionE(242, 322, ref statusBlinky, listBlinky, text);
            TjunctionE(322, 322, ref statusBlinky, listBlinky, text);
            TjunctionE(182, 502, ref statusBlinky, listBlinky, text);
            TjunctionE(382, 502, ref statusBlinky, listBlinky, text);
            TjunctionE(242, 592, ref statusBlinky, listBlinky, text);
            TjunctionE(322, 592, ref statusBlinky, listBlinky, text);
            TjunctionE(62, 672, ref statusBlinky, listBlinky, text);
            TjunctionE(502, 672, ref statusBlinky, listBlinky, text);
            TjunctionE(242, 762, ref statusBlinky, listBlinky, text);
            TjunctionE(322, 762, ref statusBlinky, listBlinky, text);

            TjunctionF(2, 132, ref statusBlinky, listBlinky, text);
            TjunctionF(442, 262, ref statusBlinky, listBlinky, text);
            TjunctionF(382, 382, ref statusBlinky, listBlinky, text);
            TjunctionF(182, 442, ref statusBlinky, listBlinky, text);
            TjunctionF(122, 592, ref statusBlinky, listBlinky, text);

            TjunctionG(122, 2, ref statusBlinky, listBlinky, text);
            TjunctionG(442, 2, ref statusBlinky, listBlinky, text);
            TjunctionG(182, 132, ref statusBlinky, listBlinky, text);
            TjunctionG(382, 132, ref statusBlinky, listBlinky, text);
            TjunctionG(182, 592, ref statusBlinky, listBlinky, text);
            TjunctionG(382, 592, ref statusBlinky, listBlinky, text);

            TjunctionH(562, 132, ref statusBlinky, listBlinky, text);
            TjunctionH(122, 262, ref statusBlinky, listBlinky, text);
            TjunctionH(182, 382, ref statusBlinky, listBlinky, text);
            TjunctionH(382, 442, ref statusBlinky, listBlinky, text);
            TjunctionH(442, 592, ref statusBlinky, listBlinky, text);

            Xjunction(122, 132, ref statusBlinky, listBlinky, text);
            Xjunction(442, 132, ref statusBlinky, listBlinky, text);
            Xjunction(122, 382, ref statusBlinky, listBlinky, text);
            Xjunction(442, 382, ref statusBlinky, listBlinky, text);
            Xjunction(122, 502, ref statusBlinky, listBlinky, text);
            Xjunction(442, 502, ref statusBlinky, listBlinky, text);

            ScanWarpA(listBlinky); ScanWarpB(listBlinky);
            SpecialScan(242, 442, listBlinky, ref statusBlinky, "blinky"); 

            SuddenTurn(listBlinky, ref statusBlinky, "blinky");
        }

        private void timerClyde_Tick(object sender, EventArgs e)
        {
            string text = "clyde";
            if (statusClyde == "UP")
            {
                listClyde[0].Top -= 1;
            }
            else if (statusClyde == "DOWN")
            {
                listClyde[0].Top += 1;
            }
            else if (statusClyde == "LEFT")
            {
                listClyde[0].Left -= 1;
            }
            else if (statusClyde == "RIGHT")
            {
                listClyde[0].Left += 1;
            }
            // Correction Point
            CornerA(2, 2, ref statusClyde, listClyde, text);
            CornerA(322, 2, ref statusClyde, listClyde, text);
            CornerA(322, 262, ref statusClyde, listClyde, text);
            CornerA(182, 322, ref statusClyde, listClyde, text);
            CornerA(2, 502, ref statusClyde, listClyde, text);
            CornerA(322, 502, ref statusClyde, listClyde, text);
            CornerA(502, 592, ref statusClyde, listClyde, text);
            CornerA(2, 672, ref statusClyde, listClyde, text);
            CornerA(322, 672, ref statusClyde, listClyde, text);

            CornerB(242, 2, ref statusClyde, listClyde, text);
            CornerB(562, 2, ref statusClyde, listClyde, text);
            CornerB(242, 262, ref statusClyde, listClyde, text);
            CornerB(382, 322, ref statusClyde, listClyde, text);
            CornerB(242, 502, ref statusClyde, listClyde, text);
            CornerB(562, 502, ref statusClyde, listClyde, text);
            CornerB(62, 592, ref statusClyde, listClyde, text);
            CornerB(242, 672, ref statusClyde, listClyde, text);
            CornerB(562, 672, ref statusClyde, listClyde, text);

            CornerC(382, 262, ref statusClyde, listClyde, text);
            CornerC(562, 262, ref statusClyde, listClyde, text);
            CornerC(562, 592, ref statusClyde, listClyde, text);
            CornerC(122, 672, ref statusClyde, listClyde, text);
            CornerC(382, 672, ref statusClyde, listClyde, text);
            CornerC(562, 762, ref statusClyde, listClyde, text);

            CornerD(2, 262, ref statusClyde, listClyde, text);
            CornerD(182, 262, ref statusClyde, listClyde, text);
            CornerD(2, 592, ref statusClyde, listClyde, text);
            CornerD(182, 672, ref statusClyde, listClyde, text);
            CornerD(442, 672, ref statusClyde, listClyde, text);
            CornerD(2, 762, ref statusClyde, listClyde, text);

            TjunctionE(242, 132, ref statusClyde, listClyde, text);
            TjunctionE(322, 132, ref statusClyde, listClyde, text);
            TjunctionE(242, 322, ref statusClyde, listClyde, text);
            TjunctionE(322, 322, ref statusClyde, listClyde, text);
            TjunctionE(182, 502, ref statusClyde, listClyde, text);
            TjunctionE(382, 502, ref statusClyde, listClyde, text);
            TjunctionE(242, 592, ref statusClyde, listClyde, text);
            TjunctionE(322, 592, ref statusClyde, listClyde, text);
            TjunctionE(62, 672, ref statusClyde, listClyde, text);
            TjunctionE(502, 672, ref statusClyde, listClyde, text);
            TjunctionE(242, 762, ref statusClyde, listClyde, text);
            TjunctionE(322, 762, ref statusClyde, listClyde, text);

            TjunctionF(2, 132, ref statusClyde, listClyde, text);
            TjunctionF(442, 262, ref statusClyde, listClyde, text);
            TjunctionF(382, 382, ref statusClyde, listClyde, text);
            TjunctionF(182, 442, ref statusClyde, listClyde, text);
            TjunctionF(122, 592, ref statusClyde, listClyde, text);

            TjunctionG(122, 2, ref statusClyde, listClyde, text);
            TjunctionG(442, 2, ref statusClyde, listClyde, text);
            TjunctionG(182, 132, ref statusClyde, listClyde, text);
            TjunctionG(382, 132, ref statusClyde, listClyde, text);
            TjunctionG(182, 592, ref statusClyde, listClyde, text);
            TjunctionG(382, 592, ref statusClyde, listClyde, text);

            TjunctionH(562, 132, ref statusClyde, listClyde, text);
            TjunctionH(122, 262, ref statusClyde, listClyde, text);
            TjunctionH(182, 382, ref statusClyde, listClyde, text);
            TjunctionH(382, 442, ref statusClyde, listClyde, text);
            TjunctionH(442, 592, ref statusClyde, listClyde, text);

            Xjunction(122, 132, ref statusClyde, listClyde, text);
            Xjunction(442, 132, ref statusClyde, listClyde, text);
            Xjunction(122, 382, ref statusClyde, listClyde, text);
            Xjunction(442, 382, ref statusClyde, listClyde, text);
            Xjunction(122, 502, ref statusClyde, listClyde, text);
            Xjunction(442, 502, ref statusClyde, listClyde, text);

            ScanWarpA(listClyde); ScanWarpB(listClyde);
            SpecialScan(322 , 442 , listClyde, ref statusClyde, "clyde");

            SuddenTurn(listClyde, ref statusClyde, "clyde");
        }

        private void timerInky_Tick(object sender, EventArgs e)
        {
            string text = "inky";
            if (statusInky == "UP")
            {
                listInky[0].Top -= 1;
            }
            else if (statusInky == "DOWN")
            {
                listInky[0].Top += 1;
            }
            else if (statusInky == "LEFT")
            {
                listInky[0].Left -= 1;
            }
            else if (statusInky == "RIGHT")
            {
                listInky[0].Left += 1;
            }
            // Correction Point
            CornerA(2, 2, ref statusInky, listInky, text);
            CornerA(322, 2, ref statusInky, listInky, text);
            CornerA(322, 262, ref statusInky, listInky, text);
            CornerA(182, 322, ref statusInky, listInky, text);
            CornerA(2, 502, ref statusInky, listInky, text);
            CornerA(322, 502, ref statusInky, listInky, text);
            CornerA(502, 592, ref statusInky, listInky, text);
            CornerA(2, 672, ref statusInky, listInky, text);
            CornerA(322, 672, ref statusInky, listInky, text);

            CornerB(242, 2, ref statusInky, listInky, text);
            CornerB(562, 2, ref statusInky, listInky, text);
            CornerB(242, 262, ref statusInky, listInky, text);
            CornerB(382, 322, ref statusInky, listInky, text);
            CornerB(242, 502, ref statusInky, listInky, text);
            CornerB(562, 502, ref statusInky, listInky, text);
            CornerB(62, 592, ref statusInky, listInky, text);
            CornerB(242, 672, ref statusInky, listInky, text);
            CornerB(562, 672, ref statusInky, listInky, text);

            CornerC(382, 262, ref statusInky, listInky, text);
            CornerC(562, 262, ref statusInky, listInky, text);
            CornerC(562, 592, ref statusInky, listInky, text);
            CornerC(122, 672, ref statusInky, listInky, text);
            CornerC(382, 672, ref statusInky, listInky, text);
            CornerC(562, 762, ref statusInky, listInky, text);

            CornerD(2, 262, ref statusInky, listInky, text);
            CornerD(182, 262, ref statusInky, listInky, text);
            CornerD(2, 592, ref statusInky, listInky, text);
            CornerD(182, 672, ref statusInky, listInky, text);
            CornerD(442, 672, ref statusInky, listInky, text);
            CornerD(2, 762, ref statusInky, listInky, text);

            TjunctionE(242, 132, ref statusInky, listInky, text);
            TjunctionE(322, 132, ref statusInky, listInky, text);
            TjunctionE(242, 322, ref statusInky, listInky, text);
            TjunctionE(322, 322, ref statusInky, listInky, text);
            TjunctionE(182, 502, ref statusInky, listInky, text);
            TjunctionE(382, 502, ref statusInky, listInky, text);
            TjunctionE(242, 592, ref statusInky, listInky, text);
            TjunctionE(322, 592, ref statusInky, listInky, text);
            TjunctionE(62, 672, ref statusInky, listInky, text);
            TjunctionE(502, 672, ref statusInky, listInky, text);
            TjunctionE(242, 762, ref statusInky, listInky, text);
            TjunctionE(322, 762, ref statusInky, listInky, text);

            TjunctionF(2, 132, ref statusInky, listInky, text);
            TjunctionF(442, 262, ref statusInky, listInky, text);
            TjunctionF(382, 382, ref statusInky, listInky, text);
            TjunctionF(182, 442, ref statusInky, listInky, text);
            TjunctionF(122, 592, ref statusInky, listInky, text);

            TjunctionG(122, 2, ref statusInky, listInky, text);
            TjunctionG(442, 2, ref statusInky, listInky, text);
            TjunctionG(182, 132, ref statusInky, listInky, text);
            TjunctionG(382, 132, ref statusInky, listInky, text);
            TjunctionG(182, 592, ref statusInky, listInky, text);
            TjunctionG(382, 592, ref statusInky, listInky, text);

            TjunctionH(562, 132, ref statusInky, listInky, text);
            TjunctionH(122, 262, ref statusInky, listInky, text);
            TjunctionH(182, 382, ref statusInky, listInky, text);
            TjunctionH(382, 442, ref statusInky, listInky, text);
            TjunctionH(442, 592, ref statusInky, listInky, text);

            Xjunction(122, 132, ref statusInky, listInky, text);
            Xjunction(442, 132, ref statusInky, listInky, text);
            Xjunction(122, 382, ref statusInky, listInky, text);
            Xjunction(442, 382, ref statusInky, listInky, text);
            Xjunction(122, 502, ref statusInky, listInky, text);
            Xjunction(442, 502, ref statusInky, listInky, text);

            ScanWarpA(listInky); ScanWarpB(listInky);

            SuddenTurn(listInky, ref statusInky, "inky");
        }

        private void timerPinky_Tick(object sender, EventArgs e)
        {
            string text = "pinky";
            if (statusPinky == "UP")
            {
                listPinky[0].Top -= 1;
            }
            else if (statusPinky == "DOWN")
            {
                listPinky[0].Top += 1;
            }
            else if (statusPinky == "LEFT")
            {
                listPinky[0].Left -= 1;
            }
            else if (statusPinky == "RIGHT")
            {
                listPinky[0].Left += 1;
            }
            // Correction Point
            CornerA(2, 2, ref statusPinky, listPinky, text);
            CornerA(322, 2, ref statusPinky, listPinky, text);
            CornerA(322, 262, ref statusPinky, listPinky, text);
            CornerA(182, 322, ref statusPinky, listPinky, text);
            CornerA(2, 502, ref statusPinky, listPinky, text);
            CornerA(322, 502, ref statusPinky, listPinky, text);
            CornerA(502, 592, ref statusPinky, listPinky, text);
            CornerA(2, 672, ref statusPinky, listPinky, text);
            CornerA(322, 672, ref statusPinky, listPinky, text);

            CornerB(242, 2, ref statusPinky, listPinky, text);
            CornerB(562, 2, ref statusPinky, listPinky, text);
            CornerB(242, 262, ref statusPinky, listPinky, text);
            CornerB(382, 322, ref statusPinky, listPinky, text);
            CornerB(242, 502, ref statusPinky, listPinky, text);
            CornerB(562, 502, ref statusPinky, listPinky, text);
            CornerB(62, 592, ref statusPinky, listPinky, text);
            CornerB(242, 672, ref statusPinky, listPinky, text);
            CornerB(562, 672, ref statusPinky, listPinky, text);

            CornerC(382, 262, ref statusPinky, listPinky, text);
            CornerC(562, 262, ref statusPinky, listPinky, text);
            CornerC(562, 592, ref statusPinky, listPinky, text);
            CornerC(122, 672, ref statusPinky, listPinky, text);
            CornerC(382, 672, ref statusPinky, listPinky, text);
            CornerC(562, 762, ref statusPinky, listPinky, text);

            CornerD(2, 262, ref statusPinky, listPinky, text);
            CornerD(182, 262, ref statusPinky, listPinky, text);
            CornerD(2, 592, ref statusPinky, listPinky, text);
            CornerD(182, 672, ref statusPinky, listPinky, text);
            CornerD(442, 672, ref statusPinky, listPinky, text);
            CornerD(2, 762, ref statusPinky, listPinky, text);

            TjunctionE(242, 132, ref statusPinky, listPinky, text);
            TjunctionE(322, 132, ref statusPinky, listPinky, text);
            TjunctionE(242, 322, ref statusPinky, listPinky, text);
            TjunctionE(322, 322, ref statusPinky, listPinky, text);
            TjunctionE(182, 502, ref statusPinky, listPinky, text);
            TjunctionE(382, 502, ref statusPinky, listPinky, text);
            TjunctionE(242, 592, ref statusPinky, listPinky, text);
            TjunctionE(322, 592, ref statusPinky, listPinky, text);
            TjunctionE(62, 672, ref statusPinky, listPinky, text);
            TjunctionE(502, 672, ref statusPinky, listPinky, text);
            TjunctionE(242, 762, ref statusPinky, listPinky, text);
            TjunctionE(322, 762, ref statusPinky, listPinky, text);

            TjunctionF(2, 132, ref statusPinky, listPinky, text);
            TjunctionF(442, 262, ref statusPinky, listPinky, text);
            TjunctionF(382, 382, ref statusPinky, listPinky, text);
            TjunctionF(182, 442, ref statusPinky, listPinky, text);
            TjunctionF(122, 592, ref statusPinky, listPinky, text);

            TjunctionG(122, 2, ref statusPinky, listPinky, text);
            TjunctionG(442, 2, ref statusPinky, listPinky, text);
            TjunctionG(182, 132, ref statusPinky, listPinky, text);
            TjunctionG(382, 132, ref statusPinky, listPinky, text);
            TjunctionG(182, 592, ref statusPinky, listPinky, text);
            TjunctionG(382, 592, ref statusPinky, listPinky, text);

            TjunctionH(562, 132, ref statusPinky, listPinky, text);
            TjunctionH(122, 262, ref statusPinky, listPinky, text);
            TjunctionH(182, 382, ref statusPinky, listPinky, text);
            TjunctionH(382, 442, ref statusPinky, listPinky, text);
            TjunctionH(442, 592, ref statusPinky, listPinky, text);

            Xjunction(122, 132, ref statusPinky, listPinky, text);
            Xjunction(442, 132, ref statusPinky, listPinky, text);
            Xjunction(122, 382, ref statusPinky, listPinky, text);
            Xjunction(442, 382, ref statusPinky, listPinky, text);
            Xjunction(122, 502, ref statusPinky, listPinky, text);
            Xjunction(442, 502, ref statusPinky, listPinky, text);

            ScanWarpA(listPinky); ScanWarpB(listPinky);

            SuddenTurn(listPinky, ref statusClyde, "pinky");
        }

        private void timerPower_Tick(object sender, EventArgs e)
        {
            powerTime++;
            if (powerTime == 7)
            {
                listBlinky[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject("panicGhost2");
                listClyde[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject("panicGhost2");
                listInky[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject("panicGhost2");
                listPinky[0].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject("panicGhost2");
            }
            else if (powerTime == 10)
            {
                timerBlinky.Interval = 15;
                ScanGhost(listBlinky, ref statusBlinky, "blinky");
                timerClyde.Interval = 15;
                ScanGhost(listClyde, ref statusClyde, "clyde");
                timerInky.Interval = 15;
                ScanGhost(listInky, ref statusInky, "inky");
                timerPinky.Interval = 15;
                ScanGhost(listPinky, ref statusPinky, "pinky");

                timerPower.Enabled = false;

                gameStatus = "NORMAL";

                if (statusBlinky == "STOP")
                {
                    statusBlinky = "UP";
                    ScanGhost(listBlinky, ref statusBlinky, "blinky");
                }
                if (statusClyde == "STOP")
                {
                    statusClyde = "UP";
                    ScanGhost(listClyde, ref statusClyde, "clyde");
                }
                if (statusInky == "STOP")
                {
                    statusInky = "LEFT";
                    ScanGhost(listInky, ref statusInky, "inky");
                }
                if (statusPinky == "STOP")
                { 
                    statusPinky = "RIGHT";
                    ScanGhost(listPinky, ref statusPinky, "pinky");
                }
            }
        }
    }
}
