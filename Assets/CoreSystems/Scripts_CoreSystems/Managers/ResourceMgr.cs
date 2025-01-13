using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceMgr : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject playerPrefab;

    [Header("Transform")]
    public Transform tr;

    // �÷��̾� ������ ��ȯ �޼���
    public GameObject GetPlayerPrefab()
    {
        return playerPrefab;
    }
}
