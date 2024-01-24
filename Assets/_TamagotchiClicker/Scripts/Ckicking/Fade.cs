namespace TamagotchiClicker
{
    public abstract class Fade
    {
        protected readonly float resultingTransparency;
        protected readonly float timeFading;

        public Fade(float resultingTransparency,
                    float timeFading)
        {
            this.resultingTransparency = resultingTransparency;
            this.timeFading = timeFading;
        }

        public abstract void FadeOut();
    }
}
