using Records.ExtensionMethods;
using Records.Records;
using System.Security.Cryptography.X509Certificates;

namespace Records
{
    public class Application
    {
        public void Start()
        {
            //var shift = new ShiftRecord(Player.Player1, new Coordinate(1, 1), new Coordinate(1, 2));
            //var shift1 = new ShiftRecord(Player.Player1, new Coordinate(1, 1), new Coordinate(1, 2));
            //var rot = new RotateRecord(Player.Player1, Direction.Up, new Coordinate(5, 5));
            //var rot1 = new RotateRecord(Player.Player2, Direction.Down, new Coordinate(6, 5));

            // Coordinate c = Coordinate.Make(1, 1);
            //Coordinate co = new Coordinate(1, 1);
            //co.ToJson();


            //Coordinate t = (Player.Unspecified, 1, 1);

            //SomeFunc(t);
            //Console.WriteLine(c);

            Coordinate c = (Player.Player1, (QuickCoord)(1, 1));


        }

        public static void SomeFunc(Coordinate c)
        {
            Console.WriteLine(c);
        }
    }
}
