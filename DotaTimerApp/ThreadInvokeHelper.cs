using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
            if (ctrl.InvokeRequired && !ctrl.IsDisposed)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                form.BeginInvoke(d, new object[] { form, ctrl, text });
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
                form.BeginInvoke(d, new object[] { form, button });
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
                form.BeginInvoke(d, new object[] { form, button });
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
                form.BeginInvoke(method, new object[] { });
            }
            else
            {
                method();
            }
        }

        public static void updateImage(Form form,PictureBox pictureBox, string resourceName)
        {
            Image image = (Image)Properties.Resources.ResourceManager.GetObject(resourceName);

            if (image != null)
            {
                if (pictureBox.InvokeRequired)
                {
                    pictureBox.Invoke(new Action(() => {pictureBox.Image = image;}));
                }
                else
                {
                    pictureBox.Image = image;
                }
            }
        }
    }
}
