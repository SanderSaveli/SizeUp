using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

namespace ViewElements
{
    public class ButtonView : ThemeChanged
    {
        public AnimationClip showAnimation;
        public AnimationClip hideAnimation;

        [SerializeField] protected Image _frontTexture;
        [SerializeField] protected Image _shadow;
        [SerializeField] protected Image _icon;

        [SerializeField]protected Animation _animation;

        private Coroutine _currentAnimationCallbackCorutine = null;
        private List<Action<bool>> _currentAnimationCallbacks;

        private const string _showName = "Show";
        private const string _hideName = "Hide";

        protected void OnEnable()
        {
            _currentAnimationCallbacks = new List<Action<bool>>();
            if(_animation == null) 
            {
                _animation = GetComponent<Animation>();
            }
            _animation.AddClip(showAnimation, _showName);
            _animation.AddClip(hideAnimation, _hideName);
        }
        public void Show(Action<bool> callback = null) 
        {
            if (_animation.GetClip(_showName) == null)
            {
                OnEnable();
            }
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
            if (_animation.Play(_showName)) 
            {
                List<Action<bool>> callBackList = new();
                if (callback != null)
                {
                    callBackList.Add(callback);
                }
                UpdateAnimationCallbacks(_animation.GetClip("Show"), callBackList);
            }
            else 
            {
                callback?.Invoke(true);
            }
        }

        private void PlayHideAnimation(Action<bool> callback = null)
        {
            if (_animation.Play(_hideName)) 
            {
                List<Action<bool>> callBackList = new(); 
                if(callback != null) 
                {
                    callBackList.Add(callback);
                }
                callBackList.Add(InverseSetActiveAllChildren);
                UpdateAnimationCallbacks(_animation.GetClip(_hideName), callBackList);
            }
            else 
            {
                callback?.Invoke(true);
            }
        }

        private void UpdateAnimationCallbacks(AnimationClip clip, List<Action<bool>> actions) 
        {
            if (clip == null)
                return;
            if(_currentAnimationCallbacks != null) 
            {
                foreach(Action<bool> callBack in _currentAnimationCallbacks) 
                {
                    callBack?.Invoke(false);
                    StopCoroutine(_currentAnimationCallbackCorutine);
                }
                if(_currentAnimationCallbackCorutine != null)
                    StopCoroutine(_currentAnimationCallbackCorutine);
            }
            _currentAnimationCallbackCorutine =
                    StartCoroutine(InvokeAfterDelay(clip.length, actions));
            _currentAnimationCallbacks = actions;
        }
        protected IEnumerator InvokeAfterDelay(float delayInSeconds, List<Action<bool>> actions) 
        {
            yield return new WaitForSeconds(delayInSeconds);
            _currentAnimationCallbacks = null;
            _currentAnimationCallbackCorutine = null;

            foreach (Action<bool> callBack in actions)
            {
                callBack?.Invoke(true);
            }
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
            if(state) 
            {
                SetActiveAllChildren(!state);
            }
        }
    }
}
