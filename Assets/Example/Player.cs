using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace QFramework.Example {
    public class Player : QMonoBehaviour
    {
        private float speed = 10f;
        private Vector3 direction = Vector3.zero;
        private Vector3 destination;
        private float threshold = 0f;

        public override IManager Manager {
            get { return PlayerManager.Instance; }
        }

        public void OnPlayerClick(Vector3 position) {
            threshold = UnityEngine.Random.Range(0.5f, 2.0f);
            speed = UnityEngine.Random.Range(5.0f, 15.0f);
            position.z = 0f;
            destination = position;
            direction = (position - transform.position).normalized;
        }

        private void Update() {
            if((transform.position - destination).sqrMagnitude > threshold) {
                transform.position += direction * speed * Time.deltaTime;
            }
        }
    }
}
