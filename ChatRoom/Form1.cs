using Microsoft.Win32;

namespace ChatRoom
{
    public partial class ChatRoom : Form
    {
        public ChatRoom()
        {
            InitializeComponent();
            ChatRoomAPIHandler.Client.DefaultRequestHeaders.Accept.Clear();
        }

        private void ChatRoom_Load(object sender, EventArgs e)
        {
            ResetDropDownOptions();
        }

        private async void UpdateTimer_Tick(object sender, EventArgs e)
        {
            if (ChatBox.Enabled)
            {
                var result = await ChatRoomAPIHandler.GetAllMessages(TabControl.TabPages[TabControl.SelectedIndex].Text);
                ChatBox.Items.Clear();
                foreach (var message in result)
                {
                    var currentTime = DateTime.Now.Subtract(message.Timestamp);
                    if (ShowHistoryCheck.Checked || (currentTime.Minutes == 0 && currentTime.Seconds <= 30))
                        ChatBox.Items.Add(message.ToString());
                }
            }
        }


        // Button Clicks:
        private async void AddTabButton_Click(object sender, EventArgs e)
        {
            var existingChatroom = await ChatRoomAPIHandler.GetChatroom(NewTabNameBox.Text);
            if (!existingChatroom.IsActive)
            {
                var newChatroom = await ChatRoomAPIHandler.PostNewChatroom(NewTabNameBox.Text);
            }
            TabControl.TabPages.Add(new TabPage() { Text = NewTabNameBox.Text });
            TabControl.SelectedTab = TabControl.TabPages[TabControl.TabCount - 1];
            NewTabNameBox.Clear();

            ChatBox.Enabled = true;
            MessageBox.Enabled = true;
            MessageBox.Clear();
            UserOptionDropdown.Enabled = true;
            ResetDropDownOptions();
        }
        private void SendButton_Click(object sender, EventArgs e) => SendMessage();

        // Text/Option Changes:
        private async void UserOptionDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (UserOptionDropdown.SelectedIndex)
            {
                case 1:
                    await ChatRoomAPIHandler.PostNewUser(TabControl.TabPages[TabControl.SelectedIndex].Text, MessageBox.Text);
                    var usercheck = await ChatRoomAPIHandler.GetUser(TabControl.TabPages[TabControl.SelectedIndex].Text, MessageBox.Text);
                    while (usercheck.Username == "")
                    {
                        usercheck = await ChatRoomAPIHandler.GetUser(TabControl.TabPages[TabControl.SelectedIndex].Text, MessageBox.Text);
                    }
                    UserOptionDropdown.Items.Add(MessageBox.Text);
                    UserOptionDropdown.SelectedIndex = UserOptionDropdown.Items.Count - 1;
                    break;
                case 2:
                    var result = await ChatRoomAPIHandler.GetUser(TabControl.TabPages[TabControl.SelectedIndex].Text, MessageBox.Text);
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
        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChatBox.Enabled = true;
            MessageBox.Enabled = true;
            MessageBox.Clear();
            UserOptionDropdown.Enabled = true;
            ResetDropDownOptions();
        }
        private void NewTabNameBox_TextChanged(object sender, EventArgs e)
        {
            if (NewTabNameBox.Text.Length > 0)
                AddTabButton.Enabled = true;
            else
                AddTabButton.Enabled = false;
        }
        private void MessageBox_TextChanged(object sender, EventArgs e)
        {
            if (MessageBox.Text.Length > 0)
                SendButton.Enabled = true;
            else
                SendButton.Enabled = false;
        }

        // Logic:
        private async void SendMessage()
        {
            string chatRoom = TabControl.TabPages[TabControl.SelectedIndex].Text;
            string user = UserOptionDropdown.Items[UserOptionDropdown.SelectedIndex].ToString();
            string text = MessageBox.Text;
            string time = DateTime.Now.ToString();
            await ChatRoomAPIHandler.PostMessage(chatRoom, text, user);

            MessageBox.Clear();
        }

        // Resets:
        private void ResetDropDownOptions()
        {
            UserOptionDropdown.Items.Clear();
            UserOptionDropdown.Items.Add("Input User");
            UserOptionDropdown.Items.Add("Add New User");
            UserOptionDropdown.Items.Add("Add Existing User");
            UserOptionDropdown.SelectedIndex = 0;
        }
    }
}