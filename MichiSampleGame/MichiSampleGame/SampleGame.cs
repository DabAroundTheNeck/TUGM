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
        private Box innerBox;
        private Button myButton;
        MyCheckbox cBox;

        [BackgroundDependencyLoader]
        private void load()
        {
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
                myButton = new Button
                {
                    Text = @"Button",
                    RelativeSizeAxes = Axes.Both,
                    Size = new Vector2(0.1f),
                    Anchor = Anchor.TopRight,
                    Origin = Anchor.TopRight,
                    BackgroundColour = Color4.Red,
                    Alpha = 1,
                    Action = TurnButton
                },
                innerBox = new Box
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Size = new Vector2(30, 30),
                    Colour = Color4.WhiteSmoke
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
                        cBox = new MyCheckbox(innerBox)
                        {
                            LabelText = @"MyCheckbox",
                        }
                    }
                }
            };
            
        }

        protected override void Update()
        {

            base.Update();
            box.Rotation += (float)Time.Elapsed / 20;
            if (cBox.Value)
            {
                box.Colour = Color4.Blue;
            }
            else
            {
                box.Colour = Color4.Tomato;
            }
        }

        public override void SetHost(GameHost host)
        {
            base.SetHost(host);
            host.Window.CursorState |= CursorState.Hidden;
            host.Window.Title = "TestGameByMichl";
        }

        public class MyCheckbox : BasicCheckbox
        {
            public bool Value;
            public MyCheckbox(Box box)
            {
                Current.ValueChanged += v => Value = v;
            }
        }

        public void TurnButton()
        {
            myButton.Rotation += 10;
        }

    }
}
