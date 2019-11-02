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
        [SerializeField] public TilemapRenderer HorizontalPipe2;
        [SerializeField] public TilemapRenderer HorizontalPipeOverlay;
        [SerializeField] public TilemapRenderer FlippedLeftAngle;
        [SerializeField] public TilemapRenderer LeftAngle;
        [SerializeField] public TilemapRenderer LeftAngleModifier;
        [SerializeField] public TilemapRenderer FlippedHorizontalT;
        [SerializeField] public TilemapRenderer FlippedRightAngle;
        [SerializeField] public TilemapRenderer FlippedRightAngleOverlay;
        [SerializeField] public TilemapRenderer End;
        [SerializeField] public TilemapRenderer EndOverlay;
        [SerializeField] public TilemapRenderer EndOverlay2;
    }
}
