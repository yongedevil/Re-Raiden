using UnityEngine;
using System.Collections;

namespace Raiden
{
    public class Player : MonoBehaviour
    {
        float moveSpeed = 6.0f;
        public Transform Vulcans;
        public GameObject Playerbullet;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            //Player controls
            float hValue = Input.GetAxis("Horizontal");
            transform.Translate(new Vector3(hValue * moveSpeed, 0, 0) * Time.deltaTime);
            float vValue = Input.GetAxis("Vertical");
            transform.Translate(new Vector3(0, 0, vValue * moveSpeed) * Time.deltaTime);

            if (Input.GetButtonDown("Fire1"))
            {
                GameObject PlayerbulletInstance = Instantiate(Playerbullet, Vulcans.position, Vulcans.rotation) as GameObject;
                Physics.IgnoreCollision(PlayerbulletInstance.collider, collider);

                if (Input.GetButtonDown("Fire1"))
                {


                    PlayerbulletInstance.rigidbody.velocity = transform.TransformDirection(Vector3.forward * 20);
                }
            }

        }
    }
}
