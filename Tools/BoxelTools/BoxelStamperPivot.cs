// 2017/04/23 10:52 PM

using UnityEngine;

public class BoxelStamperPivot : MonoBehaviour
{
    public BoxelStamper stamper;

    [ContextMenu("Stamp Between Pivots")]
    public void StampBetweenPivots()
    {
        stamper.StampBetweenPivots();
    }

    [ContextMenu("Remove Between Pivots")]
    public void RemoveBetweenPivots()
    {
        stamper.RemoveBetweenPivots();
    }
}