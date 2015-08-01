using UnityEngine;
using System.Collections;

public class registerData : MonoBehaviour {
    public string url;
    
    public void uploadData(string email, int  score) {
        StartCoroutine(uploadProcess(email, score));
    }

    IEnumerator uploadProcess(string email,int score) {
        WWW connect = new WWW(url + "APIscores/insertData.php?email="+email+"&score="+score.ToString());
        yield return connect;
        if (connect.error != null)
        {
            print("No se pudo conectar");
        }
        else if(connect.text=="1") {
            print("Registro con exito");

        }
        
    }
}
