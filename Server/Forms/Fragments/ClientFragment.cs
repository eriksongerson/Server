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
            this.testing = null;
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

            this.Controls.Add(this.thingsFlowLayoutPanel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.surnameLabel);
            this.Margin = new Padding(0);
            this.Size = new Size(882, 50);
            this.TabIndex = 0;

            this.surnameLabel.Location = new Point(0, 0);
            this.surnameLabel.Margin = new Padding(0);
            this.surnameLabel.Size = new Size(215, 30);
            this.surnameLabel.TabIndex = 0;
            this.surnameLabel.TextAlign = ContentAlignment.MiddleCenter;

            this.nameLabel.Location = new Point(0, 30);
            this.nameLabel.Margin = new Padding(0);
            this.nameLabel.Size = new Size(215, 20);
            this.nameLabel.TabIndex = 1;
            this.nameLabel.TextAlign = ContentAlignment.MiddleCenter;

            this.thingsFlowLayoutPanel.AutoScroll = true;
            this.thingsFlowLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.thingsFlowLayoutPanel.Location = new Point(215, 0);
            this.thingsFlowLayoutPanel.Margin = new Padding(0);
            this.thingsFlowLayoutPanel.Size = new Size(666, 50);
            this.thingsFlowLayoutPanel.TabIndex = 2;
            this.thingsFlowLayoutPanel.WrapContents = false;
            
            if(testing.CountOfQuestions > 14)
            {
                this.Height = 70;
                thingsFlowLayoutPanel.Height = 70;
            }

            if(testing != null)
            {
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
                for (int i = 0; i < testing.CountOfQuestions - testing.Answers.Count; i++)
                {
                    AnswerFragment answerFragment = new AnswerFragment();
                    thingsFlowLayoutPanel.Controls.Add(answerFragment);
                }
            }

            this.ResumeLayout(false);
        }
    }
}
