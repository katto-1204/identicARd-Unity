using UnityEngine;

public class OpenURLButton : MonoBehaviour
{
    public string url;

    public void OpenURL()
    {
        if (!string.IsNullOrEmpty(url))
        {
            Application.OpenURL(url);
        }
    }
}