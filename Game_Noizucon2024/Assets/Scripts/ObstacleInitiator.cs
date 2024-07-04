using UnityEngine;

public class ObstacleInitiator : MonoBehaviour
{
    [SerializeField] private GameObject obstacle;

    [Header("Developer Options")] 
    [SerializeField] private float initCd = 3;
    private float currentCd;
    private float basePositionY;
    private float newPositionY;

    void Start() {
        currentCd = initCd;
        basePositionY = transform.position.y;
    }

    void Update() {
        Init();
    }

    void Init() {
        currentCd -= Time.deltaTime;
        if (currentCd <= 0) {
            newPositionY = basePositionY + Random.Range(0f,3f);
            Instantiate(
                obstacle, 
                new Vector3(transform.position.x, newPositionY), 
                Quaternion.identity
            );
            Debug.Log("Obstacle created at " + newPositionY);
            currentCd = initCd;
        }
    }
}
