/* Copyright (C) 2008-2017, Nick Galko. All rights reserved.
*
* Your use and or redistribution of this software in source and / or
* binary form, with or without modification, is subject to: (i) your
* ongoing acceptance of and compliance with the terms and conditions of
* the License Agreement; and (ii) your inclusion of this notice
* in any version of this software that you use or redistribute.
* A copy of the License Agreement is available on repository of project
*/

using System;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}