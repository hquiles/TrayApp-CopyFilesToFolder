using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Configuration;

namespace FileProcessorApp
{
    public class SyncRegistration : File_Processor_Abstract
    {

        string sourcePath = ConfigurationManager.AppSettings.Get("originalDirectory");
        string newPath = ConfigurationManager.AppSettings.Get("newDirectory");

        public override void CopyToDropbox(object sender, EventArgs e)
        {
            
            
            string[] fileInfo = Directory.GetFiles(sourcePath);
            try
            {
                foreach (var item in fileInfo)
                {
                    string fileName = Path.GetFileName(item);
                    if (fileName.StartsWith("Registration") && fileName.EndsWith(".xlsx"))
                    {

                        string sourceFile = Path.Combine(sourcePath, fileName);
                        string destinationLocation = Path.Combine(newPath, fileName);
                        File.Copy(item, destinationLocation);
                    }

                }
            }
            catch (IOException ex)
            {

                Debug.Print(ex.InnerException + "\n" + ex.Message);
            }


        }

    }
}
