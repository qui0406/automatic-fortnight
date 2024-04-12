using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DuaXeThuVat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Random rand = new Random();

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int dx1= rand.Next(5, 10);
            int dx2 = rand.Next(5, 10);
            int dx3 = rand.Next(5, 10);

            if(picChuot.Left <= panel1.Right- picChuot.Width)
            {
                double second = 0.1;
                double tmp = Double.Parse(lbTime1.Text);
                tmp+=second;
                lbTime1.Text=tmp.ToString();
                picChuot.Left +=dx1;
            }
            if(picMeo.Left <= panel2.Right-picMeo.Width)
            {
                double second = 0.1;
                double tmp = Double.Parse(lbTime2.Text);
                tmp+=second;
                lbTime2.Text=tmp.ToString();
                picMeo.Left+=dx2;
            }
            if(picCho.Left <=panel3.Right - picCho.Width)
            {
                double second = 0.1;
                double tmp = Double.Parse(lbTime3.Text);
                tmp+=second;
                lbTime3.Text=tmp.ToString();
                picCho.Left+=dx3;
            }
            if(picChuot.Left>=panel1.Right-picChuot.Width && picMeo.Left >= panel2.Left -picMeo.Width &&
                picCho.Left >= panel3.Right- picCho.Width)
            {
                xepHang();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled=false;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            timer1.Enabled=true;
        }

        private void resetCuocDua()
        {
            timer1.Enabled=false;
            picChuot.Left=0;
            picMeo.Left=0;
            picCho.Left=0;
            lbTime1.Text="0.0";
            lbTime2.Text="0.0";
            lbTime3.Text="0.0";
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            resetCuocDua();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timer1.Enabled=false;
        }

        private void xepHang()
        {
            String tmp = "";
            double[] arrSX = { Double.Parse(lbTime1.Text), Double.Parse(lbTime2.Text), Double.Parse(lbTime3.Text) };
            double[] arrTmp = new double[arrSX.Length];
            Array.Copy(arrSX, arrTmp, arrSX.Length);
            Array.Sort(arrTmp);
            for(int i=0; i<arrSX.Length; i++)
            {
                
                if (arrSX[i]==arrTmp[0])
                {
                    tmp+=(i+1).ToString()+" ";
                }
               
            }
            lbWin.Text="Racer "+tmp+ "Win\n";
        }

        Point p1 = new Point();
        Point p2 = new Point();
        Point p3 = new Point();
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            p1=e.Location;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button==MouseButtons.Left)
            {
                int dx = e.X - p1.X;
                int dy = e.Y- p1.Y;
                panel1.Left+=dx;
                panel1.Top+=dy;
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            p2=e.Location;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button==MouseButtons.Left)
            {
                int dx = e.X- p2.X;
                int dy = e.Y -p2.Y;
                panel2.Left+=dx;
                panel2.Top+=dy;
            }
        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            p3=e.Location;
        }

        private void panel3_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button==MouseButtons.Left)
            {
                int dx = e.X- p3.X;
                int dy = e.Y -p3.Y;
                panel3.Left+=dx;
                panel3.Top+=dy;
            }
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Control | Keys.S:
                    timer1.Enabled=true;
                    return true;
                case Keys.Control | Keys.R:
                    resetCuocDua();
                    return true;
            }
            return base.ProcessDialogKey(keyData);
        }
    }
}
