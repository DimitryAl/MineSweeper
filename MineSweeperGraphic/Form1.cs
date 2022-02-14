namespace MineSweeperGraphic
{
    public partial class Form1 : Form
    {
        System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();
        const int N = 9;

        public Form1()
        {
            InitializeComponent();
            
            //UpdateTime();
            //DrawField();

            button1.Click += button1_Click;
        }

        private void UpdateTime()
        {
            label1.Text = GetTimeString(stopWatch.Elapsed);
        }

        internal void DrawField()
        {
            Pen pen = new Pen(Color.Black, 1);
            Graphics picturebox1 = Graphics.FromHwnd(pictureBox1.Handle);
            
            int cell_width = pictureBox1.Width / 9;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    picturebox1.DrawRectangle(pen, cell_width * j, cell_width * i, cell_width, cell_width);
                }
            }
        }

        private string GetTimeString(TimeSpan elapsed)
        {
            string timeString = string.Empty;

            timeString = string.Format("{0:00}:{1:00}:{2:00}.{3:000}",
                elapsed.Hours,
                elapsed.Minutes,
                elapsed.Seconds,
                elapsed.Milliseconds
                );

            return timeString;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;

            stopWatch.Start();

            DrawField();


            //MessageBox.Show("btn1");

            //label1.Text = stopWatch.Elapsed.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("btn2");

            Form2 leaderboard1 = new Form2();
            leaderboard1.Show();
        }

        private void timer1_tick(object sender, EventArgs e)
        {
            UpdateTime();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {

            int f_x = this.Location.X;
            int f_y = this.Location.Y;
            int c_x = Cursor.Position.X;
            int c_y = Cursor.Position.Y;
            int p_x = pictureBox1.Location.X;
            int p_y = pictureBox1.Location.Y;

            MessageBox.Show(Convert.ToString(f_x) + "   " + Convert.ToString(f_y) + "   " + Convert.ToString(c_x) + "   " + Convert.ToString(c_y) + "   " + Convert.ToString(p_x) + "   " + Convert.ToString(p_y));

            //if (c_x - magicNumber > p_x && c_x - magicNumber < p_x + pictureBox1.Width && c_y - magicNumber > p_y && c_y - magicNumber < p_y + pictureBox1.Height)
            //if (c_x - f_x > p_x && c_x - f_x < p_x + pictureBox1.Width)
            {
                if (e.Button == MouseButtons.Right)
                {
                    MessageBox.Show("right");
                }
                if (e.Button == MouseButtons.Left)
                {
                    MessageBox.Show("left");
                }
            }
            else
            {
               // MessageBox.Show(Convert.ToString(Cursor.Position.X-magicNumber));
            }
        }
    }
}