using System.Diagnostics;
using System.Runtime.InteropServices;

namespace WinFormsApp1
{
    public partial class MainForm : Form
    {
        private List<Point> clickPositions = new List<Point>();
        List<string> csvLines = new List<string>();
        private bool recording = false;


        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);

        const int VK_CONTROL = 0x11;
        const int VK_V = 0x56;
        const uint KEYEVENTF_KEYUP = 0x0002;
        private LowLevelMouseProc mouseProc;
        private IntPtr mouseHook;

        public MainForm()
        {
            InitializeComponent();
            this.Load += MainForm_Load;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.mouseProc = HookCallback;
            this.mouseHook = SetHook(this.mouseProc);
        }

        private void btnStartRecording_Click(object sender, EventArgs e)
        {
            if (recording)
            {
                recording = false;
                clickPositions.RemoveAt(clickPositions.Count - 1);
                this.status.Text = $"{clickPositions.Count}";//"stopped. Ready to replay";
                return;
            }
            recording = true;
            clickPositions.Clear();
            this.status.Text = "Recording seq";
        }

        private void btnReplay_Click(object sender, EventArgs e)
        {
            if (recording)
            {
                MessageBox.Show("Recording was stopped. ready to engage");
            }
            ReplayMouseClicks();
        }

        private void loadCSV_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV Files|*.csv";
            openFileDialog.Title = "Select a CSV File";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                try
                {
                    csvLines = new List<string>(File.ReadAllLines(filePath));
                    if (csvLines.Count > 0)
                    {
                        this.checkBox1.Checked = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error reading CSV file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ReplayMouseClicks()
        {
            Point position = new Point();
            if (csvLines.Count == 0)
            {
                MessageBox.Show("CSV NOT LOADED!");
                return;
            }

            MessageBox.Show("Replay will start after pressing ok until csv lines will end");

            int indexer = 0;
            while (indexer < csvLines.Count)
            {
                List<string> csvSplit = new List<string>(csvLines[indexer].Split(new string[] { this.textBox1.Text }, StringSplitOptions.None));

                for (int i = 0; i < clickPositions.Count-1; i++)
                {

                    Cursor.Position = clickPositions[i];
                    try
                    {
                        string lineToPaste = csvSplit[i];

                        Clipboard.SetText(lineToPaste);
                        mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                        mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                        keybd_event(VK_CONTROL, 0, 0, UIntPtr.Zero);
                        keybd_event(VK_V, 0, 0, UIntPtr.Zero);
                        keybd_event(VK_V, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
                        keybd_event(VK_CONTROL, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
                      
                       
                        Thread.Sleep(100);
                    }
                    catch { }
                }


                Cursor.Position = clickPositions[clickPositions.Count-1];
                mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                Thread.Sleep(1000 * Convert.ToInt16(this.textBox2.Text));

                indexer++;
            }

            MessageBox.Show("Task end");
            this.Close();
        }



        private const int WH_MOUSE_LL = 14;
        private const int WM_LBUTTONDOWN = 0x0201;
        private const int WM_LBUTTONUP = 0x0202;
        private const uint MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const uint MOUSEEVENTF_LEFTUP = 0x0004;

        private IntPtr SetHook(LowLevelMouseProc proc)
        {
            using (ProcessModule curModule = Process.GetCurrentProcess().MainModule)
            {
                return SetWindowsHookEx(WH_MOUSE_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private delegate IntPtr LowLevelMouseProc(int nCode, IntPtr wParam, IntPtr lParam);

        private IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
          
            if (nCode >= 0 && (wParam == (IntPtr)WM_LBUTTONDOWN || wParam == (IntPtr)WM_LBUTTONUP))
            {
                MSLLHOOKSTRUCT hookStruct = (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT));

        
                if (recording && (clickPositions.Count == 0 || clickPositions.Last() != hookStruct.pt))
                {
                    clickPositions.Add(hookStruct.pt);
                }
            }

            
            return CallNextHookEx(IntPtr.Zero, nCode, wParam, lParam);
        }

        private struct MSLLHOOKSTRUCT
        {
            public Point pt;
            public int mouseData;
            public int flags;
            public int time;
            public IntPtr dwExtraInfo;
        }


        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelMouseProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("user32.dll")]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, int dwExtraInfo);

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }

}

