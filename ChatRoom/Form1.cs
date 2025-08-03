using Microsoft.Win32;
using ModelObjects;
using System.ComponentModel.DataAnnotations;

namespace ChatRoom
{
    public partial class ChatRoom : Form
    {
        CreateUser CreateUserWindow;
        UserSignIn UserSignInWindow;

        CreateTab CreateTabWindow;
        TabSelection TabSelectionWindow;

        public ChatRoom()
        {
            InitializeComponent();
            ChatRoomAPIHandler.Client.DefaultRequestHeaders.Accept.Clear();
        }

        private void ChatRoom_Load(object sender, EventArgs e)
        {
            UserOptionDropdown.Items.Clear();
            UserOptionDropdown.Items.Add("Select User...");
            UserOptionDropdown.Items.Add("Add New User...");
            UserOptionDropdown.Items.Add("Add Existing User...");
            UserOptionDropdown.SelectedIndex = 0;

            CreateUserWindow = new CreateUser();
            UserSignInWindow = new UserSignIn();

            CreateTabWindow = new CreateTab();
            TabSelectionWindow = new TabSelection();
        }

        // Update Logic:
        private async void UpdateTimer_Tick(object sender, EventArgs e)
        {
            if (ChatBox.Enabled)
            {
                var currentChatroom = await ChatRoomAPIHandler.GetChatroom(TabControl.TabPages[TabControl.SelectedIndex].Text);
                if (currentChatroom.Users.Count == 0 || currentChatroom.Users.Contains(await ChatRoomAPIHandler.GetUser(UserOptionDropdown.Items[UserOptionDropdown.SelectedIndex].ToString())))
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

            if (TabSelectionWindow.Continue)
            {
                CreateTabWindow.Show();
                TabSelectionWindow.Hide();
            }

            if (CreateTabWindow.Create)
            {
                if (TabSelectionWindow.SelectedRoomType == Chatroom.RoomTypes.Server)
                    await ChatRoomAPIHandler.PostNewChatroom(CreateTabWindow.Name);
                else
                    await ChatRoomAPIHandler.PostNewDirectMessages(CreateTabWindow.Name, UserOptionDropdown.Items[UserOptionDropdown.SelectedIndex].ToString(), TabSelectionWindow.OtherUser);
                TabControl.TabPages.Add(new TabPage() { Text = CreateTabWindow.Name });
                TabControl.SelectedTab = TabControl.TabPages[TabControl.TabCount - 1];

                ChatBox.Enabled = true;
                MessageBox.Enabled = true;
                MessageBox.Clear();
                UserOptionDropdown.Enabled = true;

                AddTabButton.Enabled = true;

                TabSelectionWindow.Reset();
                CreateTabWindow.Reset();
                CreateTabWindow.Hide();
            }

            if (UserSignInWindow.Success)
            {
                UserOptionDropdown.Items.Add(UserSignInWindow.Name);
                UserOptionDropdown.SelectedIndex = UserOptionDropdown.Items.Count - 1;

                UserOptionDropdown.Enabled = true;

                UserSignInWindow.Reset();
                UserSignInWindow.Hide();
            }

            if (CreateUserWindow.Create)
            {
                UserOptionDropdown.Items.Add(CreateUserWindow.Name);
                UserOptionDropdown.SelectedIndex = UserOptionDropdown.Items.Count - 1;

                UserOptionDropdown.Enabled = true;

                CreateUserWindow.Reset();
                CreateUserWindow.Hide();
            }
        }

        // Button Clicks:
        private async void AddTabButton_Click(object sender, EventArgs e)
        {
            AddTabButton.Enabled = false;

            TabSelectionWindow.Show();
        }
        private void SendButton_Click(object sender, EventArgs e) => SendMessage();

        // Text/Option Changes:
        private async void UserOptionDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (UserOptionDropdown.SelectedIndex)
            {
                case 1:
                    UserOptionDropdown.Enabled = false;
                    CreateUserWindow.Show();
                    break;
                case 2:
                    UserOptionDropdown.Enabled = false;
                    UserSignInWindow.Show();
                    break;
            }
        }
        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChatBox.Enabled = true;
            MessageBox.Enabled = true;
            MessageBox.Clear();
            UserOptionDropdown.Enabled = true;
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
            var currentChatroom = await ChatRoomAPIHandler.GetChatroom(TabControl.TabPages[TabControl.SelectedIndex].Text);
            if (currentChatroom.Users.Count == 0 || currentChatroom.Users.Contains(await ChatRoomAPIHandler.GetUser(UserOptionDropdown.Items[UserOptionDropdown.SelectedIndex].ToString())))
            await ChatRoomAPIHandler.PostMessage(chatRoom, text, user);

            MessageBox.Clear();
        }
    }
}