namespace Survival.Weapons
{
    public class Weapon : Item.Item
    {
        public bool IsOnPlayer { get; private set; }

        public void MarkAsInHands()
        {
            IsOnPlayer = true;
        }

        public void OnTakeOff()
        {
            IsOnPlayer = false;
        }
    }
}