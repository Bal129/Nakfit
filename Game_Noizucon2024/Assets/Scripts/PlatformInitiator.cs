using System;
using UnityEngine;

public class PlatformInitiator : MonoBehaviour
{
    [Header("Platform Group")]
    [SerializeField] private GameObject[] _platforms;
    private int _selectedPlatform;

    [Header("Score Group")]
    [SerializeField] private GameObject[] _scores;
    [SerializeField] private int _scoreSpawnRate = 3;
    private int _scoreSpawnCount;

    [Header("Developer Options")]
    [SerializeField] private float _initCd = 3;
    [SerializeField] private int _spawnRange = 7;
    private float _currentCd;
    private float _basePositionY;
    private float _newPositionY;

    void Start() 
    {
        _currentCd = 0;
        _basePositionY = transform.position.y;
        _scoreSpawnCount = 0;
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
            // Pre initialization
            _selectedPlatform = UnityEngine.Random.Range(0,_platforms.Length);
            _newPositionY = _basePositionY + (1.2f * UnityEngine.Random.Range(-_spawnRange,_spawnRange));
            _newPositionY = Math.Clamp(_newPositionY, 0f, 4.8f); // Hardcoded for now, edit later
            
            // Instatiate platform
            GameObject newPlatform = Instantiate(
                _platforms[_selectedPlatform], 
                new Vector3(transform.position.x, _newPositionY),
                Quaternion.identity
            );
            // Debug.Log("Platform created at " + _newPositionY);
            // _currentCd = UnityEngine.Random.Range(0f,_initCd);

            // Instatiate score
            if (_scoreSpawnCount >= _scoreSpawnRate)
            {    
                GameObject newScore = Instantiate(
                    _scores[0], // 0 for now, may change later
                    new Vector3(transform.position.x, _newPositionY + 1.2f), // 1.2f refers to the scalling, may change later
                    Quaternion.identity
                );
                newScore.transform.parent = newPlatform.transform;
                // ^
                // |
                // set this so that the score would move with the platform
                _scoreSpawnCount = 0; // reset the spawn count
            } 
            else 
            {
                _scoreSpawnCount++;
            }

            // Post initialization
            _currentCd = _initCd;
            transform.position = new Vector2(transform.position.x, _newPositionY);
            _basePositionY = transform.position.y;
        }
    }
}
