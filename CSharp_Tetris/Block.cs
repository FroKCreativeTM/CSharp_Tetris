using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_Tetris
{
    enum BLOCKTYPE
    {
        BT_I,   // I 형태 블록
        BT_L,   // L 형태 블록
        BT_J,   // J 형태 블록
        BT_Z,   // Z 형태 블록
        BT_S,   // S 형태 블록
        BT_T,   // T 형태 블록
        BT_O    // 네모 형태 블록
    }


    class Block
    {
        int x = 0;
        int y = 0;

        // 4x4의 저장 공간이 필요하다.
        List<List<string>> BlockData = new List<List<string>>();
        BLOCKTYPE blockType;
        GameScreen screenInfo = null;

        // 게임 스크린을 지정한다.
        public Block(GameScreen _screen)
        {
            screenInfo = _screen;

            for (int y = 0; y < 4; y++)
            {
                BlockData.Add(new List<string>());
            }



            // 4x4안에 뭐든 들어간다.
            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {

                }
            }
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
                x--;
                break;
            case ConsoleKey.D:
                x++;
                break;
            // 한 번에 떨어뜨리는 키
            case ConsoleKey.S:
                y++;
                break;
            default:
                break;
            }
        }

        // 블록의 움직임을 처리한다.
        public void Move()
        {
            Input();
            screenInfo.SetBlock(y, x, "■");
            screenInfo.SetBlock(y + 1, x, "■");
            screenInfo.SetBlock(y + 2, x, "■");
            screenInfo.SetBlock(y + 3, x, "■");
        }
    }
}
