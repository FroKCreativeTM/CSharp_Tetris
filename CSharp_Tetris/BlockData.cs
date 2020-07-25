using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_Tetris
{
    // 블록 클래스의 데이터를 다루는 부분입니다.
    partial class Block
    {
        // 모든 블록의 정보이다.
        // 이것이 있는 이유는 단순하다.
        // 어떤 블록이 생성될 때는 이 블록 정보를 참조해서 
        // 블록의 타입과 방향을 참조하며, 이를 통해서 블록의 모양을 어떻게 스크린에 그릴 것인가를 알 수 있다.
        List<List<string[][]>> AllBlock = new List<List<string[][]>>();

        // 블록 데이터를 초기화합니다.
        void DataInit()
        {
            for (int BT = 0; BT < (int)BLOCKTYPE.BT_MAX; BT++)
            {
                AllBlock.Add(new List<string[][]>());

                for (int BD = 0; BD < (int)BLOCK_DIRECTION.BD_MAX; BD++)
                {
                    AllBlock[BT].Add(null);
                }
            }

            #region S
            // Stick 모양입니다.
            // Stick타입 블록의 TOP
            AllBlock[(int)BLOCKTYPE.BT_S][(int)BLOCK_DIRECTION.BD_TOP] = new string[][]
            {
                new string[]{ "■", "□", "□", "□" },
                new string[]{ "■", "□", "□", "□" },
                new string[]{ "■", "□", "□", "□" },
                new string[]{ "■", "□", "□", "□" }
            };

            // Stick타입 블록의 RIGHT
            AllBlock[(int)BLOCKTYPE.BT_S][(int)BLOCK_DIRECTION.BD_RIGHT] = new string[][]
            {
                new string[]{ "■", "■", "■", "■" },
                new string[]{ "□", "□", "□", "□" },
                new string[]{ "□", "□", "□", "□" },
                new string[]{ "□", "□", "□", "□" }
            };

            // Stick타입 블록의 BOTTOM
            AllBlock[(int)BLOCKTYPE.BT_S][(int)BLOCK_DIRECTION.BD_BOTTOM] = new string[][]
            {
                new string[]{ "■", "□", "□", "□" },
                new string[]{ "■", "□", "□", "□" },
                new string[]{ "■", "□", "□", "□" },
                new string[]{ "■", "□", "□", "□" }
            };

            // Stick타입 블록의 LEFT
            AllBlock[(int)BLOCKTYPE.BT_S][(int)BLOCK_DIRECTION.BD_LEFT] = new string[][]
            {
                new string[]{ "■", "■", "■", "■" },
                new string[]{ "□", "□", "□", "□" },
                new string[]{ "□", "□", "□", "□" },
                new string[]{ "□", "□", "□", "□" }
            };
            #endregion
            #region T
            // T 모양입니다.
            // I타입 블록의 TOP
            AllBlock[(int)BLOCKTYPE.BT_T][(int)BLOCK_DIRECTION.BD_TOP] = new string[][]
            {
                new string[]{ "□", "■", "□", "□" },
                new string[]{ "■", "■", "■", "□" },
                new string[]{ "□", "□", "□", "□" },
                new string[]{ "□", "□", "□", "□" }
            };

            // T타입 블록의 RIGHT
            AllBlock[(int)BLOCKTYPE.BT_T][(int)BLOCK_DIRECTION.BD_RIGHT] = new string[][]
            {
                new string[]{ "□", "■", "□", "□" },
                new string[]{ "□", "■", "■", "□" },
                new string[]{ "□", "■", "□", "□" },
                new string[]{ "□", "□", "□", "□" }
            };

            // T타입 블록의 BOTTOM
            AllBlock[(int)BLOCKTYPE.BT_T][(int)BLOCK_DIRECTION.BD_BOTTOM] = new string[][]
            {
                new string[]{ "□", "□", "□", "□" },
                new string[]{ "■", "■", "■", "□" },
                new string[]{ "□", "■", "□", "□" },
                new string[]{ "□", "□", "□", "□" }
            };

            // T타입 블록의 LEFT
            AllBlock[(int)BLOCKTYPE.BT_T][(int)BLOCK_DIRECTION.BD_LEFT] = new string[][]
            {
                new string[]{ "□", "■", "□", "□" },
                new string[]{ "■", "■", "□", "□" },
                new string[]{ "□", "■", "□", "□" },
                new string[]{ "□", "□", "□", "□" }
            };
            #endregion
        }
    }
}
