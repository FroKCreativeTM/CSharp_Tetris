using System;

namespace CSharp_Tetris
{
    class Program
    {
        static void Main(string[] args)
        {
            // 게임화면 객체 생성
            GameScreen cGameScreen = new GameScreen(10, 15, true);
            // 쌓인 블록 객체 생성
            AccScreen accScreen = new AccScreen(cGameScreen);
            // 블록을 하나 생성한다.
            Block block = new Block(cGameScreen, accScreen);

            while (true)
            {
                for (int i = 0; i < 40000000; i++)
                {
                    int a = 0;
                }

                // 콘솔창을 지운다.
                Console.Clear();
                // 게임 화면을 그린다.
                // 화면을 비운다.
                cGameScreen.Render();
                // 블록을 쌓인 것 외는 다시 스크린을 그리게 한다.
                cGameScreen.Clear();
                // 쌓인다는 그 자체에 대한 정보를 가져야 한다.
                accScreen.Render();
                // 부술 라인이 있나 체크한다.
                accScreen.DestroyCheck();
                // 블록이 움직인다.
                block.Move();
            }
        }
    }
}
