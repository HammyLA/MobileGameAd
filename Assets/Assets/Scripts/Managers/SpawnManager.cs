using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public static SpawnManager instance {  get; private set; }



    [SerializeField] private Transform enemyPF;
    [SerializeField] private Transform gatePF;
    [SerializeField] private float spawnTimerMax;
    [SerializeField] private float spawnTimerMin;
    [SerializeField] private float spawnRange;
    [SerializeField] private float gateSpawnTimerMax;
    [SerializeField] private float spawnExponential;
    [SerializeField] private float spawnBase;

    private Transform spawnPlace;
    private float spawnTimer;
    private float gateSpawnTimer;
    private float spawnX;
    private float gateSpawnX;
    private float gateX = 3.5f;


    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        spawnTimer = spawnTimerMax;
        gateSpawnTimer = gateSpawnTimerMax;

        spawnX = Random.Range(-spawnRange, spawnRange);
        SetGateSpawnX();

        spawnPlace = GetComponent<Transform>();
    }

    private void Update()
    {
        spawnTimer -= Time.deltaTime;
        gateSpawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0)
        {
            Instantiate(enemyPF, new Vector3(spawnX, spawnPlace.position.y, spawnPlace.position.z), enemyPF.transform.rotation);
            spawnTimer = Random.Range(spawnTimerMin, spawnTimerMax) / Mathf.Pow(spawnBase, spawnExponential * Time.timeSinceLevelLoad);
            spawnX = Random.Range(-spawnRange, spawnRange);
        }
    }

    private void SetGateSpawnX()
    {
        int val = Random.Range(0, 100);
        if (val >= 50)
        {
            gateSpawnX = gateX;
        }
        else
        {
            gateSpawnX = -gateX;
        }
    }

}
