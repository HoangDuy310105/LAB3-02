using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB3_02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int size = 14;
        string font = "Tahoma";
        private void AddFontInCMB()
        {
            foreach (FontFamily font in new InstalledFontCollection().Families)
            {
                cmbFornt.Items.Add(font.Name);
            }
        }
        private void AddSizeInCMB()
        {
            int[] sizes = { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 50, 72 };

            foreach (int size in sizes)
            {
                ScmbSizes.Items.Add(size);
            }
        }
        private void địnhDạngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDlg = new FontDialog();
            fontDlg.ShowColor = true;
            fontDlg.ShowApply = true;
            fontDlg.ShowEffects = true;
            fontDlg.ShowHelp = true;
            if (fontDlg.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.ForeColor = fontDlg.Color;
                richTextBox1.Font = fontDlg.Font;
            }
        }
        private void lamMoiRich()
        {
            richTextBox1.Clear();
            richTextBox1.Font = new Font("Tahoma", 14, FontStyle.Regular);
            cmbFornt.SelectedItem = "Tahoma";
            ScmbSizes.SelectedItem = 14;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AddFontInCMB();
            AddSizeInCMB();
            lamMoiRich();
            toolStripSplitButton1.ButtonClick += toolStripSplitButton1_ButtonClick;
            richTextBox1.TextChanged += richTextBox1_TextChanged;
            richTextBox1_TextChanged(null, null);
        }

        private void cbmFonts_SelectedIndexChanged(object sender, EventArgs e)
        {
            font = cmbFornt.Text;
            richTextBox1.Font = new Font(font, size);
        }

        private void cmbSizes_SelectedIndexChanged(object sender, EventArgs e)
        {
            size = Int32.Parse(ScmbSizes.Text);
            richTextBox1.Font = new Font(font, size, FontStyle.Regular);
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tạoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lamMoiRich();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            lamMoiRich();
        }

        private void mởToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "Text file| *.txt| RFT File | *.rft";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string selectedFileName = ofd.FileName;
                richTextBox1.LoadFile(selectedFileName, RichTextBoxStreamType.UnicodePlainText);

            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.N)
            {
                lamMoiRich();
                e.Handled = true;
                return;
            }
            if (e.Control && e.KeyCode == Keys.O)
            {
                mởToolStripMenuItem_Click(this, e);
                e.Handled = true;
                return;
            }
            if (e.Control && e.KeyCode == Keys.S)
            {
                toolStripButton1_Click(this, e);
                e.Handled = true;
                return;
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.CheckPathExists = true;
            saveFileDialog.Title = "Lưu tập tin văn bản";
            saveFileDialog.DefaultExt = "rft";
            saveFileDialog.Filter = "RichText files|*.rft";
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.AddExtension = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFileName = saveFileDialog.FileName;
                try
                {
                    richTextBox1.SaveFile(selectedFileName, RichTextBoxStreamType.UnicodePlainText);
                    MessageBox.Show("Tập tin đã được lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi trong quá trình lưu tập tin: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void lưuVănBảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.CheckPathExists = true;
            saveFileDialog.Title = "Lưu tập tin văn bản";
            saveFileDialog.DefaultExt = "rft";
            saveFileDialog.Filter = "RichText files|*.rft";
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.AddExtension = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFileName = saveFileDialog.FileName;
                try
                {
                    richTextBox1.SaveFile(selectedFileName, RichTextBoxStreamType.UnicodePlainText);
                    MessageBox.Show("Tập tin đã được lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi trong quá trình lưu tập tin: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {

            if (richTextBox1.SelectionFont.Bold)
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, richTextBox1.SelectionFont.Style & ~FontStyle.Bold);

            }
            else
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, richTextBox1.SelectionFont.Style | FontStyle.Bold);

            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont.Italic)
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, richTextBox1.SelectionFont.Style & ~FontStyle.Italic);

            }
            else
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, richTextBox1.SelectionFont.Style | FontStyle.Italic);

            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {

            if (richTextBox1.SelectionFont.Underline)
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, richTextBox1.SelectionFont.Style & ~FontStyle.Underline);

            }
            else
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, richTextBox1.SelectionFont.Style | FontStyle.Underline);

            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            // Tính tổng số ký tự
            int charCount = richTextBox1.Text.Length;

            // Tính tổng số từ
            int wordCount = richTextBox1.Text.Split(new char[] { ' ', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries).Length;

            // Hiển thị trên thanh trạng thái
            toolStripLabel1.Text = $"Ký tự: {charCount} | Từ: {wordCount}";
        }

        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    richTextBox1.SelectionColor = colorDialog.Color;
                }
            }
        }
    }
}
