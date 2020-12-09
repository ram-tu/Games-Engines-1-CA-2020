using UnityEngine;

namespace DefaultNamespace
{
    public class CityObj
    {
        public float creationTime;
        public GameObject prefab;

        public CityObj(float creationTime, GameObject obj)
        {
            this.creationTime = creationTime;
            this.prefab = obj;
        }
        
    }
}