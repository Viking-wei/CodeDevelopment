using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Pool;

namespace ObjectPool
{
    public class ObjPoolTest : MonoBehaviour
    {
        public GameObject theObject;
        public Transform theObjParent;
        private ObjectPool<GameObject> _myPool;

        private void Start()
        {
            _myPool = new ObjectPool<GameObject>(
                () =>
                {
                    var element = Instantiate(theObject, transform);

                    element.GetComponent<Button>().onClick.AddListener(() => { Debug.Log("obj is initialized"); });

                    return element;
                },
                (go) =>
                {
                    go.transform.SetParent(transform);
                    go.transform.localPosition = UnityEngine.Random.insideUnitCircle;
                    go.SetActive(true);

                },
                (go) =>
                {
                    go.transform.SetParent(theObjParent); 
                    go.SetActive(false);
                },
                (go) => { Destroy(go); }
            );
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
                _myPool.Get();
            else if(Input.GetKeyDown(KeyCode.D))
                _myPool.Release(transform.GetChild(0).gameObject);
        }
    }
}