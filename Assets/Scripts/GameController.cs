using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Transform finish;

    [SerializeField] private GameObject victoryWindow;
    [SerializeField] private GameObject defeatWindow;

    [SerializeField] private Score score;

    void Update()
    {
        if (!defeatWindow.activeSelf)
            player.Move(finish);

        if (player.HeroAlivesCount() == 0)
            defeatWindow.SetActive(true);

        if (Vector3.Distance(player.transform.position, finish.position) <= 0.05f)
            victoryWindow.SetActive(true);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
