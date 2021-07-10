using System;
using System.Windows;
using ToastNotifications;
using ToastNotifications.Core;
using ToastNotifications.Lifetime;
using ToastNotifications.Messages;
using ToastNotifications.Position;

namespace RegexTestForQuicker.ViewModel
{
    class ToastMessagesViewModel
    {
        private readonly Notifier _notifier;

        public ToastMessagesViewModel()
        {
            _notifier = new Notifier(cfg =>
            {
                cfg.PositionProvider = new PrimaryScreenPositionProvider(Corner.BottomCenter, 0, 10);

                cfg.LifetimeSupervisor = new TimeAndCountBasedLifetimeSupervisor(
                    notificationLifetime: TimeSpan.FromSeconds(3),
                    maximumNotificationCount: MaximumNotificationCount.FromCount(5));

                cfg.Dispatcher = Application.Current.Dispatcher;
            });
        }

        public void OnUnloaded()
        {
            _notifier.Dispose();
        }

        public void ShowInformation(string message)
        {
            _notifier.ShowInformation(message);
        }
        public void ShowInformation(string message, MessageOptions opts)
        {
            _notifier.ShowInformation(message, opts);
        }
    }
}
