using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;

namespace SP2_usingAPI
{
    class Program
    {
        //function import 
        [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern SafeFileHandle CreateFile(
                string fileName,
                [MarshalAs(UnmanagedType.U4)] FileAccess fileAccess,
                [MarshalAs(UnmanagedType.U4)] FileShare fileShare,
                IntPtr securityAttributes,
                [MarshalAs(UnmanagedType.U4)] FileMode creationDisposition,
                FileAttributes flags,
                IntPtr template);

        //function to read 
        private static byte[] ReadDrive(string FileName, int sizeToRead)
        {

            if (sizeToRead < 1)
                throw new System.ArgumentException("Size parameter cannot be null or 0 or less than 0!");
            SafeFileHandle drive = CreateFile(// возвращаемое значение - открытый дескриптор заданного файла
                fileName: FileName,//имя файла для чтения 
                         fileAccess: FileAccess.Read,//доступ только для чтения 
                         fileShare: FileShare.Write | FileShare.Read | FileShare.Delete,
                         securityAttributes: IntPtr.Zero,
                         creationDisposition: FileMode.OpenOrCreate,//создать или открыть существующий файл 
                         flags: FileAttributes.Normal, // У файла нет других установленных атрибутов 
                         template: IntPtr.Zero);
            if (drive.IsInvalid)
            {
                throw new IOException("Unable to access drive. Win32 Error Code " + Marshal.GetLastWin32Error());
                //if get windows error code 5 this means access denied. 
                //You must try to run the program as admin privileges. 
            }
            //чтение данных по дескриптору файла 
            FileStream diskStreamToRead = new FileStream(drive, FileAccess.Read);
            byte[] buf = new byte[512];
            diskStreamToRead.Read(buf, 0, 512);
            try { diskStreamToRead.Close(); } catch { }//закрытие файлового потока 
            try { drive.Close(); } catch { }//закрытие дескриптора 
            return buf;
        }
        //function to write 
        private static void writeToDisk(string lpFileName, byte[] dataToWrite)
        {
            if (dataToWrite == null) throw new System.ArgumentException("dataToWrite parameter cannot be null!"); 


            SafeFileHandle drive = CreateFile(
                fileName: lpFileName,//название файла для записи данных 
                             fileAccess: FileAccess.Write,//доступ только для записи 
                             fileShare: FileShare.Write | FileShare.Read | FileShare.Delete,
                             securityAttributes: IntPtr.Zero,
                             creationDisposition: FileMode.Create,//создает новый файл/ если файл создан удаляет 
                             flags: FileAttributes.Normal, //with this also an enum can be used. (as described above as EFileAttributes)
                             template: IntPtr.Zero);

            FileStream diskStreamToWrite = new FileStream(drive, FileAccess.Write);
            diskStreamToWrite.Write(dataToWrite, 0, dataToWrite.Length);//запись данных в файл
            try { diskStreamToWrite.Close(); } catch { }
            try { drive.Close(); } catch { }
        }
        static void Main(string[] args)
        {   /* 
             * Задание: 
             * Изменить регистр содержимого файла 
             */

            byte[] buf = ReadDrive("tt.txt", 512); 
                                                   
            string text = System.Text.Encoding.UTF8.GetString(buf);
            Console.WriteLine("Text from tt.txt: \n" + text);
            string new_text = "";
            
            foreach (char c in text)
            {
                new_text += c.ToString().ToUpper();
            }
            writeToDisk("pp.txt", System.Text.Encoding.UTF8.GetBytes(new_text));
            buf = ReadDrive("pp.txt", 512);
            Console.WriteLine("New text: \n" + System.Text.Encoding.UTF8.GetString(buf));
        }
    }
}