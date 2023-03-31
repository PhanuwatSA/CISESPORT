using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CISESPORT
{

    public partial class FormAllPlayer : Form
    {
        List<Player> listPlayer = new List<Player>();
        Player selectedPlayer;
        private Stream playerFilePath;

        public string Name { get; set; }
        public string LastName { get; set; }


        public FormAllPlayer()
        {
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            LoadData();
        }

        private void LoadData()
        {
            string path = "data.txt";
            if (File.Exists(path))
            {
                List<Player> players = new List<Player>();
                using (StreamReader reader = new StreamReader(path))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        string name = parts[0];
                        string lastname = parts[1];
                        string id = parts[2];
                        string major = parts[3];
                        string displayname = parts[4];
                        string mail = parts[5];
                        string phone = parts[6];
                        int age = int.Parse(parts[7]);
                        Player player = new Player(name, lastname, id, major, displayname, mail, phone, age);
                        players.Add(player);
                    }
                }
                dataGridView1.DataSource = players;
            }

        }

        private void newPlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormInfo formInfo = new FormInfo();
            formInfo.ShowDialog();

            if (formInfo.DialogResult == DialogResult.OK)
            {
                Player newPlayer = formInfo.getPlayer();
                //Add new Player to List
                this.listPlayer.Add(newPlayer);

                this.dataGridView1.DataSource = null;
                this.dataGridView1.DataSource = listPlayer;
                //Add list to Datagrid view
                formInfo.Close();
            }
        }

        private void saveFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "TEXT|*.txt|CSV|*.csv";
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != "")
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                    {
                        foreach (Player item in listPlayer)
                        {
                            writer.WriteLine(String.Format("{0},{1},{2},{3},{4},{5},{6},{7}",
                                item.Name,
                                item.Lastname,
                                item.ID,
                                item.Major,
                                item.Displayname,
                                item.Mail,
                                item.Phone,
                                item.Age));
                        }
                    }
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
            openFileDialog.Filter = "TEXT|*.txt|CSV|*.csv"; ;
            openFileDialog.ShowDialog();
            if (openFileDialog.FileName != "")
            {
                    List<Player> players = new List<Player>();
                    using (StreamReader reader = new StreamReader(openFileDialog.FileName))
                    {
                        string line = reader.ReadLine();
                        while (line != null)
                        {
                            string[] fields = line.Split(',');
                            string name = fields[0];
                            string lastname = fields[1];
                            string studentid = fields[2];
                            string major = fields[3];
                            string displayname = fields[4];
                            string mail = fields[5];
                            string phone = fields[6];
                            int age = int.Parse(fields[7]);
                            Player player = new Player(name, lastname, studentid, major, displayname, mail, phone, age);
                            players.Add(player);
                            line = reader.ReadLine();
                        }
                        this.dataGridView1.DataSource = players;
                        
                    }
                   

            }



        }

        public string SearchResult { get; set; }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {


            // ตรวจสอบว่ามีการเลือกข้อมูลใน DataGridView หรือไม่
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // อ่านค่าข้อมูลจาก DataGridView
                string name = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                string lastname = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();

                // กำหนดค่า Property SelectedData เพื่อส่งค่ากลับไปยัง Form1
                Name = name;
                LastName = lastname;

                // ปิด Form2
                this.Close();
            }
            else
            {
                MessageBox.Show("Please select a row.");
            }
        }

        private void FormAllPlayer_Load(object sender, EventArgs e)
        { 
           LoadData();
        }
        private void FormAllPlayer_FormClosing(object sender, FormClosingEventArgs e)
        {
           SaveData();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string[] lines = File.ReadAllLines("player.txt");
            foreach (string line in lines)
            {
                string[] values = line.Split(',');
                Player player = new Player(values[0], values[1], values[2], values[3],
                                           values[4], values[5], values[6], int.Parse(values[7]));
                listPlayer.Add(player);
            }
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = listPlayer;
        }

        private void existToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveData();
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string filePath = "path/to/players.txt"; // กำหนดเส้นทางของไฟล์ .txt ที่เก็บข้อมูลของผู้เล่น
            List<Player> players = new List<Player>(); // สร้าง List ของผู้เล่นเพื่อเก็บข้อมูลที่อ่านมาจากไฟล์

            if (File.Exists(filePath)) // ตรวจสอบว่าไฟล์ .txt นี้มีอยู่หรือไม่
            {
                string[] lines = File.ReadAllLines(filePath); // อ่านข้อมูลจากไฟล์ .txt และแบ่งเป็น array ของ strings โดยแต่ละ string คือข้อมูลของผู้เล่นที่อยู่ในแต่ละบรรทัดของไฟล์

                foreach (string line in lines.Skip(1)) // วนลูปผ่าน array ของ strings ที่มี index > 0 เพื่อข้ามบรรทัดแรกที่เป็น header
                {
                    string[] values = line.Split(','); // แยกข้อมูลของผู้เล่นแต่ละคนออกจากกันโดยใช้ตัวอักษร ',' เป็นตัวคั่น

                    string name = values[0];
                    string lastname = values[1];
                    string id = values[2];
                    string major = values[3];
                    string displayname = values[4];
                    string mail = values[5];
                    string phone = values[6];
                    int age = int.Parse(values[7]);

                    Player player = new Player(name, lastname, major, displayname, mail, phone, age);
                }
            }
        }

  
        private void SaveData()
        {
            string path = "data.txt";
            using (StreamWriter writer = new StreamWriter(path))
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow) //ตรวจสอบว่าไม่ใช่แถวใหม่
                    {
                        string name = row.Cells[0].Value.ToString();
                        string lastname = row.Cells[1].Value.ToString();
                        string id = row.Cells[2].Value.ToString();
                        string major = row.Cells[3].Value.ToString();
                        string displayname = row.Cells[4].Value.ToString();
                        string mail = row.Cells[5].Value.ToString();
                        string phone = row.Cells[6].Value.ToString();
                        int age = int.Parse(row.Cells[7].Value.ToString());
                        string line = string.Format("{0},{1},{2},{3},{4},{5},{6},{7}", name, lastname, id, major, displayname, mail, phone, age);
                        writer.WriteLine(line);
                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

            SaveData();
            MessageBox.Show("Saved successfully.");
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveData();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            // ตรวจสอบว่ามี Cell ที่ถูกเลือกใน DataGridView หรือไม่
            if (dataGridView1.SelectedCells.Count > 0)
            {
                // แสดง MessageBox เพื่อยืนยันการลบข้อมูล
                DialogResult result = MessageBox.Show("Are you sure you want to delete this cell?", "Confirmation", MessageBoxButtons.YesNo);

                // ถ้าตกลงลบข้อมูล
                if (result == DialogResult.Yes)
                {
                    // ลบ Cell ที่เลือกออกจาก DataGridView
                    dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[dataGridView1.SelectedCells[0].ColumnIndex].Value = null;
                }
            }
        }
    }
}