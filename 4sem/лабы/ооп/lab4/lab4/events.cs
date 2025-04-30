using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace lab4.Events
{
    public class EventRaiser : DependencyObject //УДАлить
    {
        public UIElement RaiseTunnelingEvent
        {
            get { return (UIElement)GetValue(RaiseTunnelingEventProperty); }
            set { SetValue(RaiseTunnelingEventProperty, value); }
        }

        public static readonly DependencyProperty RaiseTunnelingEventProperty =
            DependencyProperty.Register("RaiseTunnelingEvent", typeof(UIElement),
            typeof(EventRaiser), new PropertyMetadata(null, OnRaiseTunnelingEvent));

        private static void OnRaiseTunnelingEvent(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is UIElement element)
            {
                element.RaiseEvent(new RoutedEventArgs(CustomEvents.PreviewShipTunnelingEvent, element));
            }
        }

        public UIElement RaiseDirectEvent
        {
            get { return (UIElement)GetValue(RaiseDirectEventProperty); }
            set { SetValue(RaiseDirectEventProperty, value); }
        }

        public static readonly DependencyProperty RaiseDirectEventProperty =
            DependencyProperty.Register(
                "RaiseDirectEvent",
                typeof(UIElement),
                typeof(EventRaiser),
                new PropertyMetadata(null, OnRaiseDirectEvent));

        private static void OnRaiseDirectEvent(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is UIElement element)
            {
                element.RaiseEvent(new RoutedEventArgs(CustomEvents.ShipDirectEvent, element));
            }
        }

        public UIElement RaiseBubblingEvent
        {
            get { return (UIElement)GetValue(RaiseBubblingEventProperty); }
            set { SetValue(RaiseBubblingEventProperty, value); }
        }

        public static readonly DependencyProperty RaiseBubblingEventProperty =
            DependencyProperty.Register(
                "RaiseBubblingEvent",
                typeof(UIElement),
                typeof(EventRaiser),
                new PropertyMetadata(null, OnRaiseBubblingEvent));

        private static void OnRaiseBubblingEvent(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is UIElement element)
            {
                element.RaiseEvent(new RoutedEventArgs(CustomEvents.ShipBubblingEvent, element));
            }
        }
    }
    public static class CustomEvents
    {
        public static readonly  RoutedEvent ShipBubblingEvent =
            EventManager.RegisterRoutedEvent(
                "ShipBubbling",
                RoutingStrategy.Bubble,
                typeof(RoutedEventHandler),
                typeof(CustomEvents));

        public static readonly  RoutedEvent PreviewShipTunnelingEvent =
            EventManager.RegisterRoutedEvent(
                "PreviewShipTunneling",
                RoutingStrategy.Tunnel,
                typeof(RoutedEventHandler),
                typeof(CustomEvents));

        public static readonly  RoutedEvent ShipDirectEvent =
            EventManager.RegisterRoutedEvent(
                "ShipDirect",
                RoutingStrategy.Direct,
                typeof(RoutedEventHandler),
                typeof(CustomEvents));

        public static void AddShipBubblingHandler(DependencyObject d, RoutedEventHandler handler)
        {
            if (d is UIElement element)
                element.AddHandler(ShipBubblingEvent, handler);
        }

        public static void RemoveShipBubblingHandler(DependencyObject d, RoutedEventHandler handler)
        {
            if (d is UIElement element)
                element.RemoveHandler(ShipBubblingEvent, handler);
        }

    }
}
