using System;
using System.Resources;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.NetworkInformation;
using System.Security.Principal;
using Microsoft.VisualBasic;
using System.Diagnostics;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyProgram
{
    class JipseTerminal
    {
        static void Main(string[] args)

        {
            Console.Title = "JipseTerminal | Ver 0.2a";

            string[] commands = { "osver", "usr", "host", "proccount", "curdir", "termshell", "sysdir", "usrtype", "sysinf", "netinf", "exit", "archRepo" };
            
            Console.ForegroundColor= ConsoleColor.Blue;
            Console.WriteLine("Welcome to the Zaan Terminal Shell");
            Console.Write("~$");
            string commandInput = Console.ReadLine();
            //If statements for command input

            //osver
            if (commandInput == commands[0])
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(Environment.OSVersion.ToString());
            }

            //usr
            if (commandInput == commands[1])
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(Environment.UserName);
            }

            //host
            if (commandInput == commands[2])
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(Dns.GetHostName());
            }

            //proccount
            if (commandInput == commands[3])
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(Environment.ProcessorCount);
            }

            //curdir
            if (commandInput == commands[4])
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(Environment.CurrentDirectory);
            }

            //termshell
            if (commandInput == commands[5])
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("[[[[[[||");
                Console.WriteLine("      ||");
                Console.WriteLine("      ||");
                Console.WriteLine("/[[[[[[|");
                Console.WriteLine("||");
                Console.WriteLine("||");
                Console.WriteLine("|]]]]]]/");
                Console.WriteLine("");
                Console.WriteLine("Zaan Terminal Shell\nVersion: 0.1a\nOS Version: " + Environment.OSVersion);
            }

            //sysdir
            if (commandInput == commands[6])
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(Environment.SystemDirectory);
            }

            //usrtype
            if (commandInput == commands[7])
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(new WindowsAccountType());
            }

            //Sys Inf
            StringBuilder systemInfo = new StringBuilder(string.Empty);

            systemInfo.AppendFormat("Operation System:  {0}\n", Environment.OSVersion);
            systemInfo.AppendFormat("Processor Architecture:  {0}\n", Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE"));
            systemInfo.AppendFormat("Processor Model:  {0}\n", Environment.GetEnvironmentVariable("PROCESSOR_IDENTIFIER"));
            systemInfo.AppendFormat("Processor Level:  {0}\n", Environment.GetEnvironmentVariable("PROCESSOR_LEVEL"));
            systemInfo.AppendFormat("SystemDirectory:  {0}\n", Environment.SystemDirectory);
            systemInfo.AppendFormat("ProcessorCount:  {0}\n", Environment.ProcessorCount);
            systemInfo.AppendFormat("UserDomainName:  {0}\n", Environment.UserDomainName);
            systemInfo.AppendFormat("UserName: {0}\n", Environment.UserName);
            //Drives
            systemInfo.AppendFormat("LogicalDrives:\n ");
            foreach (System.IO.DriveInfo DriveInfo1 in System.IO.DriveInfo.GetDrives())
            {
                try
                {
                    systemInfo.AppendFormat("\t Drive: {0}\n\t\t VolumeLabel: " +
                        "{1}\n\t\t DriveType: {2}\n\t\t DriveFormat: {3}\n\t\t " +
                        "TotalSize: {4}\n\t\t AvailableFreeSpace: {5}\n",
                        DriveInfo1.Name, DriveInfo1.VolumeLabel, DriveInfo1.DriveType,
                        DriveInfo1.DriveFormat, DriveInfo1.TotalSize, DriveInfo1.AvailableFreeSpace);
                }
                catch
                {
                }
            }
            systemInfo.AppendFormat("Version:  {0}", Environment.Version);

            if (commandInput == commands[8])
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(systemInfo);
                Console.ReadKey();
            }

            //Netinf
            if (commandInput == commands[9])
            {
                NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
                foreach (NetworkInterface adapter in adapters)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    IPInterfaceProperties properties = adapter.GetIPProperties();
                    Console.WriteLine(adapter.Description);
                    Console.WriteLine("  DNS suffix .............................. : {0}",
                        properties.DnsSuffix);
                    Console.WriteLine("  DNS enabled ............................. : {0}",
                        properties.IsDnsEnabled);
                    Console.WriteLine("  Dynamically configured DNS .............. : {0}",
                        properties.IsDynamicDnsEnabled);

                    string hostName = Dns.GetHostName(); // Retrive the Name of HOST
                    Console.WriteLine("Host: " + hostName);
                    // Get the IP
                    string myIP = Dns.GetHostByName(hostName).AddressList[0].ToString();

                    Console.WriteLine("IP: " + myIP);
                    Console.ReadKey();

                }

                if (commandInput == commands[10])
                {
                    Environment.Exit(0);
                }

                if (commandInput == commands[11])
                {
                    WebClient webClient = new WebClient();
                    webClient.DownloadFile("http://mysite.com/myfile.txt", @"c:\myfile.txt");
                }

                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nRestart Program to continue use");
                Console.ReadLine();

                ;


            }
        }
    }


