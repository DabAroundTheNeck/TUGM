using System;
using osu.Framework;
using osu.Framework.Platform;

namespace MichiSampleGame
{
    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            using (Game game = new SampleGame())
            using (GameHost host = Host.GetSuitableHost(@"sample-game"))
                host.Run(game);
        }
    }
}
