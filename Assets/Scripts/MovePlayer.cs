using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public GameObject player;
    public Rigidbody2D rb;
    public float speed = 7f;
    private float movement;
    public static float direction;


    private void Start()
    {
        Cursor.visible = false;
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        movement = Input.GetAxis("Horizontal");
        if (movement > 0)
        {
            player.transform.localScale = new Vector2(1, 1);
            direction = 1;
        }
        else if (movement < 0)
        {
            player.transform.localScale = new Vector2(-1, 1);
            direction = -1;
        }

        rb.velocity = new Vector2(speed * movement, rb.velocity.y);
    }
    private void Update()
    {
        player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -1);
    }
}
