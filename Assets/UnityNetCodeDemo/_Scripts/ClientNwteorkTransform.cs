using UnityEngine;
using Unity.Netcode.Components;


namespace Unity.Multiplayer.Samples.Utilities.ClientAuthority {

    [DisallowMultipleComponent]
    public class ClientNwteorkTransform : NetworkTransform {

        protected override bool OnIsServerAuthoritative() {

            return false;
        }
    }
}