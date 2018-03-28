using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormatSQLFirebird
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            this.InitializeComponent();
        }

        private void btnPlainToOstendo_Click(object sender, EventArgs e)
        {
#if !DEBUG
            try
            {
#endif
                LinkedList<Parsing.Tokens.Token> list = new LinkedList<Parsing.Tokens.Token>(Parsing.Parser.ParseToTokens(rtxtIn.Text));
                LinkedListNode<Parsing.Tokens.Token> outy;
                List<LinkedListNode<Parsing.Tokens.Token>> listy = StringConverting.GetFormattedCodeFromString(list.First, out outy);
                string text = "";
                foreach(var i in listy)
                {
                    text += i.Value;
                }
                rtxtOut.Text = text;
                StringConverting.ResetConverter();
#if !DEBUG
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error: \n" + exception.Message + "\n\n" + exception.StackTrace);
            }
#endif
        }

        private void btnOstendoToPlain_Click(object sender, EventArgs e)
        {
            try
            {
                this.rtxtIn.Text = StringConverting.GetStringFromPascalCode(this.rtxtOut.Text);
            }
            catch (FormatException ex)
            {
                int num = (int)MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void btnCopyPlain_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(this.rtxtIn.Text, TextDataFormat.Text);
            }
            catch (ExternalException)
            {
                int num = (int)MessageBox.Show("An error occured setting the clipboard text, the text may not have been copied", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnCopyOstendo_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(this.rtxtOut.Text, TextDataFormat.Text);
            }
            catch (ExternalException)
            {
                int num = (int)MessageBox.Show("An error occured setting the clipboard text, the text may not have been copied", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void rtxtIn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers != Keys.Control || e.KeyCode != Keys.A)
                return;
            this.rtxtIn.SelectAll();
            e.Handled = true;
        }

        private void rtxtOut_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers != Keys.Control || e.KeyCode != Keys.A)
                return;
            this.rtxtOut.SelectAll();
            e.Handled = true;
        }
    }
}
