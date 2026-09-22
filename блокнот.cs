using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace блокнот_пр4
{
    public partial class Form1 : Form
    {
        private TextBox textBox;
        private MenuStrip menuStrip;

        public Form1()
        {
            InitializeComponent();
            CreateInterface();
        }

        private void CreateInterface()
        {
            Text = "Блокнот";
            Width = 900;
            Height = 600;
            StartPosition = FormStartPosition.CenterScreen;

            menuStrip = new MenuStrip();

            ToolStripMenuItem fileMenu = new ToolStripMenuItem("Файл");

            ToolStripMenuItem openItem = new ToolStripMenuItem("Открыть");
            ToolStripMenuItem saveItem = new ToolStripMenuItem("Сохранить как...");
            ToolStripMenuItem clearItem = new ToolStripMenuItem("Очистить");
            ToolStripMenuItem exitItem = new ToolStripMenuItem("Выход");

            openItem.Click += OpenFile;
            saveItem.Click += SaveFile;
            clearItem.Click += ClearText;
            exitItem.Click += ExitProgram;

            fileMenu.DropDownItems.Add(openItem);
            fileMenu.DropDownItems.Add(saveItem);
            fileMenu.DropDownItems.Add(new ToolStripSeparator());
            fileMenu.DropDownItems.Add(clearItem);
            fileMenu.DropDownItems.Add(new ToolStripSeparator());
            fileMenu.DropDownItems.Add(exitItem);

            menuStrip.Items.Add(fileMenu);

            textBox = new TextBox();
            textBox.Multiline = true;
            textBox.Dock = DockStyle.Fill;
            textBox.ScrollBars = ScrollBars.Both;
            textBox.AcceptsTab = true;
            textBox.WordWrap = false;
            textBox.Font = new Font("Segoe UI", 12);

            Controls.Add(textBox);
            Controls.Add(menuStrip);

            MainMenuStrip = menuStrip;
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter =
                "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";

            openFileDialog.Title = "Открыть текстовый файл";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    textBox.Text = File.ReadAllText(openFileDialog.FileName);

                    Text = "Блокнот - " +
                           Path.GetFileName(openFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Не удалось открыть файл:\n" + ex.Message,
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void SaveFile(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter =
                "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";

            saveFileDialog.Title = "Сохранить текстовый файл";
            saveFileDialog.DefaultExt = "txt";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.WriteAllText(
                        saveFileDialog.FileName,
                        textBox.Text);

                    Text = "Блокнот - " +
                           Path.GetFileName(saveFileDialog.FileName);

                    MessageBox.Show(
                        "Файл успешно сохранён.",
                        "Сохранение",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Не удалось сохранить файл:\n" + ex.Message,
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void ClearText(object sender, EventArgs e)
        {
            if (textBox.Text.Length == 0)
                return;

            DialogResult result = MessageBox.Show(
                "Очистить весь текст?",
                "Блокнот",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                textBox.Clear();
                Text = "Блокнот";
            }
        }

        private void ExitProgram(object sender, EventArgs e)
        {
            Close();
        }
    }
}