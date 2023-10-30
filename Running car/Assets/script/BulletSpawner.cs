/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject prefab;
    public float rateMin = 0.5f;
    public float rateMax = 3f;

    Transform target;
    float rate;
    float timeAfterSpawn;

    // Start is called before the first frame update
    void Start()
    {
        timeAfterSpawn = 0f;
        rate = Random.Range(rateMin, rateMax);
        target = FindObjectOfType<PlayerController>().transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;
        rate = Random.Range(rateMin, rateMax);

        if (timeAfterSpawn > rate)
        {
            timeAfterSpawn = 0;
            GameObject obj = Instantiate(prefab, transform.position, transform.rotation);
            obj.transform.LookAt(target);
        }
    }
}
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject prefab;
    public float rateMin = 0.5f;
    public float rateMax = 3f;

    Transform target;
    float rate;
    float timeAfterSpawn;

    // Start is called before the first frame update
    void Start()
    {
        timeAfterSpawn = 0f;
        target = FindObjectOfType<PlayerController>().transform; // null�� ��츦 ó���ϱ� ���� null ���Ǻ� �����ڸ� ����մϴ�.
        if (target == null)
        {
            Debug.LogError("PlayerController not found!");
        }

        // ���� ���� �ֱ⸦ Start �޼��忡�� �� ���� �����մϴ�.
        rate = Random.Range(rateMin, rateMax);
    }

    // Update is called once per frame
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;

        if (timeAfterSpawn > rate)
        {
            timeAfterSpawn = 0;
            GameObject obj = Instantiate(prefab, transform.position, transform.rotation);
            obj.transform.LookAt(target);
        }
    }
}
