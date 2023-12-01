using UnityEngine;

public class Hero : MonoBehaviour
{
    private Player player;

    private void Start()
    {
        player = GetComponentInParent<Player>();
    }
    public void Death()
    {
        player.HeroDeath(this);
        Destroy(gameObject);
    }
}
