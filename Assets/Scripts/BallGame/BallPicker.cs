using UnityEngine;

namespace BallGame
{
    public class BallPicker : MonoBehaviour
    {        
        private ICounter _scoreCounter;

        public bool InGame { get; set; }

        public void SetScoreCounter(ICounter counter)
        {
            _scoreCounter = counter;
            InGame = true;
        }

        private void LateUpdate()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.TryGetComponent(out Ball ball) && Input.GetMouseButtonDown(0) && InGame)
                {
                    Ball pickedBall = hit.collider.GetComponent<Ball>();

                    _scoreCounter.CheckBall(pickedBall);

                    pickedBall.GetComponent<MeshRenderer>().material.color = Color.yellow;

                    Destroy(hit.collider.gameObject, 0.3f);
                }
            }
        }
    }
}
