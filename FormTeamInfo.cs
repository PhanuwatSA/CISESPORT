using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.DataFormats;
using System.Runtime.Serialization.Formatters.Binary;


namespace CISESPORT
{



    public partial class FormTeamInfo : Form
    {
        public DataGridView dataGridView1;

        FormAllPlayer formInfo = new FormAllPlayer();
        List<Player> listPlayer = new List<Player>();
        List<Team> listteam = new List<Team>();


        public FormTeamInfo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            using (FormAllPlayer FormAP = new FormAllPlayer())
            {
                FormAP.ShowDialog();

                if (!string.IsNullOrEmpty(FormAP.Name))
                {
                    string selectedData = FormAP.Name;
                    string selectedData2 = FormAP.LastName;

                    textBox1.Text = selectedData;
                    textBox6.Text = selectedData2;
                }
            }

        }



        private void button2_Click(object sender, EventArgs e)
        {
            using (FormAllPlayer FormAP = new FormAllPlayer())
            {
                FormAP.ShowDialog();

                if (!string.IsNullOrEmpty(FormAP.Name))
                {
                    string selectedData = FormAP.Name;
                    string selectedData2 = FormAP.LastName;

                    textBox2.Text = selectedData;
                    textBox7.Text = selectedData2;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (FormAllPlayer FormAP = new FormAllPlayer())
            {
                FormAP.ShowDialog();

                if (!string.IsNullOrEmpty(FormAP.Name))
                {
                    string selectedData = FormAP.Name;
                    string selectedData2 = FormAP.LastName;

                    textBox3.Text = selectedData;
                    textBox8.Text = selectedData2;
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (FormAllPlayer FormAP = new FormAllPlayer())
            {
                FormAP.ShowDialog();

                if (!string.IsNullOrEmpty(FormAP.Name))
                {
                    string selectedData = FormAP.Name;
                    string selectedData2 = FormAP.LastName;

                    textBox5.Text = selectedData;
                    textBox10.Text = selectedData2;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (FormAllPlayer FormAP = new FormAllPlayer())
            {
                FormAP.ShowDialog();

                if (!string.IsNullOrEmpty(FormAP.Name))
                {
                    string selectedData = FormAP.Name;
                    string selectedData2 = FormAP.LastName;

                    textBox4.Text = selectedData;
                    textBox9.Text = selectedData2;
                }
            }
        }
        private void AddRowToDataGridView(string column1Value, string column2Value, string column3Value)
        {
            DataGridViewRow Row = new DataGridViewRow();
            Row.CreateCells(dataGridView2);

            Row.Cells[0].Value = column1Value;
            Row.Cells[1].Value = column2Value;
            Row.Cells[2].Value = column3Value;
            // row.Cells[3].Value = column4Value;

            dataGridView2.Rows.Add(Row);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //แจ้งเตือนสำหรับกรรีที่กรอกข้อมูลไม่ครบ
            if (string.IsNullOrWhiteSpace(tbName.Text) || string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text)
                || string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(textBox4.Text) ||
                string.IsNullOrWhiteSpace(textBox5.Text) || string.IsNullOrWhiteSpace(textBox6.Text) || string.IsNullOrWhiteSpace(textBox7.Text)
                || string.IsNullOrWhiteSpace(textBox8.Text) || string.IsNullOrWhiteSpace(textBox9.Text) || string.IsNullOrWhiteSpace(textBox10.Text))
            {
                MessageBox.Show("กรุณาป้อนข้อมูลให้ครบ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {   //สำหรับเพิ่มข้อมูลไปยังdatagridviewเมื่อข้อมูลครบ
                string[] row = new string[] { tbName.Text, textBox1.Text, textBox6.Text };
                dataGridView2.Rows.Add(row);
                string[] row2 = new string[] { tbName.Text, textBox2.Text, textBox7.Text };
                dataGridView2.Rows.Add(row2);
                string[] row3 = new string[] { tbName.Text, textBox3.Text, textBox8.Text };
                dataGridView2.Rows.Add(row3);
                string[] row4 = new string[] { tbName.Text, textBox4.Text, textBox9.Text };
                dataGridView2.Rows.Add(row4);
                string[] row5 = new string[] { tbName.Text, textBox5.Text, textBox10.Text };
                dataGridView2.Rows.Add(row5);
            }
            //ล้างtextbox
            tbName.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();

        }

        private void saveFileToolStripMenuItem_Click(object sender, EventArgs e)
        {

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text File (*.txt)|*.txt";
            saveFileDialog.Title = "Save Data";
            saveFileDialog.FileName = "data.txt";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName);

                    // เขียนข้อมูลใน DataGridView เป็นบรรทัดของไฟล์
                    foreach (DataGridViewRow row in dataGridView2.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            string line = "";
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                line += cell.Value + "\t";
                            }
                            streamWriter.WriteLine(line.Trim());
                        }
                    }

                    streamWriter.Close();

                    MessageBox.Show("Data saved successfully.", "Save Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Save Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text File (*.txt)|*.txt";
            openFileDialog.Title = "Open Data";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StreamReader streamReader = new StreamReader(openFileDialog.FileName);

                    // ลบข้อมูลเดิมใน DataGridView
                    dataGridView2.Rows.Clear();

                    // อ่านข้อมูลจากไฟล์และเพิ่มลงใน DataGridView
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        string[] fields = line.Split('\t');
                        dataGridView2.Rows.Add(fields[0], fields[1], fields[2]);
                    }

                    streamReader.Close();

                    MessageBox.Show("Data opened successfully.", "Open Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Open Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FormTeamInfo_Load(object sender, EventArgs e)
        {
            dataGridView2.Columns.Add("Team", "Team");
            dataGridView2.Columns.Add("Name", "Name");
            dataGridView2.Columns.Add("LastNaame", "LastName");
        }
    }

}





