using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPoolable
{
   public void GetFromPool();
   public void ReturnToPool();
   public void Destroy();
}
