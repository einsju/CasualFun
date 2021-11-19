using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CasualFun.Games.InBetween
{
    public class Enemy_Deflect : MonoBehaviour
    {
        Vector2 direction;
        [SerializeField] float speed = 150, speedOffset = 15;
        int speedRange = 10;
        public Rigidbody rb;

        void Start()
        {
            //SetSpeedAndDirection
            speed = Random.Range(speed - speedOffset, speed + speedOffset);
            int index = Random.Range(0, 3);
            Vector2[] startDirection = new Vector2[]
                {new Vector2(1, 1), new Vector2(-1, 1), new Vector2(-1, -1), new Vector2(1, -1)};
            direction = startDirection[index];
            direction.Normalize();
            rb.velocity = direction * speed;
        }

        private void Update()
        {
            if (rb.velocity.x >= -speedRange && rb.velocity.x <= speedRange)
            {
                direction = new Vector2(-direction.x, direction.y);
                rb.velocity = direction * speed;
            }
            else if (rb.velocity.y >= -speedRange && rb.velocity.y <= speedRange)
            {
                direction = new Vector2(direction.x, -direction.y);
                rb.velocity = direction * speed;
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            Vector2 contactPoint = collision.contacts[0].normal;
            Vector2 dirRange = direction + new Vector2(Random.Range(0.05f, 0.3f), Random.Range(0.05f, 0.3f));
            direction = Vector2.Reflect(dirRange.normalized, contactPoint);
            direction.Normalize();
            rb.velocity = direction * speed;
        }
    }
}
