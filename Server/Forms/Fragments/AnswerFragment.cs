using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Server.Models;

namespace Server.Forms.Fragments
{
    class AnswerFragment : Panel
    {
        
        private enum AnswerStatus
        {
            right,
            wrong,
            wait,
        }
        private AnswerStatus status;
        AnswerStatus Status
        {
            set 
            {  
                status = value;
                switch (status)
                {
                    case AnswerStatus.right:
                        this.statusLabel.BackColor = Color.Green;
                        break;
                    case AnswerStatus.wrong:
                        this.statusLabel.BackColor = Color.Red;
                        break;
                    case AnswerStatus.wait:
                        this.statusLabel.BackColor = SystemColors.ControlDark;
                        break;
                }
            }
            get { return status; }
        }

        Answer answer;

        Label statusLabel;
        
        public AnswerFragment(): base()
        {
            this.answer = null;
            Init();
        }

        public AnswerFragment(Answer answer): base()
        {
            this.answer = answer;
            Init();
        }

        private void Init()
        {
            statusLabel = new Label();

            this.Controls.Add(statusLabel);

            this.statusLabel.Size = new Size(28, 28);
            this.statusLabel.Location = new Point(4, 11);

            this.statusLabel.TextAlign = ContentAlignment.MiddleCenter;
            this.statusLabel.Text = "1";

            this.Size = new Size(40, 50);

            this.Margin = new Padding(0);

            if (answer == null)
            {
                Status = AnswerStatus.wait;
                return;
            }

            // TODO: Переработать
            switch (answer.question.Type)
            {
                case Type.single:

                    foreach (var item in answer.question.Options)
                    {
                        if(item.isRight) 
                            if(item == answer.choosen[0])
                            {
                                Status = AnswerStatus.right;
                            }
                            else
                            {
                                Status = AnswerStatus.wrong;
                            }
                    }

                    break;

                case Type.multiple:

                    // TODO: Доделать

                    break;
                case Type.filling:

                    if(answer.choosen[0].option.TrimEnd().TrimStart().ToLower() == answer.question.Options[0].option.TrimEnd().TrimStart().ToLower())
                    {
                        Status = AnswerStatus.right;
                    }
                    else
                    {
                        Status = AnswerStatus.wrong;
                    }

                    break;
            }
        }
    }
}
