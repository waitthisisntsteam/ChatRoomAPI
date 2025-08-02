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
            string chatRoom = TabControl.SelectedTab.Text;
            string user = UserOptionDropdown.SelectedItem.ToString();
            string text = MessageBox.Text;
            string time = DateTime.Now.ToString();

            await ChatRoomApi.PostMessage(chatRoom, text, user);

            MessageBox.Clear();
        }

        private async void UserOptionDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (UserOptionDropdown.SelectedIndex)
            {
                case 1:
                    await ChatRoomApi.PostNewUser(TabControl.SelectedTab.Text, MessageBox.Text);
                    var usercheck = await ChatRoomApi.GetUser(TabControl.SelectedTab.Text, MessageBox.Text);
                    while (usercheck.Username == "")
                    {
                        usercheck = await ChatRoomApi.GetUser(TabControl.SelectedTab.Text, MessageBox.Text);
                    }
                    UserOptionDropdown.Items.Add(MessageBox.Text);
                    UserOptionDropdown.SelectedIndex = UserOptionDropdown.Items.Count - 1;
                    break;
                case 2:
                    var result = await ChatRoomApi.GetUser(TabControl.SelectedTab.Text, MessageBox.Text);
                    if (!string.IsNullOrEmpty(result.Username))
                    {
                        UserOptionDropdown.Items.Add(MessageBox.Text);
                        UserOptionDropdown.SelectedIndex = UserOptionDropdown.Items.Count - 1;
                    }
                    else UserOptionDropdown.SelectedIndex = 0;
                    break;
            }
            MessageBox.Clear();
        }

        private async void UpdateTimer_Tick(object sender, EventArgs e)
        {
            if (ChatBox.Enabled)
            {
                var result = await ChatRoomApi.GetAllMessages(TabControl.SelectedTab.Text);
                ChatBox.Items.Clear();
                foreach (var message in result)
                {
                    ChatBox.Items.Add(message.ToString());
                }
            }            
        }

        private void NewTabNameBox_TextChanged(object sender, EventArgs e)
        {
            if (NewTabNameBox.Text.Length > 0)
            {
                AddTabButton.Enabled = true;
            }
            else
            {
                AddTabButton.Enabled = false;
            }
        }

        private async void AddTabButton_Click(object sender, EventArgs e)
        {
            var existingChatroom = await ChatRoomApi.GetChatroom(NewTabNameBox.Text);
            if (existingChatroom != null)
            {
                var newChatroom = await ChatRoomApi.PostNewChatroom(NewTabNameBox.Text);
            }
            TabControl.TabPages.Add(new TabPage() { Text = NewTabNameBox.Text });
            TabControl.SelectedTab = TabControl.TabPages[TabControl.TabCount - 1];
            NewTabNameBox.Clear();
        }

        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChatBox.Enabled = true;
            MessageBox.Enabled = true;
            MessageBox.Clear();
            UserOptionDropdown.Enabled = true;
            UserOptionDropdown.Items.Clear();
        }
    }
}