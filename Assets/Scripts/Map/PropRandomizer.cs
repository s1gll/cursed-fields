using System.Collections.Generic;
using UnityEngine;

public class PropRandomizer : MonoBehaviour
{
    [SerializeField] private List<GameObject> _propSpawnPoints;
    [SerializeField] private List<GameObject> _propPrefabs;

    private void Start()
    {
        SpawnProps();
    }

    private void SpawnProps()
    {
        foreach (GameObject spawn in _propSpawnPoints)
        {
            int randomProp = Random.Range(0, _propPrefabs.Count);

            GameObject prop = Instantiate(_propPrefabs[randomProp], spawn.transform.position, Quaternion.identity);
            prop.transform.parent = spawn.transform;
        }
    }
}

