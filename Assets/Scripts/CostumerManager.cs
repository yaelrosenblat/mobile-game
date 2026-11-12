using UnityEngine;

public class CostumerManager : MonoBehaviour
{
    public GameObject customer; //the costumer
    private int speed = 100;
    int flag = 0;
    float firstX = 0;
    float firstY = 0;



    // Start is called before the first frame update
    void Start()
    {
        firstX = 371;
        firstY = -736;
    }

    // Update is called once per frame
    void Update()
    {
        if (flag == 0)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(371, 507, 0), Time.deltaTime * speed); //move gameobject to y=10
            if (this.transform.position == new Vector3(371, 507, 0)) // if gets to y=10
            {
                flag = 1;
                this.transform.rotation = Quaternion.Euler(0, 0, 0); //rotate 180 degrees
                return;
            }
        }

        if (flag == 1)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(-335, 507, 0), Time.deltaTime * speed); //move to y=-10
            if (this.transform.position == new Vector3(-335, 507, 0)) // if gets to y=-10
            {
                flag = 2;
                this.transform.rotation = Quaternion.Euler(0, 0, 90); //rotate 180 degrees
                return;
            }
        }

        if (flag == 2)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(371, 507, 0), Time.deltaTime * speed); //move to y=-10
            if (this.transform.position == new Vector3(371, 507, 0)) // if gets to y=-10
            {
                flag = 3;
                this.transform.rotation = Quaternion.Euler(0, 0, 90); //rotate 180 degrees
                return;
            }
        }

        if (flag == 3)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(firstX, firstY, 0), Time.deltaTime * speed); //move to y=-10
            if (this.transform.position == new Vector3(firstX, firstY, 0)) // if gets to y=-10
            {
                this.transform.rotation = Quaternion.Euler(0, 0, 90); //rotate 180 degrees
                return;
            }
        }

    }


}
