using UnityEngine;
using UnityEngine.SceneManagement;

namespace BallGame
{
    public class GameLoader : MonoBehaviour
    {
        private const int SceneNumber = 0;

        [SerializeField] private BallsCreator _ballsCreator;
        [SerializeField] private BallPicker _ballPicker;
        [SerializeField] private Canvas _startCanvas;
        [SerializeField] private Canvas _hudCanvas;
        [SerializeField] private Canvas _finalCanvas;

        private ICounter _scoreCounter;

        private void Start()
        {
            _hudCanvas.gameObject.SetActive(false);
            _startCanvas.gameObject.SetActive(true);
        }

        public void Reset()
        {
            SceneManager.LoadScene(SceneNumber);
        }

        public void AllBallsDestroyGame()
        {

            BallsCreator ballsCreator = Instantiate(_ballsCreator, transform.position, Quaternion.identity);

            BallPicker ballPicker = Instantiate(_ballPicker, Camera.main.transform.position, Quaternion.identity);
            
            _scoreCounter = new ScoreCounterByCount(ballsCreator, _hudCanvas, _finalCanvas);

            ballPicker.SetScoreCounter(_scoreCounter);

            _startCanvas.gameObject.SetActive(false);
        }

        public void OneColorBallsDestroyGame()
        {
            BallsCreator ballsCreator = Instantiate(_ballsCreator, transform.position, Quaternion.identity);

            BallPicker ballPicker = Instantiate(_ballPicker, Camera.main.transform.position, Quaternion.identity);
            
            _scoreCounter = new ScoreCounterByColor(ballPicker, ballsCreator, _hudCanvas, _finalCanvas);

            ballPicker.SetScoreCounter(_scoreCounter);

            _startCanvas.gameObject.SetActive(false);
        }

    }
}
