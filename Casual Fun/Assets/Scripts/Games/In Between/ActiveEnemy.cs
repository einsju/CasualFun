using UnityEngine;

namespace CasualFun.Games.InBetween
{
    public class ActiveEnemy : MonoBehaviour
    {
        public float t;
        [SerializeField] SpriteRenderer obj;

        void Update()
        {
            obj.color = Color.Lerp(obj.color, Color.white, Time.deltaTime * t);
            if (obj.color.a >= 0.95f)
            {
                this.gameObject.layer = 8;
                Destroy(this);
            }
        }
    }
}
