using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BasicEventsHandler : MonoBehaviour
{ 
    public void DisplayImage(Image image)
    {
        image.enabled = true;
    }

    public void HideImage(Image image)
    {
        image.enabled = false;
    }

    public void AssignCursor(Texture2D cursorTexture)
    {
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
    }

    public void Continue(int ID)
    {
        
    }
}
