using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PlatformShoot
{
    public class CameraControl : MonoBehaviour
    {
        private Transform PlayerT;
        private void Start()
        {
            PlayerT = GameObject.FindGameObjectWithTag("Player").transform;
        }
        private void LateUpdate()
        {
            transform.localPosition = new Vector3(PlayerT.position.x, PlayerT.position.y, transform.position.z);
        }
    }
}

