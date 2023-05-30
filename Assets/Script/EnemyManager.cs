using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] GameObject _player;
    [SerializeField] GameObject _enemy;
    [SerializeField] float _instantiateDis;
    [SerializeField] private int _spawneNum;
    [SerializeField] private EnemySpawner[] _enemySpawners;
    private List<GameObject> _enemies = new List<GameObject>();
    public List<GameObject> Enemies { get => _enemies; set => _enemies = value; }

    private void Update()
    {
        EnemySpawn();
    }

    void EnemySpawn()
    {
        for (int i = 0; i < _spawneNum; i++)
        {
            EnemySpawner enemySpawner = _enemySpawners[i];
            if (!enemySpawner.IsSpawn &&
            Vector3.Distance(_player.transform.position, enemySpawner.transform.position) <= _instantiateDis)
            {
                GameObject tmp = Instantiate(_enemy, enemySpawner.transform.position, Quaternion.identity);
                Enemies.Add(tmp);
                enemySpawner.ChildEnemy = tmp.GetComponent<Enemy>();
                Enemy childEnemy = enemySpawner.ChildEnemy;
                childEnemy.LifeCount.Subscribe(x =>
                {
                    Debug.Log(x);
                    if (x <= 0)
                    {
                        enemySpawner.IsSpawn = false;
                        Enemies.Remove(childEnemy.gameObject);
                        Destroy(childEnemy.gameObject);
                    }
                })
                .AddTo(childEnemy);
                enemySpawner.IsSpawn = true;
            }
        }
    }
}
