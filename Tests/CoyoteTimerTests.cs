using NUnit.Framework;
using UnityEngine;

using TSL.PlayerTools;

namespace TSL.PlayerTools.Tests {
    public class CoyoteTimerTests {
      
      private GameObject go;

      private CoyoteTimer timer;


      private void SetupTest(float coyoteTime) {
        go = new GameObject();
        timer = go.AddComponent<CoyoteTimer>();
        timer.CoyoteTime += () => coyoteTime;
      }

      [Test]
      public void CoyoteTimer_Can_End() {
        SetupTest(0.5f);

        for (int i=0; i < 100; i++) {
          timer.Tick();
        }
        
        Assert.False(timer.InCoyoteTime());
      }

      [Test]
      public void CoyoteTimer_Can_Reset() {
        SetupTest(0.5f);

        for (int i=0; i < 100; i++) {
          timer.Tick();
        }

        timer.StartCoyoteTime();

        Assert.True(timer.InCoyoteTime());
      }
      

      [Test]
      public void CoyoteTimer_UseCoyoteTime() {
        SetupTest(0.5f);

        timer.UseCoyoteTime();

        Assert.False(timer.InCoyoteTime());
      }

    }
}
