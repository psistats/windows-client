﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Psistats.App.Utils
{
    public partial class BaseForm : Form
    {
        delegate void SetComboBoxCallback(ComboBox control, string text);
        delegate void SetCheckedListBoxCallback(CheckedListBox control, bool[] items);
        delegate void SetWindowHeightCallback(Form control, int height);
        delegate void SetTextFieldContentCallback(TextBox control, string text);
        delegate void SetLabelContentCallback(Label control, string text);
        delegate void SetVisibleCallback(Control control, bool visible);
        delegate void ThreadShowCallback(Control control);
        delegate void ThreadCloseCallback(Form control);

        public void ThreadClose(Form control)
        {
            if (control.InvokeRequired)
            {
                ThreadCloseCallback d = new ThreadCloseCallback(ThreadClose);
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
                ThreadShowCallback d = new ThreadShowCallback(ThreadShow);
                this.Invoke(d, new object[] { control });
            }
            else
            {
                Debug.WriteLine("threadShow()");
                control.Show();
            }
        }

        public void SetCheckedListBox(CheckedListBox control, bool[] items)
        {
            if (control.InvokeRequired)
            {
                SetCheckedListBoxCallback d = new SetCheckedListBoxCallback(SetCheckedListBox);
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

        public void SetTextFieldContent(TextBox control, string text)
        {
            if (control.InvokeRequired)
            {
                SetTextFieldContentCallback d = new SetTextFieldContentCallback(SetTextFieldContent);
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
                SetLabelContentCallback d = new SetLabelContentCallback(SetLabelContent);
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
                SetWindowHeightCallback d = new SetWindowHeightCallback(SetWindowHeight);
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
                SetComboBoxCallback d = new SetComboBoxCallback(SetComboBox);
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
                SetVisibleCallback d = new SetVisibleCallback(SetVisible);
                control.Invoke(d, new object[] { control, visible });
            }
            else
            {
                control.Visible = visible;
            }
        }
    }
}
