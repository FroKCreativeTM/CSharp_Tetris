using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_Tetris
{
    // 블록의 방향 enum입니다.
    enum BLOCK_DIRECTION
    {
        BD_LEFT,
        BD_TOP,
        BD_RIGHT,
        BD_BOTTOM,

        BD_MAX          // Iteration용
    }

    // 블록의 타입 enum입니다.
    enum BLOCKTYPE
    {
        BT_I,   // I 형태 블록
        BT_L,   // L 형태 블록
        BT_J,   // J 형태 블록
        BT_Z,   // Z 형태 블록
        BT_S,   // Stick 형태 블록
        BT_T,   // T 형태 블록
        BT_O,    // 네모 형태 블록


        BT_MAX    // Iteration용
    }


    partial class Block
    {
        // 블록의 위치
        int m_x = 0;
        int m_y = 0;

        // 이 블록의 타입과 방향이다.
        string[][] blockShape = null;
        // BLOCK_DIRECTION blockDirection = BLOCK_DIRECTION.BD_TOP;

        // 이 블록이 렌더링될 스크린의 정보이다.
        GameScreen screenInfo = null;

        // 게임 스크린을 지정한다.
        public Block(GameScreen _screen)
        {
            // 스크린 정보를 갱신한다.
            screenInfo = _screen;

            // 블록 데이터를 초기화한다.
            DataInit();

            // 일단
            SettingBlock(BLOCKTYPE.BT_T, BLOCK_DIRECTION.BD_RIGHT);
        }

        // 블록 모양을 결정한다.
        private void SettingBlock(BLOCKTYPE _eBlockType, BLOCK_DIRECTION _eBlockDirection)
        {
            blockShape = AllBlock[(int)_eBlockType][(int)_eBlockDirection];
        }

        // 입력을 처리한다.
        private void Input()
        {
            // 내가 키를 누르지 않았다면
            if (Console.KeyAvailable == true)
            {
                return;
            }

            // 키가 눌리면 
            // Console.ReadKey()가 리턴된다. (단 멈춘다.)
            // 그럼 키보드 중 하나라도 눌렸다면 바로 대응한다.
            switch (Console.ReadKey().Key)
            {
            case ConsoleKey.A:
                m_x--;
                break;
            case ConsoleKey.D:
                m_x++;
                break;
            // 한 번에 떨어뜨리는 키
            case ConsoleKey.S:
                m_y++;
                break;
            default:
                break;
            }
        }

        // 블록의 움직임을 처리한다.
        public void Move()
        {
            // 입력 처리를 한다.
            Input();

            // 블럭의 모양대로 그리도록 스크린에 넘겨준다..
            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    // 만약 공백이라면 처음부터 그리지 않는다.
                    if(blockShape[y][x] == "□")
                    {
                        continue;
                    }
                        
                    // 나머지는 그릴 수 있게 블록을 설정한다.
                    screenInfo.SetBlock(m_y + y, m_x + x, blockShape[y][x]);
                }
            }
        }
    }
}
