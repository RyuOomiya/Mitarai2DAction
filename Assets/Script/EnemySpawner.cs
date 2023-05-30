using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] bool _isSpawn;
    public bool IsSpawn { get => _isSpawn; set => _isSpawn = value; }
    private Enemy _childEnemy;
    public Enemy ChildEnemy { get => _childEnemy; set => _childEnemy = value; }

    private void Start()
    {
        
    }
}
