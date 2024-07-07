using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class foodcreator : MonoBehaviour
{

    [SerializeField]
    private GameObject food;
    //public bool creatfood = true;

    private float xMin, xMax, yMin, yMax;

    // Start is called before the first frame update
    void Start()
    {
        Camera cam = Camera.main;
        xMin = cam.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + 1;
        xMax = cam.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - 1;
        yMin = cam.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + 1;
        yMax = cam.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - 1;

        int x = (int)Random.Range(xMin, xMax);
        int y = (int)Random.Range(yMin, yMax);
        Instantiate(food, new Vector3(x, y), Quaternion.identity);

    }

    public bool CreateFoodPosition(List<GameObject> body)
    {
        // ����������Ĵ�С����ʳ��λ�á�
        int x = (int)Random.Range(xMin, xMax);
        int y = (int)Random.Range(yMin, yMax);
        var newPos = new Vector3(x, y, 0);

        // �ж����λ���ǲ����������ĳ��λ�ã�����ǣ�����Ҫ�������ɡ�
        foreach (var node in body)
        {
            if (node.transform.position == newPos)
            {
                Debug.Log("New position is body");
                return false;
            }
        }
        Instantiate(food, new Vector3(x, y), Quaternion.identity);

        return true;
    }



  
    
}
