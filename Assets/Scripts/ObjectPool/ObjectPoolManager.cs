using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Pool;

namespace ObjectPool
{
    public class ObjectPoolManager : MonoBehaviour
    {
        public GameObject theObject;
        public Transform theObjectPool;
        private ObjectPool<GameObject> _thePool;

        private void Start()
        {
            _thePool = new ObjectPool<GameObject>(
                //创建object时所需要执行的操作
                () =>
                {
                    var element = Instantiate(theObject, transform);
                    element.GetComponent<Button>().onClick.AddListener(
                        () => { Debug.Log("obj is initialized"); });

                    return element;
                },
                //当object被拿取时所执行的操作
                (go) =>
                {
                    go.transform.SetParent(transform);
                    go.transform.localPosition = Random.insideUnitCircle;
                    go.SetActive(true);

                },
                //当object被释放时所执行的操作
                (go) =>
                {
                    go.transform.SetParent(theObjectPool);
                    go.SetActive(false);
                },
                //物体被摧毁时执行的操作
                (go) => { Destroy(go); }
            );
        }

        private void Update()
        {
            Test();
        }

        private void Test()
        {
            if (Input.GetKeyDown(KeyCode.A))
                _thePool.Get();
            else if(Input.GetKeyDown(KeyCode.D))
                _thePool.Release(transform.GetChild(0).gameObject);
        }
    }
}