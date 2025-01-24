using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ooxx
{
    internal class Share
    {
        public static event Action gameEnd;
        public static event Action statusUpdated;
        public static int userScore = 0;
        public static int npcScore = 0;
        public static List<int> hasChecked = new List<int>();
        private static int[,] _defaultStatus =
        {
                { 2, 2, 2 },
                { 2, 2, 2 },
                { 2, 2, 2 }
            };
        private static int[,] _status = (int[,])_defaultStatus.Clone();
        public static int times = 0;
        public static int[,,] rules =
            {
                {{0,0},{0,1},{0,2}},
                {{1,0},{1,1},{1,2}},
                {{2,0},{2,1},{2,2}},
                {{0,0},{1,0},{2,0}},
                {{0,1},{1,1},{2,1}},
                {{0,2},{1,2},{2,2}},
                {{0,0},{1,1},{2,2}},
                {{0,2},{1,1},{2,0}}
            };
        public static int get(int x, int y)
        {
            return _status[x, y];
        }
        public static void reset()
        {
            _status = (int[,])_defaultStatus.Clone();
            times = 0;
            hasChecked.Clear();
            statusUpdated?.Invoke();
        }
        public static void set(int x, int y, int value)
        {
            _status[x, y] = value;
            times++;
            if (times == 9) gameEnd?.Invoke();
            statusUpdated?.Invoke();
        }
    }
}
