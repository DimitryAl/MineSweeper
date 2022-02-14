namespace MineSweeperGraphic
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            button1.Click += button1_Click;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Test");
        }
    }
}