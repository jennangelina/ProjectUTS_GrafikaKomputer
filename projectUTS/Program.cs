using OpenTK.Mathematics;
using OpenTK.Windowing.Desktop;
using System;

namespace projectUTS
{
    class Program
    {
        static void Main(string[] args)
        {
            var ourWindow = new NativeWindowSettings()
            {
                Size = new Vector2i(1000, 1000),
                Title = "Project UTS"
            };
            using (var win = new Window(GameWindowSettings.Default, ourWindow))
            {
                win.Run();
            }
        }
    }
}
