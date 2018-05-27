using System.Drawing;
using System.Windows.Forms;
using Server.Models;

namespace Server.Forms.Fragments
{
    public class ClientFragment : Panel
    {
        Testing testing; 

        Label surnameLabel;
        Label nameLabel;
        FlowLayoutPanel thingsFlowLayoutPanel;

        public ClientFragment()
        {
            InitializeComponent();
        }

        public ClientFragment(Testing testing)
        {
            this.testing = testing;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            surnameLabel = new Label();
            nameLabel = new Label();
            thingsFlowLayoutPanel = new FlowLayoutPanel();

            this.Size = new Size(882, 50);
            this.Margin = new Padding(0);

            surnameLabel.Height = 30;
            surnameLabel.Width = 215;
            nameLabel.Height = 20;
            nameLabel.Width = 215;
            thingsFlowLayoutPanel.Height = 50;
            thingsFlowLayoutPanel.Width = 682;

            this.Controls.Add(surnameLabel);
            this.Controls.Add(nameLabel);
            this.Controls.Add(thingsFlowLayoutPanel);

            surnameLabel.Location = new Point(0, 0);
            nameLabel.Location = new Point(0, 30);

            thingsFlowLayoutPanel.AutoScroll = true;
            thingsFlowLayoutPanel.Location = new Point(682, 50);
            thingsFlowLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            thingsFlowLayoutPanel.WrapContents = false;

            surnameLabel.TextAlign = nameLabel.TextAlign = ContentAlignment.MiddleCenter;
            
            if (this.testing.Client.name != null && this.testing.Client.surname != null)
            {
                surnameLabel.Text = this.testing.Client.surname;
                nameLabel.Text = this.testing.Client.name;
            }
            else
            {
                surnameLabel.Text = this.testing.Client.pc;
                nameLabel.Text = "";
            }

            thingsFlowLayoutPanel.Controls.Clear();
            foreach (var item in testing.Answers)
            {
                AnswerFragment answerFragment = new AnswerFragment(item);
                thingsFlowLayoutPanel.Controls.Add(answerFragment);
            }
            for (int i = 0; i < testing.CountOfQuestions - testing.Answers.Count; i++){
                AnswerFragment answerFragment = new AnswerFragment();
                thingsFlowLayoutPanel.Controls.Add(answerFragment);
            }

        }
    }
}
