namespace ArquitecturaHilo
{
    public partial class Form1 : Form
    {
        bool avanza;
        private Mutex exclusion= new Mutex();
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls= false;
        }
        private void iniciaHilos()
        {
            Thread SemA = new Thread(new ThreadStart(cambiarColor));
            SemA.Name = "H1";
            SemA.Start();
            Thread SemB = new Thread(new ThreadStart(cambiarColor));
            SemB.Name = "H2";
            SemB.Start();
            
        }
        private void cambiarColor() {
            int r, g, b;
            while (true)
            { 
               
                switch (Thread.CurrentThread.Name) {
                    case "H1":
                        exclusion.WaitOne();
                        avanza = false;
                        pictureBox1.BackColor = Color.White;
                        pictureBox2.BackColor = Color.White;
                        pictureBox3.BackColor = Color.Green;
                        pictureBox4.BackColor = Color.Red;
                        pictureBox5.BackColor = Color.White;
                        pictureBox6.BackColor = Color.White;
                        for (int i = 0; i<6 ;i++) {
                            pictureBox2.BackColor = Color.Yellow;
                                Thread.Sleep(500);
                            pictureBox2.BackColor = Color.White;
                            Thread.Sleep(500);

                        }
                        //Thread.Sleep(1000);
                        exclusion.ReleaseMutex();
                        break;
                    case "H2":
                        exclusion.WaitOne();
                        avanza = false;
                        pictureBox1.BackColor = Color.Red;
                        pictureBox2.BackColor = Color.White;
                        pictureBox3.BackColor = Color.White;
                        pictureBox4.BackColor = Color.White;
                        pictureBox5.BackColor = Color.White;
                        pictureBox6.BackColor = Color.Green;
                        for (int i = 0; i < 6; i++)
                        {
                            pictureBox2.BackColor = Color.Yellow;
                            Thread.Sleep(500);
                            pictureBox2.BackColor = Color.White;
                            Thread.Sleep(500);

                        }
                        //Thread.Sleep(1000);
                        exclusion.ReleaseMutex();
                        break;
                   
                }
               
                Thread.Sleep(1000);
           }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            avanza = true;
            iniciaHilos();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}