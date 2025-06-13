using UnityEngine;


public class GameManager : Singleton<GameManager>
{
    [SerializeField] private GameObject xrPrefab;

    private GameObject xrInstance;

    //  ����
    public GameState State { get; private set; } = GameState.GameStart;
    public ScoreManager Score { get; set; }
    //  ����


    private void Awake()
    {
        SingletonInit();
        if (xrInstance == null && xrPrefab != null)
        {
            xrInstance = Instantiate(xrPrefab);
            DontDestroyOnLoad(xrInstance);
        }
    }

    public void ChangeGameState(GameState newState)
    {
        State = newState;

        switch (newState)
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