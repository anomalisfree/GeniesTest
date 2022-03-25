using System;
using UnityEngine;

namespace Main.Scripts
{
    public class TouchController : MonoBehaviour
    {
        public Action<Vector2> IsBegan;
        public Action<Vector2> IsMoved;
        public Action<Vector2> IsEnded;

        private float _delayTimer;

        private const float DelayDelta = .2f;

        private void Update()
        {
            if (_delayTimer <= 0)
            {
                if (Input.touchCount == 0)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        HandleTouch(Input.mousePosition, TouchPhase.Began);
                    }

                    if (Input.GetMouseButton(0))
                    {
                        HandleTouch(Input.mousePosition, TouchPhase.Moved);
                    }

                    if (Input.GetMouseButtonUp(0))
                    {
                        HandleTouch(Input.mousePosition, TouchPhase.Ended);
                    }
                }
                else
                {
                    HandleTouch(Input.touches[0].position, Input.touches[0].phase);
                }
            }
            else
            {
                _delayTimer -= Time.deltaTime;
            }
        }

        private void HandleTouch(Vector3 touchPosition, TouchPhase touchPhase)
        {
            var moveDelta = new Vector2(touchPosition.x / Screen.currentResolution.width,
                touchPosition.y / Screen.currentResolution.width);

            switch (touchPhase)
            {
                case TouchPhase.Began:
                    IsBegan?.Invoke(moveDelta);
                    break;
                case TouchPhase.Moved:
                    IsMoved?.Invoke(moveDelta);
                    break;
                case TouchPhase.Ended:
                    IsEnded?.Invoke(moveDelta);
                    break;
            }
        }

        public void EventDelay()
        {
            _delayTimer = DelayDelta;
        }
    }
}