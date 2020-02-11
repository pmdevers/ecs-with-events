namespace Game.Engine.Events
{
    public class MouseMovedEvent
    {
        public float XPos { get; }
        public float YPos { get; }

        public MouseMovedEvent(float xPos, float yPos)
        {
            XPos = xPos;
            YPos = yPos;
        }

        public override string ToString()
        {
            return $"Mouse moved to X: '{XPos}' Y: '{YPos}'.";
        }
    }
}