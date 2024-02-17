using UnityEngine;

namespace TamagotchiClicker
{
    [RequireComponent(typeof(Click))]
    public class ClickBehavior : MonoBehaviour
    {
        [SerializeField] private Click _click;

        private IFadeOut[] _fade;
        private ClickMovement _clickMovement;

        private void Awake()
        {
            _fade = new IFadeOut[] { new FadeText(_click.TextValue), new FadeImage(_click.ImageIcon) };
            _clickMovement = new ClickMovement((RectTransform)transform);
            gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            foreach (IFadeOut fade in _fade)
                fade.FadeOut(_click.FadeConfig.ResultingTransparency, _click.FadeConfig.TimeFading);

            _clickMovement.Move(_click.FadeConfig.TimeFading, _click.FadeConfig.TakeoffAltitude);
        }

        private void OnValidate()
            => _click ??= GetComponent<Click>();
    }
}
