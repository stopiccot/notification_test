using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Notifications.iOS;

public class TestScript : MonoBehaviour {

    public async void Click() {
        using (var req = new AuthorizationRequest(AuthorizationOption.AuthorizationOptionAlert | AuthorizationOption.AuthorizationOptionBadge, true)) {
            while (!req.IsFinished) {
                await System.Threading.Tasks.Task.Delay(100);
            }
        }

        var date = DateTime.Now.AddMinutes(2);
        var text = "texttexttext";
        var title = "titletitletitle";

        var timeTrigger = new iOSNotificationCalendarTrigger {
            Year = date.Year,
            Month = date.Month,
            Day = date.Day,
            Hour = date.Hour,
            Minute = date.Minute,
            Second = date.Second
        };

        var notification = new iOSNotification {
            Body = text,
            ForegroundPresentationOption = PresentationOption.NotificationPresentationOptionAlert,
            Trigger = timeTrigger
        };

        if (!String.IsNullOrEmpty(title)) {
            notification.Title = title;
        }

        iOSNotificationCenter.ScheduleNotification(notification);

    }
}
