using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flipper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Set Minimum Size to current (design time) Size
            MinimumSize = Size;

            cboSeperator.Items.Clear();
            cboSeperator.Items.Add(new ComboItem("Comma", ","));
            cboSeperator.SelectedIndex = 0;

            cboQuotes.Items.Clear();
            cboQuotes.Items.Add(new ComboItem("None",""));
            cboQuotes.Items.Add(new ComboItem("Single", "'"));
            cboQuotes.Items.Add(new ComboItem("Double", "\""));
            cboQuotes.SelectedIndex = 0;

            cboBrackets.Items.Clear();
            cboBrackets.Items.Add(new ComboItem("None", ""));
            cboBrackets.Items.Add(new ComboItem("Round", "()"));
            cboBrackets.Items.Add(new ComboItem("Curly", "{}"));
            cboBrackets.Items.Add(new ComboItem("Square", "[]"));
            cboBrackets.SelectedIndex = 0;
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                string[] lines = textBox1.Text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

                ComboItem quotes = cboQuotes.SelectedItem as ComboItem;
                ComboItem seperator = cboSeperator.SelectedItem as ComboItem;
                ComboItem brackets = cboBrackets.SelectedItem as ComboItem;

                StringBuilder sb = new StringBuilder();

                if (!brackets.Text.Equals("None"))
                {
                    sb.Append(brackets.Data.Substring(0, 1));
                }
                for (int i = 0; i < lines.Length; i++)
                {
                    sb.Append(quotes.Data);
                    sb.Append(lines[i]);
                    sb.Append(quotes.Data);

                    if (i != lines.Length - 1)
                    {
                        sb.Append(seperator.Data);
                    }
                }
                if (!brackets.Text.Equals("None"))
                {
                    sb.Append(brackets.Data.Substring(1, 1));
                }
                Clipboard.SetText(sb.ToString());
                MessageBox.Show("Text copied to clipboard", Text);
            }
        }
    }
}
