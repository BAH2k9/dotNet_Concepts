using KhetRecord.Common;
using KhetRecord.ExtensionMethods;
namespace KhetRecord.Records
{
    public record RotateMove(DateTime Timestamp, Player Player, Rotation Rotation, Coordinate C1) : IGameMove
    {
        public static RotateMove Make(Player player, Rotation rotation, Coordinate c1)
        {
            var move = new RotateMove(DateTime.Now, player, rotation, c1);
            move.Log();
            return move;
        }
    }
    public record ShiftMove(DateTime Timestamp, Player Player, Coordinate C1, Coordinate C2) : IGameMove
    {
        public static ShiftMove Make(Player player, Coordinate c1, Coordinate c2)
        {
            var move = new ShiftMove(DateTime.Now, player, c1, c2);
            move.Log();
            return move;
        }
    }


    public record Coordinate(int X, int Y) : IGameMove
    {
        public static implicit operator Coordinate((int X, int Y) tuple)
        {
            return new Coordinate(tuple.X, tuple.Y);

        }
    }
}

