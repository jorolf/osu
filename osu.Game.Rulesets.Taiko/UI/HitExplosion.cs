﻿// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using OpenTK;
using OpenTK.Graphics;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Game.Graphics;
using osu.Game.Rulesets.Taiko.Judgements;
using osu.Game.Rulesets.Taiko.Objects;

namespace osu.Game.Rulesets.Taiko.UI
{
    /// <summary>
    /// A circle explodes from the hit target to indicate a hitobject has been hit.
    /// </summary>
    internal class HitExplosion : Container
    {
        public readonly TaikoJudgement Judgement;

        private readonly Box innerFill;

        private bool isRim;

        public HitExplosion(TaikoJudgement judgement, bool isRim)
        {
            this.isRim = isRim;

            Judgement = judgement;

            RelativeSizeAxes = Axes.Y;
            Width = TaikoPlayfield.HIT_TARGET_OFFSET + TaikoHitObject.DEFAULT_CIRCLE_DIAMETER;

            Anchor = Anchor.CentreLeft;
            Origin = Anchor.CentreLeft;

            RelativePositionAxes = Axes.Both;

            BorderColour = Color4.White;
            BorderThickness = 1;

            Alpha = 0.15f;
            Masking = true;

            Children = new[]
            {
                innerFill = new Box
                {
                    RelativeSizeAxes = Axes.Both,
                }
            };
        }

        [BackgroundDependencyLoader]
        private void load(OsuColour colours)
        {
            if (isRim)
                innerFill.Colour = colours.BlueDarker;
            else
                innerFill.Colour = colours.PinkDarker;
        }

        protected override void LoadComplete()
        {
            base.LoadComplete();

            ScaleTo(new Vector2(2f, 1), 1000, EasingTypes.OutQuint);
            FadeOut(500);

            Expire();
        }

        /// <summary>
        /// Transforms this hit explosion to visualise a secondary hit.
        /// </summary>
        public void VisualiseSecondHit()
        {
            ResizeTo(new Vector2(TaikoPlayfield.HIT_TARGET_OFFSET + TaikoHitObject.DEFAULT_STRONG_CIRCLE_DIAMETER, 1), 50);
        }
    }
}
