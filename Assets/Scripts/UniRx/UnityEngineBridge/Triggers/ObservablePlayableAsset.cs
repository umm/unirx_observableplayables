using UnityEngine;
using UnityEngine.Playables;

namespace UniRx.Triggers {

    public class ObservablePlayableAsset : PlayableAsset {

        [SerializeField]
        private ExposedReference<GameObject> targetGameObject;

        private ExposedReference<GameObject> TargetGameObject => this.targetGameObject;

        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner) {
            return ScriptPlayable<ObservablePlayableBehaviour>.Create(
                graph,
                new ObservablePlayableBehaviour {
                    Target = this.TargetGameObject.Resolve(graph.GetResolver()) ?? owner,
                }
            );
        }

    }

}