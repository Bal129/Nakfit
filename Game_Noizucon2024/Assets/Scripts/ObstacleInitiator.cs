using UnityEngine;

public class ObstacleInitiator : MonoBehaviour
{
    [SerializeField] private GameObject obstacle;

    [Header("Developer Options")] 
    [SerializeField] private float _initCd = 3;
    [SerializeField] private int _spawnRange = 7;
    private float _currentCd;
    private float _basePositionY;
    private float _newPositionY;

    void Start() 
    {
        _currentCd = _initCd;
        _basePositionY = transform.position.y;
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
            _newPositionY = _basePositionY + (1.2f * Random.Range(0,_spawnRange));
            Instantiate(
                obstacle, 
                new Vector3(transform.position.x, _newPositionY), 
                Quaternion.identity
            );
            Debug.Log("Obstacle created at " + _newPositionY);
            _currentCd = _initCd;
        }
    }
}
