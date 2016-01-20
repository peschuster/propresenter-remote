using System;
using System.Windows.Forms;

namespace ProPresenterRemote
{
    internal static class FormExtensions
    {
        public static void Invoke(this Control control, Action action)
        {
            control.Invoke((Delegate)action);
        }
    }
}