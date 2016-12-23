using System;
using System.IO;
using System.Diagnostics;


namespace Launcher
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] fileArray = Directory.GetFiles(@"C:\ProgramData\Microsoft\Windows\Start Menu\Programs", "*.lnk", SearchOption.AllDirectories);
            for (int i = 0; i < fileArray.Length; i++)
            {

                Console.WriteLine(fileArray[i]);
            }

            string findThisString = "excel";
            int strNumber;
            int strIndex = 0;
            for (strNumber = 0; strNumber < fileArray.Length; strNumber++)
            {
                strIndex = fileArray[strNumber].IndexOf(findThisString, StringComparison.OrdinalIgnoreCase);
                if (strIndex >= 0)
                    break;
            }
            Console.WriteLine("String number: {0}\nString index: {1}",
                        strNumber, strIndex);
            if (strNumber < fileArray.Length)
            {
                Process.Start(@fileArray[strNumber]);
            }
            else
            {
                Console.WriteLine("Searching application couldn't found!");
            }
        }
    }
}
