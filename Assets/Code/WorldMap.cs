namespace Assets.Code
{
    using UnityEngine;
    using UnityEngine.Tilemaps;

    public class WorldMap : MonoBehaviour
    {
        [SerializeField] public TilemapRenderer Start;
        [SerializeField] public TilemapRenderer VerticalPipe;
        [SerializeField] public TilemapRenderer VerticalPipeModifier;
        [SerializeField] public TilemapRenderer VerticalT;
        [SerializeField] public TilemapRenderer HorizontalPipe;
        [SerializeField] public TilemapRenderer FlippedLeftAngle;
        [SerializeField] public TilemapRenderer LeftAngle;
        [SerializeField] public TilemapRenderer FlippedHorizontalT;
        [SerializeField] public TilemapRenderer FlippedRightAngle;
        [SerializeField] public TilemapRenderer End;
    }
}
