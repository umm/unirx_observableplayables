using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using UnityEngine.Timeline;

namespace UniRx.Triggers {

    [SuppressMessage("ReSharper", "UseNullPropagation")]
    public class ObservableTimeControlTrigger : MonoBehaviour, ITimeControl {

        private Subject<double> setTime;

        public void SetTime(double time) {
            if (this.setTime != null) {
                this.setTime.OnNext(time);
            }
        }

        public IObservable<double> SetTimeAsObservable() {
            return this.setTime ?? (this.setTime = new Subject<double>());
        }

        private Subject<Unit> onControlTimeStart;

        public void OnControlTimeStart() {
            if (this.onControlTimeStart != null) {
                this.onControlTimeStart.OnNext(Unit.Default);
            }
        }

        public IObservable<Unit> OnControlTimeStartAsObservable() {
            return this.onControlTimeStart ?? (this.onControlTimeStart = new Subject<Unit>());
        }

        private Subject<Unit> onControlTimeStop;

        public void OnControlTimeStop() {
            if (this.onControlTimeStop != null) {
                this.onControlTimeStop.OnNext(Unit.Default);
            }
        }

        public IObservable<Unit> OnControlTimeStopAsObservable() {
            return this.onControlTimeStop ?? (this.onControlTimeStop = new Subject<Unit>());
        }

    }

}