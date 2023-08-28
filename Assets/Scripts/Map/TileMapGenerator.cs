using System.Collections.Generic;
using UnityEngine;

public class TileMapGenerator : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private GameObject[] _tilePrefabs; 
    [SerializeField] private int _tileSize = 20;
    [SerializeField] private int _preloadDistance = 3;

    private Vector2Int _playerTilePosition;
    private Dictionary<Vector2Int, GameObject> _activeTiles = new Dictionary<Vector2Int, GameObject>();

    private void Start()
    {
        _playerTilePosition = GetTilePositionFromWorldPoint(_player.position);
        GenerateInitialMap();
    }

    private void Update()
    {
        Vector2Int newPlayerTilePosition = GetTilePositionFromWorldPoint(_player.position);

        if (newPlayerTilePosition != _playerTilePosition)
        {
            _playerTilePosition = newPlayerTilePosition;
            GenerateMapAroundPlayer();
        }
    }

    private void GenerateInitialMap()
    {
        for (int x = -_preloadDistance; x <= _preloadDistance; x++)
        {
            for (int y = -_preloadDistance; y <= _preloadDistance; y++)
            {
                Vector2Int tilePosition = new Vector2Int(_playerTilePosition.x + x, _playerTilePosition.y + y);
                GenerateTile(tilePosition);
            }
        }
    }

    private void GenerateMapAroundPlayer()
    {
        HashSet<Vector2Int> tilesToRemove = new HashSet<Vector2Int>(_activeTiles.Keys);
        for (int x = -_preloadDistance; x <= _preloadDistance; x++)
        {
            for (int y = -_preloadDistance; y <= _preloadDistance; y++)
            {
                Vector2Int tilePosition = new Vector2Int(_playerTilePosition.x + x, _playerTilePosition.y + y);

                if (_activeTiles.ContainsKey(tilePosition))
                {
                    tilesToRemove.Remove(tilePosition);
                }
                else
                {
                    GenerateTile(tilePosition);
                }
            }
        }

        foreach (Vector2Int tilePosition in tilesToRemove)
        {
            DeactivateTile(tilePosition);
        }
    }

    private void GenerateTile(Vector2Int tilePosition)
    {
        GameObject tilePrefab = GetRandomTilePrefab(); 
        GameObject newTile = Instantiate(tilePrefab, GetWorldPointFromTilePosition(tilePosition), Quaternion.identity);
        newTile.SetActive(true);
        _activeTiles.Add(tilePosition, newTile);
    }

    private void DeactivateTile(Vector2Int tilePosition)
    {
        if (_activeTiles.TryGetValue(tilePosition, out GameObject tile))
        {
            _activeTiles.Remove(tilePosition);
            tile.SetActive(false);
        }
    }

    private Vector2Int GetTilePositionFromWorldPoint(Vector3 worldPoint)
    {
        int x = Mathf.FloorToInt(worldPoint.x / _tileSize);
        int y = Mathf.FloorToInt(worldPoint.y / _tileSize);
        return new Vector2Int(x, y);
    }

    private Vector3 GetWorldPointFromTilePosition(Vector2Int tilePosition)
    {
        float x = tilePosition.x * _tileSize + _tileSize / 2f;
        float y = tilePosition.y * _tileSize + _tileSize / 2f;
        return new Vector3(x, y, 0f);
    }

    private GameObject GetRandomTilePrefab()
    {
        int randomIndex = Random.Range(0, _tilePrefabs.Length);
        return _tilePrefabs[randomIndex];
    }
}
