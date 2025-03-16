using Records.ExtensionMethods;
using Records.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Records
{
    public static class RecordFactory
    {
        public static ShiftRecord MakeShiftRecord(Player Player, Coordinate From, Coordinate To)
        {
            var record = new ShiftRecord(Player, From, To);
            //record.Log();
            return record;
        }
    }
}
