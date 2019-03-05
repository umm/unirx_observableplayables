using System;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using UnityEngine.Playables;

namespace UniRx.Triggers {

    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    [SuppressMessage("ReSharper", "UseNullPropagation")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class ObservablePlayableBehaviourTrigger : MonoBehaviour {

        public struct Information {

            public Playable Playable;

            public FrameData FrameData;

            public Information(Playable playable, FrameData frameData) {
                this.Playable = playable;
                this.FrameData = frameData;
            }

        }

        private Subject<Information> onGraphStart;

        // Called when the owning graph starts playing
        internal void OnGraphStart(Playable playable) {
            if (this.onGraphStart != null) {
                this.onGraphStart.OnNext(new Information(playable, default(FrameData)));
            }
        }

        public IObservable<Information> OnGraphStartAsObservable() {
            return this.onGraphStart ?? (this.onGraphStart = new Subject<Information>());
        }

        private Subject<Information> onGraphStop;

        // Called when the owning graph stops playing
        internal void OnGraphStop(Playable playable) {
            if (this.onGraphStop != null) {
                this.onGraphStop.OnNext(new Information(playable, default(FrameData)));
            }
        }

        public IObservable<Information> OnGraphStopAsObservable() {
            return this.onGraphStop ?? (this.onGraphStop = new Subject<Information>());
        }

        private Subject<Information> onPlayableCreate;

        // Called when the playable is created
        internal void OnPlayableCreate(Playable playable) {
            if (this.onPlayableCreate != null) {
                this.onPlayableCreate.OnNext(new Information(playable, default(FrameData)));
            }
        }

        public IObservable<Information> OnPlayableCreateAsObservable() {
            return this.onPlayableCreate ?? (this.onPlayableCreate = new Subject<Information>());
        }

        private Subject<Information> onPlayableDestroy;

        // Called when the playable is destroyed
        internal void OnPlayableDestroy(Playable playable) {
            if (this.onPlayableDestroy != null) {
                this.onPlayableDestroy.OnNext(new Information(playable, default(FrameData)));
            }
        }

        public IObservable<Information> OnPlayableDestroyAsObservable() {
            return this.onPlayableDestroy ?? (this.onPlayableDestroy = new Subject<Information>());
        }

        private Subject<Information> onBehaviourPlay;

        // Called when the state of the playable is set to Play
        internal void OnBehaviourPlay(Playable playable, FrameData info) {
            if (this.onBehaviourPlay != null) {
                this.onBehaviourPlay.OnNext(new Information(playable, info));
            }
        }

        public IObservable<Information> OnBehaviourPlayAsObservable() {
            return this.onBehaviourPlay ?? (this.onBehaviourPlay = new Subject<Information>());
        }

        private Subject<Information> onBehaviourPause;

        // Called when the state of the playable is set to Paused
        internal void OnBehaviourPause(Playable playable, FrameData info) {
            if (this.onBehaviourPause != null) {
                this.onBehaviourPause.OnNext(new Information(playable, info));
            }
        }

        public IObservable<Information> OnBehaviourPauseAsObservable() {
            return this.onBehaviourPause ?? (this.onBehaviourPause = new Subject<Information>());
        }

        private Subject<Information> prepareFrame;

        // Called each frame while the state is set to Play
        internal void PrepareFrame(Playable playable, FrameData info) {
            if (this.prepareFrame != null) {
                this.prepareFrame.OnNext(new Information(playable, info));
            }
        }

        public IObservable<Information> PrepareFrameAsObservable() {
            return this.prepareFrame ?? (this.prepareFrame = new Subject<Information>());
        }

    }

}