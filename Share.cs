using System;

namespace ooxx
{
    internal class Share
    {
        public static event Action gameEnd; // 遊戲結束事件
        public static event Action statusUpdated; // 更新畫面事件
        public static int userScore = 0; // 玩家分數
        public static int npcScore = 0; // npc分數
        public static int whoseTurn = 2; // 誰的回合
        private static int[,] _defaultStatus =
            {
                { 2, 2, 2 },
                { 2, 2, 2 },
                { 2, 2, 2 }
            };
        private static int[,] _status = (int[,])_defaultStatus.Clone(); // 棋盤的狀態
        public static int times = 0; // 下了幾次(每次遊戲)
        public static bool isEnd = false;
        public static string endType = ""; // 結束類型 平手, 你贏了, npc贏了
        public static int[,,] rules = // 設定連線的規則
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
        public static int get(int x, int y) // 取得格子的值
        {
            return _status[x, y];
        }
        public static void reset() // 重置遊戲
        {
            _status = (int[,])_defaultStatus.Clone(); // 複製一份新的陣列(一定要這樣做，不然會資料連動)
            times = 0; // 重置次數
            isEnd = false; // 重置遊戲結束
            endType = ""; // 重置結束類型
            whoseTurn = 2; // 重置誰的回合
            statusUpdated?.Invoke(); // 觸發更新畫面事件
        }
        public static void set(int x, int y, int value) // 設定格子的值
        {
            _status[x, y] = value;
            times++;
            if (times == 9)
            {
                gameEnd?.Invoke();
            }; // 觸發遊戲結束事件 npc和user都下到不能下了 棋盤總共9格
            statusUpdated?.Invoke(); // 觸發更新畫面事件
        }
    }
}
