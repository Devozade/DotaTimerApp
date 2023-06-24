using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaTimerApp
{
    internal class ThreadInvokeHelper
    {
        delegate void SetTextCallback(Form form, Label ctrl, string text);
        delegate void DisableButtonCallback(Form form, Button button);
        delegate void EnableButtonCallback(Form form, Button button);
        public delegate void MethodDelegate();


        public static void SetText(Form form, Label ctrl, string text)
        {
            if (ctrl.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                form.Invoke(d, new object[] { form, ctrl, text });
            }
            else
            {
                ctrl.Text = text;
            }
        }

        public static void DisableButton(Form form, Button button)
        {
            if (button.InvokeRequired)
            {
                DisableButtonCallback d = new DisableButtonCallback(DisableButton);
                form.Invoke(d, new object[] { form, button });
            }
            else
            {
                button.Enabled = false;
            }
        }
        public static void EnableButton(Form form, Button button)
        {
            if (button.InvokeRequired)
            {
                EnableButtonCallback d = new EnableButtonCallback(EnableButton);
                form.Invoke(d, new object[] { form, button });
            }
            else
            {
                button.Enabled = true;
            }
        }

        public static void InvokeOnUIThread(Form form, MethodDelegate method)
        {
            if (form.InvokeRequired)
            {
                form.Invoke(method, new object[] { });
            }
            else
            {
                method();
            }
        }
    }
}
