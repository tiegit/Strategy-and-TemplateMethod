using System.Collections.Generic;
using UnityEngine;

namespace BallGame
{
    public class BallsSorter
    {
        public List<Ball> SelectedMaterialBallsPool = new List<Ball>();

        private List<Ball> _ballsPool = new List<Ball>();
        private List<Material> _materials = new List<Material>();
        
        public BallsSorter( List<Ball> ballsPool, List<Material> materials)
        {
            _materials = materials;
            _ballsPool = ballsPool;
        }

        public Material SelectedBallMaterial { get; private set; }

        public void SortBallsByColor()
        {
            SelectedBallMaterial = _materials[UnityEngine.Random.Range(0, _materials.Count)];

            foreach (var ball in _ballsPool)
            {
                if (SelectedBallMaterial.color == ball.GetColor())
                    SelectedMaterialBallsPool.Add(ball);
            }

            //Debug.Log("Выбранный цвет: " + SelectedBallMaterial.name);
            //Debug.Log("Количество элементов первого цвета: " + _selectedMaterialBallsPool.Count);                        
        }        
    }
}
