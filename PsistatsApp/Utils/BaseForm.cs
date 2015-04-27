using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Psistats.App.Utils
{
    /// <summary>
    /// Base form
    /// </summary>
    /// <remarks>
    /// Provides a variety of helpful methods for threadsafe manipulation of
    /// form elements.
    /// </remarks>
    public partial class BaseForm : Form
    {
        protected delegate void SetComboBoxCallback(ComboBox control, string text);
        protected delegate void SetCheckBoxCallback(CheckBox control, bool value);
        protected delegate void SetCheckedListBoxCallback(CheckedListBox control, bool[] items);
        protected delegate void SetWindowHeightCallback(Form control, int height);
        protected delegate void SetTextContentCallback(Control control, string text);
        protected delegate void SetLabelContentCallback(Label control, string text);
        protected delegate void SetVisibleCallback(Control control, bool visible);
        protected delegate void ThreadShowCallback(Control control);
        protected delegate void ThreadCloseCallback(Form control);
        protected delegate void ThreadEnableCallback(Control control, bool enabled);

        public void ThreadEnable(Control control, bool enabled)
        {
            if (control.InvokeRequired)
            {
                ThreadEnableCallback d = new ThreadEnableCallback(this.ThreadEnable);
                control.Invoke(d, new object[] { control, enabled });
            }
            else
            {
                control.Enabled = enabled;
            }
        }

        public void ThreadClose(Form control)
        {
            if (control.InvokeRequired)
            {
                ThreadCloseCallback d = new ThreadCloseCallback(this.ThreadClose);
                control.Invoke(d, new object[] { control });
            }
            else
            {
                control.Close();
            }
        }

        public void ThreadShow(Control control)
        {
            
            if (this.InvokeRequired)
            {
                ThreadShowCallback d = new ThreadShowCallback(this.ThreadShow);
                this.Invoke(d, new object[] { control });
            }
            else
            {
                Debug.WriteLine("threadShow()");
                control.Show();
            }
        }

        public void SetCheckBox(CheckBox control, bool value)
        {
            if (control.InvokeRequired)
            {
                SetCheckBoxCallback d = new SetCheckBoxCallback(this.SetCheckBox);
                control.Invoke(d, new object[] { control, value });
            }
            else
            {
                control.Checked = value;
            }
        }
        
        public void SetCheckedListBox(CheckedListBox control, bool[] items)
        {
            if (control.InvokeRequired)
            {
                SetCheckedListBoxCallback d = new SetCheckedListBoxCallback(this.SetCheckedListBox);
                control.Invoke(d, new object[] { control, items });
            }
            else
            {
                for (int idx = 0; idx < items.Count(); idx++)
                {
                    control.SetItemChecked(idx, items[idx]);
                }
            }
        }

        public void SetTextContent(Control control, string text)
        {
            if (control.InvokeRequired)
            {
                SetTextContentCallback d = new SetTextContentCallback(this.SetTextContent);
                control.Invoke(d, new object[] { control, text });
            }
            else
            {
                control.Text = text;
            }
        }

        public void SetLabelContent(Label control, string text)
        {
            if (control.InvokeRequired)
            {
                SetLabelContentCallback d = new SetLabelContentCallback(this.SetLabelContent);
                control.Invoke(d, new object[] { control, text });
            }
            else
            {
                control.Text = text;
            }
        }

        public void SetWindowHeight(Form control, int height)
        {
            if (control.InvokeRequired)
            {
                SetWindowHeightCallback d = new SetWindowHeightCallback(this.SetWindowHeight);
                control.Invoke(d, new object[] { control, height });
            }
            else
            {
                control.Height = height;
            }
        }

        public void SetComboBox(ComboBox control, string text)
        {
            if (control.InvokeRequired)
            {
                SetComboBoxCallback d = new SetComboBoxCallback(this.SetComboBox);
                control.Invoke(d, new object[] { control, text });
            }
            else
            {
                control.SelectedItem = text;
            }
        }

        public void SetVisible(Control control, bool visible)
        {
            if (control.InvokeRequired)
            {
                SetVisibleCallback d = new SetVisibleCallback(this.SetVisible);
                control.Invoke(d, new object[] { control, visible });
            }
            else
            {
                control.Visible = visible;
            }
        }
    }
}
