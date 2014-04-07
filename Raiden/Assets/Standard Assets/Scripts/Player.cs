using UnityEngine;
using System.Collections;

namespace Raiden
{
    public class Player : Ship
    {
        // Use this for initialization
        void Start()
        {
            base.Start();
        }

        // Update is called once per frame
        public void Update()
        {
            base.Update();

            //Player controls
            ProccessInput();


        }


        public void ProccessInput()
        {
            float hValue = Input.GetAxis("Horizontal");
            transform.Translate(new Vector3(hValue * speed, 0, 0) * Time.deltaTime);
            float vValue = Input.GetAxis("Vertical");
            transform.Translate(new Vector3(0, 0, vValue * speed) * Time.deltaTime);


            if (Input.GetButtonDown("Fire1"))
            {
                FireWeapon(0, transform.forward);
            }
            else if (Input.GetButtonDown("Fire2"))
            {
                FireWeapon(1, transform.forward);
            }
        }

        public override void LoadData(DataNode node)
        {
            base.LoadData(node);

        }
    }
}
