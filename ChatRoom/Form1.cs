namespace ChatRoom
{
    public partial class ChatRoom : Form
    {
        public ChatRoom()
        {
            InitializeComponent();
            ChatRoomApi.Client.DefaultRequestHeaders.Accept.Clear();
        }

        private void ChatRoom_Load(object sender, EventArgs e)
        {
            UserOptionDropdown.Items.Clear();
            UserOptionDropdown.Items.Add("Input User");
            UserOptionDropdown.Items.Add("Add New User");
            UserOptionDropdown.SelectedIndex = 0;
        }

        private void SendButton_Click(object sender, EventArgs e) => SendMessage();

        private void SendMessage()
        {
            ChatRoomApi.PostMessage(MessageBox.Text, UserOptionDropdown.SelectedItem.ToString());
            MessageBox.Clear();
        }

        private void UserOptionDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (UserOptionDropdown.SelectedIndex == 0)
            {
                MessageBox.Clear();
            }
            else if (UserOptionDropdown.SelectedIndex == 1)
            {
                ChatRoomApi.PostNewUser(MessageBox.Text);
                UserOptionDropdown.Items.Add(MessageBox.Text);

                UserOptionDropdown.SelectedIndex = UserOptionDropdown.Items.Count - 1;
                MessageBox.Clear();
            }
        }
    }
}