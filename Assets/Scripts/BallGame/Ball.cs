using UnityEngine;

namespace BallGame
{
    public class Ball : MonoBehaviour
    {
        public Color GetColor()
        {
            return gameObject.GetComponent<MeshRenderer>().material.color;
        }
    }
}
