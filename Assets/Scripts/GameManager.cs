using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// khái báo Gâmnager lưu các thông số chính
    /// </summary>
    // static để gọi bất cứ đâu và Instance để truy cập và sủa đổi trưc tiếp các gía trị cửa lớp
    public static GameManager Instance { get; private set; }

    // thế  giới
    public int world { get; private set; }
    // khu vực thế giới
    public int stage { get; private set; }
    // mạng của người chơi
    public int lives { get; private set; }
    // tiền của người chơi
    public int coins { get; private set; }


    // hàm thức dậy 
    private void Awake()
    {
        // xác định luôn thay đổi 
        // nếu thay đổi destroy còn không thay đổi giữ nguyên
        if (Instance != null)
        {
            // nếu đã tồn tại thì bỏ qua 
            DestroyImmediate(gameObject);
        }
        else
        {
            // nếu không tồn tại xác định là giá trị đầu tiên
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void OnDestroy()
    {
        // trong khi destroy các giá trị về rỗng - null
        if (Instance == this)
        {
            Instance = null;
        }
    }

    private void Start()
    {
        // xác định tốc độ chạy frame là 60 frame trên 1 s
        Application.targetFrameRate = 60;
        // gọi ham new game
        NewGame();
    }

    public void NewGame()
    {
        //làm mới lại từ đầu 
        lives = 3;
        coins = 0;
        // chạy về scene khởi đầu 
        LoadLevel(1, 1);
    }
    public void GameOver()
    {
        // TODO: show game over screen

        NewGame();
    }

    public void LoadLevel(int world, int stage)
    {
        this.world = world;
        this.stage = stage;
        if (stage == 2)
        {
            Debug.Log("level 2");
        }
        SceneManager.LoadScene($"{world}-{stage}");


    }

    public void NextLevel()
    {
        float nextgame = stage + 1;
        Debug.Log("Level" + nextgame);
        LoadLevel(world, stage);
    }

    public void ResetLevel(float delay)
    {
        Invoke(nameof(ResetLevel), delay);
    }

    public void ResetLevel()
    {
        lives--;

        if (lives > 0)
        {
            LoadLevel(world, stage);
        }
        else
        {
            GameOver();
        }
    }

    public void AddCoin()
    {
        coins++;

        if (coins == 100)
        {
            coins = 0;
            AddLife();
        }
    }

    public void AddLife()
    {
        lives++;
    }

}
