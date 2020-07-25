using System;

namespace CSharp_Tetris
{
    class Program
    {
        static void Main(string[] args)
        {
            // 게임화면 객체 생성
            GameScreen cGameScreen = new GameScreen(10, 15);
            // 블록을 하나 생성한다.
            Block block = new Block(cGameScreen);

            while (true)
            {
                for (int i = 0; i < 10000000; i++)
                {
                    int a = 0;
                }

                // 콘솔창을 지운다.
                Console.Clear();
                // 게임 화면을 그린다.
                cGameScreen.Render();
                // 화면을 비운다.
                cGameScreen.Clear();
                // 블록이 움직인다.
                block.Move();
            }
        }
    }
}
