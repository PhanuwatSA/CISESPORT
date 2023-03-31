namespace CISESPORT
{
    public partial class FormInfo : Form
    {
        private Player _newPlayer;
        
        public FormInfo()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string name = tbName.Text;
            string lastname = tbLastname.Text;
            string studentid = tbStudentID.Text;
            string mail = tbMail.Text;
            string phone = tbPhone.Text;
            string major = tbMajor.Text;
            string displayname = tbDisplayName.Text;
            int iAge = 0;
            try
            {
                string age = tbAge.Text;
                iAge = Int32.Parse(age);
            }
            catch (FormatException ex) { 
                //Do something if have some exception
                MessageBox.Show("โปรดป้อนตัวเลข");
                return;
            }

            _newPlayer = new Player(name,lastname,studentid,major,
                displayname,mail,phone,iAge);

            this.DialogResult = DialogResult.OK;           
        }
        public Player getPlayer() { return _newPlayer; }

        
    }
}