using KhetRecord.Common;
using KhetRecord.Records;

namespace KhetRecord
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Press Enter to Start");

                if (Console.ReadLine() == "q")
                {
                    break;
                }

                int x = 0;

                while (x < 10)
                {

                    await Task.Delay(1000);
                    Console.WriteLine("Creating Move");
                    var shiftMove1 = ShiftMove.Make(Player.Player1, (x, x), (1 + x, x + 1));

                    x++;
                }
            }

        }
    }
}
