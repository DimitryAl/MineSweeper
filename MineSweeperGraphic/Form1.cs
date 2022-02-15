namespace MineSweeperGraphic
{
    public partial class Form1 : Form
    {


        System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();
        const int N = 9;
        int mines = 10;
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

            Generator gen = new Generator(this, pictureBox1, 
                /*cells.GetUpperBound(0) + 1, cells.Length / (cells.GetUpperBound(0) + 1)*/N, N);
            gen.GenerateCells(ref cells);
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    MessageBox.Show("gencells\t" + Convert.ToString(cells[i, j].x) + "__-" +Convert.ToString(cells[i, j].y));
                    //MessageBox.Show("gencells\t" + Convert.ToString(cells[i, j].side));
                }
            }
            gen.GenerateBombs(mines, N, cells);
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    MessageBox.Show("genbombs\t" + Convert.ToString(cells[i, j].cell_state));
                }
            }
            gen.GenerateDigits(cells);

            button1.Enabled = false;
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
            if (!field_drawn)
            {
                return;
            }
            Cell cell = new();

            for (int i=0; i<N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    MessageBox.Show("msclick\t"+Convert.ToString(cells[i, j].x) + Convert.ToString(cells[i, j].y));
                }
            }

            int res = cell.FindCell(this, cells, e, N, ref mines);
            if (res == 0)
            {
                MessageBox.Show("You died!");
            }
            else if (res == -1)
            {
                MessageBox.Show("restart program!");
            }
            else
            {
                MessageBox.Show("Nice!");
            }
        }

    }
}