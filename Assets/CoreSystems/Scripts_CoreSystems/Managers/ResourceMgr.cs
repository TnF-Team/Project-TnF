using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceMgr : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject playerPrefab;

    [Header("Transform")]
    public Transform tr;

    // 플레이어 프리팹 반환 메서드
    public GameObject GetPlayerPrefab()
    {
        return playerPrefab;
    }
}
