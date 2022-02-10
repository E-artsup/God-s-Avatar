using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GodAvatar
{
    [System.Serializable]
    public class Input
    {
        public KeyCode primary;
        public KeyCode alternate;

        public bool Pressed()
        {
            return UnityEngine.Input.GetKey(primary) || UnityEngine.Input.GetKey(alternate);
        }

        public bool PressedDown()
        {
            return UnityEngine.Input.GetKeyDown(primary) || UnityEngine.Input.GetKeyDown(alternate);
        }

        public bool PressedUp()
        {
            return UnityEngine.Input.GetKeyUp(primary) || UnityEngine.Input.GetKeyUp(alternate);
        }
    }

    public class Comp_Playerinputs : MonoBehaviour
    {
        public Input Forward;
        public Input Backward;
        public Input Right;
        public Input Left;
        public Input Attack;
        public Input Power;

        [SerializeField] private Animator _animator;

        private Quaternion _oldRotation;

        private void Update()
        {
            _oldRotation = transform.rotation;
            //Debug.Log(transform.rotation);

        }

        public int MoveAxisForwardRaw
        {
            get
            {
                if (Forward.Pressed() && Backward.Pressed())
                {
                    transform.rotation = _oldRotation;
                    _animator.SetBool("IsWalking", false);
                    return 0;
                }
                else if (Forward.Pressed())
                {
                    if (Right.Pressed())
                    {
                        transform.rotation = new Quaternion(0, 0.4f, 0, 0.9f);
                    }
                    else if (Left.Pressed())
                    {
                        transform.rotation = new Quaternion(0, 0.4f, 0, -0.9f);
                    }
                    else
                    {
                        transform.rotation = new Quaternion(0, 0, 0, 0);
                    }
                    //transform.Rotate(0, 45, 0, Space.World);
                    _animator.SetBool("IsWalking", true);

                    return 1;
                }
                else if (Backward.Pressed())
                {
                    if (Right.Pressed())
                    {
                        transform.rotation = new Quaternion(0, 0.9f, 0, 0.4f);
                    }
                    else if (Left.Pressed())
                    {
                        transform.rotation = new Quaternion(0, -0.9f, 0, 0.4f);
                    }
                    else
                    {
                        transform.rotation = new Quaternion(0, 1, 0, 0);
                    }
                    _animator.SetBool("IsWalking", true);
                    return -1;
                }
                else
                {
                    //Debug.Log("TEP");
                    return 0;
                }
            }
        }

        public int MoveAxisRightRaw
        {
            get
            {
                if(Right.Pressed() && Left.Pressed())
                {
                    transform.rotation = _oldRotation;
                    _animator.SetBool("IsWalking", false);
                    return 0;
                }
                else if (Right.Pressed())
                {
                    if (Forward.Pressed())
                    {
                        transform.rotation = new Quaternion(0, 0.4f, 0, 0.9f);
                    }
                    else if (Backward.Pressed())
                    {
                        transform.rotation = new Quaternion(0, 0.9f, 0, 0.4f);
                    }
                    else
                    {
                        transform.rotation = new Quaternion(0, 0.7f, 0, 0.7f);
                    }
                    //Debug.Log("Droite");

                    _animator.SetBool("IsWalking", true);
                    return 1;
                }
                else if (Left.Pressed())
                {
                    if (Forward.Pressed())
                    {
                        transform.rotation = new Quaternion(0, 0.4f, 0, -0.9f);
                    }
                    else if (Backward.Pressed())
                    {
                        transform.rotation = new Quaternion(0, -0.9f, 0, 0.4f);
                    }
                    else
                    {
                        transform.rotation = new Quaternion(0, 0.7f, 0, -0.7f);
                    }
                    //Debug.Log("Gauche");
                    _animator.SetBool("IsWalking", true);
                    return -1;
                }
                else
                {
                    //Debug.Log("NOPE");
                    _animator.SetBool("IsWalking", false);
                    return 0;
                }
            }
        }

        public const string MouseXString = "Mouse X";
        public const string MouseYString = "Mouse Y";
        public const string MouseScrollString = "Mouse ScrollWheel";

        public static float MouseXInput { get => UnityEngine.Input.GetAxis(MouseXString); } 
        public static float MouseYInput { get => UnityEngine.Input.GetAxis(MouseYString); } 
        public static float MouseScrollInput { get => UnityEngine.Input.GetAxis(MouseScrollString); } 


    }
}

