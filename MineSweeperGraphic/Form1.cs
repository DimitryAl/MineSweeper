namespace MineSweeperGraphic
{
    public partial class Form1 : Form
    {
        

        System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();
        const int N = 9;
        const int qnt = 10;
        bool field_drawn = false;
        Cell[,] cells = new Cell[N, N];

        public Form1()
        {
            InitializeComponent();

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
            
            int cell_side = pictureBox1.Width / 9;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    picturebox1.DrawRectangle(pen, cell_side * j, cell_side * i, cell_side, cell_side);
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
            field_drawn = true;
            
            Generator gen = new Generator(this, pictureBox1, cells.GetUpperBound(0) + 1, cells.Length / (cells.GetUpperBound(0) + 1));
            gen.GenerateCells(cells);
            gen.GenerateBombs(qnt, N, cells);
            gen.GenerateDigits(cells);
            for (int i = 0;i < N;i++)
            {
                MessageBox.Show(Convert.ToString(cells[i, 0].number));
            }

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

            //int f_x = this.Location.X;
            //int f_y = this.Location.Y;
            //int c_x = Cursor.Position.X;
            //int c_y = Cursor.Position.Y;
            //int p_x = pictureBox1.Location.X + 10;
            //int p_y = pictureBox1.Location.Y + 30;
            //int cell_side = pictureBox1.Width / 9;
            
            //if (field_drawn)
            //{
            //    if (c_x - f_x > p_x && c_x - f_x < p_x + cell_side && c_y - f_y > p_y && c_y - f_y < p_y + cell_side)
            //    {
            //        if (e.Button == MouseButtons.Right)
            //        {
            //            MessageBox.Show("right");
            //        }
            //        if (e.Button == MouseButtons.Left)
            //        {
            //            MessageBox.Show("left");
            //        }
            //    }
            //    else
            //    {
            //        // MessageBox.Show(Convert.ToString(Cursor.Position.X-magicNumber));
            //    }
            //}

        }

    }
}