using UnityEngine;

public class Hero : MonoBehaviour
{
    private Player player;
    private Vector3 moveTarget;
    [SerializeField] private float speed;
    private bool switchDirection = false;

    private float transX;
    private float transY;
    private float transZ;

    //[SerializeField] private float offsetX = 0.5f;
    private void Start()
    {
        player = GetComponentInParent<Player>();
    }

    private void Update()
    {
        if (switchDirection)
        {
            transX = transform.position.x;
            transY = 0;
            transZ = transform.position.z;
            switchDirection = false;
        }

        if (moveTarget != Vector3.zero)
            if (Mathf.Abs((transX + moveTarget.x - transform.position.x)/* * offsetX*/) >= 0.05f)
                transform.position = Vector3.MoveTowards(transform.position, new Vector3((transX - moveTarget.x)/* * offsetX*/, transform.position.y, transform.position.z), speed * Time.deltaTime);

        Debug.Log(new Vector3(moveTarget.x, 0, 0));
    }

    public void Death()
    {
        player.HeroDeath(this);
        Destroy(gameObject);
    }

    public Vector3 MoveTarget
    {
        get { return moveTarget; }
        set { moveTarget = value; }
    }

    public bool Tumbler
    {
        get { return switchDirection; }
        set { switchDirection = value; }
    }
}
