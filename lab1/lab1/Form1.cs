using System;
using System.Windows.Forms;
// подключаем атрибут DllImport 
using System.Runtime.InteropServices;
using System.Text;
using static lab1.enums;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Drawing;
using System.Collections.Generic;
using System.Globalization;

namespace lab1
{
    public partial class Form1 : Form
    {
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern bool GetComputerName(StringBuilder lpBuffer, ref uint lpnSize);
        [DllImport("advapi32.dll", SetLastError = true)]
        static extern bool GetUserName(System.Text.StringBuilder sb, ref Int32 length);
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern uint GetWindowsDirectory(StringBuilder lpBuffer, uint uSize);
        [DllImport("kernel32")]
        static extern bool GetVersionEx(ref OSVERSIONINFOEX osvi);
        [DllImport("user32.dll")]
        static extern int GetSystemMetrics(SystemMetric smIndex);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SystemParametersInfo(uint uiAction, uint uiParam, StringBuilder pvParam, SPIF fWinIni);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SystemParametersInfo(SPI uiAction, uint uiParam, ref ANIMATIONINFO pvParam, SPIF fWinIni);

        [DllImport("user32.dll")]
        static extern uint GetSysColor(int nIndex);
        [DllImport("user32.dll")]
        static extern bool SetSysColors(int cElements, int[] lpaElements, int[] lpaRgbValues);
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool GetSystemTimes(out FILETIME lpIdleTime, out FILETIME lpKernelTime, out FILETIME lpUserTime);
        [DllImport("kernel32.dll")]
        static extern uint GetTimeZoneInformation(out TIME_ZONE_INFORMATION lpTimeZoneInformation);
        public enum HKL { HKL_PREV, HKL_NEXT }
        /// <summary>Sets the input locale identifier (formerly called the keyboard layout handle) for the calling thread or the current process. The input locale identifier specifies a locale as well as the physical layout of the keyboard</summary>
        /// <param name="hkl">Input locale identifier to be activated.</param>
        /// <param name="Flags">Specifies how the input locale identifier is to be activated.</param>
        /// <returns>The return value is of type HKL. If the function succeeds, the return value is the previous input locale identifier. Otherwise, it is zero</returns>
        [DllImport("user32.dll", SetLastError = true)]
        internal static extern HKL ActivateKeyboardLayout(HKL hkl, uint Flags);
        [DllImport("kernel32.dll")]
        static extern int GetCurrencyFormat(uint Locale, uint dwFlags, string lpValue, CURRENCYFMT test, IntPtr lpCurrencyStr, int cchCurrency);
        [DllImport("user32.dll")]
        static extern bool OemToChar(IntPtr lpszSrc, [Out] StringBuilder lpszDst);

        [StructLayout(LayoutKind.Sequential)]
        public struct UserRec
        {
            [MarshalAs(UnmanagedType.LPStruct)]
            public int userParam1;
        }
        [DllImport("kernel32.dll")]
        static extern int GetCurrencyFormat(uint Locale, uint dwFlags, string lpValue,
           [In, MarshalAs(UnmanagedType.LPStruct)] UserRec userRec, IntPtr lpCurrencyStr, int cchCurrency);
        [DllImport("kernel32.dll")]
        static extern uint GetLastError();
        [StructLayout(LayoutKind.Sequential)]
        public class CURRENCYFMT
        {
            [MarshalAs(System.Runtime.InteropServices.UnmanagedType.U4)]
            public UInt32 uiNumDigits;
            [MarshalAs(System.Runtime.InteropServices.UnmanagedType.U4)]
            public UInt32 uiLeadingZero;
            [MarshalAs(System.Runtime.InteropServices.UnmanagedType.U4)]
            public UInt32 uiGrouping;
            [MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPWStr)]
            public String lpDecimalSep;
            [MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPWStr)]
            public String lpThousandSep;
            [MarshalAs(System.Runtime.InteropServices.UnmanagedType.U4)]
            public UInt32 uiNegativeOrder;
            [MarshalAs(System.Runtime.InteropServices.UnmanagedType.U4)]
            public UInt32 uiPositiveOrder;
            [MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPWStr)]
            public String lpCurrencySymbol;
        };

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct TIME_ZONE_INFORMATION
        {
            [MarshalAs(UnmanagedType.I4)]
            public Int32 Bias;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string StandardName;
            public SYSTEMTIME StandardDate;
            [MarshalAs(UnmanagedType.I4)]
            public Int32 StandardBias;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string DaylightName;
            public SYSTEMTIME DaylightDate;
            [MarshalAs(UnmanagedType.I4)]
            public Int32 DaylightBias;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SYSTEMTIME
        {
            [MarshalAs(UnmanagedType.U2)] public short Year;
            [MarshalAs(UnmanagedType.U2)] public short Month;
            [MarshalAs(UnmanagedType.U2)] public short DayOfWeek;
            [MarshalAs(UnmanagedType.U2)] public short Day;
            [MarshalAs(UnmanagedType.U2)] public short Hour;
            [MarshalAs(UnmanagedType.U2)] public short Minute;
            [MarshalAs(UnmanagedType.U2)] public short Second;
            [MarshalAs(UnmanagedType.U2)] public short Milliseconds;

            public SYSTEMTIME(DateTime dt)
            {
                dt = dt.ToUniversalTime();  // SetSystemTime expects the SYSTEMTIME in UTC
                Year = (short)dt.Year;
                Month = (short)dt.Month;
                DayOfWeek = (short)dt.DayOfWeek;
                Day = (short)dt.Day;
                Hour = (short)dt.Hour;
                Minute = (short)dt.Minute;
                Second = (short)dt.Second;
                Milliseconds = (short)dt.Millisecond;
            }
        }
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        struct OSVERSIONINFOEX
        {
            public int dwOSVersionInfoSize;
            public int dwMajorVersion;
            public int dwMinorVersion;
            public int dwBuildNumber;
            public int dwPlatformId;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
            public string szCSDVersion;
            public UInt16 wServicePackMajor;
            public UInt16 wServicePackMinor;
            public UInt16 wSuiteMask;
            public byte wProductType;
            public byte wReserved;
        }

        class ItemColor
        {
            string itemName;//имя элемента
            Color itemColor;//цвет элемента
            bool hasChanged = false;//были изменения?

            public ItemColor(string itemName, Color itemColor)
            {
                this.ItemName = itemName;
                this.IItemColor = itemColor;
            }

            public string ItemName { get => itemName; set => itemName = value; }
            public Color IItemColor { get => itemColor; set => itemColor = value; }
            public bool HasChanged { get => hasChanged; set => hasChanged = value; }
        }
        public Form1()
        {
            InitializeComponent();
        }

        List<ItemColor> listSystemColors = new List<ItemColor>();
        private void Form1_Load(object sender, EventArgs e)
        {
            get_computer_name();
            get_user_name();
            get_system_path();
            get_version_os();
            get_system_metrics();
            get_system_parametrs();
            fillComboBoxes();
            listSystemColors = saveSystemColors();
            get_system_time();
            get_api();
        }

        private void get_computer_name()
        {
            StringBuilder stringBuilder= new StringBuilder();
            uint lpnSize = 100;
            GetComputerName(stringBuilder, ref lpnSize);
            lblCompName.Text = "Computer name: ";
            lblCompName.Text += stringBuilder.ToString();
        }
        private void get_user_name()
        {
            StringBuilder stringBuilder= new StringBuilder();
            Int32 lpnSize = 100;
            GetUserName(stringBuilder, ref lpnSize);
            lblUserName.Text = "User name: ";
            lblUserName.Text += stringBuilder.ToString();
        }
        private void get_system_path()
        {
            StringBuilder stringBuilder= new StringBuilder();
            uint uSize = 100;
            GetWindowsDirectory(stringBuilder, uSize);
            lblSysPath.Text = "System path: ";
            lblSysPath.Text += stringBuilder.ToString();
        }

        private void get_version_os()
        {
            OSVERSIONINFOEX temp = new OSVERSIONINFOEX();
            temp.dwOSVersionInfoSize = 100;
            GetVersionEx(ref temp);
            lblVersionOs.Text = "Version OS: ";
            lblVersionOs.Text += temp.dwOSVersionInfoSize;
        }

        private void get_system_metrics()
        {
            lblSystemMetrics.Text = "System Metrics: ";
            int h = GetSystemMetrics(SystemMetric.SM_CXFRAME);
            lblSystemMetrics.Text += "\nthe width of the horizontal border " + h.ToString();

            h = GetSystemMetrics(SystemMetric.SM_ARRANGE);
            lblSystemMetrics.Text += "\nhow the system arranged minimized windows " + h.ToString();

            h = GetSystemMetrics(SystemMetric.SM_CXICON);
            lblSystemMetrics.Text += "\nThe default width of an icon, in pixels " + h.ToString();

        }

        private void get_system_parametrs()
        {
            uint Size = 0;
            StringBuilder stringBuilder = new StringBuilder();
            SystemParametersInfo(SPI.SPI_GETDRAGFULLWINDOWS, Size, stringBuilder, SPIF.SPIF_SENDCHANGE);
            lblSystemParametrs.Text = "System Parametrs: " + SPI.SPI_GETDRAGFULLWINDOWS.ToString();

            SystemParametersInfo(SPI.SPI_GETBORDER, Size, stringBuilder, SPIF.SPIF_SENDCHANGE);

            lblSystemParametrs.Text += "\nGet borders: " + SPI.SPI_GETBORDER.ToString();
            SystemParametersInfo(SPI.SPI_GETDEFAULTINPUTLANG, Size, stringBuilder, SPIF.SPIF_SENDCHANGE);

            lblSystemParametrs.Text += "\nGetdefault ... : " + SPI.SPI_GETDEFAULTINPUTLANG.ToString();
        }

        void fillComboBoxes()
        {
            cbxSysEl.DataSource = Enum.GetValues(typeof(SystemElementsToColor));
            cbxSysEl.SelectedItem = null;
            cbxSysEl.Text = "Выберите элемент";
            foreach (System.Reflection.PropertyInfo prop in typeof(Color).GetProperties())
            {
                if (prop.PropertyType.FullName == "System.Drawing.Color")
                {
                    cbxColor.Items.Add(prop.Name);
                }
            }
            cbxColor.SelectedItem = null;
            cbxColor.Text = "Выберите цвет";
        }

        List<ItemColor> saveSystemColors()
        {
            List<ItemColor> list = new List<ItemColor>();//список системных цветов
            foreach (SystemElementsToColor se in cbxSysEl.Items)
            {
                int color1 = Convert.ToInt32(GetSysColor((int)se));
                Color color = Color.FromArgb(color1 & 0xFF, (color1 & 0xFF00) >> 8, (color1 & 0xFF0000) >> 16);
                list.Add(new ItemColor(se.ToString(), color));

            }
            return list;
        }
        void ResetColors()
        {
            listSystemColors.ForEach(x =>
            {
                if (x.HasChanged)
                {
                    Color oldColor = x.IItemColor;
                    SystemElementsToColor item = (SystemElementsToColor)Enum.Parse(typeof(SystemElementsToColor), x.ItemName);
                    SetSysColors(1, new int[] { (int)item }, new int[] { System.Drawing.ColorTranslator.ToWin32(oldColor) });
                    x.HasChanged = false;
                }
            });
            lblSCs.Text = "";
        }
        private void btnSetSysColor_Click(object sender, EventArgs e)
        {
            if (cbxColor.SelectedItem != null && cbxSysEl.SelectedItem != null)
            {
                Color newColor = Color.FromName(cbxColor.SelectedItem.ToString());
                SystemElementsToColor item = (SystemElementsToColor)Enum.Parse(typeof(SystemElementsToColor), cbxSysEl.SelectedItem.ToString());

                listSystemColors.ForEach(x =>
                {
                    if (x.ItemName == item.ToString())
                    {
                        lblSCs.Text = "oldColor: ";
                        GetSystemColor();
                        SetSysColors(1, new int[] { (int)item }, new int[] { System.Drawing.ColorTranslator.ToWin32(newColor) });
                        lblSCs.Text += "\nChosenColor: " + x.ItemName + " " + newColor.A + " " + newColor.R + " " + newColor.G + " " + newColor.B;
                        lblSCs.Text += "\nnewColor: ";

                        x.HasChanged = true;
                        GetSystemColor();
                    }
                });

            }
            else { System.Windows.Forms.MessageBox.Show("What?"); }
        }
        void GetSystemColor()
        {
            if (cbxSysEl.SelectedItem != null)
            {
                //элемент выбранный из списка
                SystemElementsToColor item = (SystemElementsToColor)Enum.Parse(typeof(SystemElementsToColor), cbxSysEl.SelectedItem.ToString());
                //возвращает RGB цвет элемента item 
                int color1 = Convert.ToInt32(GetSysColor((int)item));
                //преобразование RGB в Color
                Color color = Color.FromArgb(color1 & 0xFF, (color1 & 0xFF00) >> 8, (color1 & 0xFF0000) >> 16);
                lblSCs.Text += "\n" + item.ToString() + " " + color;
            }
        }

        private void btnResetSysCol_Click_1(object sender, EventArgs e)
        {
            ResetColors();
        }

        private void btnGetColor_Click(object sender, EventArgs e)
        {
            GetSystemColor();
        }

        [Obsolete]
        private void get_system_time()
        {
            FILETIME idleTime, kernelTime, userTime;
            GetSystemTimes(out idleTime, out kernelTime, out userTime);
            ulong idleTimeLong = ((ulong)idleTime.dwHighDateTime << 32) + (uint)idleTime.dwLowDateTime;             
            lblSystemTime.Text = "something: " + (idleTimeLong / TimeSpan.TicksPerSecond).ToString();

            TIME_ZONE_INFORMATION tIME_ZONE_INFORMATION = new TIME_ZONE_INFORMATION();
            uint h = GetTimeZoneInformation(out tIME_ZONE_INFORMATION);
            lblSystemTime.Text += "\ntime zone info" + tIME_ZONE_INFORMATION.StandardName;

            lblSystemTime.Text += "\nCalendar don't work";
        }

        private void get_api()
        {
            uint size = 0x00000008;
            ActivateKeyboardLayout(HKL.HKL_NEXT, size);
            lblWinAPI.Text = "ActiveKeyboardLayout: ";
            lblWinAPI.Text += size.ToString();
            uint h = GetLastError();
            lblWinAPI.Text += "\nGetLastError: " + h.ToString();
            oemtochar();
            get_currency();
        }
        private void oemtochar()
        {
            StringBuilder stringBuilder= new StringBuilder();
            IntPtr intPtr= IntPtr.Zero;
            OemToChar(intPtr, stringBuilder);
            lblWinAPI.Text += "\nOemToChar: ";
            lblWinAPI.Text += stringBuilder.ToString();
        }
        private void get_currency()
        {
            string str = "200.0m!";
            CURRENCYFMT cURRENCYFMT = new CURRENCYFMT();
            Decimal number = new Decimal();
            int temp = GetCurrencyFormat(0, 0, str, cURRENCYFMT, IntPtr.Zero, 0);

            if (temp != 0)
            {
                IntPtr ptrCurrencyStr = Marshal.AllocHGlobal((int)temp);

                temp = GetCurrencyFormat(0, 0, str, cURRENCYFMT, ptrCurrencyStr, (int)temp);
                lblWinAPI.Text += "\nCurrency: ";
                lblWinAPI.Text = cURRENCYFMT.lpDecimalSep;

                Marshal.FreeHGlobal(ptrCurrencyStr);
            }
            else { 
                int error = Marshal.GetLastWin32Error(); 

                lblWinAPI.Text += "\nCurrency2: ";
                lblWinAPI.Text += error.ToString();
            }
        }
    }
}
