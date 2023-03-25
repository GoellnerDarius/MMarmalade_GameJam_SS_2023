using UnityEngine;

public class BulletMove : MonoBehaviour
{
    // Start is called before the first frame update
    public float BulletSpeed = 30;

    private int pierce;

    void Start()
    {
        pierce = PowerUpSates.piercing;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 1, 0) * (BulletSpeed * Time.deltaTime));
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Collided(col);
    }

    private void Collided(Collider2D other)
    {
        Debug.Log(tag + " collides with " + other.tag, gameObject);

        if (this.CompareTag("EnemyBullet") && !other.CompareTag("EnemyBullet") && !other.CompareTag("Enemy"))
        {
            // Hey moch wos cooles?
        }

        //Reduces Piercing and deletes Bullet
        if (this.CompareTag("PlayerBullet") && !other.CompareTag("PlayerBullet") && !other.CompareTag("Player"))
        {
            pierce--;
            if (pierce <= 0)
                Destroy(gameObject);
            if (other.CompareTag("EnemyBullet"))
                Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Collided(col.collider);
    }
}
