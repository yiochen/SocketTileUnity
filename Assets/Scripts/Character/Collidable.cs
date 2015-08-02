using UnityEngine;
using System.Collections;

public interface Collidable {
    void OnCollide(Vector3 distance);
    void OnCanMove(Vector3 distance);
}
