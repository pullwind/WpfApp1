using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    public static class StringExtensions
    {
        public static bool Contains(this string source, string toCheck, StringComparison comp)
        {
            return source?.IndexOf(toCheck, comp) >= 0;
        }
    }
    internal class PCinfoClass
	{

        //https://stackoverflow.com/questions/2039186/reading-the-registry-and-wow6432node-key

        public static List<string> getListApp(string target_name, List<string> list2)
		{
            var list = new List<string>();
            StringComparison comp = StringComparison.OrdinalIgnoreCase;

            string registry_key = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";

            // if build app in 32bit,  then can not found 7-zip 
            // if build app in 64bit,  then cat not found filezilla
            // so here we try seach in different view of registry.
            Console.WriteLine("--------------32 bit view of Registry");
            using (var view32 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32))
            {
                // 32bit
                using(var key = view32.OpenSubKey(registry_key,false))
                {
                    foreach (string subkey_name in key.GetSubKeyNames())
                    {
                        //if (subkey_name.Contains(target_name, comp))
                        //{
                        //    list2.Add(subkey_name + "  Found in 32bit registry view");
                        //}

                        using (RegistryKey subkey = key.OpenSubKey(subkey_name))
                        {
                            var dn = subkey.GetValue("DisplayName") as string;



                            if (dn != null)
                            {
                                if (dn.Contains(target_name, comp))
                                {
                                    list.Add(dn + "  Found in 32bit registry view");
                                }
                            }

                            Console.WriteLine(subkey_name + " ---------- " + dn);

                        }
                    }
                }
            }

            //now , open 64bit view of registry
            Console.WriteLine("--------------64 bit view of Registry");
            using (var view32 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
            {
                // 32bit
                using (var key = view32.OpenSubKey(registry_key, false))
                {
                    foreach (string subkey_name in key.GetSubKeyNames())
                    {
                        //if (subkey_name.Contains(target_name, comp))
                        //{
                        //    list2.Add(subkey_name + "  Found in 64bit registry view");
                        //}

                        using (RegistryKey subkey = key.OpenSubKey(subkey_name))
                        {
                            var dn = subkey.GetValue("DisplayName") as string;



                            if (dn != null)
                            {
                                if (dn.Contains(target_name, comp))
                                {
                                    list.Add(dn + "  Found in 64bit registry view");
                                }
                            }

                            Console.WriteLine(subkey_name + " ---------- " + dn);

                        }
                    }
                }
            }

            

            return list; 
		
		}	


	}
}
