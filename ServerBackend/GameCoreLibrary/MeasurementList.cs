using System.Collections.Generic;

namespace GameCoreLibrary
{
    public static class MeasurementList
    {
        public static readonly Dictionary<ObjectType, Measurement> Measurements =
            new Dictionary<ObjectType, Measurement>
            {
                {ObjectType.Platform, new Measurement {Height = 20, Width = 200,}},
                {ObjectType.Player, new Measurement {Height = 128, Width = 64,}},
                {ObjectType.Table, new Measurement {Height = 25, Width = 64,}},
                {ObjectType.Bitcoin, new Measurement {Height = 128, Width = 64,}},
            };
    };
}