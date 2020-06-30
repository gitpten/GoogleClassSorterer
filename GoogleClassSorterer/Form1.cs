using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace GoogleClassSorterer
{
    public partial class Form1 : Form
    {
        MarkTable markTable;
        List<string> fullNames;
        List<Pupil> pupilsFromXml=new List<Pupil>();
        string matchFileName;
        public Form1()
        {
            InitializeComponent();
            ClassRoomOpenFileDialog.Filter = "CSV files(*.csv)|*.csv";
            NZOpenFileDialog.Filter = "XLSX files(*.xlsx)|*.xlsx";
            matchSaveFileDialog.Filter = "XML files(*.xml)|*.xml";
            MatchOpenFileDialog.Filter = "XML files(*.xml)|*.xml";
            GradeSaveFileDialog.Filter = "XLSX files(*.xlsx)|*.xlsx";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ClassRoomOpenFileDialog.ShowDialog() == DialogResult.Cancel)
                return;

            
            string fileName = ClassRoomOpenFileDialog.FileName;

            lblClassRoomFileError.Text = "File reading...";
            lblClassRoomFileError.ForeColor = Color.Black;
            //try
            //{
                ReadClassRoomFile(fileName);
                lblClassRoomFileError.Text = "File have read";
                lblClassRoomFileError.ForeColor = Color.Green;
                btnNZ.Enabled = true;
                btnLoadXml.Enabled = true;
            //}
            //catch
            //{
            //    lblClassRoomFileError.ForeColor = Color.Red;
            //    lblClassRoomFileError.Text = "Upps... Wrong file";

            //}



        }

        private void ReadClassRoomFile(string fileName)
        {
            markTable = new MarkTable();
            markTable.SetFromFile(fileName);
        }

        private void Merge(Pupil pupil, Pupil newPupil)
        {
            if (pupil.TrueName == null && newPupil.TrueName != null)
            {
                pupil.TrueName = newPupil.TrueName;
                return;
            }

            if (pupil.TrueName == newPupil.TrueName)
                return;

            if (pupil.TrueName != null && newPupil.TrueName != null)
            {
                if (MessageBox.Show($"{pupil.TrueName} or {newPupil.TrueName}. First! If not, press No", "", MessageBoxButtons.YesNo) == DialogResult.No)
                    pupil.TrueName = newPupil.TrueName;
            }
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (NZOpenFileDialog.ShowDialog() == DialogResult.Cancel)
                return;

            string fileName = NZOpenFileDialog.FileName;
            lblNZFileError.Text = "File reading...";
            lblNZFileError.ForeColor = Color.Black;
            try
            {
                ReadNamesRoomFile(fileName);
                lblNZFileError.Text = "File have read";
                lblNZFileError.ForeColor = Color.Green;
                btnMatch.Visible = true;
            }
            catch
            {
                lblNZFileError.Text = "Upps... Wrong file";
            }
        }

        private void ReadNamesRoomFile(string fileName)
        {
            fullNames = NzListReader.GetList(fileName);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form f = new Form2(markTable.Pupils, fullNames);
            f.ShowDialog();
            markTable.JoinTheSamePupil();
            PushNewToXml(markTable.Pupils, pupilsFromXml);
            btnMakeXlsx.Enabled = true;
        }

        private void PushNewToXml(List<Pupil> pupils, List<Pupil> pupilsFromXml)
        {

            foreach (var pupil in pupils.Where(x => x.TrueName != null))
            {
                if (pupilsFromXml.FirstOrDefault(x => x.FirstName == pupil.FirstName &&
                                                    x.LastName == pupil.LastName &&
                                                    x.TrueName == pupil.TrueName &&
                                                    x.Email == pupil.Email) != null) continue;

                var sameByEmail = pupilsFromXml.FirstOrDefault(x => x.Email!=null && x.Email == pupil.Email);
                if (sameByEmail != null)
                {
                    sameByEmail.TrueName = pupil.TrueName;
                }
                else
                    pupilsFromXml.Add(pupil);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (matchFileName == null)
                SaveAsMatchToFile();
            else
                SaveMatchToFile();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SaveAsMatchToFile();
        }

        private void SaveAsMatchToFile()
        {
            if (matchSaveFileDialog.ShowDialog() == DialogResult.Cancel)
                return;

            matchFileName = matchSaveFileDialog.FileName;

            SaveMatchToFile();
        }

        private void SaveMatchToFile()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Pupil>));
            using (FileStream fs = new FileStream(matchFileName, FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, pupilsFromXml);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (MatchOpenFileDialog.ShowDialog() == DialogResult.Cancel)
                return;

            DialogResult dialogResult = default;
            if (matchFileName != null)
            {
                dialogResult = MessageBox.Show(@"We have loaded some file with matches. Merge them?

Press Yes to verge
Press No to rewrite exited file
Press Cancel to save exited file",
                                "File exist", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Cancel)
                    return;
            }
            

                matchFileName = MatchOpenFileDialog.FileName;            

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Pupil>));
            try
            {

                using (FileStream fs = new FileStream(matchFileName, FileMode.Open))
                {
                    if (dialogResult == DialogResult.No)
                        pupilsFromXml = new List<Pupil>();
                    PushNewToXml((List<Pupil>)xmlSerializer.Deserialize(fs), pupilsFromXml);
                }
                lblMatchFileError.Text = "File have read";
                lblMatchFileError.ForeColor = Color.Green;
                btnSaveXml.Enabled = true;
                btnSaveAsXml.Enabled = true;
                btnMakeXlsx.Enabled = true;
            }
            catch (Exception)
            {
                lblMatchFileError.Text = "Upps... Wrong file";
                lblMatchFileError.ForeColor = Color.Red;
            }

            PushXmlToCsv(markTable.Pupils, pupilsFromXml);
        }

        private void PushXmlToCsv(List<Pupil> pupils, List<Pupil> pupilsFromXml)
        {
            foreach (var pupil in pupils)
            {
                Pupil fullpupil = pupilsFromXml.FirstOrDefault(x => x.Email != null && x.Email == pupil.Email);
                if (fullpupil != null)
                    pupil.TrueName = fullpupil.TrueName;

            }
            markTable.JoinTheSamePupil();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (GradeSaveFileDialog.ShowDialog() == DialogResult.Cancel)
                return;

            string fileName = GradeSaveFileDialog.FileName;

            if (!fileName.EndsWith(".xlsx"))
                fileName = $"{fileName}.xlsx";

            XlsxSerialiser xmlSerializer = new XlsxSerialiser(markTable, fullNames);
            //try
            //{

                using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
                {
                    xmlSerializer.Serialize(fs);
                }
                lblXLSError.Text = "File have made";
                lblXLSError.ForeColor = Color.Green;
            //}
            //catch (Exception)
            //{
            //    lblXLSError.Text = "Upps... Something went wrong. File haven't been made";
            //    lblXLSError.ForeColor = Color.Red;
            //}
        }
    }
}
