using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _enemies;
    public List<GameObject> Enemies { get => _enemies; set => _enemies = value; }
}
