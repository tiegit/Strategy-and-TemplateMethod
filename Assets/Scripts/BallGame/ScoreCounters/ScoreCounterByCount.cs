using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BallGame
{
    public class ScoreCounterByCount: ICounter
    {
        private BallsCreator _ballsCreator;
        private Canvas _hudCanvas;
        private Canvas _finalCanvas;

        private Win _win;
        private Loose _loose;

        public ScoreCounterByCount(BallsCreator ballsCreator, Canvas hudCanvas, Canvas finalCanvas)
        {
            _ballsCreator = ballsCreator;            
            _hudCanvas = hudCanvas;
            _finalCanvas = finalCanvas;

            PrepareCanvases();

            SetHUDMessage();
        }

        public void CheckBall(Ball pickedBall)
        {
            _ballsCreator.BallsPool.Remove(pickedBall);
            if(_ballsCreator.BallsPool.Count <= 0) ShowWinMessage();
        }

        private void SetHUDMessage()
        {
            _hudCanvas.gameObject.SetActive(true);
            _hudCanvas.GetComponentInChildren<TextMeshProUGUI>().text = "Уничтожте все шары ";
            _hudCanvas.GetComponentInChildren<Image>().gameObject.SetActive(false);
        }

        private void ShowWinMessage()
        {
            _loose.gameObject.SetActive(false);
            _win.transform.parent.gameObject.SetActive(true);
            _win.GetComponent<TextMeshProUGUI>().text = "Победа! Ты уничтожил все шары";
        }

        private void PrepareCanvases()
        {
            _win = _finalCanvas.GetComponentInChildren<Win>();
            _win.transform.parent.gameObject.SetActive(false);
            _loose = _finalCanvas.GetComponentInChildren<Loose>();
            _loose.transform.parent.gameObject.SetActive(false);
        }
    }
}