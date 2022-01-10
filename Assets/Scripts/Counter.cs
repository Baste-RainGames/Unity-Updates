using UnityEngine;
using System.Diagnostics;
using System.Collections;

public class Counter : MonoBehaviour {
    public float StartTime = 1f;

    private Stopwatch sp;
    private long total;
    private long num;
    private long last;
    public int Counts { get ; set ; }

    private void Awake() {
        sp = new Stopwatch();
    }

    private void Start() {
        StartCoroutine(log());
    }

    private void Update () {
        if (Time.time < StartTime) return;
        sp.Start();
    }

    private void LateUpdate() {
        if (Time.time < StartTime) return;
        sp.Stop();
        num++;
        last = sp.ElapsedTicks;
        total += last;
        sp.Reset();
    }

    private IEnumerator log() {
        var delay = new WaitForSeconds(.1f);
        while (true) {
            yield return delay;
            if (num > 0) {
                var lastTime = (float) last / Stopwatch.Frequency * 1000f;
                var avgTime = (total / (float) num) / Stopwatch.Frequency * 1000f;
                UnityEngine.Debug.Log($"Last time: {lastTime:f8}ms. Average time: {avgTime:f8}ms.");

                Counts++;
            }
        }
    }
}