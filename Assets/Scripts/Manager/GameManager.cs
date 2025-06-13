using UnityEngine;


public class GameManager : Singleton<GameManager>
{
    [SerializeField] private GameObject xrPrefab;

    private GameObject xrInstance;

    //  ����
    public GameState State { get; private set; } = GameState.GameStart;

    //  ����
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
        Debug.Log($"����: {score} ��");
        CheckEndCondition();
    }

    public void FailAttempt()
    {
        fail++;
        Debug.Log($"���� : {fail} ��");
        CheckEndCondition();
    }

    //  ���� ���� Ȯ��
    private void CheckEndCondition()
    {
        if (score >= 3)
        {
            ChangeState(GameState.End);
            Debug.Log("�¸�!");
        }
        else if (fail >= 3)
        {
            ChangeState(GameState.End);
            Debug.Log("�й�!");
        }
    }

    public void ChangeState(GameState state)
    {
        State = state;

        switch (state)
        {
            case GameState.GameStart:
                Debug.Log("���� ����");
                break;

            case GameState.Preview:
                Debug.Log("���� Ž�� ����");
                break;

            case GameState.Playing:
                Debug.Log("Ž�� ����");
                break;

            case GameState.End:
                Debug.Log("���� ����");
                break;
        }
    }
}