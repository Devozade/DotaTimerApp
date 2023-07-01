using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaTimerApp
{
    public class LabelUpdater
    {
        public static void UpdateLabel(Label label, string text, Form form)
        {
            if (label != null)            
            {
                ThreadInvokeHelper.SetText(form, label, text);
            }
        
        }
    }
}
