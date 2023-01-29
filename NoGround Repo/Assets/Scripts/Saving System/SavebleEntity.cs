using UnityEngine;

public class SavebleEntity : MonoBehaviour
{
      public void CaptureState(out object stat, out Tag tag)
      {
            var saveble = GetComponent<ISaveble>();
            saveble.CaptureState(out stat, out tag);
      }
      public void RestoreState(object state) => GetComponent<ISaveble>().RestoreState(state);
      public Tag GetTag() => GetComponent<ISaveble>().GetTag();



}