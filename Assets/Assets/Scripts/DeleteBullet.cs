using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteBullet : MonoBehaviour
{
    public static DeleteBullet instance { get; private set; }

    private Transform deleteTransform;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        deleteTransform = GetComponent<Transform>();
    }

    public float getZPos()
    {
        return deleteTransform.position.z;
    }
}
