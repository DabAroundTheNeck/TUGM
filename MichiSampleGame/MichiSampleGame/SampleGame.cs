using osu.Framework;
using osu.Framework.Graphics;
using OpenTK;
using OpenTK.Graphics;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Allocation;

namespace MichiSampleGame
{
    internal class SampleGame : Game
    {
        private Box box;

        private bool expansion = false;

        [BackgroundDependencyLoader]
        private void load()
        {
            Add(box = new Box
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Size = new Vector2(150, 150),
                Colour = Color4.Gold
            });
        }

        protected override void Update()
        {
            base.Update();
            if (box.Size.X <= 30)
            {
                expansion = true;
            }
            if (box.Size.X >= 300)
            {
                expansion = false;
            }

            if (expansion)
            {
                box.Size += new Vector2(1, 1);
            }
            if (!expansion)
            {
                box.Size -= new Vector2(1, 1);
            }
            box.Rotation += (float)Time.Elapsed / 10;
        }
    }
}
