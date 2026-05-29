using System.Collections;
using UnityEngine;

namespace Code.Infrastructure.Runner
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}