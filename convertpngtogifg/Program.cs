using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using BarcodeLib;

namespace convertpngtogifg
{
    static class Program
    /*
     * 
     * Program som konverterar png till gif för att utskrifter av barcodes från outlook/internet explorer ska bli rätt från Alma
     * 
     */
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           
            string result = Path.GetTempPath();
            //outlookscript skapar sina filer i tempkatalogen och bilder hamnar i "almaletter_files"
            string almapath = Path.Combine(result, "almaletter_files");
            try
            {
                string[] files = Directory.GetFiles(almapath, "*.png", SearchOption.TopDirectoryOnly);
                foreach (string fileName in files)
                {
                    System.Drawing.Image image1 = System.Drawing.Image.FromFile(fileName);
                    image1.Save(almapath + "\\" + Path.GetFileNameWithoutExtension(fileName) + ".gif", System.Drawing.Imaging.ImageFormat.Gif);
                }
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Error: The directory specified could not be found.");
            }
            catch (IOException e)
            {
                if (e.Source != null)
                    Console.WriteLine("IOException source: {0}", e.Source);
            }

            Application.Exit(); 
         }
    }
}
