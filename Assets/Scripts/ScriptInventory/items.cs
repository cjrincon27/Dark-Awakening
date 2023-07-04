using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class items : MonoBehaviour
{
    
    public int ID;
    public string type;
    public string descripcion;
    public Sprite icon;

    [HideInInspector]
    public bool pickedUp;

    private void OnEnable()
    {
        DataManager.Instance.OnDataLoad += DestroyItem;
    }

    public void DestroyItem(int ID)
    {
        if (this.ID == ID) Destroy(this.gameObject);
    }
    private void OnDisable()
    {
        DataManager.Instance.OnDataLoad -= DestroyItem;
    }


}
