using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BallGame
{
    public class BallsCreator : MonoBehaviour
    {
        public List<Ball> BallsPool = new List<Ball>();
        public List<Material> UniqMaterialsPool = new List<Material>();

        [SerializeField] private Ball _ballPrefab;
        [SerializeField, Range(1, 9)] private int _numberOfBalls;
        [SerializeField] private Material[] _materials;

        private List<Material> MaterialsPool = new List<Material>();
        private Material _ballMaterial;
        public BallsSorter BallsSorter { get; private set; }

        private void Awake() // Если поставить Start, то BallsSorter не успевает подготовить цвет
        {
            CereateBalls();

            BallsSorter = new BallsSorter(BallsPool, UniqMaterialsPool);
            BallsSorter.SortBallsByColor();
        }

        private void CereateBalls()
        {
            for (int i = 0; i < _numberOfBalls; i++)
            {
                Vector3 position = new Vector3(i, 0, 0);

                Ball ball = Instantiate(_ballPrefab, transform.position + position, Quaternion.identity);

                _ballMaterial = _materials[UnityEngine.Random.Range(0, _materials.Length)];
                                
                ball.GetComponent<MeshRenderer>().material = _ballMaterial;
                                                
                BallsPool.Add(ball);
                MaterialsPool.Add(_ballMaterial);
            }

            UniqMaterialsPool = MaterialsPool.Distinct().ToList();            
        }
    }
}
