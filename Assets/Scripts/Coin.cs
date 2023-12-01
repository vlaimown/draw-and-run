using UnityEngine;

public class Coin : MonoBehaviour
{
    private Score score;
    [SerializeField] private int value;

    private void Start()
    {
        score = FindAnyObjectByType<Score>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hero"))
        {
            score.Value += value;
            Destroy(gameObject);
        }
    }
}
