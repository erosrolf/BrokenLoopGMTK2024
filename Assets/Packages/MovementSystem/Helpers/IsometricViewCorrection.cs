using UnityEngine;

namespace MovementSystem.Helpers
{
    public class IsometricViewCorrection
    {
        private Matrix4x4 _isometricMatrix;

        public IsometricViewCorrection(float rotation)
        {
            _isometricMatrix = Matrix4x4.Rotate(Quaternion.Euler(0, rotation, 0));
        }

        public void Correction(ref Vector3 input) => input = _isometricMatrix.MultiplyPoint3x4(input);
    }
}