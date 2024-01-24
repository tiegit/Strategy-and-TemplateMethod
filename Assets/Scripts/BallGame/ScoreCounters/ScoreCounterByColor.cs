using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BallGame
{
    public class ScoreCounterByColor: ICounter
    {
        private BallPicker _ballPicker;
        private BallsCreator _ballsCreator;
        private Color _selectedBallMaterialColor;
        private List<Ball> _selectedMaterialBallsPool;
        private Canvas _hudCanvas;
        private Canvas _finalCanvas;

        private Win _win;
        private Loose _loose;

        public ScoreCounterByColor(BallPicker ballPicker, BallsCreator ballsCreator, Canvas hudCanvas, Canvas finalCanvas)
        {
            _ballPicker = ballPicker;
            _ballsCreator = ballsCreator;

            _selectedBallMaterialColor = _ballsCreator.BallsSorter.SelectedBallMaterial.color;
            _selectedMaterialBallsPool = _ballsCreator.BallsSorter.SelectedMaterialBallsPool;
            _hudCanvas = hudCanvas;
            _finalCanvas = finalCanvas;

            PrepareCanvases();

            SetHUDMessage();
        }

        public void CheckBall(Ball pickedBall)
        {
            if (pickedBall.GetComponent<MeshRenderer>().material.color == _selectedBallMaterialColor)
            {
                _selectedMaterialBallsPool.Remove(pickedBall);

                if (_selectedMaterialBallsPool.Count <= 0)
                {
                    ShowWinMessage();
                    _ballPicker.InGame = false;
                }
            }
            else
            {
                ShowLooseMessage();
                _ballPicker.InGame = false;
            }
        }

        private void SetHUDMessage()
        {
            _hudCanvas.gameObject.SetActive(true);
            _hudCanvas.GetComponentInChildren<TextMeshProUGUI>().text = "Уничтожте шары ";
            _hudCanvas.GetComponentInChildren<Image>().color = _selectedBallMaterialColor;
        }

        private void ShowWinMessage()
        {
            _loose.gameObject.SetActive(false);
            _win.transform.parent.gameObject.SetActive(true);
            _win.GetComponent<TextMeshProUGUI>().text = "Победа! Ты уничтожил все шары нужного цвета";
        }

        private void ShowLooseMessage()
        {
            _win.gameObject.SetActive(false);
            _loose.transform.parent.gameObject.SetActive(true);
            _loose.GetComponent<TextMeshProUGUI>().text = "Проиграл! Ты уничтожил не тот шар";
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
