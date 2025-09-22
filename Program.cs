using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.Win32;

namespace blank
{
    static class ProgramUi
    {
        static List<Blank> mWindows = new();

        public static IDictionary<Screen, Blank> GetBlankScreensDictionary()
        {
            Dictionary<Screen, Blank> screens = new();
            foreach (var window in mWindows)
                screens[Screen.FromPoint(window.Center)] = window;
            return screens;
        }

        public static ICollection<Screen> GetBlankScreens() =>
            GetBlankScreensDictionary().Keys;

        public static void Update(Color? overrideColor = null, bool withTopmost = false)
        {
            foreach (var window in mWindows)
                window.Update(overrideColor, withTopmost);
        }

        static void AddWindow(Screen screen)
        {
            var window = new Blank(Utils.RectCenter(screen.WorkingArea));
            mWindows.Add(window);
            window.Show();
        }

        static void RemoveWindow(Blank window)
        {
            window.Close();
            mWindows.Remove(window);
        }

        public static void AddOrRemoveBlankScreen(Screen screen, bool? addOrRemove = null)
        {
            var currScreens = GetBlankScreensDictionary();
            bool exists = currScreens.ContainsKey(screen);

            if (!exists && addOrRemove != false)
                AddWindow(screen);
            else if (exists && addOrRemove != true)
                RemoveWindow(currScreens[screen]);

            if (mWindows.Count == 0)
                Application.Exit();
        }

        public static void DeleteDupScreens()
        {
            var currWindows = GetBlankScreensDictionary().Values.ToHashSet();

            var dups = mWindows.Where(window => !currWindows.Contains(window)).ToArray();

            foreach (var window in dups)
                RemoveWindow(window);
        }
    }

    class Program : WindowsFormsApplicationBase
    {
        Program()
        {
            IsSingleInstance = true;
        }

        static string[] Serialize(IReadOnlyList<Point> points)
        {
            var args = new string[points.Count * 2];
            for (int i = 0; i < points.Count; i++)
            {
                args[i * 2] = points[i].X.ToString();
                args[i * 2 + 1] = points[i].Y.ToString();
            }
            return args;
        }

        static Point[] Deserialize(IReadOnlyList<string> args)
        {
            var points = new Point[args.Count / 2];
            for (int i = 0; i < points.Length; i++)
            {
                points[i].X = int.Parse(args[i * 2]);
                points[i].Y = int.Parse(args[i * 2 + 1]);
            }
            return points;
        }

        void OnAnyStartup(IReadOnlyCollection<string> args)
        {
            foreach (var point in Deserialize(args.ToArray()))
                ProgramUi.AddOrRemoveBlankScreen(Screen.FromPoint(point), true);

            Utils.ActivateLastWindow(ProgramUi.GetBlankScreens());
        }

        protected override bool OnStartup(StartupEventArgs eventArgs)
        {
            SystemEvents.DisplaySettingsChanged += (s, e) => ProgramUi.DeleteDupScreens();

            OnAnyStartup(eventArgs.CommandLine);
            Application.Run();
            return false;
        }

        protected override void OnStartupNextInstance(StartupNextInstanceEventArgs eventArgs)
        {
            Application.OpenForms[0]?.BeginInvoke(() =>
            {
                OnAnyStartup(eventArgs.CommandLine);
            });
        }

        static List<Point> GetInitialScreenPositions()
        {
            var positions = new List<Point>();
            var startupScreenPos = Utils.GetStartupScreenPos();

            bool ctrl = Control.ModifierKeys.HasFlag(Keys.Control);
            bool shift = Control.ModifierKeys.HasFlag(Keys.Shift);
            if (ctrl)
            {
                foreach (var screen in Screen.AllScreens)
                    positions.Add(Utils.RectCenter(screen.WorkingArea));
            }
            else if (shift)
            {
                var startupScreen = Screen.FromPoint(startupScreenPos);

                foreach (var screen in Screen.AllScreens)
                    if (!screen.Equals(startupScreen))
                        positions.Add(Utils.RectCenter(screen.WorkingArea));
            }
            else
            {
                positions.Add(startupScreenPos);
            }

            return positions;
        }

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            var initialPositions = GetInitialScreenPositions();
            if (initialPositions.Count == 0)
                return;

            new Program().Run(Serialize(initialPositions));
        }
    }
}
