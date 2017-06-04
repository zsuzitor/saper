using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace saper1
{
     

    public partial class Form1 : Form
    {
        public int[,] osNOVNOI = new int[10,10];
        public bool[,] flagkibool = new bool[10, 10];
        public bool[,] okritaya = new bool[10, 10];
        //public int[] massBomb = new int[10];
        public List<int> massBomb = new List<int>();
        Random rand = new Random();
        public Form1()
        {
            InitializeComponent();
            pictureBox1_Click_1(null, null);



            //кусок для чисел

            /*for(int i=0;i<10;++i)
            {
                for(int a=0;a<10;++a)
                {
                    for(int b=0;b<8;++b)
                    {
                        osNOVNOI
                    }

                }

            }*/





        }

        public bool checkBomb(int a)
        {


           foreach(int i in massBomb)
            {
                if (i == a)
                    return true;
            }
            return false;



        }


        //клик правой
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            int a123 = massBomb[0];
            //if (e.Equals(MouseButtons.Left))
            int X = ((PictureBox)sender).Left;
            int Y = ((PictureBox)sender).Top;
            /* for (int i = 0; i < 10; ++i)
                 for (int b = 0; b < 10; ++b)
                     */
            //if (osNOVNOI[X, Y] == -1)
                  //  {
                      //  bool p = false; }
                        
                        if (((MouseEventArgs)e).Button== MouseButtons.Left)
                {

               

                if (osNOVNOI[X / 30, Y / 30] == -1)
                {
                    
                    for (int b = 0; b < 10; ++b)
                    {
                        
                            foreach (Control i in panel1.Controls)
                        {
                            PictureBox a = i as PictureBox;
                            if (a != null)
                            {
                                if(massBomb[b]%10==a.Left/30&& massBomb[b] / 10 == a.Top/30)
                                {
                                    a.Image = imageList1.Images[12];
                                }
                               
                            }
                        }


                    }



                        MessageBox.Show("LOOSE");
                    pictureBox1_Click_1(null, null);

                }
                else
                {
                    //сюда число которое будет появляться
                    okritaya[X / 30, Y / 30] = true;
                    ((PictureBox)sender).Image= imageList1.Images[osNOVNOI[X / 30, Y / 30 ]+3];
                }
            }
            else
            {
                if(!okritaya[X / 30, Y / 30])
                {

                
                //поменять картинку а не установить
                flagkibool[X / 30, Y / 30] = flagkibool[X / 30, Y / 30] ? false : true;
                if(flagkibool[X / 30, Y / 30])
                ((PictureBox)sender).Image = imageList1.Images[2];
                else
                    ((PictureBox)sender).Image = imageList1.Images[1];
                }
            }

        }




        private void pictureBox1_Click_1(object sender, EventArgs e)
        {//новая игра
            List<Control> massDelet = new List<Control>() ;
            foreach(Control i in panel1.Controls)
            {
                PictureBox a = i as PictureBox;
                if(a!=null)
                {
                    massDelet.Add(a);
                }
            }
            for(int i = massDelet.Count; i>0;--i)
            {
                massDelet[i-1].Dispose();

            }


            
            for (int i = 0; i < 10; ++i)
            {
                for (int a = 0; a < 10; ++a)
                {
                    PictureBox tecpic = new PictureBox();
                    tecpic.Image = imageList1.Images[1];
                    tecpic.Size = new Size(30, 30);

                    tecpic.MouseDown += pictureBox1_Click;

                    tecpic.Location = new Point(a * 30, i * 30);
                    panel1.Controls.Add(tecpic);
                }

            }
            for (int a = 0; a < 10; ++a)

                for (int b = 0; b < 10; ++b)
                    osNOVNOI[a, b] = 0;
            massBomb.Clear();
            while (massBomb.Count() != 10)
            {
                int bomba = rand.Next(0, 100);
                while (checkBomb(bomba))
                {
                    bomba = rand.Next(0, 100);
                }
                massBomb.Add(bomba);
                osNOVNOI[bomba % 10, bomba / 10] = -1;

            }

            
                

                    for (int i = 0; i < 10; ++i)
            {
                //massBomb[i]
                for (int a = massBomb[i] % 10 - 1; a <= massBomb[i] % 10 + 1; ++a)
                {
                    for (int b = massBomb[i] / 10 - 1; b <= massBomb[i] / 10 + 1; ++b)
                    {
                        try
                        {
                            if (osNOVNOI[a, b] != -1)
                                osNOVNOI[a, b] += 1;
                        }
                        catch
                        {

                        }
                    }
                }

            }


        }
    }
}


/*
if(e.Equals(MouseButtons.Left))
            {

                int X = ((PictureBox)sender).Left;
                int Y = ((PictureBox)sender).Top;

                if(osNOVNOI[X/30+1,Y/30+1]==-1)
                {
                    //this.Close();
                    // ((PictureBox)sender)
                    MessageBox.Show("LOOSE");
                    
                }
                else
                {
                    //сюда число которое будет появляться
                }
            }
            else
            {
                ((PictureBox)sender).Image = imageList1.Images[2];
            }


    */