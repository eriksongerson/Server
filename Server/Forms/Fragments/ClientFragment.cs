using System.Threading;
using System.Windows.Forms;
using Server.Models;

namespace Server.Forms.Fragments
{
    public class ClientFragment : Panel
    {

        private Label totalQuestionLabel;
        private Label rightQuestionLabel;
        private Label currentQuestionLabel;
        private Label thirdAnswerView;
        private Label secondAnswerView;
        private Label firstAnswerView;
        private Label themeLabel;
        private Label nameLabel;
        private Label surnameLabel;

        private Client _client;

        public Client Client
        {
            set
            {
                _client = value;
                new Thread(start: Redraw);
            }
            get => _client;
        }

        public ClientFragment()
        {
            InitializeComponent();
        }

        public ClientFragment(Client client)
        {
            InitializeComponent();
            this.Client = client;
        }

        private void Redraw()
        {

        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.totalQuestionLabel = new Label();
            this.rightQuestionLabel = new Label();
            this.currentQuestionLabel = new Label();
            this.thirdAnswerView = new Label();
            this.secondAnswerView = new Label();
            this.firstAnswerView = new Label();
            this.themeLabel = new Label();
            this.nameLabel = new Label();
            this.surnameLabel = new Label();
            // 
            // panel1
            // 
            //this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            //this.Controls.Add(this.totalQuestionLabel);
            //this.Controls.Add(this.rightQuestionLabel);
            //this.Controls.Add(this.currentQuestionLabel);
            //this.Controls.Add(this.thirdAnswerView);
            //this.Controls.Add(this.secondAnswerView);
            //this.Controls.Add(this.firstAnswerView);
            //this.Controls.Add(this.themeLabel);
            //this.Controls.Add(this.nameLabel);
            //this.Controls.Add(this.surnameLabel);
            //this.Location = new System.Drawing.Point(0, 0);
            this.Margin = new Padding(0);
            this.Size = new System.Drawing.Size(657, 49);
            //this.TabIndex = 4;
            // 
            // totalQuestionLabel
            // 
            totalQuestionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            totalQuestionLabel.Location = new System.Drawing.Point(607, 4);
            totalQuestionLabel.Name = "totalQuestionLabel";
            totalQuestionLabel.Size = new System.Drawing.Size(40, 40);
            totalQuestionLabel.TabIndex = 7;
            totalQuestionLabel.Text = "100";
            totalQuestionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rightQuestionLabel
            // 
            rightQuestionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            rightQuestionLabel.Location = new System.Drawing.Point(561, 4);
            rightQuestionLabel.Name = "rightQuestionLabel";
            rightQuestionLabel.Size = new System.Drawing.Size(40, 40);
            rightQuestionLabel.TabIndex = 6;
            rightQuestionLabel.Text = "11";
            rightQuestionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // currentQuestionLabel
            // 
            currentQuestionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            currentQuestionLabel.Location = new System.Drawing.Point(515, 4);
            currentQuestionLabel.Name = "currentQuestionLabel";
            currentQuestionLabel.Size = new System.Drawing.Size(40, 40);
            currentQuestionLabel.TabIndex = 5;
            currentQuestionLabel.Text = "13";
            currentQuestionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // thirdAnswerView
            // 
            thirdAnswerView.BackColor = System.Drawing.Color.Green;
            thirdAnswerView.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            thirdAnswerView.Location = new System.Drawing.Point(474, 7);
            thirdAnswerView.Name = "thirdAnswerView";
            thirdAnswerView.Size = new System.Drawing.Size(35, 35);
            thirdAnswerView.TabIndex = 4;
            thirdAnswerView.Text = "12";
            thirdAnswerView.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // secondAnswerView
            // 
            secondAnswerView.BackColor = System.Drawing.Color.Maroon;
            secondAnswerView.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            secondAnswerView.Location = new System.Drawing.Point(433, 7);
            secondAnswerView.Name = "secondAnswerView";
            secondAnswerView.Size = new System.Drawing.Size(35, 35);
            secondAnswerView.TabIndex = 3;
            secondAnswerView.Text = "11";
            secondAnswerView.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // firstAnswerView
            // 
            firstAnswerView.BackColor = System.Drawing.Color.Green;
            firstAnswerView.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            firstAnswerView.Location = new System.Drawing.Point(392, 7);
            firstAnswerView.Name = "firstAnswerView";
            firstAnswerView.Size = new System.Drawing.Size(35, 35);
            firstAnswerView.TabIndex = 2;
            firstAnswerView.Text = "10";
            firstAnswerView.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // themeLabel
            // 
            themeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            themeLabel.Location = new System.Drawing.Point(183, 0);
            themeLabel.Margin = new Padding(0);
            themeLabel.Name = "themeLabel";
            themeLabel.Size = new System.Drawing.Size(206, 49);
            themeLabel.TabIndex = 1;
            themeLabel.Text = "label7";
            themeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nameLabel
            // 
            nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            nameLabel.Location = new System.Drawing.Point(0, 29);
            nameLabel.Margin = new Padding(0);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(183, 20);
            nameLabel.TabIndex = 0;
            nameLabel.Text = "Имя";
            nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // surnameLabel
            // 
            surnameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            surnameLabel.Location = new System.Drawing.Point(0, 0);
            surnameLabel.Margin = new Padding(0);
            surnameLabel.Name = "surnameLabel";
            surnameLabel.Size = new System.Drawing.Size(183, 29);
            surnameLabel.TabIndex = 0;
            surnameLabel.Text = "Фамилия";
            surnameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

        }
    }
}
