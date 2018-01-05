using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using UnityEngine.Playables;

namespace UniRx.Triggers {

    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    [SuppressMessage("ReSharper", "UseNullPropagation")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class ObservablePlayableBehaviour : PlayableBehaviour {

        public GameObject Target { get; set; }

        // Called when the owning graph starts playing
        public override void OnGraphStart(Playable playable) {
            // ObservablePlayableBehaviourTrigger が存在していない場合、Subscribe されていないと見なして何もしない
            if (this.Target == default(GameObject) || this.Target.GetComponent<ObservablePlayableBehaviourTrigger>() == default(ObservablePlayableBehaviourTrigger)) {
                return;
            }
            this.Target.GetComponent<ObservablePlayableBehaviourTrigger>().OnGraphStart(playable);
        }

        // Called when the owning graph stops playing
        public override void OnGraphStop(Playable playable) {
            // ObservablePlayableBehaviourTrigger が存在していない場合、Subscribe されていないと見なして何もしない
            if (this.Target == default(GameObject) || this.Target.GetComponent<ObservablePlayableBehaviourTrigger>() == default(ObservablePlayableBehaviourTrigger)) {
                return;
            }
            this.Target.GetComponent<ObservablePlayableBehaviourTrigger>().OnGraphStop(playable);
        }

        // Called when the state of the playable is set to Play
        public override void OnBehaviourPlay(Playable playable, FrameData info) {
            // ObservablePlayableBehaviourTrigger が存在していない場合、Subscribe されていないと見なして何もしない
            if (this.Target == default(GameObject) || this.Target.GetComponent<ObservablePlayableBehaviourTrigger>() == default(ObservablePlayableBehaviourTrigger)) {
                return;
            }
            this.Target.GetComponent<ObservablePlayableBehaviourTrigger>().OnBehaviourPlay(playable, info);
        }

        // Called when the state of the playable is set to Paused
        public override void OnBehaviourPause(Playable playable, FrameData info) {
            // ObservablePlayableBehaviourTrigger が存在していない場合、Subscribe されていないと見なして何もしない
            if (this.Target == default(GameObject) || this.Target.GetComponent<ObservablePlayableBehaviourTrigger>() == default(ObservablePlayableBehaviourTrigger)) {
                return;
            }
            this.Target.GetComponent<ObservablePlayableBehaviourTrigger>().OnBehaviourPause(playable, info);
        }

        // Called each frame while the state is set to Play
        public override void PrepareFrame(Playable playable, FrameData info) {
            // ObservablePlayableBehaviourTrigger が存在していない場合、Subscribe されていないと見なして何もしない
            if (this.Target == default(GameObject) || this.Target.GetComponent<ObservablePlayableBehaviourTrigger>() == default(ObservablePlayableBehaviourTrigger)) {
                return;
            }
            this.Target.GetComponent<ObservablePlayableBehaviourTrigger>().PrepareFrame(playable, info);
        }

    }

}