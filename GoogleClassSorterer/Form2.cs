using CsvHelper.TypeConversion;
using DocumentFormat.OpenXml.Bibliography;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoogleClassSorterer
{
    public partial class Form2 : Form
    {
        private Label labelForMoving;
        Point startLocation;
        Point labelLocation;

        List<Pupil> pupils;
        List<string> trueNames;

        List<Label> pupilsLabels;
        List<Label> namesLabels;
        List<Label> readyLabels;

        Label markedLabel;

        Color RegularColor = Color.Black;
        Color usedElementColor = Color.Gray;
        Color activeColor = Color.Red;

        public Form2(List<Pupil> pupils, List<string> trueNames)
        {
            InitializeComponent();
            this.pupils = pupils;
            this.trueNames = trueNames;
            pupilsLabels = new List<Label>();
            namesLabels = new List<Label>();
            readyLabels = new List<Label>();
            InitializeLabels();
        }

        private void ArrangeLabel()
        {
            pnlNameLabel.Controls.Clear();
            pnlPupilLabel.Controls.Clear();
            pnlReadyLabel.Controls.Clear();

            ArrangeColumn(pupilsLabels, pnlPupilLabel);
            ArrangeColumn(namesLabels, pnlNameLabel);
            ArrangeColumn(readyLabels, pnlReadyLabel);

        }

        private void ArrangeColumn(List<Label> labels, Panel container)
        {
            labels.Sort((first, second) =>
                                    {
                                        if (first.ForeColor == second.ForeColor)
                                        {
                                            return first.Text.CompareTo(second.Text);
                                        }
                                        else
                                        {
                                            return first.ForeColor == RegularColor ? -1 : 1;
                                        }
                                    });
            int x = 0;int y = 0;
            foreach (var label in labels)
            {
                container.Controls.Add(label);
                label.Location = new Point(x, y);
                y += label.Height * 120 / 100;
            }
        }

        private void InitializeLabels()
        {        
            foreach (var name in trueNames)
            {
                AddNameToPnlNames(name);
            }

            foreach (var pupil in pupils)
            {
                PupilLabel label = new PupilLabel();
                label.Font = new System.Drawing.Font("Montserrat", 10F);
                label.AutoSize = true;
                label.pupil = pupil;

                if (pupil.TrueName == null)
                {
                    AddToPupilLabel(label);
                }
                else
                {
                    var lblTrueNme = namesLabels.FirstOrDefault(x => x.Text == pupil.TrueName);
                    if (lblTrueNme != null)
                    {
                        MarkNameAsUsed(lblTrueNme);
                    }

                    AddToReadyLabel(label);
                }
            }



            FoundRightNames();
            ArrangeLabel();
        }

        private void MarkNameAsUsed(Label lblTrueNme)
        {
            lblTrueNme.ForeColor = usedElementColor;
        }

        private void AddToPupilLabel(PupilLabel label)
        {
            pupilsLabels.Add(label);
            label.Text = String.Format($"{label.pupil.FirstName} {label.pupil.LastName} {label.pupil.Email}");
        }

        private void AddNameToPnlNames(string name)
        {
            Label label = new Label();
            label.ForeColor = RegularColor;
            label.Font = new System.Drawing.Font("Montserrat", 10F);
            label.AutoSize = true;
            label.Text = String.Format($"{name}");
            label.MouseDown += label2_MouseDown;
            label.MouseMove += label2_MouseMove;
            label.MouseUp += label2_MouseUp;
            namesLabels.Add(label);
        }

        private void AddToReadyLabel(PupilLabel label)
        {
            readyLabels.Add(label);
            label.Text = String.Format($"{label.pupil.FirstName} {label.pupil.LastName}: {label.pupil.TrueName}");
            label.DoubleClick += Label_DoubleClick;
        }

        private void Label_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                PupilLabel label = (PupilLabel)sender;

                AddNameToPnlNames(label.pupil.TrueName);
                readyLabels.Remove(label);
                label.pupil.TrueName = null;
                AddToPupilLabel(label);
                ArrangeLabel();
            }
            catch (Exception)
            {
                throw new Exception("Instead PupilLabel has been got something else");
            }

            
        }

        private void FoundRightNames()
        {
            for (int i = pupilsLabels.Count - 1; i >=0; i--)
            {
                for (int j = namesLabels.Count - 1; j >= 0; j--)
                {
                    PupilLabel pupilLabel = (PupilLabel)pupilsLabels[i];
                    if (IsTheSameName(pupilLabel.pupil,namesLabels[j].Text))
                    {
                        AddTrueName(pupilLabel, namesLabels[j]);
                    }
                }
            }
        }

        private bool IsTheSameName(Pupil pupil, string fullName)
        {
            return String.Format($"{pupil.FirstName} {pupil.LastName}") == fullName ||
                String.Format($"{pupil.LastName} {pupil.FirstName}") == fullName;
        }

        private void label2_MouseMove(object sender, MouseEventArgs e)
        {
            bool IsIntersectWithSomeOne = false;

            if (e.Button != MouseButtons.Left) return;

            Label label = (Label)sender;
            if (label != labelForMoving) return;

            label.Left -= startLocation.X - e.X;

            label.Top -= startLocation.Y - e.Y;
            if (label.Left < 0)
            {
                label.Parent = pnlPupilLabel;
                label.Left += pnlPupilLabel.Width;
            }
            else if (label.Left > pnlNameLabel.Width)
            {
                label.Parent = pnlNameLabel;
                label.Left -= pnlPupilLabel.Width;
            }

            if (label.Parent != pnlPupilLabel) return;

            Rectangle r2 = new Rectangle() { Size = label.Size, Location = label.Location };
            foreach (var lblPupil in pupilsLabels)
            {
                Rectangle r1 = new Rectangle() { Size = lblPupil.Size, Location = lblPupil.Location };

                if (r2.IntersectsWith(r1))
                {
                    IsIntersectWithSomeOne = true;
                    if (markedLabel == null)
                    {
                        markedLabel = lblPupil;
                        markedLabel.ForeColor = activeColor;
                    }
                    else
                    {
                        Rectangle r3 = r1;
                        r3.Intersect(r2);
                        Rectangle r4 = new Rectangle() { Size = markedLabel.Size, Location = markedLabel.Location };
                        r4.Intersect(r2);
                        if (Area(r3) > Area(r4))
                        {
                            markedLabel.ForeColor = RegularColor;
                            markedLabel = lblPupil;
                            markedLabel.ForeColor = activeColor;
                        }

                    }
                }
            }

            if (!IsIntersectWithSomeOne && markedLabel != null)
            {
                markedLabel.ForeColor = RegularColor;
                markedLabel = null;
            }
        }

        public static int Area(Rectangle rect)
        {
            return rect.Width * rect.Height;
        }

        private void label2_MouseDown(object sender, MouseEventArgs e)
        {
            Label label = (Label)sender;

            if (label.Parent != pnlNameLabel) return;

            labelForMoving = label;
            startLocation = e.Location;
            labelLocation = label.Location;


        }

        private void label2_MouseUp(object sender, MouseEventArgs e)
        {
            Label label = (Label)sender;
            if (markedLabel != null)
            {
                markedLabel.ForeColor = RegularColor;
                AddTrueName(markedLabel as PupilLabel, label);

            }
            else

            {
                label.Location = labelLocation;
            }
        }

        private void AddTrueName(PupilLabel pupilLabel, Label lblName)
        {
            if (pupilLabel != null)
            {
                pupilLabel.pupil.TrueName = lblName.Text;
                pupilsLabels.Remove(pupilLabel);
                MarkNameAsUsed(lblName);
                AddToReadyLabel(pupilLabel);
                ArrangeLabel();
            }

        }

    }
}
