using System.Runtime.InteropServices;
using Vanara.PInvoke;

namespace blank
{
    static class Utils
    {
        public static Point RectCenter(Rectangle rect)
        {
            return new Point((rect.Left + rect.Right) / 2, (rect.Top + rect.Bottom) / 2);
        }

        public static Point GetStartupScreenPos()
        {
            Kernel32.GetStartupInfo(out var info);
            if (!info.dwFlags.HasFlag(Kernel32.STARTF.STARTF_USESTDHANDLES) && !info.hStdOutput.IsNull)
            {
                var monitor = (HMONITOR) (nint) info.hStdOutput;
                var monitorInfo = User32.MONITORINFO.Default;
                if (User32.GetMonitorInfo(monitor, ref monitorInfo))
                    return RectCenter(monitorInfo.rcWork);
            }
            return RectCenter(Screen.PrimaryScreen?.WorkingArea ?? Rectangle.Empty);
        }

        public static void ActivateLastWindow(ICollection<Screen> excludeScreens)
        {
            User32.EnumWindows((hwnd, param) =>
            {
                if (User32.IsWindowVisible(hwnd) && !User32.IsMinimized(hwnd) &&
                    User32.GetWindowRect(hwnd, out var rect))
                {
                    var exStyles = (User32.WindowStylesEx) User32.GetWindowLong(hwnd, User32.WindowLongFlags.GWL_EXSTYLE);
                    if (!exStyles.HasFlag(User32.WindowStylesEx.WS_EX_TOOLWINDOW))
                    {
                        Screen screen = Screen.FromPoint(RectCenter(rect));
                        if (!excludeScreens.Contains(screen))
                        {
                            User32.SetForegroundWindow(hwnd);
                            return false;
                        }
                    }
                }

                return true;
            }, 0);
        }

        static COLORREF[] CustomColors = new COLORREF[16];

        public static Color? ChooseColorWithPreview(Control parent, Color color, Action<Color> preview)
        {
            ComDlg32.CHOOSECOLOR info = new();
            info.lStructSize = (uint) Marshal.SizeOf<ComDlg32.CHOOSECOLOR>();
            info.hwndOwner = parent.Handle;
            info.rgbResult = color;
            info.Flags = ComDlg32.CC.CC_ANYCOLOR | ComDlg32.CC.CC_ENABLEHOOK |
                ComDlg32.CC.CC_FULLOPEN | ComDlg32.CC.CC_RGBINIT | ComDlg32.CC.CC_SOLIDCOLOR;

            var customColorsPin = GCHandle.Alloc(CustomColors, GCHandleType.Pinned);
            info.lpCustColors = customColorsPin.AddrOfPinnedObject();

            info.lpfnHook = (HWND hwnd, uint msg, nint wparam, nint lparam) =>
            {
                switch ((User32.WindowMessage) msg)
                {
                case User32.WindowMessage.WM_COMMAND:
                case User32.WindowMessage.WM_HSCROLL:
                case User32.WindowMessage.WM_VSCROLL:
                    {
                        const int COLOR_RED = 706;
                        const int COLOR_GREEN = 707;
                        const int COLOR_BLUE = 708;

                        int red = (int) User32.GetDlgItemInt(hwnd, COLOR_RED, out var _, false);
                        int green = (int) User32.GetDlgItemInt(hwnd, COLOR_GREEN, out var _, false);
                        int blue = (int) User32.GetDlgItemInt(hwnd, COLOR_BLUE, out var _, false);

                        preview(Color.FromArgb(red, green, blue));
                    }
                    break;
                }

                return 0;
            };

            bool done = ComDlg32.ChooseColor(ref info);

            customColorsPin.Free();
            GC.KeepAlive(info.lpfnHook);

            return done ? info.rgbResult : null;
        }
    }
}
