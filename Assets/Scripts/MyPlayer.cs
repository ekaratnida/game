using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class MyPlayer : MonoBehaviourPun
{
    public float Movespeed = 5f;
    public float Turnspeed = 180f;
    public TextMesh Caption = null;

    private void Start()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            if (this.transform.GetChild(i).name == "Caption")
            {
                print(this.transform.GetChild(i).name);
                Caption = this.transform.GetChild(i).gameObject.GetComponent<TextMesh>();
                Caption.text = string.Format("Ekarat {0}", photonView.ViewID);
            }
        }
    }

    private void Update()
    {
        if (photonView.IsMine == true)
        {
            Controls();
        }         
    }
    private void Controls()
    {
        float vert = Input.GetAxis("Vertical");
        float horz = Input.GetAxis("Horizontal");
        this.transform.Translate(Vector3.forward * vert * Movespeed * Time.deltaTime);
        this.transform.localRotation *= Quaternion.AngleAxis(horz * Turnspeed * Time.deltaTime, Vector3.up);
    }


    void OnCollisionEnter(Collision collision)
    {
        //Output the Collider's GameObject's name
        //Debug.Log(collision.collider.name);

        if(collision.collider.name == "coin(Clone)"){
            //Destroy(collision.gameObject);
            collision.gameObject.transform.SetParent(this.transform);
            collision.gameObject.transform.position = new Vector3(0,5,0);
        }
    }
}
