using Records.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Records.Records
{
    public record ShiftRecord : IJsonSerialisable
    {
        public Player Player { get; init; }
        public Coordinate From { get; init; }
        public Coordinate To { get; init; }
        public ShiftRecord(Player player, Coordinate from, Coordinate to)
        {
            Player = player;
            From = from;
            To = to;
            this.Log();
        }
    }

    public record RotateRecord : IJsonSerialisable
    {
        public Player Player { get; init; }
        public Direction Direction { get; init; }
        public Coordinate Coordinate { get; init; }
        public RotateRecord(Player player, Direction direction, Coordinate coordinate)
        {
            Player = player;
            Direction = direction;
            Coordinate = coordinate;
            this.Log();
        }
    }
    public record BackRecord : IJsonSerialisable
    {
        public Player Player { get; init; }
        public BackRecord(Player player)
        {
            Player = player;
            this.Log();
        }
    }
    public record FireLaserRecord : IJsonSerialisable
    {
        public Player Player { get; init; }

        public FireLaserRecord(Player player)
        {
            Player = player;
            this.Log();
        }
    }
    //public record Coordinate(int X, int Y) : IJsonSerialisable
    //{
    //    public static implicit operator Coordinate((int X, int Y) tuple)
    //    {
    //        var coordinate = new Coordinate(tuple.X, tuple.Y);
    //        Console.WriteLine(coordinate);
    //        return coordinate;
    //    }
    //}

    public record QuickCoord(int X, int Y) : IJsonSerialisable
    {
        public static implicit operator QuickCoord((int X, int Y) tuple)
        {
            var coordinate = new QuickCoord(tuple.X, tuple.Y);
            Console.WriteLine(coordinate);
            return coordinate;
        }
    }

    public record Coordinate(int X, int Y) : IJsonSerialisable
    {
        public static implicit operator Coordinate((Player Player, QuickCoord QuickCoord) tuple)
        {
            Coordinate c = tuple;
            return c;
        }

        public static implicit operator Coordinate((Player player, int X, int Y) tuple)
        {
            if (tuple.player == Player.Unspecified)
            {
                throw new Exception("Player is unspecified");
            }
            else
            {
                var coordinate = Coordinate.Make(tuple);
                return coordinate;
            }

        }

        public static Coordinate Make((Player player, int x, int y) tuple)
        {
            Console.WriteLine("Make Coord");
            return new Coordinate(tuple.x, tuple.y);
        }
    }

    public enum Direction
    {
        Unspecified,
        Left,
        Right,
        Up,
        Down
    }

    /*
     * Player Enum Starts with Unspecified:
    Player.Unspecified feels like a code smell. You’ve got an Unspecified value in the Player enum, 
    which essentially breaks the idea of enums as representing concrete options.
    An enum should be used for a set of valid states, and Unspecified is just a way of making the enum more 
    "nullable". You could likely do this with Nullable<Player> instead.
    Recommendation: Use a Nullable<Player> instead of having Unspecified as a value. 
    It communicates better that the Player can be unset, and it avoids the need for special handling of 
    Unspecified cases.
     */
    public enum Player
    {
        Unspecified = 0,
        Player1 = 1,
        Player2 = 2
    }



}
