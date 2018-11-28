using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public enum Swipe
    {
        None,
        Up,
        Down,
        Left,
        Right,
        UpLeft,
        UpRight,
        DownLeft,
        DownRight
    };

    public class SwipeManager  : MonoBehaviour
    {
        // Min length to detect the Swipe
        public float MinSwipeLength = 5f;

        private Vector2 _firstPressPos;
        private Vector2 _secondPressPos;
        private Vector2 _currentSwipe;

        private Vector2 _firstClickPos;
        private Vector2 _secondClickPos;

        public static Swipe SwipeDirection;
        public float ReturnForce = 10f;

        private void FixedUpdate()
        {
            DetectSwipe();
        }

        public void DetectSwipe()
        {
            if (Input.touches.Length > 0)
            {
                Touch t = Input.GetTouch(0);

                if (t.phase == TouchPhase.Began)
                {
                    _firstPressPos = new Vector2(t.position.x, t.position.y);
                }

                if (t.phase == TouchPhase.Ended)
                {
                    _secondPressPos = new Vector2(t.position.x, t.position.y);
                    _currentSwipe = new Vector3(_secondPressPos.x - _firstPressPos.x, _secondPressPos.y - _firstPressPos.y);

                    // Make sure it was a legit swipe, not a tap
                    if (_currentSwipe.magnitude < MinSwipeLength)
                    {
                        SwipeDirection = Swipe.None;
                        return;
                    }

                    _currentSwipe.Normalize();

                    // Swipe up
                    if (_currentSwipe.y > 0 && _currentSwipe.x > -0.5f && _currentSwipe.x < 0.5f)
                    {
                        SwipeDirection = Swipe.Up;
                    }
                    // Swipe down
                    else if (_currentSwipe.y < 0 && _currentSwipe.x > -0.5f && _currentSwipe.x < 0.5f)
                    {
                        SwipeDirection = Swipe.Down;
                    }
                    // Swipe left
                    else if (_currentSwipe.x < 0 && _currentSwipe.y > -0.5f && _currentSwipe.y < 0.5f)
                    {
                        SwipeDirection = Swipe.Left;
                    }
                    // Swipe right
                    else if (_currentSwipe.x > 0 && _currentSwipe.y > -0.5f && _currentSwipe.y < 0.5f)
                    {
                        SwipeDirection = Swipe.Right;
                    }
                    // Swipe up left
                    else if (_currentSwipe.y > 0 && _currentSwipe.x < 0)
                    {
                        SwipeDirection = Swipe.UpLeft;
                    }
                    // Swipe up right
                    else if (_currentSwipe.y > 0 && _currentSwipe.x > 0)
                    {
                        SwipeDirection = Swipe.UpRight;
                    }
                    // Swipe down left
                    else if (_currentSwipe.y < 0 && _currentSwipe.x < 0)
                    {
                        SwipeDirection = Swipe.DownLeft;

                        // Swipe down right
                    }
                    else if (_currentSwipe.y < 0 && _currentSwipe.x > 0)
                    {
                        SwipeDirection = Swipe.DownRight;
                    }
                }
            }
            else
            {
                if (Input.GetMouseButtonDown(0))
                {
                    _firstClickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                }
                else
                {
                    SwipeDirection = Swipe.None;
                    //Debug.Log ("None");
                }
                if (Input.GetMouseButtonUp(0))
                {
                    _secondClickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                    _currentSwipe = new Vector3(_secondClickPos.x - _firstClickPos.x, _secondClickPos.y - _firstClickPos.y);

                    // Make sure it was a legit swipe, not a tap
                    if (_currentSwipe.magnitude < MinSwipeLength)
                    {
                        SwipeDirection = Swipe.None;
                        return;
                    }

                    _currentSwipe.Normalize();

                    //Swipe directional check
                    // Swipe up
                    if (_currentSwipe.y > 0 && _currentSwipe.x > -0.5f && _currentSwipe.x < 0.5f)
                    {
                        SwipeDirection = Swipe.Up;
                        Debug.Log("Up");
                    }
                    // Swipe down
                    else if (_currentSwipe.y < 0 && _currentSwipe.x > -0.5f && _currentSwipe.x < 0.5f)
                    {
                        SwipeDirection = Swipe.Down;
                        Debug.Log("Down");
                    }
                    // Swipe left
                    else if (_currentSwipe.x < 0 && _currentSwipe.y > -0.5f && _currentSwipe.y < 0.5f)
                    {
                        SwipeDirection = Swipe.Left;
                        Debug.Log("Left");
                    }
                    // Swipe right
                    else if (_currentSwipe.x > 0 && _currentSwipe.y > -0.5f && _currentSwipe.y < 0.5f)
                    {
                        SwipeDirection = Swipe.Right;
                        Debug.Log("right");
                    }     // Swipe up left
                    else if (_currentSwipe.y > 0 && _currentSwipe.x < 0)
                    {
                        SwipeDirection = Swipe.UpLeft;
                        Debug.Log("UpLeft");

                    }
                    // Swipe up right
                    else if (_currentSwipe.y > 0 && _currentSwipe.x > 0)
                    {
                        SwipeDirection = Swipe.UpRight;
                        Debug.Log("UpRight");

                    }
                    // Swipe down left
                    else if (_currentSwipe.y < 0 && _currentSwipe.x < 0)
                    {
                        SwipeDirection = Swipe.DownLeft;
                        Debug.Log("DownLeft");
                        // Swipe down right
                    }
                    else if (_currentSwipe.y < 0 && _currentSwipe.x > 0)
                    {
                        SwipeDirection = Swipe.DownRight;
                        Debug.Log("DownRight");
                    }
                }
            }
        }
 }


/* para llamarlo desde otro codigo use esta linea:         
        if(SwipeManager.SwipeDirection == Swipe.Down) // Swipe.Direccion
        {
            //Haga algo
        }
*/
