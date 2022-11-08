using System.Collections;
using System.Collections.Generic;
using Lean.Pool;
using Setups;
using UnityEngine;
using Zenject;

public class PlatformsController : MonoBehaviour
{
    [Inject] private GameSettings _gameSettings;

    private Queue<Platform> _platforms;
    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        if (_platforms.Count< _gameSettings.maxCreatedPlatforms)
        {
            var platform = LeanPool.Spawn(_gameSettings.platform);

            if (_platforms.Count > 0)
            {
                platform.transform.position = _platforms.Peek().NextPlatformSpawnPoint.position;
            }
            
            _platforms.Enqueue(platform);
        }
        
        yield return new WaitForSeconds(0.25f);
    }
}
