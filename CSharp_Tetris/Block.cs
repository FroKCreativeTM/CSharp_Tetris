using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

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
        BLOCKTYPE curBlockType = BLOCKTYPE.BT_L;
        BLOCK_DIRECTION curBlockDirection = BLOCK_DIRECTION.BD_TOP;
        // 블록 타입 지정용
        Random newRandom = new Random();

        // 이 블록이 렌더링될 스크린의 정보이다.
        GameScreen screenInfo = null;
        // 블록이 쌓인 것에 대한 정보
        AccScreen AccScreen = null;

        // 게임 스크린을 지정한다.
        public Block(GameScreen _screen, AccScreen _AccScreen)
        {
            if(_screen == null || _AccScreen == null)
            {
                return;
            }

            // 스크린 정보를 갱신한다.
            screenInfo = _screen;

            // 쌓인 블록 정보를 저장한다.
            AccScreen = _AccScreen;

            // 블록 데이터를 초기화한다.
            DataInit();

            // 블록을 생성한다.
            Reset();
        }

        // 블록을 새로 생성한다.
        public void Reset()
        {
            // 블록을 랜덤으로 지정한다.
            RandomBlockType();
            m_x = 0;
            m_y = 1;
            // 블록을 세팅한다.
            SettingBlock(curBlockType, curBlockDirection);
        }

        public void RandomBlockType()
        {
            // 인덱스를 랜덤으로 생성한다.
            int RandomIndex = newRandom.Next((int)BLOCKTYPE.BT_I, (int)BLOCKTYPE.BT_MAX);
            curBlockType = (BLOCKTYPE)RandomIndex;
        }

        // 블록 모양을 결정한다.
        private void SettingBlock(BLOCKTYPE _eBlockType, BLOCK_DIRECTION _eBlockDirection)
        {
            blockShape = AllBlock[(int)_eBlockType][(int)_eBlockDirection];
        }

        // 쌓인 블록 스크린에 적용
        public void SetAccScreen()
        {
            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    // "■" 블록만 찍게
                    if (blockShape[y][x] == "■") 
                    {
                        // y에 -1을 하는 이유는 할당된 스크린을 나가지 않게!
                        AccScreen.SetBlock(m_y + y - 1, m_x + x, blockShape[y][x]);
                    }
                }
            }
        }

        // 더 이상 내려갈 수 있는 지 체크하는 메소드이다.
        public bool DownCheck()
        {
            // 더 이상 내려갈 수 없으면 쌓인다.
            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    // 만약 ■ 모양인 경우 체크
                    if(blockShape[y][x] == "■")
                    {
                        // AccScreen의 Y와 똑같은 경우인지 체크한다.
                        // 또는 아래 블록이 있는 경우
                        if(m_y + y == AccScreen.Y || AccScreen.IsBlock(m_y + y, m_x + x, "■"))
                        {
                            // 쌓인다.
                            SetAccScreen();
                            // 블록을 리셋한다.
                            Reset();
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        // 아래로 내려가게 한다.
        public void Down()
        {
            // 일단 아래를 확인하고 더 이상 내려갈 수 없으면 쌓인다.
            if(DownCheck())
            {
                return;
            }
            m_y++;
        }

        // 입력을 처리한다.
        private void Input()
        {
            // 일단 떨어지는 건 기본이다.
            // m_y++;

            // 내가 키를 누르지 않았다면
            if (Console.KeyAvailable == false)
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
                    Down();
                    break;
                // 왼쪽으로 돌리는 키
                case ConsoleKey.Q:
                    --curBlockDirection;
                    if(0 > curBlockDirection)
                    {
                        curBlockDirection = BLOCK_DIRECTION.BD_BOTTOM;
                    }
                    // 세팅을 바꾼다.
                    SettingBlock(curBlockType, curBlockDirection);
                    break;
                // 오른쪽으로 돌리는 키
                case ConsoleKey.E:
                    ++curBlockDirection;
                    if(curBlockDirection == BLOCK_DIRECTION.BD_MAX)
                    {
                        curBlockDirection = BLOCK_DIRECTION.BD_LEFT;
                    }
                    // 세팅을 바꾼다.
                    SettingBlock(curBlockType, curBlockDirection);
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
