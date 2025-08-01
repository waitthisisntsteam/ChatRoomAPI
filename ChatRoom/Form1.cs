using Microsoft.Win32;

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
            UserOptionDropdown.Items.Add("Add Existing User");
            UserOptionDropdown.SelectedIndex = 0;
        }

        private void SendButton_Click(object sender, EventArgs e) => SendMessage();

        private async void SendMessage()
        {
            string user = UserOptionDropdown.SelectedItem.ToString();
            string text = MessageBox.Text;
            string time = DateTime.Now.ToString();

            await ChatRoomApi.PostMessage(text, user);
            ChatBox.Items.Add($"[{time}] {user}: {text}");

            MessageBox.Clear();
        }

        private async void UserOptionDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (UserOptionDropdown.SelectedIndex == 0)
            {
                MessageBox.Clear();
            }
            else if (UserOptionDropdown.SelectedIndex == 1)
            {
                await ChatRoomApi.PostNewUser(MessageBox.Text);
                UserOptionDropdown.Items.Add(MessageBox.Text);

                UserOptionDropdown.SelectedIndex = UserOptionDropdown.Items.Count - 1;
                MessageBox.Clear();
            }
            else if (UserOptionDropdown.SelectedIndex == 2)
            {
                var result = await ChatRoomApi.GetUser(MessageBox.Text);
                if (!string.IsNullOrEmpty(result.Username))
                {
                    UserOptionDropdown.Items.Add(MessageBox.Text);
                    UserOptionDropdown.SelectedIndex = UserOptionDropdown.Items.Count - 1;
                }
                else UserOptionDropdown.SelectedIndex = 0;
                    
                MessageBox.Clear();
            }
        }
    }
}