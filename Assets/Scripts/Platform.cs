using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private Transform nextPlatformSpawnPoint;

    public Transform NextPlatformSpawnPoint => nextPlatformSpawnPoint;
}