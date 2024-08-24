using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering.Universal;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance {  get; private set; }

    [SerializeField] private Transform playerPF;
    [SerializeField] private LayerMask wallLayerMask;
    [SerializeField] private float speed;
    [SerializeField] private WeaponSO weaponSO;
    [SerializeField] private int health;

    private bool addedPlayer;
    private Transform playerManagerTransform;
    private Player[] playerPFList;
    private GameInput gameInput;
    private float playerSize;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        gameInput = GameInput.instance;
        playerManagerTransform = this.transform;

        Instantiate(playerPF, playerManagerTransform);


        playerPFList = GetComponentsInChildren<Player>();
        playerSize = 1f;
    }

    private void Update()
    {
        bool canMove = !Physics.Raycast(this.transform.position, Movement(), playerSize, wallLayerMask);
        if (canMove)
        {
            this.transform.position += Movement() * Time.deltaTime * speed;
        }
    }

    private float GetPlayerListPositionData()
    {
        float positionXSum = 0;
        foreach (Player player in playerPFList) {
            positionXSum += player.transform.position.x;
        }
        return positionXSum / playerPFList.Length;
    }

    public WeaponSO GetPlayerWeaponSO()
    {
        return weaponSO;
    }

    public int GetPlayerHealth()
    {
        return health;
    }

    public Player[] GetPlayerPFList()
    {
        return playerPFList;
    }

    public void AddPlayer()
    {
        Instantiate(playerPF, playerManagerTransform);
        playerPFList = GetComponentsInChildren<Player>();
         

        if (playerPFList.Length % 2 == 0)
        {
            playerPFList[playerPFList.Length - 1].transform.localPosition = Vector3.right * Mathf.Floor(playerPFList.Length / 2);
        }
        else
        {
            playerPFList[playerPFList.Length - 1].transform.localPosition = Vector3.left * Mathf.Floor(playerPFList.Length / 2);
            playerSize += 1;
        }

    }

    public void upgradePlayerWeapons()
    {
        if (weaponSO.upgradeSO != null)
        {
            weaponSO = weaponSO.upgradeSO;
            foreach (Player player in playerPFList)
            {
                player.SetPlayerWeaponSO(weaponSO);
            }
        }

    }

    public void decrementHealth()
    {
        health--;
    }

    private Vector3 Movement()
    {
        Vector2 inputVector = gameInput.getNormalizedMovementVector();
        Vector3 movement = new Vector3(inputVector.x, inputVector.y);
        return movement;
    }
}
