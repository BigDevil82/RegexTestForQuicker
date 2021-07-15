using ICSharpCode.AvalonEdit.Rendering;
using ICSharpCode.AvalonEdit.Search;
using RegexTestForQuicker.Models;
using RegexTestForQuicker.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace RegexTestForQuicker
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        private readonly ToastMessagesViewModel _tmvm; //Toast Message Model
        //private readonly SearchReplaceResultBackgroundRenderer _render; //TextEditor BackgroundRender
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
            (DataContext as MainWindowViewModel).PropertyChanged += HighlightMatches;

            _tmvm = new ToastMessagesViewModel();
            Unloaded += OnUnloaded;

            //_render = new SearchReplaceResultBackgroundRenderer();
            //this.input.TextArea.TextView.BackgroundRenderers.Add(_render);

        }

        private void OnUnloaded(object sender, RoutedEventArgs e)
        {
            _tmvm.OnUnloaded();
        }


        // Highltight all matches string in texteditor when results changed
        public void HighlightMatches(Object sender, PropertyChangedEventArgs e)
        {
            //只监测结果的变化
            if (e.PropertyName != "ResultList") return;

            this.input.TextArea.TextView.BackgroundRenderers.Clear();
            var _render = new SearchReplaceResultBackgroundRenderer();
            this.input.TextArea.TextView.BackgroundRenderers.Add(_render);

            //_render.CurrentResults?.Clear();
            try
            {
                var results = Regex.Matches(this.input.Text, pattern.Text,
                (sender as MainWindowViewModel).SelectedRegexOptions).OfType<Match>().Select(m => new Results(m));
                foreach (var r in results)
                {
                    _render.CurrentResults.Add(r);
                }
            }
            catch { }

        }

        //avalonedit hightlight render
        class SearchReplaceResultBackgroundRenderer : IBackgroundRenderer
        {
            private Brush _markerBrush;
            private Pen _markerPen;
            private Brush _markerBrush2;
            private Pen _markerPen2;
            public List<ISearchResult> CurrentResults { get; } = new List<ISearchResult>();

            public KnownLayer Layer => KnownLayer.Selection;

            public SearchReplaceResultBackgroundRenderer()
            {
                _markerBrush = Brushes.LightGreen;
                _markerPen = new Pen(_markerBrush, 1);
                _markerBrush2 = Brushes.LightSkyBlue;
                _markerPen2 = new Pen(_markerBrush2, 1);
            }

            public Brush MarkerBrush
            {
                get => _markerBrush;
                set
                {
                    _markerBrush = value;
                    _markerPen = new Pen(_markerBrush, 1);
                }
            }

            public void Draw(TextView textView, DrawingContext drawingContext)
            {
                if (textView == null)
                    throw new ArgumentNullException("textView");
                if (drawingContext == null)
                    throw new ArgumentNullException("drawingContext");

                if (CurrentResults == null || !textView.VisualLinesValid)
                    return;

                var visualLines = textView.VisualLines;
                if (visualLines.Count == 0)
                    return;

                var viewStart = visualLines.First().FirstDocumentLine.Offset;
                var viewEnd = visualLines.Last().LastDocumentLine.EndOffset;

               
                int currentBrush = 1;  //1 for lightGreen and 2 for blue
                List<ISearchResult> ResultsInView = CurrentResults.Where(r => viewStart <= r.Offset 
                && r.Offset <= viewEnd || viewStart <= r.EndOffset && r.EndOffset <= viewEnd).ToList();
                
                for (int i = 0; i < ResultsInView.Count(); i++)
                {
                    var result = ResultsInView[i];
                    var geoBuilder = new BackgroundGeometryBuilder
                    {
                        //BorderThickness = markerPen != null ? markerPen.Thickness : 0,
                        AlignToWholePixels = true,
                        CornerRadius = 3
                    };
                    geoBuilder.AddSegment(textView, result);
                    var geometry = geoBuilder.CreateGeometry();

                    if (geometry != null)
                    {
                        //if the adjcent match result stay together,using different color to mark
                        if (i > 0 && result.Offset == ResultsInView[i - 1].EndOffset)
                        {
                            switch (currentBrush)
                            {
                                case 1:
                                    drawingContext.DrawGeometry(_markerBrush2, _markerPen2, geometry);
                                    currentBrush = 2;
                                    break;

                                case 2:
                                    drawingContext.DrawGeometry(_markerBrush, _markerPen, geometry);
                                    currentBrush = 1;
                                    break;

                                default:
                                    break;
                            }
                        }
                        else
                        {
                            drawingContext.DrawGeometry(_markerBrush, _markerPen, geometry);
                            currentBrush = 1;
                        }
                        
                    }
                    
                }
            }
        }


        //copy match value when right click on some item
        private void CopyResult(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Clipboard.SetText((sender as TextBlock).Text);
            _tmvm.ShowInformation("结果已复制",new ToastNotifications.Core.MessageOptions
                {
                    FontSize = new double?(15.0),
                    UnfreezeOnMouseLeave = true
                });
        }

    }
}

