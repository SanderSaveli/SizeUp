using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace ViewElements
{
    public class ButtonView : ThemeChanged
    {
        public AnimationClip showAnimation;
        public AnimationClip hideAnimation;

        [SerializeField] private Image _frontTexture;
        [SerializeField] private Image _shadow;
        [SerializeField] private Image _icon;

        private Animation _animation;

        private Coroutine _currentAnimationCallbackCorutine;
        private Action<bool> _currentAnimationCallback;

        private void OnEnable()
        {
            _animation = GetComponent<Animation>();
            _animation.AddClip(showAnimation, "Show");
            _animation.AddClip(hideAnimation, "Hide");
        }
        public void Show(Action<bool> callback = null) 
        {
            SetActiveAllChildren(true);
            PlayShowAnimation(callback);
        }

        public void Hide(Action<bool> callback = null) 
        {
            PlayHideAnimation(callback);
        }
        public override void ChangeTheme(Theme theme)
        {
            ButtonTheme buttonTheme = theme.ButtonTheme;
            _frontTexture.color = buttonTheme.ButtonColor;
            _icon.color = buttonTheme.IconColor;
        }

        private void PlayShowAnimation(Action<bool> callback = null) 
        {
            if (_animation.Play("Show")) 
            {
                if(callback != null) 
                {
                    UpdateAnimationCallback(_animation.clip, callback);
                }
            }
            else 
            {
                callback?.Invoke(true);
            }
        }

        private void PlayHideAnimation(Action<bool> callback = null)
        {
            if (_animation.Play("Hide")) 
            {
                if(callback != null) 
                {
                    UpdateAnimationCallback(_animation.clip, callback);
                    InvokeAfterDelay(_animation.clip.length, InverseSetActiveAllChildren);
                }
            }
            else 
            {
                callback?.Invoke(true);
            }
        }

        private void UpdateAnimationCallback(AnimationClip clip, Action<bool> action) 
        {
            if(_currentAnimationCallback != null) 
            {
                _currentAnimationCallback?.Invoke(false);
                StopCoroutine(_currentAnimationCallbackCorutine);
                _currentAnimationCallback = null;
                _currentAnimationCallbackCorutine = null;
            }
            _currentAnimationCallbackCorutine =
                    StartCoroutine(InvokeAfterDelay(clip.length, action));
            _currentAnimationCallback = action;
        }
        protected IEnumerator InvokeAfterDelay(float delayInSeconds, Action<bool> action) 
        {
            yield return new WaitForSeconds(delayInSeconds);
            _currentAnimationCallback = null;
            _currentAnimationCallbackCorutine = null;
            action?.Invoke(true);
        }

        private void SetActiveAllChildren(bool state) 
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(state);
            }
        }

        private void InverseSetActiveAllChildren(bool state) 
        {
            SetActiveAllChildren(!state);
        }
    }
}
