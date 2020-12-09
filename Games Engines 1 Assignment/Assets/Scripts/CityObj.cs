using UnityEngine;

namespace DefaultNamespace
{
    public class CityObj
    {
        public float creationTime;
        public GameObject prefab;
        public Vector3 pos;
        public Quaternion rot;

        public CityObj(float creationTime, GameObject obj,Vector3 pos,Quaternion rot)
        {
            this.creationTime = creationTime;
            this.prefab = obj;
            this.pos = pos;
            this.rot = rot;
        }
        
    }
}