using System.IO;
using System.Text;

namespace Final_Project_Assignment
{
    public partial class Form1 : Form
    {
        public Font SnamDeklenchaya { get; private set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "CSV (*.csv) | *.csv";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string[] readAlline = File.ReadAllLines(ofd.FileName);

                string readAllText = File.ReadAllText(ofd.FileName);
                for (int i = 0; i < readAlline.Length; i++)
                {
                    string allDATARAW = readAlline[i];
                    string[] allDATASplited = allDATARAW.Split(',');
                    this.dataGridView1.Rows.Add(allDATASplited[0], allDATASplited[1], allDATASplited[2], allDATASplited[3], allDATASplited[4], allDATASplited[5], allDATASplited[6], allDATASplited[7]);

                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Code = textBoxcode.Text;
            string Day = textBoxday.Text;
            string List = textBoxlist.Text;
            string Price = textBoxprice.Text;
            string textbox1 = textBox1.Text;
            string Pod = comboBox1.Text;
            string Eliquid = comboBox2.Text;
            string Accessories = comboBox3.Text;

            int n = dataGridView1.Rows.Add();
            dataGridView1.Rows[n].Cells[0].Value = textBoxcode.Text;
            dataGridView1.Rows[n].Cells[1].Value = textBoxday.Text;
            dataGridView1.Rows[n].Cells[2].Value = textBoxlist.Text;
            dataGridView1.Rows[n].Cells[3].Value = textBoxprice.Text;
            dataGridView1.Rows[n].Cells[4].Value = textBox1.Text;

            if (Pod == "Smok")
            {
                Pod pod = new Pod();
                pod.Smok = Pod;
                dataGridView1.Rows[n].Cells[5].Value = pod.Smok;
            }
            if (Pod == "Vopoo")
            {
                Pod pod = new Pod();
                pod.Vopoo = Pod;
                dataGridView1.Rows[n].Cells[5].Value = pod.Vopoo;
            }
            if (Pod == "Smoant")
            {
                Pod pod = new Pod();
                pod.Smoant = Pod;
                dataGridView1.Rows[n].Cells[5].Value = pod.Smoant;
            }
            if (Pod == "Relx")
            {
                Pod pod = new Pod();
                pod.Relx = Pod;
                dataGridView1.Rows[n].Cells[5].Value = pod.Relx;
            }

            if (Eliquid == "Allgrape")
            {
                Eliquid eliquid = new Eliquid();
                eliquid.Allgrape = Eliquid;
                dataGridView1.Rows[n].Cells[6].Value = eliquid.Allgrape;
            }
            if (Eliquid == "Punthai")
            {
                Eliquid eliquid = new Eliquid();
                eliquid.Punthai = Eliquid;
                dataGridView1.Rows[n].Cells[6].Value = eliquid.Punthai;
            }
            if (Eliquid == "Playmore")
            {
                Eliquid eliquid = new Eliquid();
                eliquid.Playmore = Eliquid;
                dataGridView1.Rows[n].Cells[6].Value = eliquid.Playmore;
            }
            if (Eliquid == "Marbo")
            {
                Eliquid eliquid = new Eliquid();
                eliquid.Marbo = Eliquid;
                dataGridView1.Rows[n].Cells[6].Value = eliquid.Marbo;
            }
            if (Accessories == "Coil")
            {
                Accessories accessorie = new Accessories();
                accessorie.Coil = Accessories;
                dataGridView1.Rows[n].Cells[7].Value = accessorie.Coil;
            }
            if (Accessories == "Cotton")
            {
                Accessories accessorie = new Accessories();
                accessorie.Cotton = Accessories;
                dataGridView1.Rows[n].Cells[7].Value = accessorie.Cotton;
            }
            if (Accessories == "Vapcelll")
            {
                Accessories accessorie = new Accessories();
                accessorie.Vapcelll = Accessories;
                dataGridView1.Rows[n].Cells[7].Value = accessorie.Vapcelll;
            }
            if (Accessories == "Wire")
            {
                Accessories accessorie = new Accessories();
                accessorie.Wire = Accessories;
                dataGridView1.Rows[n].Cells[7].Value = accessorie.Wire;
            }


            dataGridView1.Rows[n].Cells[0].Value = Code;
            dataGridView1.Rows[n].Cells[1].Value = Day;
            dataGridView1.Rows[n].Cells[2].Value = List;
            dataGridView1.Rows[n].Cells[3].Value = Price;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "CSV(*.csv)|*.csv";
                bool fileError = false;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (!fileError)
                    {
                        try
                        {
                            int columnCount = dataGridView1.Columns.Count;
                            string column = "";
                            string[] outputCSV = new string[dataGridView1.Rows.Count + 1];
                            for (int i = 0; i < columnCount; i++)
                            {
                                column += dataGridView1.Columns[i].HeaderText.ToString() + ",";
                            }
                            outputCSV[0] += column;
                            for (int i = 1; (i - 1) < dataGridView1.Rows.Count; i++)
                            {
                                for (int j = 0; j < columnCount; j++)
                                {
                                    outputCSV[i] += dataGridView1.Rows[i - 1].Cells[j].Value.ToString() + ",";
                                }
                            }

                            File.WriteAllLines(saveFileDialog.FileName, outputCSV, Encoding.UTF8);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error :" + ex.Message);
                        }
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("ใบเสร็จ", new Font("SnamDeklenchaya", 20, FontStyle.Underline), Brushes.Red, new Point(370, 100));
            e.Graphics.DrawString("---------------------------------------------------------------------", new Font("Arial", 16, FontStyle.Regular), Brushes.Black, new Point(100, 150));
            e.Graphics.DrawString("ยี่ห้อของ ;" + comboBox1.Text, new Font("SnamDeklenchaya", 16, FontStyle.Regular), Brushes.Black, new Point(100, 200));
            e.Graphics.DrawString("น้ำยา ; " + comboBox2.Text, new Font("SnamDeklenchaya", 16, FontStyle.Regular), Brushes.Black, new Point(100, 250));
            e.Graphics.DrawString("อุปกรณ์เสริม ; " + comboBox3.Text, new Font("SnamDeklenchaya", 16, FontStyle.Regular), Brushes.Black, new Point(100, 300));
            e.Graphics.DrawString("ราคา ;" + textBoxprice.Text, new Font("SnamDeklenchaya", 16, FontStyle.Regular), Brushes.Black, new Point(100, 350));
            e.Graphics.DrawString("---------------------------------------------------------------------", new Font("Arial", 16, FontStyle.Regular), Brushes.Black, new Point(100, 500));
        }
    }
}             