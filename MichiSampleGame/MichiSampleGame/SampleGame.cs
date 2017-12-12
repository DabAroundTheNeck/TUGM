using osu.Framework;
using osu.Framework.Graphics;
using OpenTK;
using OpenTK.Graphics;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Allocation;
using osu.Framework.Graphics.UserInterface;
using osu.Framework.Input;
using osu.Framework.Graphics.Cursor;
using osu.Framework.Graphics.Containers;
using osu.Framework.Platform;

namespace MichiSampleGame
{
    internal class SampleGame : Game
    {
        private Box box;
        private Button button;
        InputState iS;

        [BackgroundDependencyLoader]
        private void load()
        {
            iS = new InputState();
            Children = new Drawable[]
            {
                new CursorContainer(),
                box = new Box
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Size = new Vector2(150, 150),
                    Colour = Color4.Tomato
                },
                new FillFlowContainer
                {
                    Anchor = Anchor.TopLeft,
                    Origin = Anchor.TopLeft,
                    Direction = FillDirection.Vertical,
                    Spacing = new Vector2(0, 10),
                    Padding = new MarginPadding(10),
                    AutoSizeAxes = Axes.Both,
                    Children = new Drawable[]
                    {
                        new MyCheckbox(button)
                        {
                            LabelText = @"MyCheckbox",
                        }
                    }
                }
            };

            button.Enabled.Value = true;
        }

        protected override void Update()
        {

            base.Update();
            box.Rotation += (float)Time.Elapsed / 10;
        }

        public override void SetHost(GameHost host)
        {
            base.SetHost(host);
            host.Window.CursorState |= CursorState.Hidden;
            host.Window.Title = "TestGameByMichl";
        }

        public class MyCheckbox : BasicCheckbox
        {
            public MyCheckbox(Button box)
            {
                Current.ValueChanged += v => box.Rotation += 10;
            }
        }

    }
}
