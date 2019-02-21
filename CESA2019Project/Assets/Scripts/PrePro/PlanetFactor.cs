using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PrePro.Planet
{
    public class PlanetFactor : MonoBehaviour
    {
        //  惑星のプレハブ
        [SerializeField] GameObject planetPrefab;

        //  左上基点座標
        [SerializeField] Vector3 cardinalPoint;

        //  縦に配置する個数
        [SerializeField, Range(1, 10)] int vNum = 3;

        //  横に配置する個数
        [SerializeField, Range(1, 10)] int hNum = 3;

        //  惑星間の縦の距離
        [SerializeField] float vDistance;

        //  惑星間の横の距離
        [SerializeField] float hDistance;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        /// <summary>
        /// 惑星生成
        /// </summary>
        private void Create(Vector3 pos,Transform parent)
        {
            GameObject obj = Instantiate(planetPrefab, pos, Quaternion.identity);
            obj.transform.parent = parent;
        }

        [ContextMenu("Create Planet")]
        private void Generation()
        {
            //  親オブジェクト生成
            GameObject pObject = new GameObject("Planets");

            for (int v = 0; v < vNum; ++v)
            {
                for (int h = 0; h < hNum; ++h)
                {
                    //  左上中心
                    Vector3 pos = cardinalPoint;

                    //  横
                    pos.x += h * hDistance;

                    //  縦
                    pos.y -= v * vDistance;

                    //  生成
                    Create(pos, pObject.transform);
                }
            }
        }
    }
}
