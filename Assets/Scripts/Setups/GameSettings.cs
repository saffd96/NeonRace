using UnityEngine;

namespace Setups
{
    [CreateAssetMenu(fileName = "GameSettings")]

    public class GameSettings : ScriptableObject
    {
        [Header("Prefabs")]
        public Platform platform;

        [Header("Game Settings")]
        public float minMaxAngle = 135f;

        public int maxCreatedPlatforms = 3;
    }
}