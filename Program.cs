using System;
using System.Windows.Forms;

namespace _25521643_TangThiThanhTam_Lab2
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new FormDieuHuong());
        }
    }
}