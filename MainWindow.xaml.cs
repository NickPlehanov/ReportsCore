using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using MahApps.Metro.Controls;
using System;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ReportsCore {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow {
        public MainWindow() {
            InitializeComponent();
        }

        private void mapView_Loaded(object sender,System.Windows.RoutedEventArgs e) {
            //GMaps.Instance.Mode = AccessMode.ServerAndCache;
            //gmaps.MapProvider = GMap.NET.MapProviders.YandexMapProvider.Instance;
            //gmaps.MinZoom = 10;
            //gmaps.MaxZoom = 17;
            //gmaps.Zoom = 2;
            //gmaps.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            //gmaps.CanDragMap = true;
            //gmaps.DragButton = MouseButton.Left;
            //gmaps.CenterPosition = new PointLatLng(55.159904, 61.401919);
            //gmaps.MouseRightButtonDown += new MouseButtonEventHandler(gmaps_mouseButton);

            //GMapOverlay markersOverlay = new GMapOverlay("markers");
            //GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(55.1863870,61.3350213),GMarkerGoogleType.red) {
            //    IsVisible = true
            //};
            //PointLatLng point = new PointLatLng(55.1863870,61.3350213);
            //PointLatLng point = new PointLatLng(55.186391,61.33474);
            //GMap.NET.WindowsPresentation.GMapMarker marker = new GMap.NET.WindowsPresentation.GMapMarker(point);
            //marker.Shape = new Ellipse {
            //    Width = 10,
            //    Height = 10,
            //    Stroke = Brushes.Red,
            //    StrokeThickness = 3.5
            //};
            //gmaps.Markers.Add(marker);

            //point = new PointLatLng(55.13476407, 61.4469485);
            //marker = new GMap.NET.WindowsPresentation.GMapMarker(point);
            //marker.Shape = new Ellipse {
            //    Width = 10,
            //    Height = 10,
            //    Stroke = Brushes.Red,
            //    StrokeThickness = 3.5
            //};
            //gmaps.Markers.Add(marker);


            //gmaps.
            //gmaps.Overlays.Add(markersOverlay);
            //gmaps.MapPoint = new System.Windows.Point(55.1863870,61.3350213);
            //gmaps.Position = PointLatLng.Add(new PointLatLng(55.186391,61.334740),new SizeLatLng());
        }

        //void gmaps_mouseButton(object sender, MouseButtonEventArgs e) {
        //    var t = groupid;
        //}
    }
}
