using UnityEngine;

public class FuelCanistreController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    private void FixedUpdate()
    {
        _rigidbody2D.velocity = new Vector2(0, -1f);

        float targetXPosition = Mathf.Clamp(_rigidbody2D.position.x, -3.5f, 3.5f);
        Vector2 targetPosition = new Vector2(targetXPosition, _rigidbody2D.position.y);
        _rigidbody2D.MovePosition(targetPosition);
    }

}
