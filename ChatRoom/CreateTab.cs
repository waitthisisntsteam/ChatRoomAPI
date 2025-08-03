using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatRoom
{
    public partial class CreateTab : Form
    {
        public bool Create = false;
        public string Name = string.Empty;

        public CreateTab()
        {
            InitializeComponent();
        }

        private async void ChatroomBox_TextChanged(object sender, EventArgs e)
        {
            if (ChatroomBox.Text == string.Empty)
                ChatroomResult.Text = "Room must have a unique name.";
            else
            {
                var result = await ChatRoomAPIHandler.GetChatroom(ChatroomBox.Text);
                if (result.IsActive)
                    ChatroomResult.Text = "Room already exists. Join?";
                else
                    ChatroomResult.Text = "Room not taken. Create?";
                Name = ChatroomBox.Text;
            }
        }

        private void CreateOrJoinButton_Click(object sender, EventArgs e)
        {
            Create = true;
        }

        public void Reset()
        {
            Create = false;
            Name = string.Empty;
            ChatroomBox.Text = string.Empty;
            ChatroomResult.Text = string.Empty;
        }
    }
}
