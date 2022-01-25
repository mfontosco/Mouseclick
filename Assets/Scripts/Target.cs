using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    
    [SerializeField] private float speed;
    [SerializeField] private float maximumHeight = 16;
    [SerializeField] private float minimumHeight = 12;
    public GameManager gameManager;
    public ParticleSystem explosionParticle;
    private Rigidbody playerRb;
    private float maxTorque = 10;
    private float minTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = 6;
    public int pointValue;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerRb = GetComponent<Rigidbody>();
        playerRb.AddForce(RandomForce() * speed, ForceMode.Impulse);
        playerRb.AddTorque(RandomTorque(),RandomTorque(),RandomTorque());
        transform.position = RandomSpawnPos();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            gameManager.UpdateScore(pointValue);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        
        gameManager.GameOver();
        Destroy(gameObject);
    }
    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minimumHeight,maximumHeight);
    }
    float RandomTorque()
    {
        return Random.Range(-minTorque,maxTorque);
    }
    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange,xRange), ySpawnPos);
    }
    //private void FixedUpdate()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        playerRb.AddForce(Vector3.up * Random.Range(12, 16) * speed, ForceMode.Impulse);
    //    }
       
    //}
}
