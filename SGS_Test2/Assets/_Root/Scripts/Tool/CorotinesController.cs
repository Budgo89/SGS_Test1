using System.Collections;
using UnityEngine;

public sealed class CorotinesController : MonoBehaviour
{
   public Coroutine StartCoroutines(IEnumerator coroutine)
   {
      return StartCoroutine(coroutine);
   }

   public void StopCoroutines(Coroutine coroutine)
   {
      StopCoroutine(coroutine);
   }
}
