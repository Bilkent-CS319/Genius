using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using Shell32;

namespace CS319_Genius.Codes
{
    class Launcher : Job
    {

        // @Said, you need to assume you have an txt file with program names, exe names and path in it.
        // Not sure whether this System.Environment.CurrentDirectory works or not, so I would suggest you to test it first. 
        private string exeLocation = "";


        // You probably don't need to touch this. So ... 
        public Launcher(Responder.JobType typeJob, string inputWord) : base(typeJob, inputWord)
        {
        }

        // This part is quite tricky. So let me explain a little bit. What you need to do first is searching given keyWord
        // If you find the given keyWord in programDatabase.dat, just stick with the path in there. Execute it.
        // If you couldn't find the given keyWord in programDatabase.dat, you need to search all Program Files and Program Files (x86)
        // To do that, you need to implement checkPrograms() method.
        // If you couldn't find it in there too, just return false so we can warn user. 

        // This is the method where you should do all your job, execute program and return result which is either false or true.
        public override bool doJob()
        {

            return searchInDatabase();
        }

        // Check in database, if you find it, return its path as a string.
        private bool searchInDatabase() {

            string[] username = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Split('\\');

            string[] sourceOne = Directory.GetFiles(@"C:\ProgramData\Microsoft\Windows\Start Menu\Programs", "*.lnk", SearchOption.AllDirectories);
            string[] sourceTwo = Directory.GetFiles("C:\\Users\\" +  username[username.Length-1]+
                            "\\AppData\\Roaming\\Microsoft\\Windows\\Start Menu\\Programs", "*.lnk", SearchOption.AllDirectories);

            string[] fileArray = new string[sourceOne.Length + sourceTwo.Length];
            sourceOne.CopyTo(fileArray, 0);
            sourceTwo.CopyTo(fileArray, sourceOne.Length);

            // foreach (string i in fileArray) Console.WriteLine(i);

            string findThisString = this.keyWord;
            int strNumber;
            int strIndex = 0;
            for (strNumber = 0; strNumber < fileArray.Length; strNumber++)
            {
                strIndex = fileArray[strNumber].IndexOf(findThisString, StringComparison.OrdinalIgnoreCase);
                if (strIndex >= 0)
                    break;
            }

            if (strNumber < fileArray.Length)
            {
                Console.WriteLine("Path.. " + fileArray[strNumber]);
                Process.Start(@fileArray[strNumber]);
                exeLocation = GetShortcutTargetFile(fileArray[strNumber]);
                Console.WriteLine("EXE LOCATION : " + exeLocation);
                return true;
            }

            return false;
        }


        private static string GetShortcutTargetFile(string shortcutFilename)
        {
            string pathOnly = System.IO.Path.GetDirectoryName(shortcutFilename);
            string filenameOnly = System.IO.Path.GetFileName(shortcutFilename);

            Shell shell = new Shell();
            Folder folder = shell.NameSpace(pathOnly);
            FolderItem folderItem = folder.ParseName(filenameOnly);
            if (folderItem != null)
            {
                Shell32.ShellLinkObject link = (Shell32.ShellLinkObject)folderItem.GetLink;
                return link.Path;
            }

            return string.Empty;
        }


        public string getExeLocation()
        {
            string[] words = exeLocation.Split('\\');
            return words[words.Length-1];
        }


        // Check in folders, if you find it, ADD path, app name and exe name to the programDatabase.dat and return its path as a string.
        public string searchInFolders()
        {
            // Use this.
            string appName = this.keyWord;
          
            //Check all files and their dirs. 
            Console.WriteLine(string.Format("Going to list all applications" ));
            foreach (var item in Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall").GetSubKeyNames())
            {
                object programName = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\" + item).GetValue("DisplayName");
                object programLoc = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\" + item).GetValue("InstallLocation");
                Console.WriteLine(programName + " Path: " + programLoc);
            }
            
            // Check x86. Since most of the systems are using 64 bit. However Said, these are just the paths for Uninstallers. You still need to extract .exe's by hand.
            foreach (var item in Registry.LocalMachine.OpenSubKey("SOFTWARE\\WOW6432Node\\Microsoft\\Windows\\CurrentVersion\\Uninstall").GetSubKeyNames())
            {
                object programName = Registry.LocalMachine.OpenSubKey("SOFTWARE\\WOW6432Node\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\" + item).GetValue("DisplayName");
                object programLoc = Registry.LocalMachine.OpenSubKey("SOFTWARE\\WOW6432Node\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\" + item).GetValue("InstallLocation");
                Console.WriteLine(programName + " Path: " + programLoc);
            }


            return null;
        }
    }
}
