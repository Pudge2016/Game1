using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapCollision : MonoBehaviour
{
    public Tilemap tilemap; // посилання на Tilemap
    public TileBase bigWallTile; // плитка BigWall
    TileBase tile;

    void Start()
    {
        // Отримуємо всі клітинки на Tilemap
        foreach (Vector3Int position in tilemap.cellBounds.allPositionsWithin)
        {
            tile = tilemap.GetTile(position); // отримуємо плитку в позиції

            if (tile == bigWallTile) // якщо плитка є BigWall
            {
                // Додаємо колізію для цієї клітинки
                AddCollisionToTile(position);
            }
        }
    }

    // Метод для додавання колізії для плитки BigWall
    void AddCollisionToTile(Vector3Int position)
    {
        // Створюємо об'єкт, який буде мати колізію для цієї плитки
        GameObject collisionObject = new GameObject("BigWallCollision");
        collisionObject.transform.position = tilemap.CellToWorld(position);

        // Додаємо колайдер для цієї плитки
        BoxCollider2D collider = collisionObject.AddComponent<BoxCollider2D>();

        // Можна налаштувати розміри колайдера, щоб вони відповідали розмірам плитки
        collider.size = new Vector2(tilemap.cellSize.x, tilemap.cellSize.y);

        // Додаємо цей об'єкт на сцену
        collisionObject.transform.SetParent(tilemap.transform);
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (tile.name == "bigWallTile" && collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Танк не може наїхати на BigWall!");
        }
    }
}
