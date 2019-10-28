namespace Assets.Code
{
    using UnityEngine;
    using UnityEngine.Tilemaps;

    public class WorldMap : MonoBehaviour
    {
        [SerializeField] public TilemapRenderer StartTileMap;
        [SerializeField] public TilemapRenderer VerticalPipeTileMap;
        [SerializeField] public TilemapRenderer VerticalPipeModifierTileMap;
    }
}
