using TMPro;
using UnityEngine;

public class EndGameWindow : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    private Score score;
    void Start()
    {
        score = FindAnyObjectByType<Score>();
        scoreText.text = $"Score: {score.Value}";
    }
}
