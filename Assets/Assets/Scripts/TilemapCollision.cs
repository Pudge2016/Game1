using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapCollision : MonoBehaviour
{
    public Tilemap tilemap; // ��������� �� Tilemap
    public TileBase bigWallTile; // ������ BigWall
    TileBase tile;

    void Start()
    {
        // �������� �� ������� �� Tilemap
        foreach (Vector3Int position in tilemap.cellBounds.allPositionsWithin)
        {
            tile = tilemap.GetTile(position); // �������� ������ � �������

            if (tile == bigWallTile) // ���� ������ � BigWall
            {
                // ������ ����� ��� ���� �������
                AddCollisionToTile(position);
            }
        }
    }

    // ����� ��� ��������� ���糿 ��� ������ BigWall
    void AddCollisionToTile(Vector3Int position)
    {
        // ��������� ��'���, ���� ���� ���� ����� ��� ���� ������
        GameObject collisionObject = new GameObject("BigWallCollision");
        collisionObject.transform.position = tilemap.CellToWorld(position);

        // ������ �������� ��� ���� ������
        BoxCollider2D collider = collisionObject.AddComponent<BoxCollider2D>();

        // ����� ����������� ������ ���������, ��� ���� ��������� ������� ������
        collider.size = new Vector2(tilemap.cellSize.x, tilemap.cellSize.y);

        // ������ ��� ��'��� �� �����
        collisionObject.transform.SetParent(tilemap.transform);
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (tile.name == "bigWallTile" && collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("���� �� ���� ������ �� BigWall!");
        }
    }
}
