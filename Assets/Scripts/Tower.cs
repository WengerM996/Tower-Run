using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Tower : MonoBehaviour
{
    [SerializeField] private Vector2Int _humanInTowerRange;
    [SerializeField] private Human[] _humansTemplates;

    private List<Human> _humanInTower;

    private void Start()
    {
        _humanInTower = new List<Human>();
        int humanInTowerCount = Random.Range(_humanInTowerRange.x, _humanInTowerRange.y);
        SpawnHumans(humanInTowerCount);
    }

    private void SpawnHumans(int humanCount)
    {
        var spawnPoint = transform.position;

        for (int i = 0; i < humanCount; i++)
        {
            _humanInTower.Add(Instantiate(_humansTemplates[Random.Range(0, _humansTemplates.Length)], spawnPoint, Quaternion.identity, transform));
            _humanInTower[i].transform.localPosition = new Vector3(0f, _humanInTower[i].transform.localPosition.y, 0f);
            spawnPoint = _humanInTower[i].FixationPoint.position;
        }
    }

    public List<Human> CollectHuman(Transform distanceChecker, float fixationMaxDistance)
    {
        for (int i = 0; i < _humanInTower.Count; i++)
        {
            float distanceBetweenPoints = CheckDistanceY(distanceChecker, _humanInTower[i].FixationPoint.transform);
            
            if (distanceBetweenPoints < fixationMaxDistance)
            {
                List<Human> collectedHumans = _humanInTower.GetRange(0, i + 1);
                _humanInTower.RemoveRange(0, i + 1);
                return collectedHumans;
            }
        }

        return null;
    }

    private float CheckDistanceY(Transform distanceChecker, Transform humanFixationPoint)
    {
        Vector3 distanceCheckerY = new Vector3(0,distanceChecker.position.y,0);
        Vector3 humanFixationPointY = new Vector3(0,humanFixationPoint.position.y,0);
        return Vector3.Distance(distanceCheckerY, humanFixationPointY);
    }

    public void Break()
    {
        Destroy(gameObject);
    }
}
