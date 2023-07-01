using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaTimerApp
{
    internal class ButtonUpdater
    {

        public static void UpdateButton(Button button, bool status, Form form)
        {
            if (status)
            {
                ThreadInvokeHelper.EnableButton(form, button);
                return;
            }                      
            ThreadInvokeHelper.DisableButton(form, button);
        
        }
    }
}
