﻿//Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
//Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using System.Collections.Generic;
using osu.Game.Modes.Objects;
using osu.Game.Modes.UI;
using osu.Game.Modes.Vitaru.UI;
using System;
using osu.Game.Modes.Vitaru.UI;
using osu.Game.Graphics;
using osu.Game.Beatmaps;

namespace osu.Game.Modes.Vitaru
{
    public class VitaruRuleset : Ruleset
    {
        public override ScoreOverlay CreateScoreOverlay() => new VitaruScoreOverlay();

        public override HitObjectParser CreateHitObjectParser() => new VitaruObjectParser();

        public ScoreProcessor CreateScoreProcessor() => new VitaruScoreProcessor();

        public override ScoreProcessor CreateScoreProcessor(int hitObjectCount)
        {
            throw new NotImplementedException();
        }

        public override HitRenderer CreateHitRendererWith(Beatmap beatmap)
        {
            throw new NotImplementedException();
        }

        public override DifficultyCalculator CreateDifficultyCalculator(Beatmap beatmap)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Mod> GetModsFor(ModType type)
        {
            switch (type)
            {
                case ModType.DifficultyReduction:
                    return new Mod[]
                    {
                        new VitaruModEasy(),
                        new VitaruModNoFail(),
                        new VitaruModHalfTime(),
                    };

                case ModType.DifficultyIncrease:
                    return new Mod[]
                    {
                        new VitaruModHardRock(),
                        new MultiMod
                        {
                            Mods = new Mod[]
                            {
                                new VitaruModSuddenDeath(),
                            },
                        },
                        new MultiMod
                        {
                            Mods = new Mod[]
                            {
                                new VitaruModDoubleTime(),
                                new VitaruModNightcore(),
                            },
                        },
                        new VitaruModHidden(),
                        new VitaruModDoubleTrouble(),
                    };

                case ModType.Special:
                    return new Mod[]
                    {
                        new VitaruModRelax(),
                        new MultiMod
                        {
                            Mods = new Mod[]
                            {
                                new ModAutoplay(),
                                new ModCinema(),
                            },
                        },
                    };

                default:
                    return new Mod[] { };
            }
        }

        public override FontAwesome Icon => FontAwesome.fa_osu_vitaru_o;

        protected override PlayMode PlayMode => PlayMode.Vitaru;
    }
}
