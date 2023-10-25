using UnityEngine;

public class FuelCanistreController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    private void FixedUpdate()
    {
        _rigidbody2D.velocity = new Vector2(0, -1f);

        switch (_rigidbody2D.position.x)
        {
            case <= -3.5f:
                _rigidbody2D.position = new Vector2(-3.5f, _rigidbody2D.position.y);
                break;
            case >= 3.5f:
                _rigidbody2D.position = new Vector2(3.5f, _rigidbody2D.position.y);
                break;
        }
    }

}
