namespace Assets.Code
{
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    ///     Elements for the user interface.
    /// </summary>
    /// <remarks>
    ///     Serializing the field enables me to assign a Game Object within the Unity Engine.
    /// This enables controlling on-screen elements via code. In this example these elements
    /// will be modified by the DisplayHandler.
    /// </remarks>
    public class View : MonoBehaviour
    {
        [SerializeField] public Text userInstructions;
    }
}
