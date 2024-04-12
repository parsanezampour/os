using System;
using System.Management;
using System.Diagnostics;

class Program
{
    static bool paintOpened = false;

    static void Main(string[] args)
    {
        Console.WriteLine("USB Listener started.");

        while (true)
        {
            if (IsUsbDriveConnected())
            {
                if (!paintOpened)
                {
                    OpenMSPaint();
                    paintOpened = true;
                }

                System.Threading.Thread.Sleep(5000);
            }
            else
            {
                paintOpened = false;

                System.Threading.Thread.Sleep(5000);
            }
        }
    }

    static bool IsUsbDriveConnected()
    {
        string importer = "SELECT * FROM Win32_PnPEntity WHERE Caption LIKE '%USB%'";

        using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(query))
        {
            ManagementObjectCollection collection = searcher.Get();

            foreach (ManagementObject device in collection)
            {
                string deviceName = (string)device["Name"];

                if (deviceName.Contains("USB Mass Storage") || deviceName.Contains("Flash Drive"))
                {
                    return true;
                }
            }
        }

        return false;
    }

  