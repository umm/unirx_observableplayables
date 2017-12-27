using System.Diagnostics.CodeAnalysis;
using UnityEngine.Playables;

namespace UniRx.Triggers {

    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    [SuppressMessage("ReSharper", "UseNullPropagation")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class ObservablePlayableBehaviourTrigger : PlayableBehaviour {

        public class PlayableInfo {

            public PlayableBehaviour PlayableBehaviour { get; }

            public Playable Playable { get; }

            public FrameData FrameData { get; }

            public PlayableInfo(PlayableBehaviour playableBehaviour, Playable playable, FrameData frameData) {
                PlayableBehaviour = playableBehaviour;
                Playable = playable;
                FrameData = frameData;
            }

        }

        private Subject<PlayableInfo> onGraphStart;

        // Called when the owning graph starts playing
        public override void OnGraphStart(Playable playable) {
            if (this.onGraphStart != null) {
                this.onGraphStart.OnNext(new PlayableInfo(this, playable, default(FrameData)));
            }
        }

        public IObservable<PlayableInfo> OnGraphStartAsObservable() {
            return this.onGraphStart ?? (this.onGraphStart = new Subject<PlayableInfo>());
        }

        private Subject<PlayableInfo> onGraphStop;

        // Called when the owning graph stops playing
        public override void OnGraphStop(Playable playable) {
            if (this.onGraphStop != null) {
                this.onGraphStop.OnNext(new PlayableInfo(this, playable, default(FrameData)));
            }
        }

        public IObservable<PlayableInfo> OnGraphStopAsObservable() {
            return this.onGraphStop ?? (this.onGraphStop = new Subject<PlayableInfo>());
        }

        private Subject<PlayableInfo> onBehaviourPlay;

        // Called when the state of the playable is set to Play
        public override void OnBehaviourPlay(Playable playable, FrameData info) {
            if (this.onBehaviourPlay != null) {
                this.onBehaviourPlay.OnNext(new PlayableInfo(this, playable, info));
            }
        }

        public IObservable<PlayableInfo> OnBehaviourPlayAsObservable() {
            return this.onBehaviourPlay ?? (this.onBehaviourPlay = new Subject<PlayableInfo>());
        }

        private Subject<PlayableInfo> onBehaviourPause;

        // Called when the state of the playable is set to Paused
        public override void OnBehaviourPause(Playable playable, FrameData info) {
            if (this.onBehaviourPause != null) {
                this.onBehaviourPause.OnNext(new PlayableInfo(this, playable, info));
            }
        }

        public IObservable<PlayableInfo> OnBehaviourPauseAsObservable() {
            return this.onBehaviourPause ?? (this.onBehaviourPause = new Subject<PlayableInfo>());
        }

        private Subject<PlayableInfo> prepareFrame;

        // Called each frame while the state is set to Play
        public override void PrepareFrame(Playable playable, FrameData info) {
            if (this.prepareFrame != null) {
                this.prepareFrame.OnNext(new PlayableInfo(this, playable, info));
            }
        }

        public IObservable<PlayableInfo> PrepareFrameAsObservable() {
            return this.prepareFrame ?? (this.prepareFrame = new Subject<PlayableInfo>());
        }

    }

}