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
        [DllImport("gdi32.dll")]
        static extern IntPtr CreateRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect);
        [DllImport("ImageSearchDLL.dll")]
        private static extern IntPtr ImageSearch(int x, int y, int right, int bottom, [MarshalAs(UnmanagedType.LPStr)]string imagePath);

        public IntPtr hwnd;
        Thread connectThread;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load1(object sender, EventArgs e)
        {
            connectThread = new Thread(new ThreadStart(connect));
            connectThread.Start();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            /*Bitmap cap = PrintWindow(hwnd);
            RECT brt;
            GetWindowRect(hwnd, out brt);
            cap = crop(cap, new Rectangle(600, 20, 500, 100));
            var ocr = new TesseractEngine("./tessdata", "jpn", EngineMode.Default);
            var texts = ocr.Process(cap);
            MessageBox.Show(texts.GetText());
            Form2 newForm = new Form2(cap);
            newForm.Show();*/
            SetWindowPos(hwnd, 1, 0, 0, 1280, 750, 2);     
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
            SendMessage(hwnd, 0x0202, (IntPtr)0x00000000, (IntPtr)0);*/

        }
        public static Bitmap PrintWindow(IntPtr hwnd)
        {
            Rectangle rc = Rectangle.Empty;
            Graphics gfxWin = Graphics.FromHwnd(hwnd);
            rc = Rectangle.Round(gfxWin.VisibleClipBounds);
            Bitmap bmp = new Bitmap(rc.Width, rc.Height, PixelFormat.Format32bppArgb);
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
        private void connect()
        {
            while(true)
            {
                //string test = "蒼藍の誓い-ブルーオースWindows版";
                //int hwnds = FindWindow(null, test);
                int hwnds = FindWindow("UnityWndClass", null);
                hwnd = new IntPtr(hwnds);
                if (hwnd.Equals((IntPtr)0))
                {
                    //MessageBox.Show("실패");
                    currentStatus.Text = "연결 실패!";
                }
                else
                {
                    currentStatus.Text = "연결 성공!";
                    return;
                }
            }
            
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (connectThread.IsAlive == true)
                connectThread.Abort();
        }
        
    }
}
