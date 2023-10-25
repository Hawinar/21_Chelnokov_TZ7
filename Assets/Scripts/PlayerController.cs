using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private Rigidbody2D _rigidbody2D;

    [SerializeField] private GameObject _projectile;
    [SerializeField] private float _timeBetweenShot;
    private float _time;

    // Update is called once per frame
    private void Update()
    {
        if (Time.time > _time)
        {

            Shot();
            _time = Time.time + _timeBetweenShot;
        }
    }
    private void OnMouseDrag()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float targetXPosition = Mathf.Clamp(mousePosition.x, -3.5f, 3.5f);
        float targetYPosition = Mathf.Clamp(mousePosition.y, -2.5f, 4f);

        Vector2 position = new Vector2(targetXPosition, targetYPosition);

        _rigidbody2D.MovePosition(position);
    }
    private void Shot()
    {
        Instantiate(_projectile, _player.transform.position + new Vector3(0, 0.75f, 0), new Quaternion(0, 0, 0, 0));
    }
}
