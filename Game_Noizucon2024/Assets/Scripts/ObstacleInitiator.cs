using System;
using UnityEngine;

public class ObstacleInitiator : MonoBehaviour
{
    [Header("PlatformGroup")]
    [SerializeField] private GameObject[] _obstacles;
    private int _selectedObstacle;

    [Header("Developer Options")] 
    [SerializeField] private float _initCd = 7;
    [SerializeField] private int _spawnRange = 3;
    private float _currentCd;
    private float _basePositionX;
    private float _newPositionX;

    void Start() 
    {
        _currentCd = _initCd;
        _basePositionX = transform.position.x;
    }

    void Update() 
    {
        Init();
    }

    void Init() 
    {
        _currentCd -= Time.deltaTime;
        if (_currentCd <= 0)
        {
            _selectedObstacle = UnityEngine.Random.Range(0,_obstacles.Length);
            _newPositionX = _basePositionX + (1.2f * UnityEngine.Random.Range(-_spawnRange,_spawnRange));
            _newPositionX = Math.Clamp(_newPositionX, -4.4f, 4.4f); // Hardcoded for now, edit later
            Instantiate(
                _obstacles[_selectedObstacle], 
                new Vector3(_newPositionX, transform.position.y),
                Quaternion.identity
            );
            // Debug.Log("Platform created at " + _newPositionY);
            // _currentCd = UnityEngine.Random.Range(0f,_initCd);
            _currentCd = _initCd;
        }
    }
}
