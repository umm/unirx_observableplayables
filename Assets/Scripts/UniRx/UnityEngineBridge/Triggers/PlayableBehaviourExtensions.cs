using System;
using UnityEngine;

namespace UniRx.Triggers {

    public static class PlayableBehaviourExtensions {

        public static IObservable<ObservablePlayableBehaviourTrigger.Information> OnGraphStartAsObservable(this Component component) {
            return component.GetOrAddObservablePlayableBehaviourTrigger().OnGraphStartAsObservable();
        }

        public static IObservable<ObservablePlayableBehaviourTrigger.Information> OnGraphStopAsObservable(this Component component) {
            return component.GetOrAddObservablePlayableBehaviourTrigger().OnGraphStopAsObservable();
        }

        public static IObservable<ObservablePlayableBehaviourTrigger.Information> OnPlayableCreateAsObservable(this Component component) {
            return component.GetOrAddObservablePlayableBehaviourTrigger().OnPlayableCreateAsObservable();
        }

        public static IObservable<ObservablePlayableBehaviourTrigger.Information> OnPlayableDestroyAsObservable(this Component component) {
            return component.GetOrAddObservablePlayableBehaviourTrigger().OnPlayableDestroyAsObservable();
        }

        public static IObservable<ObservablePlayableBehaviourTrigger.Information> OnBehaviourPlayAsObservable(this Component component) {
            return component.GetOrAddObservablePlayableBehaviourTrigger().OnBehaviourPlayAsObservable();
        }

        public static IObservable<ObservablePlayableBehaviourTrigger.Information> OnBehaviourPauseAsObservable(this Component component) {
            return component.GetOrAddObservablePlayableBehaviourTrigger().OnBehaviourPauseAsObservable();
        }

        public static IObservable<ObservablePlayableBehaviourTrigger.Information> OnBehaviourStopAsObservable(this Component component) {
            return component.GetOrAddObservablePlayableBehaviourTrigger().OnBehaviourPlayAsObservable().SelectMany(component.GetOrAddObservablePlayableBehaviourTrigger().OnBehaviourPauseAsObservable().Take(1));
        }

        // NOTE: In some corner case, OnBehaviourPlayAsObservable is not fired. It's useful for the case.
        public static IObservable<ObservablePlayableBehaviourTrigger.Information> OnBehaviourStopByPlayableCreateAsObservable(this Component component) {
            return component.GetOrAddObservablePlayableBehaviourTrigger().OnPlayableCreateAsObservable().SelectMany(component.GetOrAddObservablePlayableBehaviourTrigger().OnBehaviourPauseAsObservable().Take(1));
        }

        public static IObservable<ObservablePlayableBehaviourTrigger.Information> PrepareFrameAsObservable(this Component component) {
            return component.GetOrAddObservablePlayableBehaviourTrigger().PrepareFrameAsObservable();
        }

        private static ObservablePlayableBehaviourTrigger GetOrAddObservablePlayableBehaviourTrigger(this Component component) {
            if (component.gameObject.GetComponent<ObservablePlayableBehaviourTrigger>() == default(ObservablePlayableBehaviourTrigger)) {
                component.gameObject.AddComponent<ObservablePlayableBehaviourTrigger>();
            }
            return component.gameObject.GetComponent<ObservablePlayableBehaviourTrigger>();
        }

    }

}
