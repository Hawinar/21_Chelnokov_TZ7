using System;
using System.Collections.Generic;
using UnityEngine;

public class AirplaneController : MonoBehaviour
{
    [SerializeField] private GameObject _projectile;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private List<Skin> skins = new List<Skin>();

    [SerializeField] private float _timeBetweenShot;
    private float _time;

    private void Start()
    {
        int rnd = UnityEngine.Random.Range(0, skins.Count);
        _spriteRenderer.sprite = skins[rnd].sprite;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Time.time > _time)
        {

            Shot();
            _time = Time.time + _timeBetweenShot;
        }
    }
    private void FixedUpdate()
    {
        float targetXPosition = Mathf.Clamp(_rigidbody2D.position.x, -3.5f, 3.5f);
        Vector2 targetPosition = new Vector2(targetXPosition, _rigidbody2D.position.y);
        _rigidbody2D.MovePosition(targetPosition);
    }
    [Serializable]
    class Skin
    {
        public Sprite sprite;
    }
    private void Shot()
    {
        Instantiate(_projectile, _rigidbody2D.transform.position + new Vector3(0, -0.75f, 0), new Quaternion(0, 0, 0, 0));
    }
}
