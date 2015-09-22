﻿using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Configuration;

namespace FileProcessorApp
{
    public class SyncClaims : File_Processor_Abstract
    {
        string sourcePath = ConfigurationManager.AppSettings.Get("originalDirectory");
         string newPath = ConfigurationManager.AppSettings.Get("newDirectory");    
        
        
        public override void CopyToDropbox(object sender, EventArgs e)
        {
            //string sourcePath = @"C:\Users\20904\Desktop\olddest\";
            //string newPath = @"C:\Users\20904\Desktop\olddest\";

            //DirectoryInfo di = new DirectoryInfo(@"C:\Users\20904\Desktop\olddest\");

            //C:\\Users\\20904\\Desktop\\newdest

            string[] fileInfo = Directory.GetFiles(sourcePath);
            try
            {
                foreach (var item in fileInfo)
                {
                    string fileName = Path.GetFileName(item);
                    if (fileName.Equals("Claims.xlsx"))
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
