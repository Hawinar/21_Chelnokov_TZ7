using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private Collider2D _collider2D;
    [SerializeField] private float _speed;

    private void FixedUpdate()
    {
        _rigidbody2D.velocity = new Vector2(0, _speed);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Airplane" && _collider2D.gameObject.tag != "EnemyProjectile")
        {
            Destroy(collision.gameObject);
            Destroy(_collider2D.gameObject);
            Debug.Log("“уда его");
            GameManager.Score += 100;
        }
        if (collision.gameObject.tag == "EnemyProjectile")
        {
            Destroy(collision.gameObject);
            Destroy(_collider2D.gameObject);
        }
    }
}
