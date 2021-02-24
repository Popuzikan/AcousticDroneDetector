using MindFusion.RealTimeCharting.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace AcusticDetector.ChartSetting
{
    static class ChartInitialize {
        public static void InitChart(RealTimeChart chartObj, ref Series seriesObj, int sampleRate)  {
            chartObj.FrameLeftThickness = 0;
            chartObj.FrameRightThickness = 1;
            chartObj.FrameTopThickness = 30;
            chartObj.FrameBottomThickness = 10;

            chartObj.TitleFontFamily = new FontFamily("Verdana");
            chartObj.XAxis.TitleFontSize = 20;
            chartObj.XAxis.Length = sampleRate / 20;
            chartObj.XAxis.Interval = (int)chartObj.XAxis.Length / 10;
            chartObj.XAxis.LabelBrush = Brushes.White;

            chartObj.XAxis.LabelFontSize = 12;
            chartObj.XAxis.LabelFormat = "0";
            chartObj.XAxis.LabelFontFamily = new FontFamily("Verdana");

            chartObj.MinorGridSizeY = 4;
            chartObj.MinorGridSizeX = 40;

            chartObj.MinorGridStroke = Brushes.White;
            chartObj.MinorGridStrokeThickness = 0.1;

            Axis yAxis = new Axis();
            yAxis.Origin = 0;
            yAxis.Length = 1;
            yAxis.Interval = 0.2;
            yAxis.Stroke = Brushes.Gray;
            yAxis.TitleBrush = Brushes.White;
            yAxis.Visibility = Visibility.Visible;
            yAxis.PinLabels = true;

            chartObj.YAxisCollection.Add(yAxis);

            seriesObj = new Series(chartObj.YAxisCollection[0])  {
                Stroke = Brushes.GreenYellow,
            };

            chartObj.SeriesCollection.Add(seriesObj);
            chartObj.TooltipAxis.Visibility = Visibility.Visible;
            chartObj.ShowFallbackTooltip = true;
        }
    }
}
