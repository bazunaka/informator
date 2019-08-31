using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace informator
{
    class Program
    {
        static void Main(string[] args)
        {
            OutputResult("Производитель ПЭВМ:", GetHardwareInfo("Win32_ComputerSystem", "Manufacturer"));
            OutputResult("Модель ПЭВМ:", GetHardwareInfo("Win32_ComputerSystem", "Model"));
            OutputResult("Имя ПЭВМ:", GetHardwareInfo("Win32_ComputerSystem", "Name"));
            Console.ReadKey();
        }

        private static List<string> GetHardwareInfo(string WIN32_Class, string ClassItemField)
        {
            List<string> result = new List<string>();

            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM " + WIN32_Class);

            try
            {
                foreach (ManagementObject obj in searcher.Get())
                {
                    result.Add(obj[ClassItemField].ToString().Trim());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        private static void OutputResult(string info, List<string> result)
        {
            if (info.Length > 0)
                Console.WriteLine(info);

            if (result.Count > 0)
            {
                for (int i = 0; i < result.Count; ++i)
                    Console.WriteLine(result[i]);
            }
        }
    }
}
