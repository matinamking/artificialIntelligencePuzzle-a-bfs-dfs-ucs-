using Pazel.createPazle;
using Pazel.movePazleMatrix;
using System.Text;

namespace Pazel
{
    public partial class Form1 : Form
    {
        public int[,] Pazle1 = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 0 } };
        public int[,] Pazle2 = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 0 } };
        public int counter = 0;
        public int sec = 0;
        public int min = 0;
        public int endCount;
        public int endTime;
        public bool result = false;
        public int[] location1 = new int[2];
        public int[] location2 = new int[2];
        List<Button> buttonsPazel1 = new List<Button>();
        List<Button> buttonsPazel2 = new List<Button>();
        Start pazle = new Start();
        moveMatrix move = new moveMatrix();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pazle.freList(buttonsPazel1, RandMatrix);
            pazle.frePazleControlerColor(buttonsPazel1, Pazle1);
            pazle.locationZero(Pazle1, location1);
        }
        public void start()
        {
            pazle.start(Pazle1, Pazle2, buttonsPazel2, AgentMatrix, location2);

            tik.Start();
            lbCounter.Text = (counter = 0).ToString();
            min = 0;
            sec = 0;

            AgentMatrix.Visible = true;
            labelCounter.Visible = true;
            labelTime.Visible = true;
            lbTime.Visible = true;
            lbCounter.Visible = true;
            panelLeftPazle.Visible = true;

            endCount = ((int)numCount.Value);
            endTime = ((int)numTime.Value);
        }

        private void rand_Click(object sender, EventArgs e)
        {
            start();
        }
        private void tik_Tick(object sender, EventArgs e)
        {
            if (sec == 60)
            {
                sec = 0;
                min++;
                if (endTime == min)
                {
                    MessageBox.Show("You Lose");
                    start();
                }
            }
            sec++;
            lbTime.Text = min.ToString() + ":" + sec.ToString();
        }
        private void btnUpL_Click(object sender, EventArgs e)
        {
            counter++;
            lbCounter.Text = counter.ToString();
            move.btnUp(location2, Pazle2, buttonsPazel2);
            if (move.result(Pazle1, Pazle2, counter, endCount)) start();
        }

        private void btnDownL_Click(object sender, EventArgs e)
        {
            counter++;
            lbCounter.Text = counter.ToString();
            move.btnDown(location2, Pazle2, buttonsPazel2);
            if (move.result(Pazle1, Pazle2, counter, endCount)) start();
        }

        private void btnRightL_Click(object sender, EventArgs e)
        {
            counter++;
            lbCounter.Text = counter.ToString();
            move.btnRight(location2, Pazle2, buttonsPazel2);
            if (move.result(Pazle1, Pazle2, counter, endCount)) start();
        }

        private void btnLeftL_Click(object sender, EventArgs e)
        {
            counter++;
            lbCounter.Text = counter.ToString();
            move.btnLeft(location2, Pazle2, buttonsPazel2);
            if (move.result(Pazle1, Pazle2, counter, endCount)) start();
        }

        private void btnUpR_Click(object sender, EventArgs e)
        {
            move.btnUp(location1, Pazle1, buttonsPazel1);
        }

        private void btnDownR_Click(object sender, EventArgs e)
        {
            move.btnDown(location1, Pazle1, buttonsPazel1);
        }

        private void btnRightR_Click(object sender, EventArgs e)
        {
            move.btnRight(location1, Pazle1, buttonsPazel1);
        }

        private void btnLeftR_Click(object sender, EventArgs e)
        {
            move.btnLeft(location1, Pazle1, buttonsPazel1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BFS bfs = new BFS(Pazle2, Pazle1, buttonsPazel2);
            bfs.SolveBFS();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DFS dfs = new DFS(Pazle2, Pazle1, buttonsPazel2);
            dfs.SolveDFS();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}