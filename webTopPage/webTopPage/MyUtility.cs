using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace webTopPage
{
    class MyUtility
    {
        public static void WARNING(string text)
        {
            MessageBox.Show(text,
            "エラー",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
        }

        public static void CONFIRM(string text)
        {
            MessageBox.Show(text,
            "確認",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
        }
    }
}
