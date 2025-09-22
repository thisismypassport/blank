using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Win32;

namespace blank
{
    public class ColorItem(string name, Color color)
    {
        public string Name { get; } = name;
        public int ColorArgb { get; } = color.ToArgb();

        [JsonConstructor]
        public ColorItem(string Name, int ColorArgb) : this(Name, Color.FromArgb(ColorArgb)) { }

        [JsonIgnore]
        public Color Color => Color.FromArgb(ColorArgb);
    }

    public static class ColorImages
    {
        static Dictionary<(int, Color, bool), Bitmap> Images = new();

        public static Image Get(Control control, Color color, bool full = false)
        {
            var key = (control.DeviceDpi, color, full);
            if (Images.TryGetValue(key, out var image))
                return image;

            var size = control.LogicalToDeviceUnits(new Size(16, 16));
            var bitmap = new Bitmap(size.Width, size.Height);
            using (var gfx = Graphics.FromImage(bitmap))
            using (var brush = new SolidBrush(color))
            {
                if (full)
                {
                    gfx.Clear(color);
                }
                else
                {
                    var offset = control.LogicalToDeviceUnits(new Size(2, 2));
                    var mainSize = size - offset * 2;
                    gfx.Clear(Color.Transparent);
                    gfx.FillRectangle(brush, offset.Width, offset.Height, mainSize.Width, mainSize.Height);
                }
            }

            Images.Add(key, bitmap);
            return bitmap;
        }
    }

    public static class ColorData
    {
        static ColorItem[] Defaults =
        {
            new ColorItem ("Black", Color.Black),
            new ColorItem ("Dark Gray", Color.FromArgb(0x40, 0x40, 0x40)),
            new ColorItem ("Light Gray", Color.FromArgb(0xc0, 0xc0, 0xc0)),
            new ColorItem ("White", Color.White),
        };

        static ColorItem[]? mDefined;
        static Color? mCurrent = null;
        static bool? mIsAlwaysOnTop = null;

        static string RegistryKey = "HKEY_CURRENT_USER\\Software\\MyInput\\Other\\Blank";
        static string DefinedColors = "DefinedColors";
        static string CurrentColor = "CurrentColor";
        static string AlwaysOnTop = "AlwaysOnTop";

        public static IEnumerable<ColorItem> GetDefinedDefault() => Defaults;

        public static IEnumerable<ColorItem> GetDefined()
        {
            if (mDefined == null)
            {
                if (Registry.GetValue(RegistryKey, DefinedColors, null) is string regStr &&
                    JsonSerializer.Deserialize<ColorItem[]>(regStr) is ColorItem[] regData)
                {
                    mDefined = regData;
                }
                else
                {
                    mDefined = Defaults;
                }
            }
            return mDefined;
        }

        public static void SetDefined(IEnumerable<ColorItem> defined)
        {
            mDefined = defined.ToArray();
            var regStr = JsonSerializer.Serialize(mDefined);
            Registry.SetValue(RegistryKey, DefinedColors, regStr);
        }

        public static Color GetDefaultColor() => Defaults[0].Color;

        public static Color GetCurrentColor()
        {
            if (mCurrent == null)
            {
                if (Registry.GetValue(RegistryKey, CurrentColor, null) is int regInt)
                    mCurrent = Color.FromArgb(regInt);
                else
                    mCurrent = GetDefaultColor();
            }
            return mCurrent.Value;
        }

        public static void SetCurrentColor(Color value)
        {
            mCurrent = value;
            Registry.SetValue(RegistryKey, CurrentColor, value.ToArgb());
        }

        public static bool GetIsAlwaysOnTop()
        {
            if (mIsAlwaysOnTop == null)
            {
                if (Registry.GetValue(RegistryKey, AlwaysOnTop, null) is int regInt)
                    mIsAlwaysOnTop = regInt != 0;
                else
                    mIsAlwaysOnTop = false;
            }
            return mIsAlwaysOnTop.Value;
        }

        public static void SetIsAlwaysOnTop(bool value)
        {
            mIsAlwaysOnTop = value;
            Registry.SetValue(RegistryKey, AlwaysOnTop, value ? 1 : 0);
        }
    }
}
