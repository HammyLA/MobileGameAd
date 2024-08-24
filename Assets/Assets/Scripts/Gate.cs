using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{

    [SerializeField] private Transform gatePF;
    [SerializeField] private int maxAddNumber;
    [SerializeField] private float gateMoveSpeed;

    private float addValue;
    private Vector3 moveVector;

    private void Start()
    {
        addValue = Random.Range(0, maxAddNumber);
        moveVector = Vector3.back * gateMoveSpeed * Time.deltaTime;
    }

    private void Update()
    {
        gatePF.position += moveVector;
    }
}
