using UnityEngine;

public class SimpleGunGrabber : CustomGrabber {
    protected override void OnTriggerStay(Collider other) {
        base.OnTriggerStay(other);
        if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, controller) || Input.GetKeyDown(KeyCode.E)) {
            if (hand.isFull) {
                return;
            }
            var simpleGun = other.transform.root.gameObject.GetComponent<SimpleGun>();
            if (simpleGun != null) {
                if (other.transform.parent != null && other.transform.parent.name.Contains("Snap")) {
                    return;
                }
                PlaceInHand(other, simpleGun.snapOffset);
            }
        }
    }
}
