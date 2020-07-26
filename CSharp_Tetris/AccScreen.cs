using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_Tetris
{
    // 쌓인 블록 정보를 저장하는 클래스
    class AccScreen : GameScreen
    {
        // 다시 그릴 스크린 또한 필요하다.
        GameScreen screenInfo = null;

        // 라인을 안 그릴꺼니까 false다.
        public AccScreen(GameScreen gameScreen) 
            : base(gameScreen.X, gameScreen.Y - 2, false)
        {
            screenInfo = gameScreen;
        }

        // 한 줄이 다 채워지면 라인을 없앤다.
        public void DestroyCheck()
        {
            for (int y = BlockList.Count - 1; y >= 0 ; y--)
            {
                bool IsDestroy = true;
                for (int x = 0; x < BlockList[y].Count; x++)
                {
                    // 만약 한 라인에 공백이 있다면 부술 필요가 없다.
                    if (BlockList[y][x] == "□")
                    {
                        IsDestroy = false;
                    }
                }

                // 만약 부술 라인이 있다면
                if (IsDestroy)
                {
                    // 새로운 라인을 생성한다.
                    List<string> newLine = new List<string>();

                    // 공백을 넣는다.
                    for (int i = 0; i < X; i++)
                    {
                        newLine.Add("□");
                    }

                    // 맨 뒤를 날리고 다시 넣는다.
                    BlockList.RemoveAt(BlockList.Count - 1);
                    BlockList.Insert(0, newLine);

                    // 내려 앉았으니 다시 검색한다.
                    y = BlockList.Count - 1;
                }
            }

        }

        // 부모가 이미 렌더를 가지고 있다.
        // 그렇기 때문에 오버라이드를 한다.
        public override void Render() 
        {
            for (int y = 0; y < BlockList.Count; y++)
            {
                for (int x = 0; x < BlockList[y].Count; x++)
                {
                    // 부모에게 전달한다.
                    // 단 한 칸 아래 있는 애이기 때문에 y는 + 해서 전달할 필요가 있다.
                    screenInfo.SetBlock(y + 1, x, BlockList[y][x]);
                }
            }
        }
    }
}
