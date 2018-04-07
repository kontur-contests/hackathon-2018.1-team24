using System;

namespace GameCoreLibrary
{
    public class PlayerState
    {
        Guid PlayerId { get; set; }
        float X { get; set; }
        float Y { get; set; }
        bool IsAlive { get; set; }
    }
}