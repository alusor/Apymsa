using UnityEngine;
using System.Collections;

public class UpdateData : MonoBehaviour {

    public string url;

    public void uploadData(string email, int score)
    {
        StartCoroutine(uploadProcess(email, score));
    }

    IEnumerator uploadProcess(string email, int score)
    {
        WWW connect = new WWW(url + "APIscores/updateData.php?email=" + email + "&score=" + score.ToString());
        yield return connect;
        print(connect.text);
        if (connect.error != null)
        {
            print("No se pudo conectar");
        }
        else if (int.Parse(connect.text) == 1)
        {
            print("Actualizacion Exitosa");

        }
        print(connect.text);

    }
}
