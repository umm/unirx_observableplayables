using System;
using UnityEngine;

namespace UniRx.Triggers {

    // ReSharper disable once PartialTypeWithSinglePart
    public static partial class TimeControlExtensions {

        public static IObservable<Unit> OnControlTimeStartAsObservable(this Component component) {
            return component.GetOrAddObservableTimeControlTrigger().OnControlTimeStartAsObservable();
        }

        public static IObservable<Unit> OnControlTimeStopAsObservable(this Component component) {
            return component.GetOrAddObservableTimeControlTrigger().OnControlTimeStopAsObservable();
        }

        public static IObservable<double> SetTimeAsObservable(this Component component) {
            return component.GetOrAddObservableTimeControlTrigger().SetTimeAsObservable();
        }

        private static ObservableTimeControlTrigger GetOrAddObservableTimeControlTrigger(this Component component) {
            if (component.gameObject.GetComponent<ObservableTimeControlTrigger>() == default(ObservableTimeControlTrigger)) {
                component.gameObject.AddComponent<ObservableTimeControlTrigger>();
            }
            return component.gameObject.GetComponent<ObservableTimeControlTrigger>();
        }

    }

}