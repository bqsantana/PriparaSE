namespace PriparaSE
{
    public partial class Form1 : Form
    {
        Stream openedFile;
        MemoryStream workFile;
        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (openedFile = openFileDialog1.OpenFile())
                    {
                        workFile = new MemoryStream();
                        openedFile.Seek(0, SeekOrigin.Begin);
                        openedFile.CopyTo(workFile);

                        SaveFile saveFile = new SaveFile();
                        saveFile.mapSaveFile(openedFile);

                    }
                }

                catch 
                {

                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}