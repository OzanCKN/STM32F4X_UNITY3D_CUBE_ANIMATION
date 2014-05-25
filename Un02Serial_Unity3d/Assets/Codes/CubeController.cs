using UnityEngine;
using System.Collections;
using System.IO;

public class CubeController : MonoBehaviour
{
	//Service1Client sc = new Service1Client();
    //GameService.Service1Client sc = new GameService.Service1Client();
    // Use this for initialization
    void Start()
    {
        //sc.OpenCom();

    }
	int counter = 0 ;
    void interpreter(string[] list)
    {
        for (int i = 0; i <= list.Length - 1; i++)
        {
			// x sol / küp bana doğru aşağı eğilir
			if (list[i].ToString().IndexOf("x") > -1){
				Debug.Log("sol");
				transform.Rotate(Vector3.up * Time.deltaTime*300);
			}
			// X sağ
			if (list[i].ToString().IndexOf("X") > -1){
				Debug.Log("sag");
				transform.Rotate(Vector3.down * Time.deltaTime*300);
			}

			// y aşağı / küp sağa döner
			if (list[i].ToString().IndexOf("Y") > -1){
				Debug.Log("geri");
				transform.Rotate(Vector3.left * Time.deltaTime*300);
			}
			// Y Yukarı
			if (list[i].ToString().IndexOf("y") > -1){
				Debug.Log("ileri");
				transform.Rotate(Vector3.right * Time.deltaTime*300);
			}

        }
		FileStream fileStream = new FileStream(@"C:\GameData.txt", FileMode.Truncate); 
		fileStream.Close ();
    }

    // Update is called once per frame
    void Update()
    {
		counter++;
		//interpreter (sc.GetData ());
			interpreter (File.ReadAllLines (@"C:\GameData.txt"));
			

    }
}
