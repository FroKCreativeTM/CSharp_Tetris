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
        // 스크린 틀 자체를 렌더할 정보를 저장.
        // 자식도 사용 가능하게 설정한다.
        protected List<List<string>> BlockList = new List<List<string>>();

        public int X
        {
            get
            {
                return BlockList[0].Count;
            }
        }

        public int Y
        {
            get
            {
                return BlockList.Count;
            }
        }

        public GameScreen(int _x, int _y, bool TopAndBotLine)
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

            // 위 아래 라인이 아니라면 그릴 것 없다.
            if(TopAndBotLine == false)
            {
                return;
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

        public bool IsBlock(int _y, int _x, string _eBlockType)
        {
            return BlockList[_y][_x] == _eBlockType;
        }

        // 블록 타입을 바꿀 수 있다.
        public void SetBlock(int _y, int _x, string _eBlockType)
        {
            BlockList[_y][_x] = _eBlockType;
        }

        // 게임 창을 렌더링합니다.
        public virtual void Render()
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
