using UnityEngine;


public class GameManager : Singleton<GameManager>
{
    [SerializeField] private GameObject xrPrefab;

    private GameObject xrInstance;

    //  상태
    public GameState State { get; private set; } = GameState.GameStart;

    //  점수
    private int score = 0;
    private int fail = 0;

    private void Awake()
    {
        SingletonInit();
        if (xrInstance == null && xrPrefab != null)
        {
            xrInstance = Instantiate(xrPrefab);
            DontDestroyOnLoad(xrInstance);
        }
    }

    private void Start()
    {
        ChangeState(GameState.Preview);
    }


    public void AddScore()
    {
        score++;
        Debug.Log($"점수: {score} 점");
        CheckEndCondition();
    }

    public void FailAttempt()
    {
        fail++;
        Debug.Log($"실패 : {fail} 번");
        CheckEndCondition();
    }

    //  종료 조건 확인
    private void CheckEndCondition()
    {
        if (score >= 3)
        {
            ChangeState(GameState.End);
            Debug.Log("승리!");
        }
        else if (fail >= 3)
        {
            ChangeState(GameState.End);
            Debug.Log("패배!");
        }
    }

    public void ChangeState(GameState state)
    {
        State = state;

        switch (state)
        {
            case GameState.GameStart:
                Debug.Log("게임 시작");
                break;

            case GameState.Preview:
                Debug.Log("사전 탐색 시작");
                break;

            case GameState.Playing:
                Debug.Log("탐색 시작");
                break;

            case GameState.End:
                Debug.Log("게임 종료");
                break;
        }
    }
}