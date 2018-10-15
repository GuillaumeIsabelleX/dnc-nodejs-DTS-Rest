using FXCMCommands;
using Newtonsoft.Json;

using System;

namespace dnc_nodejs_DTS_Rest
{
    class Program
    {
        static void Main(string[] args)
        {

            var proc = new System.Diagnostics.Process();
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.RedirectStandardInput = true;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardError = true;
            proc.StartInfo.FileName = "node";
            proc.StartInfo.Arguments = "main.js";
            proc.Start();
            proc.BeginOutputReadLine();

            // proc.StandardInput.WriteLine("2 + 2;");
            // proc.StandardInput.WriteLine("setTimeout(function(){ process.exit();}, 10000).suppressOut;");
            proc.OutputDataReceived += proc_OutputDataReceived;

            FXCMCommander fx = new FXCMCommander();

            proc.StandardInput.WriteLine(fx.GetSymbols);

            proc.WaitForExit();
        }

        static void proc_OutputDataReceived(object sender, System.Diagnostics.DataReceivedEventArgs e)
        {
            System.Console.WriteLine("-----------------------------------");
            string mydata = e.Data.ToString();

            System.Console.WriteLine("The data received is : " + mydata);

            if (mydata.Contains("\"") && mydata.Contains("{"))
            {
                try
                {

                    MyMessage yourObject = JsonConvert.DeserializeObject<MyMessage>(mydata);

                    System.Console.WriteLine("Converted... \n" +
                    "Name: " + yourObject.Name + "\n"
                    + "Phone: " + yourObject.Phone
                    );
                }
                catch (Exception)
                { }
            }
            else
            {
                System.Console.WriteLine("NOT JSON FORMATTED CONTENT DETECTED");
            }

        }
    }
    public class MyMessage
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }
    }


}

