namespace WeaponSwitchingGame
{
    public interface IControllableCharacter
    {
        public void SetInput(float h, float v, float rotateY);

        public void RotateX(float value);
    }
}