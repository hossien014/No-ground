using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISaveble
{

      public void CaptureState(out object ObjectToSave, out Tag tag);
      public void RestoreState(object SavedObject);
      public Tag GetTag();
}