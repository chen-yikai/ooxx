using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooxx
{
    internal class Share
    {
        public static event Action statusUpdated;
        private static int[,] _status = {
                { 2, 2, 2 },
                { 2, 2, 2 },
                { 2, 2, 2 }
            };
        public static int get(int x, int y)
        {
            return _status[x, y];
        }
        public static void set(int x, int y, int value)
        {
            _status[x, y] = value;
            statusUpdated?.Invoke();
        }
    }
}
