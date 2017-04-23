using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Solution
{
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine()); // Number of elements which make up the association table.
        int Q = int.Parse(Console.ReadLine()); // Number Q of file names to be analyzed.
        //This will use the file Ext as the Key and the MIME type as the value.
        Dictionary <string, string> fileExtention = new Dictionary<string, string>();
        List<string> inputExtentions = new List<string>();
        for (int i = 0; i < N; i++)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            string Extention = inputs[0].ToLower();
            string MIMEType = inputs[1];
            fileExtention.Add(Extention, MIMEType);
        }
        for (int i = 0; i < Q; i++)
        {
            string FNAME = Console.ReadLine(); // One file name per line.
            FNAME = FNAME.ToLower();
            string extention = "Nothing";
            
            if(FNAME.Contains('.'))
            {
                extention = FNAME.Substring(FNAME.LastIndexOf('.')+1);
            }
            
            inputExtentions.Add(extention);
        }
             
        foreach(string extention in inputExtentions)
        {
            if(extention == "Nothing")
            {
                Console.WriteLine("UNKNOWN");
            }
            else if(fileExtention.ContainsKey(extention))
            {
                string MIMEType = fileExtention[extention];
                Console.WriteLine(MIMEType);
            }
            else
            {
                Console.WriteLine("UNKNOWN");
            }
        }  
    }
}