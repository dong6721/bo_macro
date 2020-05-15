using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using Tesseract;
using System.Runtime.InteropServices;
using System.Windows.Interop;

namespace bo_macro
{
    
    public partial class Form1 : Form
    {                
        [DllImport("user32.dll")]
        public static extern int FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        static extern bool PrintWindow(IntPtr hwnd, IntPtr hDC, uint nFlags);
        [DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowRgn(IntPtr hWnd, IntPtr hRgn);
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);
        [DllImport("user32")]
        public static extern int SetWindowPos(IntPtr hwnd, int hWndInsertAfter, int x, int y, int cx, int cy, int wFlags);
        [DllImport("user32")]
        public static extern Int32 GetCursorPos(out POINT pt);
        public struct POINT
        {
            public Int32 x;
            public Int32 y;
        }
        [DllImport("user32")]
        public static extern Int32 SetCursorPos(Int32 x, Int32 y);
        [DllImport("user32")]
        public static extern int GetWindowRect(IntPtr hwnd,out RECT lpRect);
        public struct RECT
        {
            public int Left;        // x position of upper-left corner
            public int Top;         // y position of upper-left corner
            public int Right;       // x position of lower-right corner
            public int Bottom;      // y position of lower-right corner
        }
        [DllImport("user32")]
        public static extern Int32 SendMessage(IntPtr hWnd, Int32 uMsg, IntPtr WParam, IntPtr LParam);
        [DllImport("user32")]
        public static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")]
        static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc callback, IntPtr hInstance, uint threadId);
        [DllImport("user32.dll")]
        static extern bool UnhookWindowsHookEx(IntPtr hInstance);
        [DllImport("user32.dll")]
        static extern IntPtr CallNextHookEx(IntPtr idHook, int nCode, int wParam, IntPtr lParam);
        [DllImport("kernel32.dll")]
        static extern IntPtr LoadLibrary(string lpFileName);
        [DllImport("gdi32.dll")]
        static extern IntPtr CreateRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect);
        [DllImport("ImageSearchDLL.dll")]
        private static extern IntPtr ImageSearch(int x, int y, int right, int bottom, [MarshalAs(UnmanagedType.LPStr)]string imagePath);

        public IntPtr hwnd;
        Thread connectThread;
        Thread loopThread;
        public delegate void DelegateStatusText(string strText);
        public delegate void DelegateSet_New_Drop();
        public delegate void DelegateSet_Value();
        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x100;
        public static bool loop_thread=false;
        public static bool in_battle = false;
        private LowLevelKeyboardProc _proc = hookProc;
        private static IntPtr hhook = IntPtr.Zero;
        public static bool oil_check = false;
        public static bool drop_check = false;
        public static string oil_val;
        public static string drop_val;
        public static string stage_val;

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load1(object sender, EventArgs e)
        {
            connectThread = new Thread(new ThreadStart(connect));
            loopThread = new Thread(new ThreadStart(loop));
            connectThread.Start();
            loopThread.Start();
            SetHook();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //testing set
            ShowWindowAsync(hwnd, 1);
            SetWindowPos(hwnd, 0, 0, 0, 1280, 750, 0x2);

            /*Bitmap cap = PrintWindow(hwnd);
            RECT brt;
            GetWindowRect(hwnd, out brt);
            //cap = crop(cap, new Rectangle(770, 30, 80, 50));
            cap = crop(cap, new Rectangle(200, 130, 30, 270));      //new 함선
            var ocr = new TesseractEngine("./tessdata", "jpn", EngineMode.Default);
            var texts = ocr.Process(cap);
            MessageBox.Show(texts.GetText());
            Form2 newForm = new Form2(cap);
            newForm.Show();*/

            //set window position setting
            /*ShowWindowAsync(hwnd, 1);
            IntPtr basehwnd = GetForegroundWindow();
            SetForegroundWindow(hwnd);
            RECT brt;
            GetWindowRect(hwnd, out brt);
            try
            {
                SetWindowPos(hwnd, 0, 0, 0, 1280, 750, 0x2);                
                Thread.Sleep(40);
                string[] search = UseImageSearch("*70 img\\2.png", hwnd);
                if (search == null)
                    return;                   //서치실패의 경우 return
                int[] search_ = new int[search.Length];
                for (int j = 0; j < search.Length; j++)
                {
                    search_[j] = Convert.ToInt32(search[j]);
                }
                SetCursorPos(search_[1] + (search_[3] / 2), search_[2] + (search_[4] / 2));
                SendMessage(hwnd, 0x0201, (IntPtr)0x00000001, (IntPtr)0);
                SendMessage(hwnd, 0x0202, (IntPtr)0x00000000, (IntPtr)0);                
            }
            catch
            {

            }
            finally
            {
                //SetWindowPos(hwnd, 0, 0, 0, brt.Right - brt.Left, brt.Bottom - brt.Top, 0x2);
                SetForegroundWindow(basehwnd);
            }*/

            

            //image search algorhtm

            /*ShowWindowAsync(hwnd, 1);
            SetForegroundWindow(hwnd);
            Thread.Sleep(100);
            string[] search = UseImageSearch("*70 img\\gas.png", hwnd);
            if (search == null)
                return;                   //서치실패의 경우 return
            int[] search_ = new int[search.Length];
            for (int j = 0; j < search.Length; j++)
            {
                search_[j] = Convert.ToInt32(search[j]);
            }
            SetCursorPos(search_[1] + (search_[3]/2), search_[2] + (search_[4]/2));
            SendMessage(hwnd, 0x0201, (IntPtr)0x00000001, (IntPtr)0);
            SendMessage(hwnd, 0x0202, (IntPtr)0x00000000, (IntPtr)0);
            */
        }

        //hooking
        public void SetHook()
        {
            IntPtr hInstance = LoadLibrary("User32");
            hhook = SetWindowsHookEx(WH_KEYBOARD_LL, _proc, hInstance, 0);
        }
        public static void UnHook()
        {
            UnhookWindowsHookEx(hhook);
        }
        public static IntPtr hookProc(int code, IntPtr wParam, IntPtr lParam)
        {
            if (code >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                if (vkCode.ToString() == "116")     //F5 = 116
                {
                    loop_thread = !loop_thread;
                }
                return CallNextHookEx(hhook, code, (int)wParam, lParam);                
            }
            else
                return CallNextHookEx(hhook, code, (int)wParam, lParam);
        }
        //hooking end
            
        //print window setting
        public static Bitmap PrintWindow(IntPtr hwnd)
        {
            Rectangle rc = Rectangle.Empty;
            Graphics gfxWin = Graphics.FromHwnd(hwnd);
            rc = Rectangle.Round(gfxWin.VisibleClipBounds);
            Bitmap bmp = new Bitmap(rc.Width, rc.Height + 30, PixelFormat.Format32bppArgb);
            Graphics gfxBmp = Graphics.FromImage(bmp);
            IntPtr hdcBitmap = gfxBmp.GetHdc();
            bool succeeded = PrintWindow(hwnd, hdcBitmap, 2);
            gfxBmp.ReleaseHdc(hdcBitmap);
            if (!succeeded)
            {
                gfxBmp.FillRectangle(new SolidBrush(Color.Gray), new Rectangle(Point.Empty, bmp.Size));
            }
            IntPtr hRgn = CreateRectRgn(0, 0, 0, 0);
            GetWindowRgn(hwnd, hRgn);
            Region region = Region.FromHrgn(hRgn);
            if (!region.IsEmpty(gfxBmp))
            {
                gfxBmp.ExcludeClip(region);
                gfxBmp.Clear(Color.Transparent);
            }
            gfxBmp.Dispose();
            //bmp.Save("test.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
            return bmp;
        }
        public static Bitmap crop(Bitmap src,Rectangle cropRect)
        {
            Bitmap target = new Bitmap(cropRect.Width, cropRect.Height);
            using (Graphics g = Graphics.FromImage(target))
            {
                g.DrawImage(src, new Rectangle(0, 0, target.Width, target.Height),
                                 cropRect,
                                 GraphicsUnit.Pixel);
            }
            return target;
        }
        public static String[] UseImageSearch(string imgPath,IntPtr hwnd)
        {
            /*int right = Screen.PrimaryScreen.WorkingArea.Right;
            int bottom = Screen.PrimaryScreen.WorkingArea.Bottom;*/
            RECT brt;
            GetWindowRect(hwnd,out brt);
            IntPtr result = ImageSearch(brt.Left, brt.Top, brt.Right, brt.Bottom, imgPath);
            String res = Marshal.PtrToStringAnsi(result);
            //이미지 서치 결과값  0번 =  결과 성공1 실패0 1,2번 = x,y 3,4번 = 이미지의 세로가로길이
            //res = 한자씩 나눠져있음
            if (res[0] == '0') //res를 이용하여 이미지여부 확인
            {
                /*MessageBox.Show("Not found");*/
                return null;
            }
            String[] data = res.Split('|'); // |로 결과 값을 조각
            /*int x; int y;
            int.TryParse(data[1], out x); //x좌표
            int.TryParse(data[2], out y); //y좌표
            for(int i=0; i<5; i++)
              MessageBox.Show(i + "번째 " + data[i]);*/
            return data;
        }

        //invoke list
        private void setStatus(string text)
        {
            if(currentStatus.InvokeRequired)
            {
                var d = new DelegateStatusText(setStatus);
                currentStatus.Invoke(d, new object[] { text });
            }
            else
            {
                currentStatus.Text = text;
            }
        }
        private void set_new_drop()
        {
            if (currentStatus.InvokeRequired)
            {
                var d = new DelegateSet_New_Drop(set_new_drop);
                currentStatus.Invoke(d, new object[] { });
            }
            else
            {
                drop_ship_val.Text = (Int32.Parse(drop_ship_val.Text) - 1).ToString();
            }
        }
        private void set_value()
        {
            if(currentStatus.InvokeRequired)
            {
                var d = new DelegateSet_Value(set_value);
                currentStatus.Invoke(d, new object[] { });
            }
            else
            {
                oil_val = min_oil_val.Text;
                drop_val = drop_ship_val.Text;
                stage_val = select_stage.Text;
                min_oil_val.Enabled = false;
                drop_ship_val.Enabled = false;
                select_stage.Enabled = false;
                min_oil_checkBox.Enabled = false;
                drop_ship_checkBox.Enabled = false;

            }
        }
        private void set_unlock()
        {
            if (currentStatus.InvokeRequired)
            {
                var d = new DelegateSet_Value(set_unlock);
                currentStatus.Invoke(d, new object[] { });
            }
            else
            {
                min_oil_val.Enabled = true;
                drop_ship_val.Enabled = true;
                select_stage.Enabled = true;
                min_oil_checkBox.Enabled = true;
                drop_ship_checkBox.Enabled = true;
            }
        }
        //invoke end

        //thread list
        private void connect()
        {
            //connectThread
            while(true)
            {
                Thread.Sleep(40);
                //string test = "蒼藍の誓い-ブルーオースWindows版";
                //int hwnds = FindWindow(null, test);
                int hwnds = FindWindow("UnityWndClass", null);
                hwnd = new IntPtr(hwnds);
                try
                {
                    if (hwnd.Equals((IntPtr)0))
                    {
                        setStatus("연결 실패!");
                    }
                    else
                    {
                        setStatus("연결 성공!");
                    }
                }
                catch
                {
                    //MessageBox.Show("Label Set Error!");
                }
                
            }            
        }        
        private void loop()
        {            
            //loopthread(macro Thread);
            while (true)
            {
                if (!loop_thread)
                {
                    set_unlock();
                    Thread.Sleep(1500);
                    continue;
                }            
                Thread.Sleep(1500);
                set_value();
                ShowWindowAsync(hwnd, 1);
                SetForegroundWindow(hwnd);

                //image search algorhtm
                SetWindowPos(hwnd, 1, 0, 0, 1280, 750, 2);
                string filePath = "*50 img\\";
                Thread.Sleep(40);
                if(in_battle)
                {
                    //전투화면
                    string[] search = null;
                    String FolderName = "img/battle";
                    System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(FolderName);
                    foreach (System.IO.FileInfo File in di.GetFiles())
                    {
                        if (File.Extension.ToLower().CompareTo(".png") == 0 || File.Extension.ToLower().CompareTo(".jpg") == 0)
                        {
                            String FileNameOnly = File.Name.Substring(0, File.Name.Length);
                            //String FullFileName = File.FullName;
                            string temp = filePath + FileNameOnly;
                            search = UseImageSearch(temp, hwnd);
                            if (search == null)
                                continue;
                            else
                                break;
                        }
                    }
                    if (search == null)
                    {
                        //new_drop_check
                        Bitmap cap = PrintWindow(hwnd);
                        RECT brt;
                        GetWindowRect(hwnd, out brt);                        
                        cap = crop(cap, new Rectangle(200, 130, 30, 270));      //new ship
                        var ocr = new TesseractEngine("./tessdata", "jpn", EngineMode.Default);
                        var texts = ocr.Process(cap);
                        if(texts.GetText().Equals("&&"))
                        {
                            set_new_drop();
                        }
                        SetCursorPos((brt.Top + brt.Bottom) / 2, (brt.Left + brt.Right) / 2);
                        SendMessage(hwnd, 0x0201, (IntPtr)0x00000001, (IntPtr)0);
                        SendMessage(hwnd, 0x0202, (IntPtr)0x00000000, (IntPtr)0);
                    }
                    else
                    {
                        int[] search_ = new int[search.Length];
                        for (int j = 0; j < search.Length; j++)
                        {
                            search_[j] = Convert.ToInt32(search[j]);
                        }
                        SetCursorPos(search_[1] + (search_[3] / 2), search_[2] + (search_[4] / 2));
                        SendMessage(hwnd, 0x0201, (IntPtr)0x00000001, (IntPtr)0);
                        SendMessage(hwnd, 0x0202, (IntPtr)0x00000000, (IntPtr)0);
                    }
                    continue;
                }
                //통상화면
                if(oil_check)
                {
                    //oil_check
                    if(oil_val.Equals(""))
                    {
                        MessageBox.Show("최저연료가 입력되지 않았습니다.");
                        loop_thread = false;
                        continue;
                    }
                    Bitmap cap = PrintWindow(hwnd);
                    RECT brt;
                    GetWindowRect(hwnd, out brt);
                    cap = crop(cap, new Rectangle(770, 30, 80, 50));    //oil check
                    var ocr = new TesseractEngine("./tessdata", "eng", EngineMode.TesseractAndCube);
                    var texts = ocr.Process(cap);
                    if(Int32.Parse(oil_val) > Int32.Parse(texts.GetText()))
                    {
                        loop_thread = false;
                        continue;
                    }
                }
                if(drop_check)
                {
                    //drop_ship_check
                    if(drop_val.Equals("0"))
                    {
                        loop_thread = false;
                        continue;
                    }
                    else if(drop_val.Equals(""))
                    {
                        MessageBox.Show("드랍수를 입력하지 않았습니다.");
                        loop_thread = false;
                        continue;
                    }
                }
                try
                {
                    string[] search = null;
                    if(stage_val.Equals(""))
                    {
                        MessageBox.Show("해역이 선택되지 않았습니다.");
                        loop_thread = false;
                        continue;
                    }
                    filePath += "stage/";
                    string temp = filePath + stage_val;     //stage select
                    string temp2 = filePath + "start.png";          //start button
                    search = UseImageSearch(temp, hwnd);
                    if (search == null)
                    {
                        search = UseImageSearch(temp2, hwnd);
                        if (search == null)
                            continue;
                        else
                        {
                            in_battle = true;
                        }
                    }

                    int[] search_ = new int[search.Length];
                    for (int j = 0; j < search.Length; j++)
                    {
                        search_[j] = Convert.ToInt32(search[j]);
                    }
                    SetCursorPos(search_[1] + (search_[3] / 2), search_[2] + (search_[4] / 2));
                    SendMessage(hwnd, 0x0201, (IntPtr)0x00000001, (IntPtr)0);
                    SendMessage(hwnd, 0x0202, (IntPtr)0x00000000, (IntPtr)0);
                }
                catch
                {

                }
                finally
                {

                }                         
            }
        }
        //thread end

        //key input  
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {            
            switch(e.KeyCode)
            {
                default:
                    //nothing;
                    break;
            }
        }

        private void min_oil_val_KeyPress(object sender, KeyPressEventArgs e)
        {
            //숫자만 입력되도록 필터링
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))    //숫자와 백스페이스를 제외한 나머지를 바로 처리
            {
                e.Handled = true;
            }
        }
        private void drop_ship_val_KeyPress(object sender, KeyPressEventArgs e)
        {
            //숫자만 입력되도록 필터링
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))    //숫자와 백스페이스를 제외한 나머지를 바로 처리
            {
                e.Handled = true;
            }
        }
        //key input end


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (connectThread.IsAlive == true)
                connectThread.Abort();
            if (loopThread.IsAlive == true)
                loopThread.Abort();
            UnHook();
        }
        private void min_oil_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            oil_check = !oil_check;
        }

        private void drop_ship_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            drop_check = !drop_check;
        }
    }
}
