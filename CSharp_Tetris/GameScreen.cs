using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_Tetris
{
    enum TBLOCK
    { 
        TB_VOID,
        TB_WALL,
        TB_BLOCK,
    }

    class GameScreen
    {
        private List<List<string>> BlockList = new List<List<string>>();

        public GameScreen(int _x, int _y)
        {
            if(_x < 0 ||  _y < 0)
            {
                throw new Exception();
            }

            for (int y = 0; y < _y; y++)
            {
                BlockList.Add(new List<string>());

                for (int x = 0; x < _x; x++)
                {
                    BlockList[y].Add("□");
                }
            }

            // 맨 위와 맨 아래는 벽으로 막아준다.
            for (int i = 0; i < BlockList[0].Count; i++)
            {
                BlockList[0][i] = "▣";
            }

            for (int i = 0; i < BlockList[BlockList.Count - 1].Count; i++)
            {
                BlockList[BlockList.Count - 1][i] = "▣";
            }
        }

        // 블록 타입을 바꿀 수 있다.
        public void SetBlock(int _y, int _x, string _eBlockType)
        {
            BlockList[_y][_x] = _eBlockType;
        }

        // 게임 창을 렌더링합니다.
        public void Render()
        {
            for (int y = 0; y < BlockList.Count; y++)
            {
                for (int x = 0; x < BlockList[y].Count; x++)
                {
                    Console.Write(BlockList[y][x]);
                }
                Console.WriteLine();
            }
        }

        // 스크린을 초기화 세팅 하면서 동시에 비워준다.
        public void Clear()
        {
            for (int y = 0; y < BlockList.Count; y++)
            {
                for (int x = 0; x < BlockList[y].Count; x++)
                {
                    if(y == 0 || y == BlockList.Count - 1)
                    {
                        BlockList[y][x] = "▣";
                        continue;
                    }

                    BlockList[y][x] = "□";
                }
            }
        }
    }
}
