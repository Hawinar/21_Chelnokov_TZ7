using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private GameObject _fuelCanister;
    [SerializeField] private float _timeBetweenSpawn;

    private List<int> spawnList = new List<int>() { 1, 2, 3, 4, 5 };
    private float _time;

    // Update is called once per frame
    private void Update()
    {
        if (Time.time > _time)
        {
            int rnd = Random.Range(0, spawnList.Count);

            switch (rnd)
            {
                case 1:
                    Spawn(_fuelCanister);
                    break;
                default:
                    Spawn(_enemy);
                    break;
            }
            _time = Time.time + _timeBetweenSpawn;
        }
    }
    private void Spawn(GameObject gameObject)
    {
        float x = Random.Range(-3.5f, 3.5f);
        Instantiate(gameObject, new Vector3(x, 6, 0), new Quaternion(0, 0, 0, 0));
    }
}
