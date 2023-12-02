using UnityEngine;

public class Hero : MonoBehaviour
{
    private Player player;
    private Transform moveTarget;
    [SerializeField] private float speed;

    private void Start()
    {
        player = GetComponentInParent<Player>();
    }

    private void Update()
    {
        if (moveTarget != null)
        {
            if (Vector3.Distance(transform.position, moveTarget.position) > 0.05)
                transform.position = Vector3.MoveTowards(transform.position, moveTarget.position, speed * Time.deltaTime);
            else
                moveTarget = null;
        }
    }

    public void Death()
    {
        player.HeroDeath(this);
        Destroy(gameObject);
    }

    public Transform MoveTarget
    {
        get { return moveTarget; }
        set { moveTarget = value; }
    }
}
